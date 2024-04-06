using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO.Ports;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using Go.ALPR.Sri.Common;

namespace Go.ALPR.Sri.Business
{       

    public class BasculaService: IBasculaService
    {
        private readonly ILogger<BasculaService> _logger;
        private readonly IConfiguration _config;
        
        private SerialPort _serialPort = null;
        private BasculaSettings _basculaSettings;

        //private static Regex _pesoRegex = new Regex(@"\d+", RegexOptions.Compiled);

        private static Regex _pesoRegex;

        private bool _basculaOffline;

        private bool _modoContinuo;

        //Almacena la cadena leida de la bascula hasta que se utiliza, cada vez que hay una lectura
        private string _lecturaBascula = null;
        private Object _syncLecturaBascula = new Object();

        private int _ultimoPesoEstable = 0;
        private int _pesoActual = 0;
        private Object _syncPesoActual = new Object();
        

        private Timer _temporizador = null;
        private TimerState _estadoTemporizador = null;


        private IProgress<int> _controlValidezPeso = null;
                

        private string LecturaBascula {
            get
            {
                lock (_syncLecturaBascula)
                {
                    return _lecturaBascula;
                }
            }
            set
            {
                lock (_syncLecturaBascula)
                {
                    _lecturaBascula = value;
                }
            }
        }


        private int PesoActual { 
            get {
                lock (_syncPesoActual)
                {
                    return _pesoActual;
                }
            }
            set {
                lock (_syncPesoActual)
                {
                    _pesoActual = value;
                }
            }
        }


        public BasculaService(ILogger<BasculaService> logger, IConfiguration configuration)
        {
            _config = configuration;
            _logger = logger;
        }

        public bool ConfigurarPuerto()
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            bool result = false;
            try
            {
                _basculaSettings = _config.GetSection("Bascula").Get<BasculaSettings>();

                string pattern = @"" + _basculaSettings.TramaRegExp;

                _pesoRegex = new Regex(pattern, RegexOptions.Compiled);

                var configCOM = _config.GetSection("PuertoCOM");

                string puerto = configCOM.GetSection("Nombre").Value;
                int baudios = Convert.ToInt32(configCOM.GetSection("Baudios").Value);
                int paridad = Convert.ToInt32(configCOM.GetSection("Paridad").Value);
                int dataBits = Convert.ToInt32(configCOM.GetSection("DataBits").Value);
                int stopBits = Convert.ToInt32(configCOM.GetSection("StopBits").Value);             

                _serialPort = new SerialPort(puerto, baudios, (Parity)paridad, dataBits, (StopBits)stopBits);

                if (!_serialPort.IsOpen)
                {
                    _serialPort.DataReceived -= new SerialDataReceivedEventHandler(SerialPort_DataReceived);
                    _serialPort.Open();
                }

                if (_serialPort.IsOpen)
                {
                    _serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
                }

                _modoContinuo = (_basculaSettings.Modo == 0);

                _basculaOffline = false;

            }
            catch (Exception ex)
            {
                _basculaOffline = true;
                _logger.LogError(ex, this.TraceMethod(new { }));               
            }

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }
                

        public bool BasculaOffline()
        {
            return _basculaOffline;
        }

        public bool ModoContinuo()
        {
            return _modoContinuo;
        }

