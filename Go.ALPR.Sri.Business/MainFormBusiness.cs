using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using Go.ALPR.Sri.Common;

namespace Go.ALPR.Sri.Business
{
    public partial class MainFormBusiness : IMainFormBusiness
    {
        private readonly ILogger<MainFormBusiness> _logger;
        private readonly IConfiguration _config;
        private readonly IIdentificacionService _identificacion;
        private readonly IBasculaService _bascula;        
        private readonly ILocalizacionService _localizacionService;
        private readonly ITransporteService _transporteService;
        private readonly IOperacionService _operacionService;
        private readonly IEmpresaService _empresaService;

        private InstalacionDatos _datosInstalacion;
        private readonly UsuarioSesionDto _usuarioSesion;
        private bool _sistemaVisionActivado = false;
        private int _numeroReintentosFallido = 0;

        private const string Camara1NombreParcial = "_C1_";
        private const string Camara2NombreParcial = "_C2_";
        private const string Camara3NombreParcial = "_C3_";

        
        #region "Constructor"
        public MainFormBusiness(ILogger<MainFormBusiness> logger,
                                IConfiguration configuration,
                                IIdentificacionService identificacion, 
                                IBasculaService bascula,
                                IEmpresaService empresaService,                                
                                ILocalizacionService localizacionService,
                                ITransporteService transporteService,
                                IOperacionService operacionService,
                                UsuarioSesionDto usuarioSesion) {

            _logger = logger;
            _config = configuration;
            _identificacion = identificacion;
            _bascula = bascula;            
            _localizacionService = localizacionService;            
            _transporteService = transporteService;
            _operacionService = operacionService;
            _empresaService = empresaService;
            _usuarioSesion = usuarioSesion;
        }
        

        public void Inicializar()
        {
            _sistemaVisionActivado = bool.Parse(_config.GetSection("SistemaVisionActivado").Value);
            _numeroReintentosFallido = int.Parse(_config.GetSection("NumeroReintentosFallido").Value);

            _datosInstalacion = _config.GetSection("Instalacion").Get<InstalacionDatos>();
        }

        #endregion


        #region "Carga maestros"            

        public List<LocalizacionDto> ObtenerListaLocalizaciones()
        {
            return _localizacionService.ObtenerLista(true);
        }

        public List<EmpresaDto> ObtenerListaExpedidores()
        {
            return _empresaService.ObtenerExpedidores();
        }

        #endregion

        #region "IDENTIFICACIÓN VEHÍCULO"
        public async Task<MainFormDto> NuevaEntrada(IProgress<string> progreso)
        {
            MainFormDto mainData = new MainFormDto();            

            IdentificacionDto identificacion = null;
            if (_sistemaVisionActivado)
            {
                identificacion = await _identificacion.ObtenerIdentificacion((byte)Enums.TipoIdentificacion.Entrada, progreso);

                //Reintentamos la indentificación mientras sea fallida
                int numeroReintento = _numeroReintentosFallido;
                while (identificacion.Estado == (byte)Enums.TipoEstado.Fallo && numeroReintento > 0)
                {
                    progreso.Report("Identificación fallida. Reintentando...");
                    await Task.Delay(1000);
                    identificacion = await _identificacion.ObtenerIdentificacion((byte)Enums.TipoIdentificacion.Entrada, progreso);
                    numeroReintento--;
                }
            }
            else
            {
                identificacion = _identificacion.ObtenerIdentificacionVacia((byte)Enums.TipoIdentificacion.Entrada);
            }

            ProcesarIdentificacion(ref mainData, identificacion);

            if (identificacion.Estado == (byte)Enums.TipoEstado.Inicial || identificacion.Estado == (byte)Enums.TipoEstado.Enterado)
            {
                //Lanzamos el borrado del registro
                await _identificacion.Eliminar(identificacion.Id);
            }
            else
            {

                if (mainData.Estado >= (byte)Enums.TipoEstado.Correcto && mainData.Estado < (byte)Enums.TipoEstado.Fallo)
                {
                    progreso.Report("Identificando transporte...");
                    await Task.Delay(500);
                    var transporte = _transporteService.ObtenerTransporte(mainData.Transporte.Matricula);

                    if (transporte != null)
                    {
                        mainData.TransporteReconocido = true;

                        //Sobreescribimos el remolque con lo devuelto por el sistema de visión
                        transporte.Remolque = mainData.Transporte.Remolque;                                               

                        mainData.Transporte = transporte;

                        if (mainData.Transporte.TipoOperacion.IdTipoOperacion == (byte)Enums.TipoOperacion.Carga)
                        {
                            mainData.Origen.Nombre = _datosInstalacion.Nombre;
                            mainData.Origen.Direccion = _datosInstalacion.Direccion;
                            mainData.Origen.Cif = _datosInstalacion.Cif;
                            mainData.Origen.Nima = _datosInstalacion.Nima;
                        }
                        else
                        {
                            mainData.Destino.Nombre = _datosInstalacion.Nombre;
                            mainData.Destino.Direccion = _datosInstalacion.Direccion;
                            mainData.Destino.Cif = _datosInstalacion.Cif;
                            mainData.Destino.Nima = _datosInstalacion.Nima;
                        }                        

                    }
                }

                var pesada = _bascula.ObtenerPeso();
                mainData.PesoCorrecto = pesada.PesoCorrecto;
                if (pesada.PesoCorrecto)
                {
                    mainData.Peso = pesada.Peso;
                    mainData.PesoLeido = pesada.Peso;
                }
            }

            return mainData;
        }

