using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

using MiniMVPNetCore;


namespace Go.ALPR.Sri.WinForms
{
    public partial class frmOperaciones : OperacionesFormDesignable, IViewOperacionesForm
    {
        public frmOperaciones()
        {
            InitializeComponent();
        }

        public override void Bind(IPresentOperacionesForm presenter)
        {
            base.Bind(presenter);
        }

        private void frmOperaciones_Load(object sender, EventArgs e)
        {
            dtpFechaInicio.Checked = false;
            dtpFechaInicio.MaxDate = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            dtpFechaFin.Checked = false;
            dtpFechaFin.MaxDate = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            Presenter.ConfigurarComboTipo(cmbTipoOperacion);
            Presenter.ConfiguraComboTamanioPagina(cmbPageSize);
            Presenter.ConfigurarGrid(dgvData);
            HabilitarBotonesElemento(false);

            cmbPageSize.SelectedIndexChanged += new EventHandler(cmbPageSize_SelectedIndexChanged);
        }
                      
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
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


        public string Numero
        {
            get
            {
                return txtNumero.Text;
            }
        }
               

        public string Matricula
        {
            get
            {
                return txtMatricula.Text.Trim();
            }
        }

        public string Remolque
        {
            get
            {
                return txtRemolque.Text.Trim();
            }
        }

        public string Conductor
        {
            get
            {
                return txtConductor.Text.Trim();
            }
        }

        public string Empresa
        {
            get
            {
                return txtEmpresa.Text.Trim();
            }
        }

        public byte Tipo
        {
            get
            {
                return ((KeyValuePair<byte, string>)cmbTipoOperacion.SelectedItem).Key;
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

        public string TipoCarga
        {
            get
            {
                return txtConductor.Text.Trim();
            }
        }
               
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtMatricula.Text = "";
            txtRemolque.Text = "";
            txtConductor.Text = "";
            txtEmpresa.Text = "";
            cmbTipoOperacion.SelectedIndex = 0;
            dtpFechaInicio.Checked = false;
            dtpFechaFin.Checked = false;
            txtTipoCarga.Text = "";
            Presenter.Buscar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Presenter.Buscar();
        }

        private void btnImprimirAlbaran_Click(object sender, EventArgs e)
        {
            Presenter.ImprimirAlbaran();
        }

        private void btnGuardarAlbaran_Click(object sender, EventArgs e)
        {
            Presenter.GuardarAlbaran();
        }

        private void btnEnviarAlbaran_Click(object sender, EventArgs e)
        {
            Presenter.EnviarAlbaran();
        }

        public void HabilitarBotonesElemento(bool enabled)
        {
            btnGuardarAlbaran.Enabled = enabled;
            btnImprimirAlbaran.Enabled = enabled && Presenter.ImpresionHabilitada;
            btnEditar.Enabled = enabled;
            btnEnviarAlbaran.Enabled = enabled && Presenter.CorreoHabilitado;
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Presenter.MostrarDetalle();
        }

        private void btnCerrarDetalle_Click(object sender, EventArgs e)
        {
            Presenter.OcultarDetalle();            
        }


        public void MostrarOcultarDetalle(bool mostrar)
        {
            if (mostrar)
            {
                pnlTop.Visible = false;
                pnlFormulario.Dock = DockStyle.Fill;
                pnlFormulario.Visible = true;
            }
            else
            {
                pnlFormulario.Visible = false;
                pnlTop.Visible = true;
            }
        }


        public string Camara1Entrada
        {
            set
            {
                picCamara1Entrada.ImageLocation = value;
                if (value != null)
                {
                    picCamara1Entrada.Cursor = Cursors.Hand;
                    picCamara1Entrada.Load();
                }
                else
                {
                    picCamara1Entrada.Cursor = Cursors.Default;
                }
            }
        }

        public string Camara2Entrada
        {
            set
            {
                picCamara2Entrada.ImageLocation = value;
                if (value != null)
                {
                    picCamara2Entrada.Cursor = Cursors.Hand;
                    picCamara2Entrada.Load();
                }
                else
                {
                    picCamara2Entrada.Cursor = Cursors.Default;
                }
            }
        }

        public string Camara3Entrada
        {
            set
            {
                picCamara3Entrada.ImageLocation = value;
                if (value != null)
                {
                    picCamara3Entrada.Cursor = Cursors.Hand;
                    picCamara3Entrada.Load();
                }
                else
                {
                    picCamara3Entrada.Cursor = Cursors.Default;
                }
            }
        }

        public string Camara1Salida
        {
            set
            {
                picCamara1Salida.ImageLocation = value;
                if (value != null)
                {
                    picCamara1Salida.Cursor = Cursors.Hand;
                    picCamara1Salida.Load();
                }
                else
                {
                    picCamara1Salida.Cursor = Cursors.Default;
                }
            }
        }

        public string Camara2Salida
        {
            set
            {
                picCamara2Salida.ImageLocation = value;
                if (value != null)
                {
                    picCamara2Salida.Cursor = Cursors.Hand;
                    picCamara2Salida.Load();
                }
                else
                {
                    picCamara2Salida.Cursor = Cursors.Default;
                }
            }
        }


        public string Camara3Salida
        {
            set
            {
                picCamara3Salida.ImageLocation = value;
                if (value != null)
                {
                    picCamara3Salida.Cursor = Cursors.Hand;
                    picCamara3Salida.Load();
                }
                else
                {
                    picCamara3Salida.Cursor = Cursors.Default;
                }
            }
        }

        private void picCamara1Entrada_Click(object sender, EventArgs e)
        {
            Presenter.AmpliarFotoCamara1Entrada(sender, e);
        }

        private void picCamara2Entrada_Click(object sender, EventArgs e)
        {
            Presenter.AmpliarFotoCamara2Entrada(sender, e);
        }

        private void picCamara3Entrada_Click(object sender, EventArgs e)
        {
            Presenter.AmpliarFotoCamara3Entrada(sender, e);
        }

        private void picCamara1Salida_Click(object sender, EventArgs e)
        {
            Presenter.AmpliarFotoCamara1Salida(sender, e);
        }

        private void picCamara2Salida_Click(object sender, EventArgs e)
        {
            Presenter.AmpliarFotoCamara2Salida(sender, e);
        }

        private void picCamara3Salida_Click(object sender, EventArgs e)
        {
            Presenter.AmpliarFotoCamara3Salida(sender, e);
        }

       
    }


    public interface IViewOperacionesForm : IView
    {
        string Pagina { set; }
                
        bool PaginaPrimera { set; }

        bool PaginaAnterior { set; }

        bool PaginaSiguiente { set; }

        bool PaginaUltima { set; }

        string Numero { get; }
        string Matricula { get; }
        string Remolque { get; }
        string Conductor { get; }
        string Empresa { get; }
        byte Tipo { get; }
        DateTime FechaInicio { get; }
        DateTime FechaFin { get; }
        string TipoCarga { get; }

        void HabilitarBotonesElemento(bool enabled);

        void MostrarOcultarDetalle(bool mostrar);

        string Camara1Entrada { set; }
        string Camara2Entrada { set; }
        string Camara3Entrada { set; }
        string Camara1Salida { set; }
        string Camara2Salida { set; }
        string Camara3Salida { set; }
    }

    public class OperacionesFormDesignable : View<IPresentOperacionesForm>
    {
        //Clase vacia para que el diseñador muestre bien el formulario
    }
}