        void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                LecturaBascula = _serialPort.ReadExisting();
                if (!_modoContinuo)
                {
                    ObtenerPesoReal();
                    IniciarTemporizadorValidez();
                }
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }           
        }               

        public BasculaDto ObtenerPeso()
        {
            _logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            BasculaDto result = new BasculaDto();

            result.Lectura = "";

            try
            {
                if (_serialPort.IsOpen && !_basculaOffline)
                {
                    string lecturaBasculaLocal = LecturaBascula;

                    if (lecturaBasculaLocal != null)
                    {
                        result.Lectura = lecturaBasculaLocal.Trim();

                        _logger.LogTrace($"{this.TraceMethod(new { result.Lectura })} - LECTURA BASCULA");
                    }

                    if (result.Lectura != "")
                    {
                        Match pesoMatch = _pesoRegex.Match(result.Lectura);

                        if (pesoMatch.Success)
                        {
                            int peso;
                            result.PesoCorrecto = int.TryParse(pesoMatch.Groups["peso"].Value, out peso);
                            if (result.PesoCorrecto)
                            {
                                result.Peso = peso;
                                _logger.LogTrace($"{this.TraceMethod(new { peso })} - PESO LEIDO");
                            }
                            else
                            {
                                _logger.LogTrace($"{this.TraceMethod(new { result.Lectura })} - ERROR AL CONVERTIR A ENTERO");
                            }
                        }
                        else
                        {
                            result.PesoCorrecto = false;
                        }
                    }
                    else
                    {
                        result.PesoCorrecto = false;
                    }
                }
                else
                {
                    _basculaOffline = true;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }                       

            _logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            return result;
        }


        public int ObtenerPesoReal()
        {
            int result = 0;

            string lecturaBasculaLocal = LecturaBascula;

            if(lecturaBasculaLocal != null)
            {
                Match pesoMatch = _pesoRegex.Match(lecturaBasculaLocal.Trim());

                if (pesoMatch.Success)
                {
                    bool correcto = int.TryParse(pesoMatch.Groups["peso"].Value, out result);

                    if (!correcto)
                    {
                        result = 0;
                    }
                }

            }

            PesoActual = result;

            return result;
        }

        class TimerState
        {
            public int PesoNuevo;
            public int Segundos;
        }


        public int ComprobarPesoEstable()
        {
            int result = 0; //Inestable

            if ((Math.Abs(PesoActual - _ultimoPesoEstable) > _basculaSettings.PesoEstabilidadBascula) || _temporizador != null)
            { 
                if (_temporizador == null)
                {
                    _estadoTemporizador = new TimerState { PesoNuevo = PesoActual, Segundos = 0 };

                    _temporizador = new Timer(
                        callback: TiempoPesoEstabilizadoConcluido,
                        state: _estadoTemporizador,
                        dueTime: 1000,
                        period: 1000);
                }
                else
                {
                    //Cuando finaliza la cuenta de los segundos
                    if(_estadoTemporizador.Segundos >= _basculaSettings.TiempoEstabilidadBascula)
                    {
                        if (Math.Abs(PesoActual - _estadoTemporizador.PesoNuevo) <= _basculaSettings.PesoEstabilidadBascula)
                        {
                            _ultimoPesoEstable = PesoActual;
                            result = 1;
                        }
                        _temporizador.Dispose();
                        _temporizador = null;
                    }
                }
            }
            else
            {
                result = 1; //Estable
            }            

            return result;
        }

        private void TiempoPesoEstabilizadoConcluido(Object stateInfo)
        {
            var state = stateInfo as TimerState;
            Interlocked.Increment(ref state.Segundos);                        
        }
                        

        public void ConfigurarControlValidezPeso(IProgress<int> peso)
        {
            _controlValidezPeso = peso;
        }

        private void IniciarTemporizadorValidez()
        {
            if (_controlValidezPeso != null)
            {
                ResetTemporizador();
                int tiempoValidez = _basculaSettings.ValidezPeso * 1000;
                _temporizador = new Timer(
                    callback: TiempoValidezPesoConcluido,
                    state: null,
                    dueTime: tiempoValidez,
                    period: tiempoValidez);

                _controlValidezPeso.Report(PesoActual);
            }            
        }

        private void ResetTemporizador()
        {
            if (_temporizador != null)
            {
                _temporizador.Dispose();
                _temporizador = null;
            }
        }


        private void TiempoValidezPesoConcluido(Object stateInfo)
        {
            ResetLecturaBascula();            
        }

        public void ResetLecturaBascula()
        {
            try
            {
                if (!_modoContinuo)
                {
                    LecturaBascula = null;
                    ResetTemporizador();
                    _controlValidezPeso.Report(0);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }            
        }


        ~BasculaService()
        {
            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.DataReceived -= new SerialDataReceivedEventHandler(SerialPort_DataReceived);
                    _serialPort.Close();
                }
                _serialPort.Dispose();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, this.TraceMethod(new { }));
            }
        }
    }

    public class BasculaSettings
    { 
             
        public int Modo { get; set; }                           //0: Continuo, 1: Por evento

        public int ValidezPeso { get; set; }                    //Tiempo en segundos durante el cual es válido el peso --> Modo=0

        public int TiempoEstabilidadBascula { get; set; }       //Tiempo en segundos tras el cual se condidera estable el peso --> Modo=1

        public int PesoEstabilidadBascula { get; set; }         //Variación del peso en Kg admitida para considerar el peso estable --> Modo=1

        public string TramaRegExp { get; set; }                 //Expresión regular para extraer el peso de la trama

        public BasculaSettings()
        {
            TiempoEstabilidadBascula = 5;
            PesoEstabilidadBascula = 10;
            ValidezPeso = 30;
        }

        public override string ToString()
        {
            return String.Format("Modo: {0}; ValidezPeso: {1}; TiempoEstabilidadBascula: {2}; PesoEstabilidadBascula: {3}; TramaRegExp: {4}", Modo.ToString(), ValidezPeso.ToString(), TiempoEstabilidadBascula.ToString(), PesoEstabilidadBascula.ToString(), TramaRegExp);
        }
    }

}