using System;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;

using System.IO;
using System.IO.Ports;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Go.ALPR.Sri.Business;
//using Go.ALPR.Sri.Signature;

using NLog.Windows.Forms;

namespace Go.ALPR.Sri.Tests
{   
    public partial class frmMain : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _config;
        private readonly ILogger<frmMain> _logger;
        private readonly IMainFormBusiness _business;
        private readonly IOperacionService _service;

        //private readonly ISignatureService _signature;

        //SerialPort PuertoLectura = null;

        //private delegate void SetTextDeleg(string text);

        public frmMain(IServiceProvider serviceProvider, ILogger<frmMain> logger, IConfiguration configuration, IMainFormBusiness business, IOperacionService service
            
            //, ISignatureService signature
            )
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _logger = logger;
            _business = business;
            _service = service;
            _config = configuration;
            //_signature = signature;

            RichTextBoxTarget.ReInitializeAllTextboxes(this);

            //PuertoLectura = new SerialPort();

            //if (!PuertoLectura.IsOpen)
            //{
            //    PuertoLectura.PortName = "COM3";
            //    PuertoLectura.BaudRate = 9600;
            //    PuertoLectura.Parity = Parity.None;
            //    PuertoLectura.DataBits = 8;
            //    PuertoLectura.StopBits = StopBits.One;
            //    PuertoLectura.Open();
            //}
            //if (PuertoLectura.IsOpen)
            //{
            //    //Esperar la respuesta de la básccula con la lectura del peso
            //    PuertoLectura.DataReceived += new SerialDataReceivedEventHandler(PuertoLectura_DataReceived);
            //}

            try
            {
                _business.ConfigurarBascula();
            }
            catch
            {
                MessageBox.Show("Error al configurar la báscula. Cosulte el log para mas detalles");
                btnBascula.Enabled = !_business.BasculaOffline();
            }