        public async Task<MainFormDto> NuevaSalida(IProgress<string> progreso)
        {
            MainFormDto mainData = new MainFormDto();
            
            IdentificacionDto identificacion = null;
            if (_sistemaVisionActivado)
            {
                identificacion = await _identificacion.ObtenerIdentificacion((byte)Enums.TipoIdentificacion.Salida, progreso);

                //Reintentamos la indentificación mientras sea fallida
                int numeroReintento = _numeroReintentosFallido;
                while (identificacion.Estado == (byte)Enums.TipoEstado.Fallo && numeroReintento > 0)
                {
                    progreso.Report("Identificación fallida. Reintentando...");
                    await Task.Delay(1000);
                    identificacion = await _identificacion.ObtenerIdentificacion((byte)Enums.TipoIdentificacion.Salida, progreso);
                    numeroReintento--;
                }
            }
            else
            {
                identificacion = _identificacion.ObtenerIdentificacionVacia((byte)Enums.TipoIdentificacion.Salida);
            }

            ProcesarIdentificacion(ref mainData, identificacion);

            if (identificacion.Estado == (byte)Enums.TipoEstado.Inicial || identificacion.Estado == (byte)Enums.TipoEstado.Enterado)
            {
                //Lanzamos el borrado del registro
                await _identificacion.Eliminar(identificacion.Id);
            }
            else
            {
                if (mainData.Estado >= (byte)Enums.TipoEstado.Correcto && mainData.Estado < (byte)Enums.TipoEstado.Fallo)
                {
                    progreso.Report("Identificando entrada previa...");
                    await Task.Delay(500);
                    var entradaPrevia = _operacionService.ObtenerEntradaPrevia(mainData.Transporte.Matricula);

                    if (entradaPrevia != null)
                    {
                        mainData.EntradaPrevia = entradaPrevia;

                        //Reservamos el remolque leido
                        mainData.EntradaPrevia.Remolque = mainData.Transporte.Remolque;                        

                        mainData.TransporteReconocido = true;
                        
                        mainData.Transporte = _transporteService.ObtenerTransporte(entradaPrevia.Matricula);

                        //Sobreescribimos el remolque con lo devuelto por el sistema de visión
                        mainData.Transporte.Remolque = mainData.EntradaPrevia.Remolque;

                        mainData.Origen.Nombre = entradaPrevia.Origen;
                        mainData.Origen.Direccion = entradaPrevia.OrigenDireccion;
                        mainData.Origen.Cif = entradaPrevia.OrigenCif;
                        mainData.Origen.Nima = entradaPrevia.OrigenNima;

                        mainData.Destino.Nombre = entradaPrevia.Destino;
                        mainData.Destino.Direccion = entradaPrevia.DestinoDireccion;
                        mainData.Destino.Cif = entradaPrevia.DestinoCif;
                        mainData.Destino.Nima = entradaPrevia.DestinoNima;
                        
                    }
                    else
                    {
                        return mainData;  //Retornamos y evitamos leer el peso
                    }                   
                }

                var pesada = _bascula.ObtenerPeso();
                mainData.PesoCorrecto = pesada.PesoCorrecto;
                if (pesada.PesoCorrecto)
                {
                    mainData.Peso = pesada.Peso;
                    mainData.PesoLeido = pesada.Peso;
                }
            }

            return mainData;            
        }

