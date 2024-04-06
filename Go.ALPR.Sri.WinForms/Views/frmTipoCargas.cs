using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

using MiniMVPNetCore;


namespace Go.ALPR.Sri.WinForms
{
    public partial class frmTipoCargas : TipoCargasFormDesignable, IViewTipoCargasForm
    {

        private bool _datosModificados;

        public frmTipoCargas()
        {
            InitializeComponent();
        }

        public override void Bind(IPresentTipoCargasForm presenter)
        {
            base.Bind(presenter);
        }

        private void frmTipoCargas_Load(object sender, EventArgs e)
        {
            Presenter.ConfiguraComboTamanioPagina(cmbPageSize);
            Presenter.ConfigurarComboTipo(cmbTipoOperacion);
            Presenter.ConfiguarComboTipoCargaPadre(cmbTipoCargaPadre);
            Presenter.ConfigurarComboExpedidores(cmbEmpresaExpedicion);
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

        public byte TipoFiltro
        {
            get
            {
                return ((KeyValuePair<byte, string>)cmbTipoOperacion.SelectedItem).Key;
            }
        }

        public string LERFiltro
        {
            get
            {
                return txtCodigoLerFiltro.Text;
            }           
        }

        public string ADRFiltro
        {
            get
            {
                return txtDenominacionADRFiltro.Text;
            }            
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreFiltro.Text = "";
            cmbTipoOperacion.SelectedIndex = 0;
            txtNombreFiltro.Text = "";
            txtCodigoLerFiltro.Text = "";
            txtDenominacionADRFiltro.Text = "";

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


        public string CodigoLer
        {
            get
            {
                return txtCodigoLer.Text;
            }
            set
            {
                txtCodigoLer.Text = value;
            }
        }


        public string DenominacionAdr
        {
            get
            {
                return txtDenominacionAdr.Text;
            }
            set
            {
                txtDenominacionAdr.Text = value;
            }
        }


        public object TipoCargaPadre
        {
            get
            {
                return cmbTipoCargaPadre.SelectedValue;
            }
            set
            {
                cmbTipoCargaPadre.SelectedValue = value;
            }
        }


        public object EmpresaExpedicion
        {
            get
            {
                return cmbEmpresaExpedicion.SelectedValue;
            }
            set
            {
                cmbEmpresaExpedicion.SelectedValue = value;
            }
        }



        public bool DatosModificados
        {
            set
            {
                _datosModificados = value;
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

       


        public void HabilitarTipoOperacion(bool enabled)
        {
            rdbCarga.Enabled = enabled;
            rdbDescarga.Enabled = enabled;
        }
    }


    public interface IViewTipoCargasForm : IView
    {

        string NombreFiltro { get; }
        byte TipoFiltro { get; }
        string LERFiltro { get; }
        string ADRFiltro { get; }
        

        string Nombre { get;  set; }

        string CodigoLer { get; set; }

        string DenominacionAdr { get; set; }

        bool Carga { get; set; }

        bool Descarga { get; set; }

        object TipoCargaPadre { get; set; }

        object EmpresaExpedicion { get; set; }


        bool DatosModificados { set; }

        string Pagina { set; }

        bool PaginaPrimera { set; }

        bool PaginaAnterior { set; }

        bool PaginaSiguiente { set; }

        bool PaginaUltima { set; }


        void NombreFocus();

        void MostrarOcultarDetalle(bool mostrar);

        void HabilitarBotonesElemento(bool enabled);

        void HabilitarTipoOperacion(bool enabled);

    }

    public class TipoCargasFormDesignable : View<IPresentTipoCargasForm>
    {
        //Clase vacia para que el diseñador muestre bien el formulario
    }
}
