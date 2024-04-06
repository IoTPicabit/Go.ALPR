using System;
using System.Linq;
using System.Xml.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using Microsoft.Data.SqlClient;
using System.Data;

using Microsoft.EntityFrameworkCore;
using AutoMapper;

using Go.ALPR.Sri.Common;
using Go.ALPR.Sri.SqlServer;
using Go.ALPR.Sri.SqlServer.Entities;


namespace Go.ALPR.Sri.Business
{
    public class IdentificacionAccesoService: IIdentificacionAccesoService
    {        
        private readonly IConfiguration _config;
        private readonly ILogger<IdentificacionAccesoService> _logger;
        private readonly SRIDbContext _dbContext;
        private readonly IMapper _mapper;

        private CancellationTokenSource _lecturaMatriculaToken;
        private TaskCompletionSource<EventArgs> _tcsLecturaCamarasRealizada;

        private SqlDependencyEx _listener;

        public IdentificacionAccesoService(IConfiguration configuration, ILogger<IdentificacionAccesoService> logger, IMapper mapper, SRIDbContext dbContext)
        {
            _config = configuration;
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        private async Task<EventArgs> EsperarIdentificacionCamaras(byte estado, int timeout = Timeout.Infinite)
        {  

            _lecturaMatriculaToken = new CancellationTokenSource();
            _tcsLecturaCamarasRealizada = new TaskCompletionSource<EventArgs>();


            // Establecemos el timeout
            if (timeout != Timeout.Infinite)
            {
                _lecturaMatriculaToken.CancelAfter(timeout);
            }

            try
            {
                using (_lecturaMatriculaToken.Token.Register(() => _tcsLecturaCamarasRealizada.TrySetCanceled(), useSynchronizationContext: false))
                {

                    if (estado == (byte)Enums.TipoEstado.Inicial)
                    {                        
                        _logger.LogTrace($"{this.TraceMethod(new { estado })} - ESPERANDO AL ENTERADO SISTEMA DE VISIÓN...");
                    }
                    else
                    {
                        _logger.LogTrace($"{this.TraceMethod(new { estado })} - ESPERANDO A LA LECTURA DE LA MATRÍCULA...");
                    }

                    return await _tcsLecturaCamarasRealizada.Task.ConfigureAwait(continueOnCapturedContext: false);
                }
            }               
            finally
            {
                   
            }            
        }

        private void Listener_TableChanged(object sender, SqlDependencyEx.TableChangedEventArgs e)
        {
            // e.Data contiene la información cambiada en formato XML
            //Solo tenemos en cuenta los cambios en el campo estado
            if (CheckCambioEstado(e.Data))
            { 
                _logger.LogTrace($"{this.TraceMethod(new { e.Data })} - CAMBIO EN TABLA T_Vision_acceso");
                _tcsLecturaCamarasRealizada.TrySetResult(e);
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
            _listener = new SqlDependencyEx(_dbContext.Database.GetConnectionString(), "SRI", "T_Vision_acceso", listenerType: SqlDependencyEx.NotificationTypes.Update);
            _listener.TableChanged += Listener_TableChanged;

            IdentificacionDto dto = null;
            try
            {
                //Tiempo de espera: nos viene en segundos y lo pasamos a milisegundos
                int timeOut = 1000 * Convert.ToInt32(_config.GetSection("TimeOutLecturaMatricula").Value);

                _listener.Start(); //Activamos la escucha de cambios en la tabla del sistema de visión

                progreso.Report("Solicitanto identificación al sistema de visión");
                await Task.Delay(500);

                var tipoParam = new SqlParameter("@Tipo", tipo);
                var entity = _dbContext
                                    .TVisionAccesos
                                    .FromSqlRaw("exec dbo.NuevaIdentificacionAcceso @Tipo", tipoParam).AsNoTracking().ToList().FirstOrDefault();

                if (entity != null)                    
                {   

                    try
                    {
                        //Primero: Esperamos al "enterado" por el sistema de identificación
                        progreso.Report("Esperando al sistema de visión");
                        var result = await EsperarIdentificacionCamaras(entity.Estado, timeOut);

                        //Si llega aquí, puede que se haya producido la LECTURA o solo el ENTERADO
                        entity = _dbContext.TVisionAccesos.Where(i => i.Id == entity.Id).AsNoTracking().FirstOrDefault();

                        if(entity.Estado == (byte)Enums.TipoEstado.Enterado)
                        {
                            //Ahora esperamos a la "lectura" de la matrícula                            
                            progreso.Report("Esperando al sistema de visión");                            
                            result = await EsperarIdentificacionCamaras(entity.Estado, timeOut);

                            //Si llega aquí, se ha producido la LECTURA de la matrícula, bien o mal, recuperamos el registro de nuevo
                            entity = _dbContext.TVisionAccesos.Where(i => i.Id == entity.Id).AsNoTracking().FirstOrDefault();
                        }

                        progreso.Report("Lectura matrícula realizada");
                        await Task.Delay(500);

                        _logger.LogTrace($"{this.TraceMethod(new { entity.Id, entity.Estado })} - LECTURA REALIZADA");

                    }
                    catch(TaskCanceledException)
                    {
                        //Cuando se produce algun timeout, pasa por aqui, recuperamos el registro para determinar en que momento ha expirado
                        entity = _dbContext.TVisionAccesos.Where(i => i.Id == entity.Id).AsNoTracking().FirstOrDefault();

                        _logger.LogTrace($"{this.TraceMethod(new { entity.Id, entity.Estado })} - EXPIRÓ EL TIEMPO DE ESPERA");
                        progreso.Report("Expiró el tiempo de espera");
                        await Task.Delay(500);
                    }
                    finally
                    {
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
            finally
            {
                if (_listener.Active)
                {
                    _listener.Stop();
                }
                _listener = null;
            }         

            _logger.LogTrace($"{this.TraceMethod(new { tipo })} - FIN");

            return dto;
        }

        public async Task<bool> RegistrarAcceso(string id, bool resultado)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            bool result = false;
            try
            {
                TVisionAcceso entity = _dbContext.TVisionAccesos.Where(tv => tv.Id == id).FirstOrDefault();

                if (entity != null)
                {

                    Acceso entityAcceso = new Acceso();

                    entityAcceso.Id = entity.Id;
                    entityAcceso.Tipo = entity.Tipo;
                    entityAcceso.Fecha = entity.Fecha;
                    entityAcceso.Estado = entity.Estado;
                    entityAcceso.Matricula = entity.MatriculaC;
                    entityAcceso.Resultado = resultado;

                    _dbContext.Accesos.Add(entityAcceso);

                    _dbContext.TVisionAccesos.Remove(entity);

                    int num = await _dbContext.SaveChangesAsync(true);

                    result = (num == 2);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }
    
    }
}
