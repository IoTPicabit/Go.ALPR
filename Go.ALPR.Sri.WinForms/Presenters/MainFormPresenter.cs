using System;
using System.Data;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

using System.Linq;

using System.Windows.Forms;
using MiniMVPNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using Go.ALPR.Sri.Business;
using Go.ALPR.Sri.Common;
using Go.ALPR.Sri.Printer;
using Go.ALPR.Sri.PlcComm;


namespace Go.ALPR.Sri.WinForms
{
    public class MainFormPresenter: Presenter<IViewMainForm>, IPresentMainForm
    {

        private readonly IConfiguration _config;
        private readonly IServiceProvider _serviceProvider;
        private readonly IMainFormBusiness _business;
        private readonly UsuarioSesionDto _usuarioSesion;
        private readonly IPrinterService _printerService;
        private readonly IPdfPrintService _pdfPrinterService;
        private readonly IClienteSMTP _clienteSMTP;
        private readonly IPLCService _plcService;
        

        private MainFormDto _mainData;

        private string _printerName;
        private bool _envioCorreosHabilitado = false;

        private bool _operando;
                
        private List<LocalizacionDto> _listaLocalizaciones;

        private IProgress<string> _progresoIdentificacion;
        private Timer _temporizadorLimpiaProgreso;

        private IProgress<int> _progresoPesoValido;

        private ComboBox _cmbTiposCarga;

        public MainFormPresenter(Func<IViewMainForm> viewFactory,
                                    IConfiguration configuration,
                                    IServiceProvider serviceProvider,
                                    IMainFormBusiness business,
                                    UsuarioSesionDto usuarioSesion,
                                    IPrinterService printerService,
                                    IPdfPrintService pdfPrinterService,
                                    IClienteSMTP clienteSMTP,
                                    IPLCService plcService)
            : base(viewFactory)
        {
            _config = configuration;
            _serviceProvider = serviceProvider;
            _business = business;
            _usuarioSesion = usuarioSesion;
            _printerService = printerService;
            _pdfPrinterService = pdfPrinterService;
            _clienteSMTP = clienteSMTP;
            _plcService = plcService;
        }

        ~MainFormPresenter()
        {
            _mainData = null;
            _progresoIdentificacion = null;
            _temporizadorLimpiaProgreso.Tick -= LimpiarProgresoIdentificacion;
            _temporizadorLimpiaProgreso.Dispose();
        }

        private void ShowToast(string msg, frmMessage.enmType type)
        {
            var frm = _serviceProvider.GetRequiredService<frmMessage>();
            frm.showAlert(msg, type);
        }

        public frmMain MainForm
        {
            get { return View as frmMain; }
        }

        public void InicializarFormulario()
        {
            _progresoIdentificacion = new Progress<string>(MostrarProgresoIdentificacion);
            
            _temporizadorLimpiaProgreso = new Timer();
            _temporizadorLimpiaProgreso.Tick += LimpiarProgresoIdentificacion;
            _temporizadorLimpiaProgreso.Interval = 5000;

            _business.Inicializar();
           
            _listaLocalizaciones = _business.ObtenerListaLocalizaciones();            

            View.HabilitarAccionesIdentificacion(false);
            View.HabilitarFormularioIdentificacion(false);
            View.HabilitarGuardar(false);

            //---------- Configuración de sistemas externos
            _business.ConfigurarBascula();

            _printerName = _printerService.GetDefaultPrinterName();           

            _envioCorreosHabilitado = _clienteSMTP.ComprobarConfiguracionSMTP();

            _plcService.Inicializar();
            ///---------

            string urlCamara1 = _config.GetSection("UrlCamaraStreaming1").Value;
            if(urlCamara1 != "")
            {
                View.IniciarCamara1(urlCamara1);
            }

            string urlCamara2 = _config.GetSection("UrlCamaraStreaming2").Value;
            if (urlCamara2 != "")
            {
                View.IniciarCamara2(urlCamara2);
            }

            string urlCamara3 = _config.GetSection("UrlCamaraStreaming3").Value;
            if (urlCamara3 != "")
            {
                View.IniciarCamara3(urlCamara3);
            }
            
            MostrarProgresoIdentificacion("");
        }

        public void ConfigurarComboExpedidores(ComboBox cmb)
        {
            List<EmpresaDto> empresas = _business.ObtenerListaExpedidores();
            
            empresas.Insert(0, new EmpresaDto { IdEmpresa = 0, Nombre = "" });

            cmb.DataSource = empresas;
            cmb.DisplayMember = "Nombre";
            cmb.ValueMember = "IdEmpresa";

            cmb.Enabled = false;
        }

