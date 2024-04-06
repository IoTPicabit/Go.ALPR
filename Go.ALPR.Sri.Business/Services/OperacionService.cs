using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using Microsoft.EntityFrameworkCore;
using AutoMapper;

using Go.ALPR.Sri.Common;
using Go.ALPR.Sri.SqlServer;
using Go.ALPR.Sri.SqlServer.Entities;
using X.PagedList;

using Microsoft.Reporting.WinForms;

using System.IO;
using System.Data.SqlClient;

namespace Go.ALPR.Sri.Business
{
    public class OperacionService : IOperacionService
    {

        private readonly ILogger<OperacionService> _logger;
        private readonly SRIDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        private InstalacionDatos _datosInstalacion;

        public OperacionService(ILogger<OperacionService> logger, SRIDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
            _config = configuration;
        }

        public async Task<IPagedList<OperacionDto>> ObtenerListaPaginada(
                                                        int Numero,
                                                        string Matricula,
                                                        string Remolque,
                                                        string Conductor,
                                                        string Empresa,
                                                        byte Tipo,
                                                        DateTime FechaInicio,
                                                        DateTime FechaFin,
                                                        string TipoCarga,
                                                        int pageNumber,
                                                        int pageSize )
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            StaticPagedList<OperacionDto> result = null;            

            try
            {                
                result = await Task.Factory.StartNew(() =>                
                            {
                                var operaciones = from o in _dbContext.Operacions select o;

                                if(Numero != 0)
                                {
                                    operaciones = operaciones.Where(o => o.IdOperacion == Numero);
                                }
                                else
                                {
                                    if (!String.IsNullOrEmpty(Matricula))
                                    {
                                        operaciones = operaciones.Where(o => o.Matricula.Equals(Matricula) || o.Matricula.Contains(Matricula));
                                    }
                                    if (!String.IsNullOrEmpty(Remolque))
                                    {
                                        operaciones = operaciones.Where(o => o.Remolque.Equals(Remolque) || o.Remolque.Contains(Remolque));
                                    }
                                    if (!String.IsNullOrEmpty(Conductor))
                                    {
                                        operaciones = operaciones.Where(o => o.Conductor.Contains(Remolque));
                                    }
                                    if (!String.IsNullOrEmpty(Empresa))
                                    {
                                        operaciones = operaciones.Where(o => o.Empresa.Contains(Empresa));
                                    }
                                    if(Tipo != 0)
                                    {
                                        operaciones = operaciones.Where(o => o.IdTipoOperacion == Tipo);
                                    }
                                    if(FechaInicio != DateTime.MinValue)
                                    {
                                        operaciones = operaciones.Where(o => o.FechaHoraEntrada >= FechaInicio.Date);
                                    }
                                    if (FechaFin != DateTime.MinValue)
                                    {
                                        operaciones = operaciones.Where(o => o.FechaHoraEntrada <= FechaFin.Date.AddHours(23).AddMinutes(59).AddSeconds(59));
                                    }
                                    if (!String.IsNullOrEmpty(TipoCarga))
                                    {
                                        operaciones = operaciones.Where(o => o.TipoCarga.Contains(TipoCarga));
                                    }
                                }

                                operaciones = operaciones.Include(t => t.IdTipoOperacionNavigation);

                                operaciones = operaciones.OrderByDescending(o => o.FechaHoraEntrada).AsNoTracking();

                                var pagedOperaciones = operaciones.ToPagedList(pageNumber, pageSize);

                                var operacionesDto = _mapper.Map<IEnumerable<Operacion>, IEnumerable<OperacionDto>>(pagedOperaciones.ToArray());

                                return new StaticPagedList<OperacionDto>(operacionesDto, pagedOperaciones.GetMetaData());                                
                            });                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }


