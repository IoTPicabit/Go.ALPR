using System;
using System.Threading.Tasks;
using System.Data;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using Go.ALPR.Sri.Common;

using ClxDriver;
using ClxDriver.Common;



namespace Go.ALPR.Sri.PlcComm
{
    public class PLCService: IPLCService
    {

        private readonly ILogger<PLCService> _logger;
        private readonly IConfiguration _config;

        private EthernetIPforCLX _ethernetIPforCLX;
        
        private PLCConfig _plcConfig;

        private bool _conectado = false;

        public PLCService(ILogger<PLCService> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        ~PLCService()
        {
            _ethernetIPforCLX.ComError -= EthernetIPforCLX_ComError;
            _ethernetIPforCLX.Dispose();
        }

        public void Inicializar()
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            try
            {                

                _plcConfig = _config.GetSection("plc").Get<PLCConfig>();

                _ethernetIPforCLX = new EthernetIPforCLX();

                _ethernetIPforCLX.IPAddress = _plcConfig.IPAddress;
                _ethernetIPforCLX.Port = _plcConfig.Port;
                _ethernetIPforCLX.ProcessorSlot = _plcConfig.ProcessorSlot;
                _ethernetIPforCLX.RoutePath = _plcConfig.RoutePath;
                _ethernetIPforCLX.CIPConnectionSize = _plcConfig.CIPConnectionSize;
                _ethernetIPforCLX.DisableMultiServiceRequest = _plcConfig.DisableMultiServiceRequest;
                _ethernetIPforCLX.DisableSubscriptions = _plcConfig.DisableSubscriptions;
                _ethernetIPforCLX.PollRateOverride = _plcConfig.PollRateOverride;
                _ethernetIPforCLX.Timeout = _plcConfig.TimeOut;
                _ethernetIPforCLX.UseOmronRead = _plcConfig.UseOmronRead;

                _ethernetIPforCLX.ComError += EthernetIPforCLX_ComError;

                //Probamos a leer la hora del PLC para comprobar la conexión
                //Cuando no hay conexión devuelve una fecha vacia
                DateTime fechaPLC = _ethernetIPforCLX.ReadClock();
                if(fechaPLC != DateTime.MinValue)
                {
                    _conectado = true;
                }                

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");
        }


        private bool ProcesarAlbaran(DataTable datos)
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            bool result = false;

            if (_conectado) {

                try
                {
                    //Obtenemos la configuración de los campos del archivo de configuración
                    if (_plcConfig.Campos.Length > 0 && datos.Rows.Count > 0)
                    {
                        DataRow drOperacion = datos.Rows[0];

                        if (drOperacion != null)
                        {
                            foreach (PLCCampoConfig campo in _plcConfig.Campos)
                            {
                                if (datos.Columns.Contains(campo.CampoBD))
                                {
                                    //Si no tiene longitud interpretamos que es un entero
                                    if (campo.LongitudPLC == 0)
                                    {
                                        string valor = drOperacion[campo.CampoBD].ToString();
                                        _ethernetIPforCLX.Write(campo.CampoPLC, valor);
                                    }
                                    else
                                    {
                                        //Si no, es un string
                                        string valor = drOperacion[campo.CampoBD].ToString();
                                        if (valor.Length > campo.LongitudPLC)
                                        {
                                            valor = valor.Substring(1, campo.LongitudPLC);
                                        }
                                        _ethernetIPforCLX.WriteCustomString(campo.CampoPLC, valor, campo.LongitudPLC);
                                    }
                                }
                                else
                                {
                                    throw new Exception(string.Format("El campo {0} no existe en la base de datos", campo.CampoBD));
                                }
                            }

                            //Al final escribimos el tag de confirmación
                            _ethernetIPforCLX.Write(_plcConfig.TagConfirmacion, 1);

                            result = true;
                        }
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, this.TraceMethod(new { }));
                }

            }
            else
            {
                _logger.LogTrace($"{this.TraceMethod(new { })} - PLC NO CONECTADO");
                result = true;
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");


            return result;
        }

        public async Task<bool> EscribirAlbaran(DataTable datos)
        {

            Task<bool> escribirEnPLCTask = Task<bool>.Factory.StartNew(() => {

                return ProcesarAlbaran(datos);
                
            });

            return await escribirEnPLCTask;
        }


        private void EthernetIPforCLX_ComError(object sender, PlcComEventArgs e)
        {
            _logger.LogError($"Error {e.ErrorId} {e.ErrorMessage}");
        }

        public bool Conectado
        {
            get
            {
                return _conectado;
            }
        }

    }



    public interface IPLCService
    {
        void Inicializar();

        Task<bool> EscribirAlbaran(DataTable datos);

        bool Conectado { get; }
    }

}
