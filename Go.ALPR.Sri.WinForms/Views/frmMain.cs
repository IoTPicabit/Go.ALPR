using System;
using System.ComponentModel;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using MiniMVPNetCore;
using LibVLCSharp.Shared;


namespace Go.ALPR.Sri.WinForms
{
    public partial class frmMain : MainFormDesignable, IViewMainForm, IMainForm
    {
        private readonly SpanishPlateFont spf;

        private LibVLC _libVLC;
        private MediaPlayer _mpCamara1;
        private MediaPlayer _mpCamara2;
        private MediaPlayer _mpCamara3;


        public frmMain(SpanishPlateFont spanishPlateFont)
        {
            InitializeComponent();
            Core.Initialize();

            _libVLC = new LibVLC();

            _mpCamara1 = new MediaPlayer(_libVLC);
            vvCamara1.MediaPlayer = _mpCamara1;

            _mpCamara2 = new MediaPlayer(_libVLC);
            vvCamara2.MediaPlayer = _mpCamara2;

            _mpCamara3 = new MediaPlayer(_libVLC);
            vvCamara3.MediaPlayer = _mpCamara3;

            this.spf = spanishPlateFont;

            lblMatricula.Font = new Font(this.spf.GetFontFamily(), lblMatricula.Font.Size);
            lblRemolque.Font = new Font(this.spf.GetFontFamily(), lblRemolque.Font.Size);
            lblRemolque.BackColor = ColorTranslator.FromHtml("#F03E46");
        }

        public override void Bind(IPresentMainForm presenter)
        {
            base.Bind(presenter);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Presenter.EstablecerPermisosAdmin();            
            timerHora.Start();
            Presenter.EstablecerOperario();
            Presenter.InicializarFormulario();
            Presenter.ConfigurarComboTipoCargas(cmbTipoCarga);
            Presenter.ConfigurarComboExpedidores(cmbExpedidor);
            Activate();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == NativeMethods.WM_SHOWME)
            {
                ShowMe();
            }
            base.WndProc(ref m);
        }

