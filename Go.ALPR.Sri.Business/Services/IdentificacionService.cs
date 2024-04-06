using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using Microsoft.Data.SqlClient;

using Microsoft.EntityFrameworkCore;
using AutoMapper;

using Go.ALPR.Sri.Common;
using Go.ALPR.Sri.SqlServer;
using Go.ALPR.Sri.SqlServer.Entities;

namespace Go.ALPR.Sri.Business
{
    public class IdentificacionService: IIdentificacionService
    {        
        private readonly IConfiguration _config;
        private readonly ILogger<IdentificacionService> _logger;
        private readonly SRIDbContext _dbContext;
        private readonly IMapper _mapper;

        private CancellationTokenSource _lecturaMatriculaToken;
        private TaskCompletionSource<EventArgs> _tcsLecturaCamarasRealizada;

        public IdentificacionService(IConfiguration configuration, ILogger<IdentificacionService> logger, IMapper mapper, SRIDbContext dbContext)
        {
            _config = configuration;
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        private async Task<EventArgs> EsperarIdentificacionCamaras(int timeout = Timeout.Infinite)
        {                      
            // Establecemos el timeout
            if (timeout != Timeout.Infinite)
            {
                _lecturaMatriculaToken.CancelAfter(timeout);
            }

            try
            {
                using (_lecturaMatriculaToken.Token.Register(() => _tcsLecturaCamarasRealizada.TrySetCanceled(), useSynchronizationContext: false))
                {                   
                    return await _tcsLecturaCamarasRealizada.Task.ConfigureAwait(continueOnCapturedContext: false);
                }
            }               
            finally
            {
                   
            }            
        }

        private bool CheckCambioEstado(XElement root)
        {
            //<root>
            //  <inserted>
            //    <row>
            //      <Id>20210526001</Id>
            //      <Tipo>1</Tipo>
            //      <Fecha>2021-05-26T20:26:33.343</Fecha>
            //      <Estado>0</Estado>
            //      <Path>dfgdgd</Path>
            //      <Bit_Vida>0</Bit_Vida>
            //    </row>
            //  </inserted>
            //  <deleted>
            //    <row>
            //      <Id>20210526001</Id>
            //      <Tipo>1</Tipo>
            //      <Fecha>2021-05-26T20:26:33.343</Fecha>
            //      <Estado>0</Estado>
            //      <Bit_Vida>0</Bit_Vida>
            //    </row>
            //  </deleted>
            //</root>

            bool result;

            int[] estados = (from est in root.Descendants("Estado") select (int)est).ToArray();

            result = (estados[0] != estados[1]);

            return result;
        }

        public IdentificacionDto ObtenerIdentificacionVacia(byte tipo)
        {
            IdentificacionDto dto = new IdentificacionDto();

            dto.Tipo = tipo;
            dto.Estado = (byte)Enums.TipoEstado.SistemaApagado;

            return dto;
        }

        public async Task<IdentificacionDto> ObtenerIdentificacion(byte tipo, IProgress<string> progreso)
        {
            _logger.LogTrace($"{this.TraceMethod(new { tipo })} - INICIO");            

            //Configuración del listener que comprueba cuando cambia la información de la lectura de las cámaras
            //ALTER DATABASE SRI SET ENABLE_BROKER
            //-- For SQL Express
            //ALTER AUTHORIZATION ON DATABASE::SRI TO userTest
            var listener = new SqlDependencyEx(_dbContext.Database.GetConnectionString(), "SRI", "T_Vision", listenerType: SqlDependencyEx.NotificationTypes.Update);                         
            listener.TableChanged += (o, e) =>            
            {                             
                // e.Data contiene la información cambiada en formato XML
                //Solo tenemos en cuenta los cambios en el campo estado
                if (CheckCambioEstado(e.Data))
                {
                    _logger.LogTrace($"{this.TraceMethod(new { tipo })} - CAMBIO EN TABLA T_Vision");
                    _tcsLecturaCamarasRealizada.TrySetResult(e);
                }                
            };

            IdentificacionDto dto = null;
            try
            {
                progreso.Report("Solicitanto identificación al sistema de visión");
                await Task.Delay(500);
                var tipoParam = new SqlParameter("@Tipo", tipo);
                var entities = _dbContext
                                    .TVisions
                                    .FromSqlRaw("exec dbo.NuevaIdentificacion @Tipo", tipoParam).AsNoTracking().ToList();

                if(entities.Count > 0)
                {  
                    listener.Start(); //Escuchamos si cambia el registro

                    var entity = entities[0];

                    try
                    {
                        //Tiempo de espera: nos viene en segundos y lo pasamos a milisegundos
                        int timeOut = 1000 * Convert.ToInt32(_config.GetSection("TimeOutLecturaMatricula").Value);

                        //Primero: Esperamos al "enterado" por el sistema de identificación
                        _lecturaMatriculaToken = new CancellationTokenSource();
                        _tcsLecturaCamarasRealizada = new TaskCompletionSource<EventArgs>();
                        _logger.LogTrace("ESPERANDO AL ENTERADO SISTEMA DE VISIÓN.....");
                        progreso.Report("Esperando al sistema de visión");                        
                        var result = await EsperarIdentificacionCamaras(timeOut);

                        //Si llega aquí, puede que se haya producido la lectura o solo el enterado
                        entity = _dbContext.TVisions.Where(i => i.Id == entity.Id).AsNoTracking().FirstOrDefault();

                        if(entity.Estado == (byte)Enums.TipoEstado.Enterado)
                        {
                            //Ahora esperamos a la "lectura" de la matrícula
                            _lecturaMatriculaToken = new CancellationTokenSource();
                            _tcsLecturaCamarasRealizada = new TaskCompletionSource<EventArgs>();
                            _logger.LogTrace("ESPERANDO A LA LECTURA DE LA MATRÍCULA.....");
                            progreso.Report("Esperando al sistema de visión");                            
                            result = await EsperarIdentificacionCamaras(timeOut);

                            //Si llega aquí, se ha leido la matrícula, bien o mal, recuperamos el registro de nuevo
                            entity = _dbContext.TVisions.Where(i => i.Id == entity.Id).AsNoTracking().FirstOrDefault();
                        }

                        progreso.Report("Lectura matrícula realizada");
                        await Task.Delay(500);
                        _logger.LogTrace($"{this.TraceMethod(new { entity.Id, entity.Estado })} - LECTURA REALIZADA");
                    }
                    catch(TaskCanceledException)
                    {
                        //Cuando se produce algun timeout, pasa por aqui, recuperamos el registro para determinar en que proceso ha expirado
                        entity = _dbContext.TVisions.Where(i => i.Id == entity.Id).FirstOrDefault();
                        _logger.LogTrace($"{this.TraceMethod(new { entity.Id, entity.Estado })} - EXPIRÓ EL TIEMPO DE ESPERA");
                        progreso.Report("Expiró el tiempo de espera");
                        await Task.Delay(500);
                    }
                    finally
                    {
                        if (listener.Active)
                        {
                            listener.Stop();
                        }
                        listener = null;

                        _lecturaMatriculaToken.Dispose();
                        _tcsLecturaCamarasRealizada = null;
                    }
                    
                    dto = _mapper.Map<IdentificacionDto>(entity);

                }                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { tipo }));                
            }           

            _logger.LogTrace($"{this.TraceMethod(new { tipo })} - FIN");

            return dto;
        }

        public async Task<bool> Eliminar(string id)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            bool result = false;
            try
            {
                TVision entity = _dbContext.TVisions.Where(tv => tv.Id == id).FirstOrDefault();

                if(entity != null)
                {
                    _dbContext.TVisions.Remove(entity);

                    int num = await _dbContext.SaveChangesAsync(true);

                    result = (num == 1);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }

        public Task CancelarIdentificacion()
        {
            if (_lecturaMatriculaToken != null && !_lecturaMatriculaToken.IsCancellationRequested && _lecturaMatriculaToken.Token.CanBeCanceled)
            {
                _lecturaMatriculaToken.Cancel();
                _lecturaMatriculaToken.Dispose();
            }

            _logger.LogTrace($"{this.TraceMethod()} - LECTURA CANCELADA");

            return Task.CompletedTask;
        }
    
    }
}