           // btnFirma.Enabled = _signature.IsSignaturePadConnected();

        }

        //private void PuertoLectura_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{

        //    //Thread.Sleep(500);

        //    _logger.LogInformation("Lectura en el puerto COM3 del tipo: " + e.EventType.ToString());

        //    string data = PuertoLectura.ReadExisting();

        //    this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });
        //}

        //private void si_DataReceived(string data) { 
        //    lblPeso.Text = data.Trim(); 
        //}

        #region "Identificación"
        private async void btnEntrada_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            try
            {
                btn.Enabled = false;

                Cursor = Cursors.WaitCursor;

                LimpiarPantalla();

                var indicadorProgreso = new Progress<string>(MostrarProgresoIdentificacion);

                var data = await _business.NuevaEntrada(indicadorProgreso);

                if (data != null)
                {
                    ////ÑÑÑ//////////////lblCamion.Text = data.Matricula;
                    ////ÑÑÑ//////////////lblRemolque.Text = data.Remolque;

                    if (data.Estado > 10)
                    {
                        picCamara1.ImageLocation = data.Camara1Path;
                        picCamara2.ImageLocation = data.Camara2Path;
                        picCamara3.ImageLocation = data.Camara3Path;
                        picCamara1.Load();
                        picCamara2.Load();
                        picCamara3.Load();

                        if (data.Estado == 30)
                        {
                            MessageBox.Show("El sistema de visión no identificó de forma correcta al vehículo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        if (data.Estado == 0)
                        {
                            MessageBox.Show("El sistema de visión no respondió en el tiempo establecido. Posiblemente no esté funcionando.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("El sistema de visión no pudo realizar la identificación del vehículo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btn.Enabled = true;
            }
        }

        private async void btnSalida_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            try
            {
                btn.Enabled = false;

                Cursor = Cursors.WaitCursor;

                LimpiarPantalla();

                var indicadorProgreso = new Progress<string>(MostrarProgresoIdentificacion);

                var data = await _business.NuevaSalida(indicadorProgreso);

                if (data != null)
                {
                    ////ÑÑÑ//////////////lblCamion.Text = data.Matricula;
                    ////ÑÑÑ//////////////lblRemolque.Text = data.Remolque;

                    if (data.Estado> 10)
                    {
                        picCamara1.ImageLocation = data.Camara1Path;
                        picCamara2.ImageLocation = data.Camara2Path;
                        picCamara3.ImageLocation = data.Camara3Path;
                        picCamara1.Load();
                        picCamara2.Load();
                        picCamara3.Load();

                        if (data.Estado == 30)
                        {
                            MessageBox.Show("El sistema de visión no identificó de forma correcta al vehículo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        if (data.Estado == 0)
                        {
                            MessageBox.Show("El sistema de visión no respondió en el tiempo establecido. Posiblemente no esté funcionando.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("El sistema de visión no pudo realizar la identificación del vehículo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btn.Enabled = true;
            }
        }

        private void MostrarProgresoIdentificacion(string progreso)
        {
            
        }

        private void LimpiarPantalla()
        {
            lblCamion.Text = "";
            lblRemolque.Text = "";

            picCamara1.ImageLocation = null;
            picCamara2.ImageLocation = null;
            picCamara3.ImageLocation = null;
        }

        private void picCamara1_Click(object sender, EventArgs e)
        {
            var frmViewer = new frmPicture();

            frmViewer.Titulo = "Cámara 1";
            frmViewer.Path = ((PictureBox)sender).ImageLocation;

            frmViewer.ShowDialog(this);
        }

        private void picCamara1_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void picCamara1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void picCamara2_Click(object sender, EventArgs e)
        {
            var frmViewer = new frmPicture();

            frmViewer.Titulo = "Cámara 2";
            frmViewer.Path = ((PictureBox)sender).ImageLocation;

            frmViewer.ShowDialog(this);
        }

        private void picCamara2_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void picCamara2_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void picCamara3_Click(object sender, EventArgs e)
        {
            var frmViewer = new frmPicture();

            frmViewer.Titulo = "Cámara 3";
            frmViewer.Path = ((PictureBox)sender).ImageLocation;

            frmViewer.ShowDialog(this);
        }

        private void picCamara3_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void picCamara3_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }



        #endregion


        private void btnBascula_Click(object sender, EventArgs e)
        {

            //if (PuertoLectura.IsOpen)
            //{
            //    PuertoLectura.Close();
            //}

            Button btn = (Button)sender;

            try
            {
                btn.Enabled = false;

                Cursor = Cursors.WaitCursor;

                lblPeso.Text = _business.ObtenerLecturaBascula();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btn.Enabled = true;
            }
        }

        private void btnEnviarPeso_Click(object sender, EventArgs e)
        {
            SerialPort MyCOMPort = new SerialPort();

            string[] AvailablePorts = SerialPort.GetPortNames();

            //_logger.LogInformation("Puertos disponibles: ");

            //foreach (string port in AvailablePorts){
            //    _logger.LogInformation(port);
            //}

            MyCOMPort.PortName = "COM2";
            MyCOMPort.BaudRate = 9600;
            MyCOMPort.Parity = Parity.None;
            MyCOMPort.DataBits = 8;
            MyCOMPort.StopBits = StopBits.One;
            MyCOMPort.Open();
            MyCOMPort.Write(txtPeso.Text);            
            MyCOMPort.Close();

            _logger.LogInformation("Se ha escrito en el puerto COM2");
        }

        private async void btnImprimirAlbaran_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            //int idOperacion = 1006;

            //await _service.ObtenerAlbaran(idOperacion).ContinueWith(generacion =>
            //{
            //    if (generacion.Result != null)
            //    {
            //        string rutaGuardadoAlbaranes = _config.GetSection("RutaGuardadoAlbaranes").Value;
            //        if (!rutaGuardadoAlbaranes.EndsWith(@"\"))
            //        {
            //            rutaGuardadoAlbaranes = rutaGuardadoAlbaranes + @"\";
            //        }
            //        string nombreArchivo = string.Format("{0}Albaran_{1}_{2}.pdf", rutaGuardadoAlbaranes, idOperacion, DateTime.Now.ToString("yyyyMMddHHmmss"));

            //        File.WriteAllBytes(nombreArchivo, generacion.Result);

            //        //MemoryStream stream = new MemoryStream(generacion.Result);
            //        //_printerService.Print(stream, _printerName);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Error al generar el albarán. Revise el log para mas detalles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //});

            Cursor = Cursors.Default;
        }

        private void btnFirma_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Stream result = _signature.CaputurarFirma("José Félix Martínez Francos", "Confirmación salida de transporte", 1066);

            //    if (result != null)
            //    {
            //        picFirma.Image = System.Drawing.Image.FromStream(result);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error" + ex.Message);
            //}

        }

        private void btnMessageTest_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<frmMessage>();
            frm.showAlert("Error alsdfj alskfjasd", frmMessage.enmType.Warning);
        }
    }
}