        private void ProcesarIdentificacion(ref MainFormDto mainData, IdentificacionDto identificacion)
        {
            _logger.LogTrace($"{this.TraceMethod()} - INICIO");

            mainData.IdIdentificacion = identificacion.Id;
            mainData.Tipo = identificacion.Tipo;
            mainData.Estado = identificacion.Estado;

            if(identificacion.Estado >= (byte)Enums.TipoEstado.Correcto)
            {
                if(identificacion.MatriculaC != null)
                {
                    mainData.MatriculaLeida = identificacion.MatriculaC.Trim();
                    mainData.Transporte.Matricula = mainData.MatriculaLeida;
                }
                if (identificacion.MatriculaR != null)
                {
                    mainData.Transporte.Remolque = identificacion.MatriculaR.Trim();
                }

                string patronEntradaSalida = "S";
                if(identificacion.Tipo == (byte)Enums.TipoIdentificacion.Entrada)
                {
                    patronEntradaSalida = "E";
                }

                //Ejemplo nombre imagen: 20210526001_C1_E_20210526014204.jpg
                if (identificacion.Path != null)
                {
                    var files = Directory.EnumerateFiles(identificacion.Path, identificacion.Id + "_C?_" + patronEntradaSalida + "_*");
                    foreach (var file in files)
                    {
                        if (file.Contains(identificacion.Id + Camara1NombreParcial + patronEntradaSalida))
                        {
                            mainData.Camara1Path = Path.GetFullPath(file);
                        }
                        else if (file.Contains(identificacion.Id + Camara2NombreParcial + patronEntradaSalida))
                        {
                            mainData.Camara2Path = Path.GetFullPath(file);
                        }
                        else if (file.Contains(identificacion.Id + Camara3NombreParcial + patronEntradaSalida))
                        {
                            mainData.Camara3Path = Path.GetFullPath(file);
                        }
                    }

                }
            }

            _logger.LogTrace($"{this.TraceMethod()} - FIN");
        }

        public MainFormDto IdentificacionManualTransporte(byte tipo, string matricula)
        {
            MainFormDto result = null;

            if(tipo == (byte)Enums.TipoIdentificacion.Entrada)
            {
                var transporte = _transporteService.ObtenerTransporte(matricula);

                if (transporte != null)
                {
                    result = new MainFormDto();

                    result.TransporteReconocido = true;

                    result.Transporte = transporte;

                    if (result.Transporte.TipoOperacion.IdTipoOperacion == (byte)Enums.TipoOperacion.Carga)
                    {
                        result.Origen.Nombre = _datosInstalacion.Nombre;
                        result.Origen.Direccion = _datosInstalacion.Direccion;
                        result.Origen.Cif = _datosInstalacion.Cif;
                        result.Origen.Nima = _datosInstalacion.Nima;
                    }
                    else
                    {
                        result.Destino.Nombre = _datosInstalacion.Nombre;
                        result.Destino.Direccion = _datosInstalacion.Direccion;
                        result.Destino.Cif = _datosInstalacion.Cif;
                        result.Destino.Nima = _datosInstalacion.Nima;
                    }
                }
            }
            else
            {                
                var entradaPrevia = _operacionService.ObtenerEntradaPrevia(matricula);

                if (entradaPrevia != null)
                {
                    result = new MainFormDto();

                    result.Transporte = _transporteService.ObtenerTransporte(entradaPrevia.Matricula);

                    result.TransporteReconocido = true;

                    result.Origen.Nombre = entradaPrevia.Origen;
                    result.Origen.Direccion = entradaPrevia.OrigenDireccion;
                    result.Origen.Cif = entradaPrevia.OrigenCif;
                    result.Origen.Nima = entradaPrevia.OrigenNima;

                    result.Destino.Nombre = entradaPrevia.Destino;
                    result.Destino.Direccion = entradaPrevia.DestinoDireccion;
                    result.Destino.Cif = entradaPrevia.DestinoCif;
                    result.Destino.Nima = entradaPrevia.DestinoNima;

                    result.EntradaPrevia = entradaPrevia;
                }
                
            }

            return result;
        }

