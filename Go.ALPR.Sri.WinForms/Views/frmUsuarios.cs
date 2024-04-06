using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

using MiniMVPNetCore;


namespace Go.ALPR.Sri.WinForms
{
    public partial class frmUsuarios : UsuariosFormDesignable, IViewUsuariosForm
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        public override void Bind(IPresentUsuariosForm presenter)
        {
            base.Bind(presenter);
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            Presenter.ConfigurarComboTiposUsuario(cmbTipo);
            Presenter.ConfigurarGrid(dgvData);
        }

        private void frmUsuarios_Shown(object sender, EventArgs e)
        {
            dgvData.ClearSelection();
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

        public string Usuario
        {
            get
            {
                return txtUsuario.Text;
            }
            set
            {
                txtUsuario.Text = value;
            }
        }

        public byte Tipo
        {
            get
            {
                return ((KeyValuePair<byte, string>)cmbTipo.SelectedItem).Key;
            }
            set
            {
                cmbTipo.SelectedValue = value;
            }
        }

        public bool Editando
        {
            get
            {
                return (bool)btnGuardar.Tag;
            }

            set
            {
                btnGuardar.Tag = value;
                btnDeshacer.Enabled = value;
                btnEliminar.Enabled = value;
                btnReiniciar.Enabled = value;                
            }
        }

        public void NombreFocus()
        {
            txtNombre.Focus();
        }
            
        public void UsuarioFocus()
        {
            txtUsuario.Focus();
        }
        

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Presenter.Nuevo();
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            Presenter.Deshacer();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Presenter.Eliminar(sender, e);
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            Presenter.Reiniciar(sender, e);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Presenter.Guardar(sender, e);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }


    public interface IViewUsuariosForm : IView
    {
        string Nombre { get;  set; }

        string Usuario { get; set; }

        byte Tipo { get; set; }

        bool Editando { get; set; }

        void NombreFocus();

        void UsuarioFocus();
    }

    public class UsuariosFormDesignable : View<IPresentUsuariosForm>
    {
        //Clase vacia para que el diseñador muestre bien el formulario
    }
}