        private void ShowMe()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            // get our current "TopMost" value (ours will always be false though)
            bool top = TopMost;
            // make our form jump to the top of everything
            TopMost = true;
            // set it back to whatever it was
            TopMost = top;
        }

        public bool EsAdmin
        {
            set
            {
                btnUsuarios.Visible = value;
                //btnLocalizaciones.Visible = value;
            }
        }

        public string Fecha
        {
            set
            {                
                lblFecha.Text = value;
            }
        }

        public string Hora
        {
            set
            {
                lblHora.Text = value;
            }
        }

        public string Operario
        {
            set
            {
                lblOperario.Text = value;
            }
        }

        public string Matricula
        {
            get
            {
                return lblMatricula.Text;
            }
            set
            {
                lblMatricula.Text = value;
            }
        }

        public string Remolque
        {
            get
            {
                return lblRemolque.Text;
            }
            set
            {
                lblRemolque.Text = value;
            }
        }

        public int Peso
        {
            get
            {
                return (int)lblPeso.Tag;
            }
            set
            {
                lblPeso.Tag = value; //Guardamos en el tag el valor entero
                lblPeso.Text = value.ToString("##,0");
            }
        }        

        public string Empresa
        {           
            set
            {               
                lblEmpresa.Text = value;
            }
        }

        public string Conductor
        {
            get
            {
                return txtConductor.Text;
            }
            set
            {
                txtConductor.Text = value;
            }
        }

        public object TipoCarga
        {
            get
            {
                return cmbTipoCarga.SelectedValue;
            }
            set
            {
                cmbTipoCarga.SelectedValue = value;
            }
        }
        
        public string Origen
        {
            get
            {
                return cmbOrigen.Text;
            }
            set
            {
                int index = cmbOrigen.FindString(value);
                if (index != -1)
                {
                    cmbOrigen.SelectedIndex = index;
                }
                else
                {
                    cmbOrigen.Text = value;
                }
            }
        }

        public string Destino
        {
            get
            {
                return cmbDestino.Text;
            }
            set
            {
                int index = cmbDestino.FindString(value);
                if (index != -1)
                {
                    cmbDestino.SelectedIndex = index;
                }
                else
                {
                    cmbDestino.Text = value;
                }
            }
        }

        public object Expedidor
        {
            get
            {
                return cmbExpedidor.SelectedItem;
            }
            set
            {
                cmbExpedidor.SelectedValue = value;
            }
        }        

        public string Camara1
        {            
            set
            {
                picCamara1.ImageLocation = value;
                if (value != null)
                {
                    picCamara1.Cursor = Cursors.Hand;
                    picCamara1.Load();
                }
                else
                {
                    picCamara1.Cursor = Cursors.Default;
                }                
            }
        }

        public string Camara2
        {
            set
            {
                picCamara2.ImageLocation = value;
                if (value != null)
                {
                    picCamara2.Cursor = Cursors.Hand;
                    picCamara2.Load();
                }
                else
                {
                    picCamara2.Cursor = Cursors.Default;
                }
            }
        }

        public string Camara3
        {
            set
            {
                picCamara3.ImageLocation = value;
                if (value != null)
                {
                    picCamara3.Cursor = Cursors.Hand;
                    picCamara3.Load();
                }
                else
                {
                    picCamara3.Cursor = Cursors.Default;
                }
            }
        }

        public string ProgresoIdentificacion
        {
            set
            {
                lblIndentificacionProgreso.Text = value;
            }
        }


        private void btnIdentificacionManual_Click(object sender, EventArgs e)
        {
            Presenter.IdentificacionManual();
        }

        private void btnPesoManual_Click(object sender, EventArgs e)
        {
            Presenter.PesoManual();
        }

        private void timerHora_Tick(object sender, EventArgs e)
        {            
            Presenter.EstablecerFechaHora();
        }
                
        private async void btnNuevaEntrada_Click(object sender, EventArgs e)
        {
            await Presenter.NuevaEntrada(sender, e);
        }

        private async void btnNuevaSalida_Click(object sender, EventArgs e)
        {
            await Presenter.NuevaSalida(sender, e);
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            Presenter.Reiniciar();
        }        

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Presenter.Guardar(sender, e);
        }                      

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Presenter.SalirAplicacion();
        }

        private void btnCambiarUsuario_Click(object sender, EventArgs e)
        {
            Presenter.CambiarUsuario();
        }

        private void btnCambiarClave_Click(object sender, EventArgs e)
        {
            Presenter.CambiarClave();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Presenter.GestionUsuarios();
        }

        private void btnOrigenes_Click(object sender, EventArgs e)
        {
            Presenter.GestionLocalizaciones();
        }

        private void btnEmpresas_Click(object sender, EventArgs e)
        {
            Presenter.GestionEmpresas();
        }

        private void btnResiduos_Click(object sender, EventArgs e)
        {
            Presenter.GestionTipoCargas();
        }

        private void btnContactos_Click(object sender, EventArgs e)
        {
            Presenter.GestionContactos();
        }

        private void btnTransportes_Click(object sender, EventArgs e)
        {
            Presenter.GestionTransportes();
        }

        private void btnOperaciones_Click(object sender, EventArgs e)
        {
            Presenter.GestionOperaciones();
        }
                
        public void LimpiarFormulario()
        {
            lblMatricula.Text = "";
            lblRemolque.Text = "";
            lblPeso.Text = "";
            LimpiarFormularioIdentificacion();
            Camara1 = null;
            Camara2 = null;
            Camara3 = null;           
        }

        public void LimpiarFormularioIdentificacion() 
        {
            lblEmpresa.Text = "";
            txtConductor.Text = "";
            cmbOrigen.SelectedIndex = -1;
            cmbOrigen.Text = "";
            cmbOrigen.DropDownStyle = ComboBoxStyle.DropDown;
            cmbDestino.SelectedIndex = -1;
            cmbDestino.Text = "";
            cmbDestino.DropDownStyle = ComboBoxStyle.DropDown;
            cmbExpedidor.SelectedValue = 0;
            cmbTipoCarga.SelectedIndex = -1;
        }

        public void ExpedidorFocus()
        {
            cmbExpedidor.Focus();
        }

        public void TipoCargaFocus()
        {
            cmbTipoCarga.Focus();
        }


        public void HabilitarBotoneraMantenimientos(bool enabled)
        {
            btnOperaciones.Enabled = enabled;
            btnTransportes.Enabled = enabled;
            btnTipoCargas.Enabled = enabled;
            btnEmpresas.Enabled = enabled;
            btnLocalizaciones.Enabled = enabled;
            btnUsuarios.Enabled = enabled;
            btnCambiarClave.Enabled = enabled;
            btnCambiarUsuario.Enabled = enabled;           
        }

        public void HabilitarBotonesIdentificacion(bool enabled)
        {            
            btnNuevaEntrada.Enabled = enabled;            
            btnNuevaSalida.Enabled = enabled;
            if (enabled)
            {
                btnNuevaEntrada.UseVisualStyleBackColor = true;
                btnNuevaSalida.UseVisualStyleBackColor = true;
            }
        }

        public void HabilitarAccionesIdentificacion(bool enabled)
        {             
            btnIdentificacionManual.Enabled = enabled;
            btnPesoManual.Enabled = enabled;
            btnReiniciar.Enabled = enabled;
            if (!enabled)
            {
                if (!btnIdentificacionManual.UseVisualStyleBackColor)
                {
                    btnIdentificacionManual.BackColor = (Color)btnIdentificacionManual.Tag;
                    btnIdentificacionManual.UseVisualStyleBackColor = true;
                }
                if (!btnPesoManual.UseVisualStyleBackColor)
                {
                    btnPesoManual.BackColor = (Color)btnPesoManual.Tag;
                    btnPesoManual.UseVisualStyleBackColor = true;
                }                
            }
        }

        public void HabilitarFormularioIdentificacion(bool enabled)
        {            
            txtConductor.Enabled = enabled;
            cmbOrigen.Enabled = enabled;
            cmbDestino.Enabled = enabled;
            
            if(enabled && cmbTipoCarga.Items.Count > 1)
            {
                cmbTipoCarga.Enabled = true;
            }
            else
            {
                cmbTipoCarga.Enabled = false;
            }
        }              

        public void IdentificacionIncorrecta()
        {
            btnIdentificacionManual.Tag = btnIdentificacionManual.BackColor;
            btnIdentificacionManual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));        
        }

        public void PesadaIncorrecta()
        {
            btnPesoManual.Tag = btnPesoManual.BackColor;
            btnPesoManual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));           
        }

        public void HabilitarGuardar(bool enabled)
        {
            btnGuardar.Enabled = enabled;
        }             

        public void CargarComboOrigenes(string[] data, bool fijar)
        {
            cmbOrigen.Items.Clear();
            cmbOrigen.Items.AddRange(data);
            if (fijar)
            {                
                cmbOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        public void CargarComboDestinos(string[] data, bool fijar)
        {
            cmbDestino.Items.Clear();
            cmbDestino.Items.AddRange(data);
            if (fijar)
            {                
                cmbDestino.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void picCamara1_Click(object sender, EventArgs e)
        {
            Presenter.AmpliarFotoCamara1(sender, e);
        }

        private void picCamara2_Click(object sender, EventArgs e)
        {
            Presenter.AmpliarFotoCamara2(sender, e);
        }

        private void picCamara3_Click(object sender, EventArgs e)
        {
            Presenter.AmpliarFotoCamara3(sender, e);
        }

        public void IniciarCamara1(string url)
        {
            _mpCamara1.Play(new Media(_libVLC, url, FromType.FromLocation));
        }

        public void IniciarCamara2(string url)
        {
            _mpCamara2.Play(new Media(_libVLC, url, FromType.FromLocation));
        }

        public void IniciarCamara3(string url)
        {
            _mpCamara3.Play(new Media(_libVLC, url, FromType.FromLocation));
        }

        private void btnCaptura_Click(object sender, EventArgs e)
        {
            Presenter.CapturaPantalla();
        }              

        private void frmMain_Shown(object sender, EventArgs e)
        {
            Presenter.MostrarAdvertenciasSistemasExternos();
        }
        public void IniciarLecturaPeso()
        {
            bgwPesoRealTime.RunWorkerAsync();
            bgwControlEstabilidad.RunWorkerAsync();            
        }
               
        private void bgwPesoRealTime_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (true)
                {
                    bgwPesoRealTime.ReportProgress(Presenter.PesoReal());
                    Thread.Sleep(200); //Obtenemos el peso continuamente
                }
            }
            catch
            {

            }                     
        }

        private void bgwPesoRealTime_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblPesoRealTime.Text = e.ProgressPercentage.ToString("##,0");
        }                
        
        private void bgwControlEstabilidad_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (true)
                {
                    bgwControlEstabilidad.ReportProgress(Presenter.PesoEstable());
                    Thread.Sleep(1000); // Comprobamos si es estable cada 1 segundo
                }
            }
            catch
            {


            }            
        }

        private void bgwControlEstabilidad_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(e.ProgressPercentage == 1)
            {
                lblPesoRealTime.ForeColor = Color.Green;
            }
            else
            {
                lblPesoRealTime.ForeColor = Color.Red;
            }
            lblKgPesoRealTime.ForeColor = lblPesoRealTime.ForeColor;
        }


        public void MostrarPesoValido(int peso)
        {
            if(peso == 0)
            {
                lblPesoRealTime.ForeColor = SystemColors.ControlText;
                lblPesoRealTime.Text = "--";
            }
            else
            {
                lblPesoRealTime.ForeColor = Color.Green;
                lblPesoRealTime.Text = peso.ToString("##,0");
            }            

            lblKgPesoRealTime.ForeColor = lblPesoRealTime.ForeColor;
        }

    }

    public interface IViewMainForm : IView
    {
        bool EsAdmin { set; }

        string Fecha { set; }
        string Hora { set; }
        string Operario { set; }

        string Matricula { get; set; }

        string Remolque { get; set; }
      
        int Peso { get; set; }

        string Empresa { set; }

        string Conductor { get; set; }

        object TipoCarga { get; set; }

        string Origen { get; set; }

        string Destino { get; set; }

        object Expedidor { get; set; }

        string Camara1 { set; }

        string Camara2 { set; }

        string Camara3 { set; }

        string ProgresoIdentificacion { set; }

        void CargarComboOrigenes(string[] data, bool fijar);

        void CargarComboDestinos(string[] data, bool fijar);

        void LimpiarFormulario();

        void ExpedidorFocus();

        void TipoCargaFocus();

        void LimpiarFormularioIdentificacion();

        void HabilitarBotoneraMantenimientos(bool enabled);

        void HabilitarBotonesIdentificacion(bool enabled);

        void HabilitarAccionesIdentificacion(bool enabled);

        void HabilitarFormularioIdentificacion(bool enabled);
           
        void IdentificacionIncorrecta();

        void PesadaIncorrecta();

        void HabilitarGuardar(bool enabled);

        void IniciarCamara1(string url);

        void IniciarCamara2(string url);

        void IniciarCamara3(string url);

        void IniciarLecturaPeso();

        void MostrarPesoValido(int peso);
    }

    public class MainFormDesignable : View<IPresentMainForm>
    {
        //Clase vacia para que el diseñador muestre bien el formulario
    }

}
