using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MiniMVPNetCore;
using LibVLCSharp.Shared;
using System.Runtime.InteropServices;


namespace Go.ALPR.Sri.WinForms
{
    public partial class frmControlAcceso : ControlAccesoFormDesignable, IViewControlAccesoForm, IMainForm
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        private readonly SpanishPlateFont spf;

        private LibVLC _libVLC;
        private MediaPlayer _mpCamara1;
        private MediaPlayer _mpCamara2;
        private MediaPlayer _mpCamara3;


        public frmControlAcceso(SpanishPlateFont spanishPlateFont)
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
            
            pnlSemaforo.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnlSemaforo.Width, pnlSemaforo.Height, pnlSemaforo.Width, pnlSemaforo.Height));

        }

        public override void Bind(IPresentControlAccesoForm presenter)
        {
            base.Bind(presenter);
        }

        private void frmControlAcceso_Load(object sender, EventArgs e)
        {                       
            timerHora.Start();
            Presenter.EstablecerOperario();
            Presenter.InicializarFormulario();
            dtpFechaInicio.Checked = true;
            dtpFechaInicio.MaxDate = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            dtpFechaFin.Checked = true;
            dtpFechaFin.MaxDate = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            Presenter.ConfigurarComboAcceso(cmbAcceso);
            Presenter.ConfiguraComboTamanioPagina(cmbPageSize);
            Presenter.ConfigurarGrid(dgvData);

            cmbPageSize.SelectedIndexChanged += new EventHandler(cmbPageSize_SelectedIndexChanged);

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
                return lblConductor.Text;
            }
            set
            {
                lblConductor.Text = value;
            }
        }       

        public string ProgresoIdentificacion
        {
            set
            {
                lblIndentificacionProgreso.Text = value;
            }
        }
               

        private void timerHora_Tick(object sender, EventArgs e)
        {            
            Presenter.EstablecerFechaHora();
        }
                
        private async void btnNuevaEntrada_Click(object sender, EventArgs e)
        {
            await Presenter.NuevaEntrada(sender, e);
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

        private void btnTransportes_Click(object sender, EventArgs e)
        {
            Presenter.GestionTransportes();
        }
                
        public void LimpiarFormulario()
        {
            lblMatricula.Text = "";
            lblResultado.Text = "";
            lblResultadoHora.Text = "";
            LimpiarFormularioIdentificacion();
            pnlSemaforo.BackColor = SystemColors.ControlDark;
        }

        public void LimpiarFormularioIdentificacion() 
        {
            lblEmpresa.Text = "";
            lblConductor.Text = "";
        }
                               

        public void IdentificacionIncorrecta(string matricula)
        {
            pnlSemaforo.BackColor = Color.Red;
            lblMatricula.Text = matricula;
            lblResultado.Text = "Sin permiso de acceso";
            lblResultadoHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            LimpiarFormularioIdentificacion();
        }

        public void IdentificacionOk(string matricula)
        {
            pnlSemaforo.BackColor = Color.DarkGreen;
            lblMatricula.Text = matricula;
            lblResultado.Text = "Permiso de acceso";
            lblResultadoHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
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

        public void OcultarCamara1()
        {
            vvCamara1.Visible = false;
        }

        public void OcultarCamara2()
        {
            vvCamara2.Visible = false;
        }

        public void OcultarCamara3()
        {
            vvCamara3.Visible = false;
        }

        private void btnCaptura_Click(object sender, EventArgs e)
        {
            Presenter.CapturaPantalla();
        }

        private void cmbPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.CambioTamanioPagina(((KeyValuePair<int, string>)cmbPageSize.SelectedItem).Key);
        }

        private void btnPrimera_Click(object sender, EventArgs e)
        {
            Presenter.PaginaPrimera(sender, e);
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            Presenter.PaginaAnterior(sender, e);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Presenter.PaginaSiguiente(sender, e);
        }

        private void btnUltima_Click(object sender, EventArgs e)
        {
            Presenter.PaginaUltima(sender, e);
        }

        public string Pagina
        {
            set
            {
                lblPagina.Text = value;
            }
        }

        public bool PaginaPrimera
        {
            set
            {
                btnPrimera.Enabled = value;
            }
        }

        public bool PaginaAnterior
        {
            set
            {
                btnAnterior.Enabled = value;
            }
        }

        public bool PaginaSiguiente
        {
            set
            {
                btnSiguiente.Enabled = value;
            }
        }

        public bool PaginaUltima
        {
            set
            {
                btnUltima.Enabled = value;
            }
        }


        public DateTime FechaInicio
        {
            get
            {
                if (dtpFechaInicio.Checked)
                {
                    return dtpFechaInicio.Value;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
        }

        public DateTime FechaFin
        {
            get
            {
                if (dtpFechaFin.Checked)
                {
                    return dtpFechaFin.Value;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
        }

        public string MatriculaFiltro
        {
            get
            {
                return txtMatricula.Text.Trim();
            }
        }

        public int AccesoFiltro
        {
            get
            {
                return ((KeyValuePair<int, string>)cmbAcceso.SelectedItem).Key;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Presenter.Buscar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtpFechaInicio.Checked = true;
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Checked = true;
            dtpFechaFin.Value = DateTime.Now;
            txtMatricula.Text = "";
            cmbAcceso.SelectedIndex = 0;
            Presenter.Buscar();
        }
    }

    public interface IViewControlAccesoForm : IView
    {
        string Fecha { set; }
        string Hora { set; }
        string Operario { set; }

        string Matricula { get; set; }
      
        string Empresa { set; }

        string Conductor { get; set; }

        string ProgresoIdentificacion { set; }

        void LimpiarFormulario();

        void LimpiarFormularioIdentificacion();
           
        void IdentificacionIncorrecta(string matricula);

        void IdentificacionOk(string matricula);

        void IniciarCamara1(string url);

        void IniciarCamara2(string url);

        void IniciarCamara3(string url);

        void OcultarCamara1();

        void OcultarCamara2();

        void OcultarCamara3();

        string Pagina { set; }

        bool PaginaPrimera { set; }

        bool PaginaAnterior { set; }

        bool PaginaSiguiente { set; }

        bool PaginaUltima { set; }

        DateTime FechaInicio { get; }
        DateTime FechaFin { get; }
        string MatriculaFiltro { get; }
        int AccesoFiltro { get; }

    }

    public class ControlAccesoFormDesignable : View<IPresentControlAccesoForm>
    {
        //Clase vacia para que el diseñador muestre bien el formulario
    }

}
