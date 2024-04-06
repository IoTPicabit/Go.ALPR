using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using Go.ALPR.Sri.Common;

using X.PagedList;

namespace Go.ALPR.Sri.Business
{
    public partial class ControlAccesoFormBusiness : IControlAccesoFormBusiness
    {
        private readonly ILogger<ControlAccesoFormBusiness> _logger;
        private readonly IConfiguration _config;
        private readonly IIdentificacionAccesoService _identificacion;      
        private readonly ITransporteService _transporteService;
        private readonly IAccesoService _accesoService;

        private InstalacionDatos _datosInstalacion;
        private readonly UsuarioSesionDto _usuarioSesion;
        private bool _sistemaVisionActivado = false;
        private int _numeroReintentosFallido = 0;

       
        #region "Constructor"
        public ControlAccesoFormBusiness(ILogger<ControlAccesoFormBusiness> logger,
                                IConfiguration configuration,
                                IIdentificacionAccesoService identificacion,                           
                                ITransporteService transporteService,
                                IAccesoService accesoService,
                                UsuarioSesionDto usuarioSesion) {

            _logger = logger;
            _config = configuration;
            _identificacion = identificacion;       
            _transporteService = transporteService;
            _accesoService = accesoService;
            _usuarioSesion = usuarioSesion;
        }
        

        public void Inicializar()
        {
            _sistemaVisionActivado = bool.Parse(_config.GetSection("SistemaVisionActivado").Value);
            _numeroReintentosFallido = int.Parse(_config.GetSection("NumeroReintentosFallido").Value);

            _datosInstalacion = _config.GetSection("Instalacion").Get<InstalacionDatos>();
        }

        #endregion


        #region "IDENTIFICACIÓN VEHÍCULO"
        public async Task<MainFormDto> NuevaEntrada(IProgress<string> progreso)
        {
            MainFormDto mainData = new MainFormDto();            

            IdentificacionDto identificacion;
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

            if (mainData.Estado >= (byte)Enums.TipoEstado.Correcto && mainData.Estado < (byte)Enums.TipoEstado.Fallo)
            {
                progreso.Report("Identificando transporte...");
                await Task.Delay(500);
                var transporte = _transporteService.ObtenerTransporte(mainData.Transporte.Matricula);

                if (transporte != null)
                {
                    mainData.TransporteReconocido = true;                                           

                    mainData.Transporte = transporte;
                }
            }

            await _identificacion.RegistrarAcceso(mainData.IdIdentificacion, mainData.TransporteReconocido);

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
               
            }

            _logger.LogTrace($"{this.TraceMethod()} - FIN");
        }

        #endregion



        public async Task<IPagedList<AccesoDto>> ObtenerListaAccesos(
                                                        DateTime FechaInicio,
                                                        DateTime FechaFin,
                                                        string Matricula,
                                                        int Acceso,
                                                        int pageNumber = 1,
                                                        int pageSize = 10
                                                    )
        {
            return await _accesoService.ObtenerListaPaginada(FechaInicio, FechaFin, Matricula, Acceso, pageNumber, pageSize);
        }
    }
}
