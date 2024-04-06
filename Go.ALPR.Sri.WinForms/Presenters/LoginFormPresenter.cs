using System;
using System.ComponentModel;
using System.Windows.Forms;
using MiniMVPNetCore;
using System.Threading.Tasks;

using Go.ALPR.Sri.Business;


namespace Go.ALPR.Sri.WinForms
{       
    public class LoginFormPresenter : Presenter<IViewLoginForm>, IPresentLoginForm
    {
        private bool _cambioUsuario;

        private readonly ISeguridadService _seguridadService;

        public LoginFormPresenter(Func<IViewLoginForm> viewFactory, ISeguridadService seguridadService)
            : base(viewFactory)
        {           
            _seguridadService = seguridadService;
        }              

        public frmLogin LoginForm
        {
            get { return View as frmLogin; }
        }

        public bool CambioUsuario
        {
            get
            {
                return _cambioUsuario;
            }
            set
            {
                _cambioUsuario = value;
            }
        }

        public void EstablecerTitulo()
        {
            if (_cambioUsuario)
            {
                LoginForm.Text = "Cambio de usuario";
            }
        }

        public async Task<bool> ComprobarLogin(object sender, EventArgs e)
        {
            Button btn = (Button)sender;                      

            bool result = false;

            if (string.IsNullOrWhiteSpace(View.Usuario))
            {
                View.UsuarioFocus();
                MessageBox.Show("El usuario no puede estar vacío", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return result;
            }

            if (string.IsNullOrWhiteSpace(View.Clave))
            {
                View.ClaveFocus();
                MessageBox.Show("La clave no puede estar vacía", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return result;
            }

            try
            {
                btn.Enabled = false;

                LoginForm.Cursor = Cursors.WaitCursor;

                result = await _seguridadService.ComprobarLogin(View.Usuario, View.Clave);

                if (!result){
                    MessageBox.Show("El usuario o clave introducidos no son correctos", "Credenciales incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoginForm.Cursor = Cursors.Default;
                btn.Enabled = true;
            }
           
            return result;
        }        
    }


    public interface IPresentLoginForm : IPresent
    {
        frmLogin LoginForm { get;  }

        bool CambioUsuario { get; set; }

        void EstablecerTitulo();

        Task<bool> ComprobarLogin(object sender, EventArgs e);
    }
}
