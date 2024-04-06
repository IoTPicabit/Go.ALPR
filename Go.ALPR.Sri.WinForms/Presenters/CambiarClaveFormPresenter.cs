using System;
using System.Windows.Forms;
using MiniMVPNetCore;
using System.Threading.Tasks;

using Go.ALPR.Sri.Business;

namespace Go.ALPR.Sri.WinForms
{
    public class CambiarClaveFormPresenter : Presenter<IViewCambiarClaveForm>, IPresentCambiarClaveForm
    {

        private readonly ISeguridadService _seguridadService;
        private readonly UsuarioSesionDto _usuarioSesion;

        public CambiarClaveFormPresenter(Func<IViewCambiarClaveForm> viewFactory, ISeguridadService seguridadService, UsuarioSesionDto usuarioSesion)
            : base(viewFactory)
        {
            _seguridadService = seguridadService;
            _usuarioSesion = usuarioSesion;
        }


        public frmCambiarClave CambiarClaveForm
        {
            get { return View as frmCambiarClave; }
        }

        public async Task<bool> CambiarClave(object sender, EventArgs e)
        {

            Button btn = (Button)sender;

            bool result = false;

            if (string.IsNullOrWhiteSpace(View.ClaveAnterior))
            {
                View.ClaveAnteriorFocus();
                MessageBox.Show("La clave anterior no puede estar vacía", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return result;
            }

            if (string.IsNullOrWhiteSpace(View.ClaveNueva))
            {
                View.ClaveNuevaFocus();
                MessageBox.Show("La nueva clave no puede estar vacía", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return result;
            }

            if (string.IsNullOrWhiteSpace(View.ClaveRepetida))
            {
                View.ClaveRepetidaFocus();
                MessageBox.Show("La repetición de la nueva clave no puede estar vacía", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return result;
            }

            if (!View.ClaveNueva.Equals(View.ClaveRepetida))
            {
                View.ClaveNuevaFocus();
                MessageBox.Show("La nueva clave y la repetición no coinciden", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return result;
            }

            try
            {
                btn.Enabled = false;

                CambiarClaveForm.Cursor = Cursors.WaitCursor;

                result = await _seguridadService.ComprobarLogin(_usuarioSesion.Login, View.ClaveAnterior);

                if (!result)
                {
                    MessageBox.Show("La clave anterior introducida no es correcta", "Credenciales incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    result = await _seguridadService.CambiarClave(_usuarioSesion.IdUsuario, View.ClaveRepetida);                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CambiarClaveForm.Cursor = Cursors.Default;
                btn.Enabled = true;
            }

            return result;

        }

    }

    public interface IPresentCambiarClaveForm : IPresent
    {
        frmCambiarClave CambiarClaveForm { get; }

        Task<bool> CambiarClave(object sender, EventArgs e);
    }
}