        public int Guardar(MainFormDto datos)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            int result = 0;
            try
            {
                //Creación de las localizaciones si no existen
                if(datos.Transporte.TipoOperacion.IdTipoOperacion == (byte)Enums.TipoOperacion.Carga)
                {
                    if(datos.Destino != null)
                    {
                        LocalizacionDto destino = _localizacionService.ObtenerPorNombre(datos.Destino.Nombre);

                        if(destino == null)
                        {
                            if (_localizacionService.CreadoSiNoExiste(datos.Destino.Nombre, datos.Transporte.TipoOperacion.IdTipoOperacion))
                            {
                                datos.Destino.Direccion = null;
                                datos.Destino.Cif = null;
                                datos.Destino.Nima = null;
                            }
                        }
                        else
                        {
                            datos.Destino = destino;
                        }                                                   
                    }                    
                }
                else
                {
                    if(datos.Origen != null)
                    {
                        LocalizacionDto origen = _localizacionService.ObtenerPorNombre(datos.Origen.Nombre);

                        if(origen == null)
                        {
                            if (_localizacionService.CreadoSiNoExiste(datos.Origen.Nombre, datos.Transporte.TipoOperacion.IdTipoOperacion))
                            {
                                datos.Origen.Direccion = null;
                                datos.Origen.Cif = null;
                                datos.Origen.Nima = null;
                            }
                        }
                        else
                        {
                            datos.Origen = origen;
                        }                        
                    }                    
                }

                //Actualizamos los datos del transporte
                _transporteService.Actualizar(datos.Transporte.Matricula, datos.Transporte.Conductor);

                //Expedidor
                if (datos.Transporte.Expedidor.IdEmpresa != 0)
                {
                    EmpresaDto expedidor = _empresaService.ObtenerPorNombre(datos.Transporte.Expedidor.Nombre);

                    if (expedidor == null)
                    {
                        datos.Transporte.Expedidor = null;
                    }
                    else
                    {
                        datos.Transporte.Expedidor = expedidor;
                    }
                }
                else
                {
                    datos.Transporte.Expedidor = null;
                }


                //Operación
                if (datos.Tipo == (byte)Enums.TipoIdentificacion.Entrada)
                {
                    OperacionDto operacion = new OperacionDto();

                    operacion.Matricula = datos.Transporte.Matricula;
                    operacion.Remolque = datos.Transporte.Remolque;
                    operacion.IdTipoOperacion = datos.Transporte.TipoOperacion.IdTipoOperacion;
                    operacion.MatriculaEntradaManual = datos.IdentificacionManual;
                    if (datos.IdentificacionManual)
                    {
                        if(datos.MatriculaLeida != "")
                        {
                            datos.MotivoIdentificacionManual = string.Format("Matrícula recogida en automático: {0}. Comentario: {1}", datos.MatriculaLeida, datos.MotivoIdentificacionManual);
                        }
                        operacion.MotivoMatriculaEntradaManual = datos.MotivoIdentificacionManual;
                    }                    
                    operacion.PesoEntrada = datos.Peso;
                    operacion.PesoEntradaManual = datos.PesoManual;
                    if (datos.PesoManual)
                    {
                        if(datos.PesoLeido != 0)
                        {
                            datos.MotivoPesoManual = string.Format("Peso leído: {0}. Comentario: {1}", datos.PesoLeido.ToString("##,0"), datos.MotivoPesoManual);
                        }
                        operacion.MotivoPesoEntradaManual = datos.MotivoPesoManual;
                    }                                        
                    operacion.UsuarioEntrada = _usuarioSesion.Nombre;

                    if (datos.Transporte.Empresa != null)
                    {
                        operacion.IdEmpresa = datos.Transporte.Empresa.IdEmpresa;
                        operacion.Empresa = datos.Transporte.Empresa.Nombre;
                        operacion.EmpresaDireccion = datos.Transporte.Empresa.Direccion;
                        operacion.EmpresaCif = datos.Transporte.Empresa.Cif;
                        operacion.EmpresaNima = datos.Transporte.Empresa.Nima;
                    }
                   
                    operacion.Conductor = datos.Transporte.Conductor;
                    operacion.IdTipoCarga = datos.Transporte.TipoCarga.IdTipoCarga;
                    operacion.TipoCarga = datos.Transporte.TipoCarga.Nombre;
                    operacion.CodigoLer = datos.Transporte.TipoCarga.CodigoLer;
                    operacion.DenominacionAdr = datos.Transporte.TipoCarga.DenominacionAdr;

                    operacion.Origen = datos.Origen.Nombre;
                    operacion.OrigenDireccion = datos.Origen.Direccion;
                    operacion.OrigenCif = datos.Origen.Cif;
                    operacion.OrigenNima = datos.Origen.Nima;

                    operacion.Destino = datos.Destino.Nombre;
                    operacion.DestinoDireccion = datos.Destino.Direccion;
                    operacion.DestinoCif = datos.Destino.Cif;
                    operacion.DestinoNima = datos.Destino.Nima;

                    if(datos.Transporte.Expedidor != null)
                    {
                        operacion.Expedidor = datos.Transporte.Expedidor.Nombre;
                        operacion.ExpedidorDireccion = datos.Transporte.Expedidor.Direccion;
                        operacion.ExpedidorCif = datos.Transporte.Expedidor.Cif;
                    }
                    else
                    {
                        operacion.Expedidor = null;
                    }                                       

                    FotoDto fotos = new FotoDto();

                    fotos.Tipo = datos.Tipo;
                    fotos.Camara1 = datos.Camara1Path;
                    fotos.Camara2 = datos.Camara2Path;
                    fotos.Camara3 = datos.Camara3Path;

                    result = _operacionService.GuardarEntrada(operacion, fotos);
                }
                else
                {
                    OperacionDto operacion = datos.EntradaPrevia;

                    operacion.Remolque = datos.Transporte.Remolque;

                    operacion.MatriculaSalidaManual = datos.IdentificacionManual;
                    if (datos.IdentificacionManual)
                    {
                        if (datos.MatriculaLeida != "")
                        {
                            datos.MotivoIdentificacionManual = string.Format("Matrícula recogida en automático: {0}. Comentario: {1}", datos.MatriculaLeida, datos.MotivoIdentificacionManual);
                        }
                        operacion.MotivoMatriculaEntradaManual = datos.MotivoIdentificacionManual;
                    }
                    operacion.PesoSalida = datos.Peso;
                    operacion.PesoSalidaManual = datos.PesoManual;
                    if (datos.PesoManual)
                    {
                        if (datos.PesoLeido != 0)
                        {
                            datos.MotivoPesoManual = string.Format("Peso leído: {0}. Comentario: {1}", datos.PesoLeido.ToString("##,0"), datos.MotivoPesoManual);
                        }
                        operacion.MotivoPesoSalidaManual = datos.MotivoPesoManual;
                    }
                    operacion.UsuarioSalida = _usuarioSesion.Nombre;

                    if (datos.Transporte.Empresa != null)
                    {
                        operacion.IdEmpresa = datos.Transporte.Empresa.IdEmpresa;
                        operacion.Empresa = datos.Transporte.Empresa.Nombre;
                        operacion.EmpresaDireccion = datos.Transporte.Empresa.Direccion;
                        operacion.EmpresaCif = datos.Transporte.Empresa.Cif;
                        operacion.EmpresaNima = datos.Transporte.Empresa.Nima;
                    }

                    operacion.Conductor = datos.Transporte.Conductor;
                    operacion.IdTipoCarga = datos.Transporte.TipoCarga.IdTipoCarga;
                    operacion.TipoCarga = datos.Transporte.TipoCarga.Nombre;
                    operacion.CodigoLer = datos.Transporte.TipoCarga.CodigoLer;
                    operacion.DenominacionAdr = datos.Transporte.TipoCarga.DenominacionAdr;

                    operacion.Origen = datos.Origen.Nombre;
                    operacion.OrigenDireccion = datos.Origen.Direccion;
                    operacion.OrigenCif = datos.Origen.Cif;
                    operacion.OrigenNima = datos.Origen.Nima;

                    operacion.Destino = datos.Destino.Nombre;
                    operacion.DestinoDireccion = datos.Destino.Direccion;
                    operacion.DestinoCif = datos.Destino.Cif;
                    operacion.DestinoNima = datos.Destino.Nima;

                    if (datos.Transporte.Expedidor != null)
                    {
                        operacion.Expedidor = datos.Transporte.Expedidor.Nombre;
                        operacion.ExpedidorDireccion = datos.Transporte.Expedidor.Direccion;
                        operacion.ExpedidorCif = datos.Transporte.Expedidor.Cif;
                    }
                    else
                    {
                        operacion.Expedidor = null;
                    }

                    operacion.FirmaProductorImagen = datos.FirmaProductorImagen;
                    operacion.FirmaConductorImagen = datos.FirmaConductorImagen;

                    FotoDto fotos = new FotoDto();

                    fotos.Tipo = datos.Tipo;
                    fotos.Camara1 = datos.Camara1Path;
                    fotos.Camara2 = datos.Camara2Path;
                    fotos.Camara3 = datos.Camara3Path;

                    result = _operacionService.GuardarSalida(operacion, fotos);
                }


                _bascula.ResetLecturaBascula();                

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }    

