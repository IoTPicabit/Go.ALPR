using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

using MiniMVPNetCore;


namespace Go.ALPR.Sri.WinForms
{
    public partial class frmTransportes : TransportesFormDesignable, IViewTransportesForm
    {
        public frmTransportes()
        {
            InitializeComponent();
        }

        public override void Bind(IPresentTransportesForm presenter)
        {
            base.Bind(presenter);
        }

        private void frmTransportes_Load(object sender, EventArgs e)
        {
            Presenter.ConfigurarComboEmpresas(cmbEmpresa);
            Presenter.ConfigurarComboTipoCargas(cmbTipoCarga);

            Presenter.ConfigurarComboTipo(cmbTipoOperacionFiltro);
            Presenter.ConfiguraComboTamanioPagina(cmbPageSize);
            Presenter.ConfigurarGrid(dgvData);
            HabilitarBotonesElemento(false);

            cmbPageSize.SelectedIndexChanged += new EventHandler(cmbPageSize_SelectedIndexChanged);
        }


        public string MatriculaFiltro
        {
            get
            {
                return txtMatriculaFiltro.Text;
            }
        }

        public string RemolqueFiltro
        {
            get
            {
                return txtRemolqueFiltro.Text;
            }
        }


        public string ConductorFiltro
        {
            get
            {
                return txtConductorFiltro.Text;
            }
        }

        public string EmpresaFiltro
        {
            get
            {
                return txtEmpresaFiltro.Text;
            }            
        }

        public byte TipoFiltro
        {
            get
            {
                return ((KeyValuePair<byte, string>)cmbTipoOperacionFiltro.SelectedItem).Key;
            }
        }

        public string TipoCargaFiltro
        {
            get
            {
                return txtTipoCargaFiltro.Text;
            }
        }



        public string Matricula
        {
            get
            {
                return txtMatricula.Text.Trim();
            }
            set
            {
                txtMatricula.Text = value;
            }
        }

        public string Remolque
        {
            get
            {
                return txtRemolque.Text.Trim();
            }
            set
            {
                txtRemolque.Text = value;
            }
        }

        public bool Carga
        {
            get
            {
                return rdbCarga.Checked;
            }
            set
            {
                rdbCarga.Checked = value;
            }
        }

        public bool Descarga
        {
            get
            {
                return rdbDescarga.Checked;
            }
            set
            {
                rdbDescarga.Checked = value;
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

        public object Empresa
        {
            get
            {
                return cmbEmpresa.SelectedValue;
            }
            set
            {
                cmbEmpresa.SelectedValue = value;
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtMatriculaFiltro.Text = "";
            txtRemolqueFiltro.Text = "";
            txtConductorFiltro.Text = "";
            txtEmpresaFiltro.Text = "";
            txtTipoCargaFiltro.Text = "";
            cmbTipoOperacionFiltro.SelectedIndex = 0;
            Presenter.Buscar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Presenter.Buscar();
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



        public void MatriculaFocus()
        {
            txtMatricula.Enabled = true;
            txtMatricula.Focus();
        }

        public void RemolqueFocus()
        {
            txtMatricula.Enabled = false;
            txtRemolque.Focus();
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

        public void HabilitarBotonesElemento(bool enabled)
        {
            btnEliminar.Enabled = enabled;
            btnEditar.Enabled = enabled;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Presenter.Nuevo();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Presenter.Editar();
        }

        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Presenter.Eliminar(sender, e);
        }           

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Presenter.Guardar(sender, e);
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

        private void btnCerrarFormulario_Click(object sender, EventArgs e)
        {
            Presenter.CerrarFormulario();
        }

        private void TipoOperacion_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                Presenter.CambiarTipoOperacion(sender, e);
            }            
        }

        
    }


    public interface IViewTransportesForm : IView
    {

        string MatriculaFiltro { get; }
        string RemolqueFiltro { get; }
        string ConductorFiltro { get; }
        string EmpresaFiltro { get; }
        public byte TipoFiltro { get;  }
        string TipoCargaFiltro { get; }


        string Matricula { get;  set; }
        string Remolque { get; set; }
        bool Carga { get; set; }
        bool Descarga { get; set; }
        string Conductor { get; set; }
        object Empresa { get; set; }
        object TipoCarga { get; set; }

        
        string Pagina { set; }
        bool PaginaPrimera { set; }
        bool PaginaAnterior { set; }
        bool PaginaSiguiente { set; }
        bool PaginaUltima { set; }

        void MatriculaFocus();
        void RemolqueFocus();
        void MostrarOcultarDetalle(bool mostrar);
        void HabilitarBotonesElemento(bool enabled);
    }

    public class TransportesFormDesignable : View<IPresentTransportesForm>
    {
        //Clase vacia para que el diseñador muestre bien el formulario
    }
}
