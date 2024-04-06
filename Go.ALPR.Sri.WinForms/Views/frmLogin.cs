using System;
using System.Diagnostics;
using System.Windows.Forms;
using MiniMVPNetCore;

namespace Go.ALPR.Sri.WinForms
{   
    public partial class frmLogin : LoginFormDesignable, IViewLoginForm
    {

        public frmLogin()
        {
            InitializeComponent();
        }

        public override void Bind(IPresentLoginForm presenter)
        {
            base.Bind(presenter);
        }

        public string Usuario
        {
            get
            {
                return txtUsuario.Text;
            }           
        }

        public string Clave
        {
            get
            {
                return txtClave.Text;
            }            
        }
              

        public void UsuarioFocus()
        {
            txtUsuario.Focus();
        }

        public void ClaveFocus()
        {
            txtClave.Focus();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {            
            Presenter.EstablecerTitulo();            
            Activate();              
        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {
            txtUsuario.Focus();            
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            var result = await Presenter.ComprobarLogin(sender, e);
            if (result)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {            
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

       
    }


    public interface IViewLoginForm : IView
    {
        string Usuario { get; }
          
        string Clave { get; }

        void UsuarioFocus();

        void ClaveFocus();
    }

    public class LoginFormDesignable : View<IPresentLoginForm>
    {
        //Clase vacia para que el diseñador muestre bien el formulario
    }

}
