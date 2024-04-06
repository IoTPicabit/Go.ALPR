using System;
using System.Windows.Forms;
using MiniMVPNetCore;

namespace Go.ALPR.Sri.WinForms
{
   
    public partial class frmCambiarClave : CambiarClaveFormDesignable, IViewCambiarClaveForm
    {

        public frmCambiarClave()
        {
            InitializeComponent();
        }

        public override void Bind(IPresentCambiarClaveForm presenter)
        {
            base.Bind(presenter);
        }

        public string ClaveAnterior
        {
            get
            {
                return txtClaveAnterior.Text;
            }
        }

        public string ClaveNueva
        {
            get
            {
                return txtClaveNueva.Text;
            }
        }

        public string ClaveRepetida
        {
            get
            {
                return txtClaveRepetida.Text;
            }
        }

        public void ClaveAnteriorFocus()
        {
            txtClaveAnterior.Focus();
        }

        public void ClaveNuevaFocus()
        {
            txtClaveNueva.Focus();
        }

        public void ClaveRepetidaFocus()
        {
            txtClaveRepetida.Focus();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            var result = await Presenter.CambiarClave(sender, e);
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

    public interface IViewCambiarClaveForm : IView
    {
        string ClaveAnterior { get; }

        string ClaveNueva { get; }

        string ClaveRepetida { get; }

        void ClaveAnteriorFocus();

        void ClaveNuevaFocus();

        void ClaveRepetidaFocus();
    }

    public class CambiarClaveFormDesignable : View<IPresentCambiarClaveForm>
    {
        //Clase vacia para que el diseñador muestre bien el formulario
    }

}