        public void ConfigurarComboTipoCargas(ComboBox cmb)
        {
            _cmbTiposCarga = cmb;
        }

        public void MostrarAdvertenciasSistemasExternos()
        {
            if (_business.BasculaOffline())
            {                
                ShowToast("Error al configurar la báscula. Cosulte el log para más detalles", frmMessage.enmType.Error);
            }
            else
            {
                if (_business.BaculaEnModoContinuo())
                {
                    View.IniciarLecturaPeso();
                }
                else
                {
                    _progresoPesoValido = new Progress<int>(MostrarPesoValido);
                    _business.ControlValidezPeso(_progresoPesoValido);
                }               
            }

            if (_printerName == null)
            {                
                ShowToast("No hay impresora predeterminada en el sistema. No se podrá imprimir", frmMessage.enmType.Warning);
            }

            if (!_envioCorreosHabilitado)
            {                
                ShowToast("Imposible conectar con el servidor SMTP. No se podrán enviar correos", frmMessage.enmType.Warning);
            }

            if (!_plcService.Conectado)
            {
                ShowToast("No hay conexión con el PLC", frmMessage.enmType.Warning);
            }

        }


        private void ConfigurarComboOrigenes()
        {
            string[] origenes;
            if(_mainData.Transporte.TipoOperacion.IdTipoOperacion == (byte)Enums.TipoOperacion.Carga)
            {
                origenes = new string[] { _mainData.Origen.Nombre };
            }
            else
            {
                origenes = _listaLocalizaciones.Where(l => l.IdTipoOperacion == _mainData.Transporte.TipoOperacion.IdTipoOperacion).Select(l => l.Nombre).ToArray();
            }
            View.CargarComboOrigenes(origenes, (_mainData.Transporte.TipoOperacion.IdTipoOperacion == (byte)Enums.TipoOperacion.Carga));
        }

        private void ConfigurarComboDestinos()

        {
            string[] destinos;
            if (_mainData.Transporte.TipoOperacion.IdTipoOperacion == (byte)Enums.TipoOperacion.Carga)
            {                
                destinos = _listaLocalizaciones.Where(l => l.IdTipoOperacion == _mainData.Transporte.TipoOperacion.IdTipoOperacion).Select(l => l.Nombre).ToArray();
            }
            else
            {
                destinos = new string[] { _mainData.Destino.Nombre };
            }
            View.CargarComboDestinos(destinos, (_mainData.Transporte.TipoOperacion.IdTipoOperacion == (byte)Enums.TipoOperacion.Descarga));
        }

        private void CargarComboTiposCarga()
        {
            List<TipoCargaDto> listaTiposCarga = new List<TipoCargaDto>();

            if(_mainData.Transporte.TipoCarga.Subproductos.Count > 0)
            {                
                listaTiposCarga.AddRange(_mainData.Transporte.TipoCarga.Subproductos);
                listaTiposCarga.Insert(0, new TipoCargaDto { IdTipoCarga = 0, Nombre = "Seleccione..." }); 
            }
            else
            {
                listaTiposCarga.Add(_mainData.Transporte.TipoCarga);
            }

            _cmbTiposCarga.DataSource = listaTiposCarga;
            _cmbTiposCarga.DisplayMember = "Nombre";
            _cmbTiposCarga.ValueMember = "IdTipoCarga";           
        }


        public void EstablecerPermisosAdmin()
        {
            View.EsAdmin = (_usuarioSesion.Tipo == (byte)Enums.TipoUsuario.Administrador);
        }

        public void EstablecerFechaHora()
        {
            DateTime fechaHora = DateTime.Now;
            View.Fecha = fechaHora.ToShortDateString();
            View.Hora = fechaHora.ToShortTimeString();
        }

        public void EstablecerOperario()
        {
            View.Operario = _usuarioSesion.Nombre;
        }

