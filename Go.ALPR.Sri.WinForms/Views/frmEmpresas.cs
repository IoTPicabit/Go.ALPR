using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

using MiniMVPNetCore;


namespace Go.ALPR.Sri.WinForms
{
    public partial class frmEmpresas : EmpresasFormDesignable, IViewEmpresasForm
    {

        private bool _datosModificados;

        public frmEmpresas()
        {
            InitializeComponent();
        }

        public override void Bind(IPresentEmpresasForm presenter)
        {
            base.Bind(presenter);
        }

        private void frmEmpresas_Load(object sender, EventArgs e)
        {
            chkHabilitadoFiltro.CheckState = CheckState.Indeterminate;
            Presenter.ConfiguraComboTamanioPagina(cmbPageSize);
            Presenter.ConfigurarGrid(dgvData);

            HabilitarBotonesElemento(false);
            cmbPageSize.SelectedIndexChanged += new EventHandler(cmbPageSize_SelectedIndexChanged);
        }

        public string NombreFiltro
        {
            get
            {
                return txtNombreFiltro.Text;
            }           
        }

        public string CIFFiltro
        {
            get
            {
                return txtCIFFiltro.Text;
            }
        }

        public string NIMAFiltro
        {
            get
            {
                return txtNIMAFiltro.Text;
            }
        }

        public bool? HabilitadoFiltro
        {
            get
            {
                if(chkHabilitadoFiltro.CheckState == CheckState.Indeterminate)
                {
                    return null;
                }
                else if (chkHabilitadoFiltro.CheckState == CheckState.Checked)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public string Nombre
        {
            get
            {
                return txtNombre.Text;
            }
            set
            {
                txtNombre.Text = value;
            }
        }

        public string CIF
        {
            get
            {
                return txtCIF.Text;
            }
            set
            {
                txtCIF.Text = value;
            }
        }

        public string Direccion
        {
            get
            {
                return txtDireccion.Text;
            }
            set
            {
                txtDireccion.Text = value;
            }
        }        

        public string NIMA
        {
            get
            {
                return txtNIMA.Text;
            }
            set
            {
                txtNIMA.Text = value;
            }
        }

        public bool Habilitado
        {
            get
            {
                return chkHabilitado.Checked;
            }
            set
            {
                chkHabilitado.Checked = value;
            }
        }
       
        public bool DatosModificados
        {
            set
            {
                _datosModificados = value;
            }
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

        public void NombreFocus()
        {
            txtNombre.Focus();
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (_datosModificados)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Presenter.Guardar(sender, e);
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Presenter.Buscar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreFiltro.Text = "";
            txtCIFFiltro.Text = "";
            txtNIMAFiltro.Text = "";
            chkHabilitadoFiltro.CheckState = CheckState.Indeterminate;

            Presenter.Buscar();
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
    }


    public interface IViewEmpresasForm : IView
    {
        string NombreFiltro { get; }
        string CIFFiltro { get; }
        string NIMAFiltro { get; }
        bool? HabilitadoFiltro { get; }


        string Nombre { get;  set; }
        string Direccion { get; set; }
        string CIF { get; set; }
        string NIMA { get; set; }
        bool Habilitado { get; set; }


        bool DatosModificados { set; }

        string Pagina { set; }

        bool PaginaPrimera { set; }

        bool PaginaAnterior { set; }

        bool PaginaSiguiente { set; }

        bool PaginaUltima { set; }


        void NombreFocus();

        void MostrarOcultarDetalle(bool mostrar);

        void HabilitarBotonesElemento(bool enabled);
    }

    public class EmpresasFormDesignable : View<IPresentEmpresasForm>
    {
        //Clase vacia para que el diseñador muestre bien el formulario
    }
}