        public async Task<bool> Eliminar(MainFormDto datos)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            bool result = false;
            try
            {
                result = await _identificacion.Eliminar(datos.IdIdentificacion);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }

        public Task<byte[]> ObtenerAlbaran(int idOperacion)
        {
            return _operacionService.ObtenerAlbaran(idOperacion);
        }

        public Task<byte[]> ObtenerCartaPorte(int idOperacion)
        {
            return _operacionService.ObtenerCartaPorte(idOperacion);
        }

        public Task<DataTable> ObtenerDatosAlbaran(int idOperacion)
        {
            return _operacionService.ObtenerDatosAlbaran(idOperacion);
        }

        public Task<Dictionary<string, string>> ObtenerListaEmails(int idOperacion)
        {       
            return _operacionService.ObtenerListaEmails(idOperacion);
        }

        #endregion

        #region "BASCULA"
        public bool ConfigurarBascula()
        {
            return _bascula.ConfigurarPuerto();
        }

        public string ObtenerLecturaBascula()
        {
            var pesada = _bascula.ObtenerPeso();

            return pesada.Lectura;
        }
        
        public bool BasculaOffline()
        {
            return _bascula.BasculaOffline();
        }

        public bool BaculaEnModoContinuo()
        {
            return _bascula.ModoContinuo();
        }

        public int ObtenerPesoReal()
        {
            return _bascula.ObtenerPesoReal();
        }

        public int ComprobarPesoEstable()
        {
            return _bascula.ComprobarPesoEstable();
        }

        public void ControlValidezPeso(IProgress<int> peso)
        {
            _bascula.ConfigurarControlValidezPeso(peso);
        }

        public void ResetLecturaBascula()
        {
            _bascula.ResetLecturaBascula();
        }

        #endregion
    }
}