        public void SalirAplicacion()
        {           
            if (MessageBox.Show("¿Está seguro que desea salir de la aplicación?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }            
        }

        public void CambiarUsuario()
        {
            var loginForm = _serviceProvider.GetRequiredService<LoginFormPresenter>();
            loginForm.CambioUsuario = true;
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                EstablecerPermisosAdmin();
                EstablecerOperario();
            }
        }

        public void CambiarClave()
        {
            var cambiarClaveForm = _serviceProvider.GetRequiredService<CambiarClaveFormPresenter>();
            if (cambiarClaveForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Clave cambiada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void GestionUsuarios()
        {
            var frm = _serviceProvider.GetRequiredService<UsuariosFormPresenter>();
            frm.ShowDialog();
        }

        public void GestionLocalizaciones()
        {
            var frm = _serviceProvider.GetRequiredService<LocalizacionesFormPresenter>();
            var resultado = frm.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                _listaLocalizaciones = _business.ObtenerListaLocalizaciones();
            }
        }

        public void GestionEmpresas()
        {
            var frm = _serviceProvider.GetRequiredService<EmpresasFormPresenter>();
            frm.ShowDialog();
        }

        public void GestionTipoCargas()
        {
            var frm = _serviceProvider.GetRequiredService<TipoCargasFormPresenter>();
            frm.ShowDialog();
        }

        public void GestionContactos()
        {
            var frm = _serviceProvider.GetRequiredService<ContactosFormPresenter>();
            frm.ShowDialog();
        }

        public void GestionTransportes()
        {
            var frm = _serviceProvider.GetRequiredService<TransportesFormPresenter>();
            frm.ShowDialog();
        }

        public void GestionOperaciones()
        {
            var frm = _serviceProvider.GetRequiredService<OperacionesFormPresenter>();
            frm.NombreImpresora = _printerName;
            frm.CorreoHabilitado = _envioCorreosHabilitado;
            frm.ShowDialog();
        }

        public async Task NuevaEntrada(object sender, EventArgs e)
        {            
            Button btn = (Button)sender;

            try
            {
                MainForm.Cursor = Cursors.WaitCursor;
                btn.BackColor = SystemColors.ActiveCaption;

                await NuevaIdentificacion((byte)Enums.TipoIdentificacion.Entrada, _progresoIdentificacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn.UseVisualStyleBackColor = true;
            }
            finally
            {                
                MainForm.Cursor = Cursors.Default;               
            }
        }

        public async Task NuevaSalida(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            try
            {
                MainForm.Cursor = Cursors.WaitCursor;
                btn.BackColor = SystemColors.ActiveCaption;

                await NuevaIdentificacion((byte)Enums.TipoIdentificacion.Salida, _progresoIdentificacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn.UseVisualStyleBackColor = true;
            }
            finally
            {                
                MainForm.Cursor = Cursors.Default;
            }
        }

        private void MostrarProgresoIdentificacion(string progreso)
        {
            View.ProgresoIdentificacion = progreso;
        }


        private void MostrarPesoValido(int peso)
        {
            if (!_operando)
            {                
                View.MostrarPesoValido(peso);
            }
        }


        private void LimpiarProgresoIdentificacion(object sender, EventArgs e)
        {
            View.ProgresoIdentificacion = "";
        }

        private async Task NuevaIdentificacion(byte tipo, IProgress<string> progreso)
        {
            try
            {
                _operando = true;

                MostrarProgresoIdentificacion("Iniciando identificación...");
                await Task.Delay(500);                

                View.HabilitarBotonesIdentificacion(false);
                View.HabilitarBotoneraMantenimientos(false);                

                if (tipo == (byte)Enums.TipoIdentificacion.Entrada)
                {
                    _mainData = await _business.NuevaEntrada(progreso);
                }
                else
                {
                    _mainData = await _business.NuevaSalida(progreso);

                    if(_mainData.Estado == (byte)Enums.TipoEstado.Correcto && _mainData.EntradaPrevia == null)
                    {
                        MessageBox.Show("No se encuentra la entrada correspondiente a este transporte " + _mainData.Transporte.Matricula, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        View.HabilitarBotonesIdentificacion(true);                        
                        View.HabilitarBotoneraMantenimientos(true);
                        View.HabilitarAccionesIdentificacion(false);                       

                        MostrarProgresoIdentificacion("Entrada no encontrada");
                        _temporizadorLimpiaProgreso.Start();
                        _operando = false;

                        _business.ResetLecturaBascula();

                        return;
                    }

                }

                if (_mainData.Estado < (byte)Enums.TipoEstado.Correcto)
                {
                    //Si se producen los timeout
                    if (_mainData.Estado == (byte)Enums.TipoEstado.Inicial)
                    {
                        MessageBox.Show("El sistema de visión no respondió en el tiempo establecido. Posiblemente no esté funcionando", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);                        
                    }
                    else
                    {
                        MessageBox.Show("El sistema de visión no pudo realizar la identificación del transporte", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    View.HabilitarBotonesIdentificacion(true);
                    View.HabilitarBotoneraMantenimientos(true);
                    View.HabilitarAccionesIdentificacion(false);                    
                    _operando = false;
                    _business.ResetLecturaBascula();
                }
                else
                {
                    //Si la identificación fue correcta o fallida o sistema apagado
                    View.HabilitarAccionesIdentificacion(true);
                    ProcesarIdentificacion();
                    ProcesarPesada();
                    ComprobarHabilitarGuardar();
                }

                MostrarProgresoIdentificacion("Identificación finalizada");
                _temporizadorLimpiaProgreso.Start();
            }
            catch
            {
                MostrarProgresoIdentificacion("");
                View.HabilitarBotonesIdentificacion(true);                
                View.HabilitarBotoneraMantenimientos(true);
                View.HabilitarAccionesIdentificacion(false);
                _operando = false;
                _business.ResetLecturaBascula();

                throw new Exception("Se ha producido un error inesperado. Consulte el log para más información");
            }
        }

        public async void Guardar(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            try
            {

                EmpresaDto nuevoExpedidor = (EmpresaDto)View.Expedidor;

                //------------- Validaciones
                if (_mainData.Transporte.TipoCarga.Subproductos.Count > 0 && (int)View.TipoCarga == 0)
                {
                    MessageBox.Show("Debe seleccionar un tipo de carga", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    View.TipoCargaFocus();
                    return;
                }


                if (_mainData.Transporte.TipoOperacion.IdTipoOperacion == (byte)Enums.TipoOperacion.Descarga && nuevoExpedidor.Nombre == "" && _mainData.Transporte.TipoCarga.DenominacionAdr != null)
                {
                    MessageBox.Show("El tipo de carga implica indicar un expedidor", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    View.ExpedidorFocus();
                    return;
                }
                //-------------------------------------------------

                btn.Enabled = false;

                MainForm.Cursor = Cursors.WaitCursor;

                //Recuperar datos del formulario
                _mainData.Transporte.Conductor = View.Conductor;
                _mainData.Origen.Nombre = View.Origen;
                _mainData.Destino.Nombre = View.Destino;
                _mainData.Transporte.Expedidor = nuevoExpedidor;

                if (_mainData.Transporte.TipoCarga.Subproductos.Count > 0)
                {
                    _mainData.Transporte.TipoCarga = _mainData.Transporte.TipoCarga.Subproductos.Where(tc => tc.IdTipoCarga == (int)View.TipoCarga).Single();
                }

                if (_mainData.Tipo == (byte)Enums.TipoIdentificacion.Entrada)
                {

                    if (_business.Guardar(_mainData) != 0)
                    {                       
                        await _business.Eliminar(_mainData);
                        ReiniciarFormulario();
                        MessageBox.Show("Entrada guardada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        btn.Enabled = true;
                        MessageBox.Show("No se pudo guardar la entrada. Consulte el log para más información", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
                else
                {
                    var frm = _serviceProvider.GetRequiredService<frmValidacionSalida>();

                    frm.OperacionID = _mainData.EntradaPrevia.IdOperacion;
                    if (_mainData.Transporte.TipoOperacion.IdTipoOperacion == (byte)Enums.TipoOperacion.Carga)
                    {
                        frm.TituloPesoNeto = "Peso cargado";
                    }
                    else
                    {
                        frm.TituloPesoNeto = "Peso descargado";
                    }
                    frm.IdentificacionManual = _mainData.IdentificacionManual || _mainData.EntradaPrevia.MatriculaEntradaManual;
                    frm.Matricula = _mainData.Transporte.Matricula;
                    frm.Remolque = _mainData.Transporte.Remolque;
                    frm.PesoEntrada = _mainData.EntradaPrevia.PesoEntrada;
                    frm.HoraEntrada = _mainData.EntradaPrevia.FechaHoraEntrada.ToShortTimeString();
                    frm.PesoEntradaManual = _mainData.EntradaPrevia.PesoEntradaManual;
                    frm.PesoSalida = _mainData.Peso;
                    frm.HoraSalida = DateTime.Now.ToShortTimeString();
                    frm.PesoSalidaManual = _mainData.PesoManual;
                    int pesoNeto = Math.Abs(_mainData.EntradaPrevia.PesoEntrada - _mainData.Peso);
                    frm.PesoNeto = pesoNeto;
                    frm.TipoCarga = _mainData.Transporte.TipoCarga.Nombre;
                    frm.Origen = _mainData.Origen.Nombre;
                    frm.Destino = _mainData.Destino.Nombre;
                    frm.Expedidor = _mainData.Transporte.Expedidor.Nombre;
                    frm.Operario = _usuarioSesion.Nombre;
                    frm.Transportista = _mainData.Transporte.Conductor;

                    var resultado = frm.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        if (_mainData.Transporte.TipoOperacion.IdTipoOperacion == (byte)Enums.TipoOperacion.Carga)
                        {
                            var localizacionDestino = _listaLocalizaciones.Find(l => l.Nombre.Equals(_mainData.Destino.Nombre));
                            if(localizacionDestino != null)
                            {
                                _mainData.Destino = localizacionDestino;
                            }                           
                        }
                        else
                        {
                            var localizacionOrigen = _listaLocalizaciones.Find(l => l.Nombre.Equals(_mainData.Origen.Nombre));
                            if (localizacionOrigen != null)
                            {
                                _mainData.Origen = localizacionOrigen;
                            }                            
                        }

                        _mainData.FirmaProductorImagen = frm.FirmaOperario;
                        _mainData.FirmaConductorImagen = frm.FirmaTransportista;

                        int idOperacion = _business.Guardar(_mainData);

                        if (idOperacion != 0)
                        {
                            //Lanzamos la impresión
                            MainForm.Cursor = Cursors.WaitCursor;

                            string rutaGuardadoAlbaranes = _config.GetSection("RutaGuardadoAlbaranes").Value;
                            if (!rutaGuardadoAlbaranes.EndsWith(@"\"))
                            {
                                rutaGuardadoAlbaranes = rutaGuardadoAlbaranes + @"\";
                            }

                            //Ejecutamos las tareas relacionadas con el albarán en formato pdf
                            var pdfBytesAlbaran = await _business.ObtenerAlbaran(idOperacion);

                            if (pdfBytesAlbaran != null)
                            {
                                var subTareasAlbaran = new List<Task>();                                

                                string nombreArchivo = string.Format("Operacion_{0}.pdf", idOperacion);

                                //Tarea para guardar el PDF en su carpeta configurada
                                Task tareaGuardarPDF = Task.Run(() => {

                                    //Guardamos el albarán en su carpeta
                                    File.WriteAllBytes(string.Format("{0}{1}", rutaGuardadoAlbaranes, nombreArchivo), pdfBytesAlbaran);

                                });
                                subTareasAlbaran.Add(tareaGuardarPDF);

                                //Esperamos a obtener la lista de emails para que colisione con cualquier otra operación del dbcontext
                                Dictionary<string, string> contactos = await _business.ObtenerListaEmails(idOperacion);

                                if (contactos.Count > 0)
                                {
                                    //Tarea para el envio del PDF por email
                                    Task tareaEnvioEmails = _clienteSMTP.EnviarAlbaran(nombreArchivo, pdfBytesAlbaran, contactos).ContinueWith(resultado =>
                                    {
                                        if (resultado.Status != TaskStatus.RanToCompletion || !resultado.Result)
                                        {
                                            ShowToast("Error al enviar el correo electrónico. Consulte el log para más detallles", frmMessage.enmType.Error);
                                        }
                                    });
                                    subTareasAlbaran.Add(tareaEnvioEmails);
                                }
                                else
                                {
                                    ShowToast("No existen contactos a los que enviar el albarán", frmMessage.enmType.Warning);
                                }

                                //Tarea para imprimir el PDF 
                                Task tareaImprimirPDF = Task.Run(() => {

                                    if (_printerName != null)
                                    {
                                        try
                                        {
                                            MemoryStream stream = new MemoryStream(pdfBytesAlbaran);
                                            _pdfPrinterService.Print(stream, _printerName);
                                        }
                                        catch
                                        {
                                            ShowToast("Error al imprimir el albarán. Consulte el log para más detallles", frmMessage.enmType.Error);
                                        }
                                    }

                                });
                                subTareasAlbaran.Add(tareaImprimirPDF);

                                //Esperamos a que finalicen todas las subtareas relacionadas con albarán
                                await Task.WhenAll(subTareasAlbaran);

                            }
                            else
                            {
                                ShowToast("Error al generar el albarán. Revise el log para mas detalles", frmMessage.enmType.Error);
                            }

                            //Ejecutamos las tareas relacionadas con la carta de porte en formato pdf
                            var pdfBytesCarta = await _business.ObtenerCartaPorte(idOperacion);

                            if (pdfBytesCarta != null) {

                                if (pdfBytesCarta.Length > 0)
                                {

                                    var subTareasCarta = new List<Task>();

                                    string nombreArchivoCarta = string.Format("CartaPorte_{0}.pdf", idOperacion);

                                    //Tarea para guardar el PDF en su carpeta configurada
                                    Task tareaGuardarPDFCarta = Task.Run(() =>
                                    {
                                        //Guardamos el albarán en su carpeta
                                        File.WriteAllBytes(string.Format("{0}{1}", rutaGuardadoAlbaranes, nombreArchivoCarta), pdfBytesCarta);

                                    });

                                    subTareasCarta.Add(tareaGuardarPDFCarta);

                                    //Tarea para imprimir el PDF 
                                    Task tareaImprimirPDFCarta = Task.Run(() =>
                                    {

                                        if (_printerName != null)
                                        {
                                            try
                                            {
                                                MemoryStream stream = new MemoryStream(pdfBytesCarta);
                                                _pdfPrinterService.Print(stream, _printerName);
                                            }
                                            catch
                                            {
                                                ShowToast("Error al imprimir la carta de porte. Consulte el log para más detallles", frmMessage.enmType.Error);
                                            }
                                        }

                                    });

                                    subTareasCarta.Add(tareaImprimirPDFCarta);

                                    //Esperamos a que finalicen todas las subtareas
                                    await Task.WhenAll(subTareasCarta);
                                }

                            } 
                            else
                            {
                                ShowToast("Error al generar la carta de porte. Revise el log para mas detalles", frmMessage.enmType.Error);
                            }

                            //Ejecutamos la tarea de escribir en el PLC la información del albarán
                            var datos = await _business.ObtenerDatosAlbaran(idOperacion);

                            if(datos.Rows.Count > 0)
                            {
                                var resultadoPLC = await _plcService.EscribirAlbaran(datos);
                                if (!resultadoPLC)
                                {
                                    ShowToast("Error al enviar datos al PLC. Consulte el log para más detallles", frmMessage.enmType.Error);
                                }
                            }
                            else
                            {
                                ShowToast("Error al obtener los datos del albarán. Revise el log para mas detalles", frmMessage.enmType.Error);
                            }

                                                                              
                            //Ejecutamos la tarea de eliminar el registro del sistema de visión
                            await _business.Eliminar(_mainData);

                            ReiniciarFormulario();

                            MainForm.Cursor = Cursors.Default;
                            
                            MessageBox.Show("Salida guardada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            btn.Enabled = true;
                            MessageBox.Show("No se pudo guardar la salida. Consulte el log para más información", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        btn.Enabled = true;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn.Enabled = true;
            }
            finally
            {
                MainForm.Cursor = Cursors.Default;
            }
        }
               
        private void ProcesarIdentificacion()
        {
            if (_mainData.Estado != (byte)Enums.TipoEstado.SistemaApagado)
            {

                View.Matricula = _mainData.Transporte.Matricula;
                View.Remolque = _mainData.Transporte.Remolque;

                if (File.Exists(_mainData.Camara1Path))
                {
                    View.Camara1 = _mainData.Camara1Path;
                }
                if (File.Exists(_mainData.Camara2Path))
                {
                    View.Camara2 = _mainData.Camara2Path;
                }
                if (File.Exists(_mainData.Camara3Path))
                {
                    View.Camara3 = _mainData.Camara3Path;
                }

            }
            else
            {
                View.IdentificacionIncorrecta();
            }            

            if (_mainData.Estado == (byte)Enums.TipoEstado.Fallo)
            {
                View.IdentificacionIncorrecta();
                MessageBox.Show("El sistema de visión no identificó de forma correcta al transporte. Proceda a introducir de forma manual la matrícula", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (_mainData.TransporteReconocido)
                {
                    if(_mainData.Estado > (byte)Enums.TipoEstado.Correcto)
                    {                        
                        ShowToast("Revisar matrícula de remolque", frmMessage.enmType.Warning);
                    }

                    MostrarDatosFormularioIdentificacion();
                }
                else
                {
                    View.LimpiarFormularioIdentificacion();
                    View.HabilitarFormularioIdentificacion(false);
                }
            }                
                      
        }

        private void ProcesarPesada()
        {
            if (_mainData.PesoCorrecto)
            {
                View.Peso = _mainData.Peso;
            }
            else
            {
                View.PesadaIncorrecta();
                MessageBox.Show("Pesaje incorrecto. Proceda a introducir de forma manual el peso", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        public async void Reiniciar()
        {
            await _business.Eliminar(_mainData);
            ReiniciarFormulario();
        }

        private void ComprobarHabilitarGuardar()
        {
            //Identificacion
            bool habilitar = _mainData.TransporteReconocido;

            //Pesaje
            habilitar = habilitar && (_mainData.PesoCorrecto || (_mainData.PesoManual && _mainData.MotivoPesoManual != ""));
            
            View.HabilitarGuardar(habilitar);            
        }

        private void ReiniciarFormulario()
        {
            View.LimpiarFormulario();
            View.HabilitarBotoneraMantenimientos(true);
            View.HabilitarBotonesIdentificacion(true);                           
            View.HabilitarAccionesIdentificacion(false);
            View.HabilitarFormularioIdentificacion(false);
            View.HabilitarGuardar(false);            
            _operando = false;
            _business.ResetLecturaBascula();
        }

        private void MostrarDatosFormularioIdentificacion()
        {
            View.Empresa = _mainData.Transporte.Empresa.Nombre;
            View.Conductor = _mainData.Transporte.Conductor;
            CargarComboTiposCarga();
            if (_mainData.Tipo == (byte)Enums.TipoIdentificacion.Salida)               
            {
                View.TipoCarga = _mainData.EntradaPrevia.IdTipoCarga;
            }

            View.Expedidor = (_mainData.Transporte.Expedidor == null ? 0 :_mainData.Transporte.Expedidor.IdEmpresa);

            ConfigurarComboOrigenes();
            ConfigurarComboDestinos();                

            View.Origen = _mainData.Origen.Nombre;
            View.Destino = _mainData.Destino.Nombre;           

            View.HabilitarFormularioIdentificacion(true);
        }

        public void IdentificacionManual()
        {
            var frm = _serviceProvider.GetRequiredService<frmIdentificacionManual>();

            frm.Matricula = _mainData.Transporte.Matricula;
            frm.Remolque = _mainData.Transporte.Remolque;
            frm.Motivo = _mainData.MotivoIdentificacionManual;

            var resultado = frm.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                _mainData.Transporte.Matricula = String.Concat(frm.Matricula.Where(c => !Char.IsWhiteSpace(c)));
                _mainData.Transporte.Remolque = String.Concat(frm.Remolque.Where(c => !Char.IsWhiteSpace(c)));
                _mainData.IdentificacionManual = true;
                _mainData.MotivoIdentificacionManual = frm.Motivo.Trim();            

                View.Matricula = _mainData.Transporte.Matricula;
                View.Remolque = _mainData.Transporte.Remolque;

                try
                {
                    var datosNuevaIdentificacion = _business.IdentificacionManualTransporte(_mainData.Tipo, _mainData.Transporte.Matricula);

                    if(datosNuevaIdentificacion != null)
                    {
                        _mainData.TransporteReconocido = datosNuevaIdentificacion.TransporteReconocido;

                        if (_mainData.TransporteReconocido)
                        {
                            _mainData.Transporte = datosNuevaIdentificacion.Transporte;

                            //Prevalece el que se hay introducido en el formulario
                            _mainData.Transporte.Remolque = String.Concat(frm.Remolque.Where(c => !Char.IsWhiteSpace(c))); 

                            _mainData.Origen = datosNuevaIdentificacion.Origen;
                            _mainData.Destino = datosNuevaIdentificacion.Destino;

                            _mainData.EntradaPrevia = datosNuevaIdentificacion.EntradaPrevia;

                            MostrarDatosFormularioIdentificacion();
                        }
                        else
                        {
                            View.LimpiarFormularioIdentificacion();
                            View.HabilitarFormularioIdentificacion(false);
                        }
                    }
                    else
                    {
                        if (_mainData.Tipo == (byte)Enums.TipoIdentificacion.Entrada)
                        {
                            MessageBox.Show("No se encuentra el transporte según la matrícula indicada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("No se encuentra la entrada correspondiente a este transporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }                           
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    ComprobarHabilitarGuardar();
                }
                
            }            
        }

        public void PesoManual()
        {
            var frm = _serviceProvider.GetRequiredService<frmPesoManual>();

            frm.Peso = _mainData.Peso.ToString();
            frm.Motivo = _mainData.MotivoPesoManual;

            var resultado = frm.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                int peso;
                bool pesoCorrecto = int.TryParse(frm.Peso.Trim(), out peso);

                if (pesoCorrecto)
                {
                    _mainData.Peso = peso;
                    _mainData.PesoManual = true;
                    _mainData.MotivoPesoManual = frm.Motivo.Trim();

                    View.Peso = peso;                    
                }

                ComprobarHabilitarGuardar();
            }            
        }

        public void AmpliarFotoCamara1(object sender, EventArgs e)
        {
            if(((PictureBox)sender).ImageLocation == null)
            {
                return;
            }

            var frm = _serviceProvider.GetRequiredService<frmPicture>();

            frm.Titulo = "Cámara 1";
            frm.Path = ((PictureBox)sender).ImageLocation;

            frm.ShowDialog();
        }

        public void AmpliarFotoCamara2(object sender, EventArgs e)
        {
            if (((PictureBox)sender).ImageLocation == null)
            {
                return;
            }

            var frm = _serviceProvider.GetRequiredService<frmPicture>();

            frm.Titulo = "Cámara 2";
            frm.Path = ((PictureBox)sender).ImageLocation;

            frm.ShowDialog();
        }

        public void AmpliarFotoCamara3(object sender, EventArgs e)
        {
            if (((PictureBox)sender).ImageLocation == null)
            {
                return;
            }

            var frm = _serviceProvider.GetRequiredService<frmPicture>();

            frm.Titulo = "Cámara 3";
            frm.Path = ((PictureBox)sender).ImageLocation;

            frm.ShowDialog();
        }

        public void CapturaPantalla()
        {
            try
            {
                //obtenemos la resolución de pantalla
                Rectangle tamanioFormulario = Screen.GetBounds(MainForm.ClientRectangle);

                //creamos un Bitmap del tamaño de nuestra pantalla
                Bitmap objBitmap = new Bitmap(tamanioFormulario.Width, tamanioFormulario.Height);

                //creamos el gráifco en base al Bitmap objBitmap 
                Graphics objGrafico = Graphics.FromImage(objBitmap);

                //transferimos la captura al objeto objGrafico en 
                //base a las medidas del bitmap
                objGrafico.CopyFromScreen(0, 0, 0, 0, objBitmap.Size);

                //liberamos el gráfico de memoria                            
                objGrafico.Flush();

                string defaultName = string.Format("Captura_{0}.jpg", DateTime.Now.ToString("yyyyMMddHHmmss"));

                SaveFileDialog saveCaptura = new SaveFileDialog();
                saveCaptura.Filter = "Archivo Jpeg|*.jpg";
                saveCaptura.Title = "Guardar captura como...";
                saveCaptura.DefaultExt = "jpg";
                saveCaptura.FileName = defaultName;
                if (saveCaptura.ShowDialog() == DialogResult.OK)
                {
                    string nombreArchivo = saveCaptura.FileName;
                    if (nombreArchivo != "")
                    {
                        objBitmap.Save(nombreArchivo);
                    }
                }

            }
            catch
            {

            }
            
        }

        public int PesoReal()
        {          
            return _business.ObtenerPesoReal();
        }

        public int PesoEstable()
        {
            return _business.ComprobarPesoEstable();
        }

    }


    public interface IPresentMainForm : IPresent
    {
        frmMain MainForm { get; }

        void InicializarFormulario();

        void ConfigurarComboExpedidores(ComboBox cmb);

        void ConfigurarComboTipoCargas(ComboBox cmb);

        void MostrarAdvertenciasSistemasExternos();

        void EstablecerPermisosAdmin();

        void EstablecerFechaHora();

        void EstablecerOperario();

        void SalirAplicacion();

        void CambiarUsuario();

        void CambiarClave();

        void GestionUsuarios();

        void GestionLocalizaciones();

        void GestionEmpresas();

        void GestionTipoCargas();

        void GestionContactos();

        void GestionTransportes();

        void GestionOperaciones();
        
        Task NuevaEntrada(object sender, EventArgs e);

        Task NuevaSalida(object sender, EventArgs e);

        void Guardar(object sender, EventArgs e);

        void Reiniciar();

        void IdentificacionManual();

        void PesoManual();

        void AmpliarFotoCamara1(object sender, EventArgs e);

        void AmpliarFotoCamara2(object sender, EventArgs e);

        void AmpliarFotoCamara3(object sender, EventArgs e);

        void CapturaPantalla();

        int PesoReal();

        int PesoEstable();
        
    }
}