        public OperacionDto ObtenerEntradaPrevia(string matricula)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            OperacionDto result = null;
            try
            {
                result = _mapper.Map<OperacionDto>(_dbContext.Operacions.AsNoTracking().Where(o => o.Matricula == matricula && o.FechaHoraSalida == null).OrderByDescending(o => o.IdOperacion).FirstOrDefault());
                if(result == null)
                {
                    _logger.LogWarning($"{this.TraceMethod(new { matricula })} - ENTRADA NO ENCONTRADA");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }

        public int GuardarEntrada(OperacionDto operacion, FotoDto fotos)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            int result = 0;
            try
            {                               

                Operacion entity = _mapper.Map<OperacionDto, Operacion>(operacion);
              
                entity.FechaHoraEntrada = DateTime.Now;
                entity.FechaHoraSalida = null;                

                entity.FirmaConductorImagen = null;
                entity.FirmaProductorImagen = null;

                Foto fotoEntity = new Foto();
                fotoEntity.Tipo = fotos.Tipo;
                fotoEntity.Camara1 = fotos.Camara1;
                fotoEntity.Camara2 = fotos.Camara2;
                fotoEntity.Camara3 = fotos.Camara3;

                entity.Fotos.Add(fotoEntity);

                _dbContext.Operacions.Add(entity);

                int num = _dbContext.SaveChanges(true);

                if (num > 0)
                {
                    result = entity.IdOperacion;
                }                    

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }

        public int GuardarSalida(OperacionDto operacion, FotoDto fotos)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            int result = 0;
            try
            {
                Operacion entity = _dbContext.Operacions.Where(o => o.IdOperacion == operacion.IdOperacion).FirstOrDefault();

                if (entity == null)
                {
                    throw new Exception("No se encuentra la operación " + operacion.IdOperacion.ToString());
                }

                entity.Remolque = operacion.Remolque;

                entity.Conductor = operacion.Conductor;
                entity.IdTipoCarga = operacion.IdTipoCarga;
                entity.TipoCarga = operacion.TipoCarga;
                entity.CodigoLer = operacion.CodigoLer;
                entity.DenominacionAdr = operacion.DenominacionAdr;

                entity.MatriculaSalidaManual = operacion.MatriculaSalidaManual;
                entity.MotivoMatriculaSalidaManual = operacion.MotivoMatriculaSalidaManual;
                entity.FechaHoraSalida = DateTime.Now;
                entity.PesoSalida = operacion.PesoSalida;
                entity.PesoSalidaManual = operacion.PesoSalidaManual;
                entity.MotivoPesoSalidaManual = operacion.MotivoPesoSalidaManual;
                entity.UsuarioSalida = operacion.UsuarioSalida;

                entity.Origen = operacion.Origen;
                entity.OrigenDireccion = operacion.OrigenDireccion;
                entity.OrigenCif = operacion.OrigenCif;
                entity.OrigenNima = operacion.OrigenNima;

                entity.Destino = operacion.Destino;
                entity.DestinoDireccion = operacion.DestinoDireccion;
                entity.DestinoCif = operacion.DestinoCif;
                entity.DestinoNima = operacion.DestinoNima;

                entity.FirmaProductor = operacion.UsuarioSalida;
                entity.FirmaProductorImagen = operacion.FirmaProductorImagen;
                entity.FirmaConductor = operacion.Conductor;
                entity.FirmaConductorImagen = operacion.FirmaConductorImagen;

                if(operacion.Expedidor != null)
                {
                    entity.Expedidor = operacion.Expedidor;
                    entity.ExpedidorDireccion = operacion.ExpedidorDireccion;
                    entity.ExpedidorCif = operacion.ExpedidorCif;
                }                

                Foto fotoEntity = new Foto();
                fotoEntity.Tipo = fotos.Tipo;
                fotoEntity.Camara1 = fotos.Camara1;
                fotoEntity.Camara2 = fotos.Camara2;
                fotoEntity.Camara3 = fotos.Camara3;
                entity.Fotos.Add(fotoEntity);

                _dbContext.Entry(entity).State = EntityState.Modified;                              

                int num = _dbContext.SaveChanges(true);                

                if (num > 0)
                {                    
                    result = operacion.IdOperacion;
                }
                    
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }


        public async Task<byte[]> ObtenerAlbaran(int id)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");
            
            byte[] result = null;
            try
            {

                var entity = await _dbContext.Operacions.AsNoTracking().Where(o => o.IdOperacion == id).FirstOrDefaultAsync();
                if (entity != null)
                {
                    var albaranData = _mapper.Map<Operacion, AlbaranDto>(entity);

                    _datosInstalacion = _config.GetSection("Instalacion").Get<InstalacionDatos>();

                    albaranData.NombreInstalacion = _datosInstalacion.Nombre;

                    var fotosEntrada = await _dbContext.Fotos.AsNoTracking().Where(f => f.IdOperacion == id && f.Tipo == 1).FirstOrDefaultAsync();
                    if(fotosEntrada != null)
                    {
                        if(fotosEntrada.Camara1 != null)
                        {
                            albaranData.Camara1Entrada = @"file:///" + new Uri(fotosEntrada.Camara1).AbsolutePath;
                        }
                        if (fotosEntrada.Camara2 != null)
                        {
                            albaranData.Camara2Entrada = @"file:///" + new Uri(fotosEntrada.Camara2).AbsolutePath;
                        }
                        if (fotosEntrada.Camara3 != null)
                        {
                            albaranData.Camara3Entrada = @"file:///" + new Uri(fotosEntrada.Camara3).AbsolutePath;
                        }                            
                    }

                    var fotosSalida = await _dbContext.Fotos.AsNoTracking().Where(f => f.IdOperacion == id && f.Tipo == 2).FirstOrDefaultAsync();
                    if (fotosSalida != null)
                    {
                        if(fotosSalida.Camara1 != null)
                        {
                            albaranData.Camara1Salida = @"file:///" + new Uri(fotosSalida.Camara1).AbsolutePath;
                        }
                        if (fotosSalida.Camara2 != null)
                        {
                            albaranData.Camara2Salida = @"file:///" + new Uri(fotosSalida.Camara2).AbsolutePath;
                        }
                        if (fotosSalida.Camara3 != null)
                        {
                            albaranData.Camara3Salida = @"file:///" + new Uri(fotosSalida.Camara3).AbsolutePath;
                        }                        
                    }                                                      

                    var report = new LocalReport();
                    report.EnableExternalImages = true;
                    using var fs = new FileStream("Albaran.rdlc", FileMode.Open);
                    var albaranes = new[] { albaranData };
                    report.LoadReportDefinition(fs);
                    report.DataSources.Add(new ReportDataSource("Albaran", albaranes));
                    result = report.Render("PDF");                   
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }

        public async Task<byte[]> ObtenerCartaPorte(int id)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            byte[] result = null;
            try
            {

                var entity = await _dbContext.Operacions.AsNoTracking().Where(o => o.IdOperacion == id).FirstOrDefaultAsync();
                if (entity != null)
                {
                    if(entity.DenominacionAdr == null || entity.DenominacionAdr == "") {
                        result = new byte[0];
                    }
                    else
                    {
                        var cartaData = _mapper.Map<Operacion, CartaDto>(entity);                                     

                        var report = new LocalReport();
                        report.EnableExternalImages = true;
                        using var fs = new FileStream("Carta.rdlc", FileMode.Open);
                        var cartas = new[] { cartaData };
                        report.LoadReportDefinition(fs);
                        report.DataSources.Add(new ReportDataSource("Carta", cartas));
                        result = report.Render("PDF");
                    }                   
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }

        public FotosOperacionDto ObtenerFotosOperacion(int id)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            FotosOperacionDto result = new FotosOperacionDto();

            result.IdOperacion = id;

            try
            {
                
                var fotosEntrada = _dbContext.Fotos.AsNoTracking().Where(f => f.IdOperacion == id && f.Tipo == 1).FirstOrDefault();
                if (fotosEntrada != null)
                {                    
                    result.Camara1Entrada = fotosEntrada.Camara1;                   
                    result.Camara2Entrada = fotosEntrada.Camara2;                    
                    result.Camara3Entrada = fotosEntrada.Camara3;                    
                }

                var fotosSalida = _dbContext.Fotos.AsNoTracking().Where(f => f.IdOperacion == id && f.Tipo == 2).FirstOrDefault();
                if (fotosSalida != null)
                {                    
                    result.Camara1Salida = fotosSalida.Camara1;                    
                    result.Camara2Salida = fotosSalida.Camara2;                    
                    result.Camara3Salida = fotosSalida.Camara3;                    
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }
    
    
        public async Task<Dictionary<string, string>> ObtenerListaEmails(int id)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");
            
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                //Contactos asociados a la empresa de la operación
                Operacion entity = await _dbContext.Operacions.AsNoTracking().Where(o => o.IdOperacion == id).FirstOrDefaultAsync();
                if(entity != null)
                {       
                    var contactos = await _dbContext.Contactos.AsNoTracking().Where(c => c.Habilitado == true && (c.IdEmpresa == entity.IdEmpresa || c.IdTipoCarga == entity.IdTipoCarga)).ToListAsync();
                    
                    if (contactos != null)
                    {
                        foreach (Contacto contacto in contactos)
                        {
                            if (!result.ContainsKey(contacto.Email))
                            {
                                result.Add(contacto.Email, (contacto.Nombre != null ? contacto.Nombre : contacto.Email));
                            }                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }


        public async Task<DataTable> ObtenerDatosAlbaran(int id)
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(_dbContext.Database.GetConnectionString()))
            {
                // Create the command and set its properties.
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM dbo.Operacion WHERE IdOperacion = @IdOperacion";
                command.CommandType = CommandType.Text;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@IdOperacion";
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = id;

                // Add the parameter to the Parameters collection.
                command.Parameters.Add(parameter);

                // Open the connection and execute the reader.
                await connection.OpenAsync();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        table.Load(reader);
                    }                   
                    reader.Close();
                }
            } 

            return table;
        }

    }
}