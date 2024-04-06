using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MiniMVPNetCore;
using System.Threading.Tasks;

using Go.ALPR.Sri.Common;
using Go.ALPR.Sri.Business;


namespace Go.ALPR.Sri.WinForms
{
    public class UsuariosFormPresenter: Presenter<IViewUsuariosForm>, IPresentUsuariosForm
    {
        private DataGridView _dgv;

        private readonly IUsuarioService _service;

        public UsuariosFormPresenter(Func<IViewUsuariosForm> viewFactory, IUsuarioService service)
            : base(viewFactory)
        {
            _service = service;
        }

        ~UsuariosFormPresenter()
        {
            _dgv.SelectionChanged -= new EventHandler(dgv_SelectionChanged);
            _dgv.Dispose();
        }

        public void ConfigurarComboTiposUsuario(ComboBox cmb)
        {
            Dictionary<byte, string> TiposUsuario = new Dictionary<byte, string>();

            TiposUsuario.Add((byte)Enums.TipoUsuario.Operario, "Operario");
            TiposUsuario.Add((byte)Enums.TipoUsuario.Administrador, "Administrador");

            cmb.DataSource = new BindingSource(TiposUsuario, null);
            cmb.DisplayMember = "Value";
            cmb.ValueMember = "Key";
        }

        public void ConfigurarGrid(DataGridView dgv)
        {
            _dgv = dgv;
            _dgv.SelectionChanged += new EventHandler(dgv_SelectionChanged);

            MostrarDatosGrid();

            View.Editando = false;
        }

        private void MostrarDatosGrid()
        {
            _dgv.DataSource = _service.ObtenerLista();

            _dgv.Columns["IdUsuario"].Visible = false;
            _dgv.Columns["Clave"].Visible = false;
            _dgv.Columns["Tipo"].Visible = false;

            _dgv.Columns["Login"].HeaderText = "Usuario";
            _dgv.Columns["TipoNombre"].HeaderText = "Tipo";
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            UsuarioDto data = DatoSeleccionado();

            if (data == null)
            {
                LimpiarFormulario();
            }
            else
            {
                View.Nombre = data.Nombre;
                View.Usuario = data.Login;
                View.Tipo = data.Tipo;
                View.Editando = true;
            }            
        }

        private UsuarioDto DatoSeleccionado()
        {
            UsuarioDto data = null;

            if (_dgv.Rows.Count > 0 && _dgv.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in _dgv.SelectedRows)
                {
                    data = row.DataBoundItem as UsuarioDto;
                }
            }

            return data;
        }

        private void LimpiarFormulario()
        {
            View.Nombre = "";
            View.Usuario = "";
            View.Tipo = (byte)Enums.TipoUsuario.Operario;
            _dgv.ClearSelection();
            View.Editando = false;
        }

        public void Nuevo()
        {
            LimpiarFormulario();
        }

        public void Deshacer()
        {
            UsuarioDto data = DatoSeleccionado();

            if (data != null)
            {
                View.Nombre = data.Nombre;
                View.Usuario = data.Login;
                View.Tipo = data.Tipo;
                View.Editando = true;
            }
        }

        public async void Eliminar(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            UsuarioDto data = DatoSeleccionado();

            if (MessageBox.Show("¿Está seguro que desea eliminar el usuario " + data.Nombre + "?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    btn.Enabled = false;

                    UsuariosForm.Cursor = Cursors.WaitCursor;

                    var result = await _service.Eliminar(data);
                    if (result)
                    {                       
                        MostrarDatosGrid();
                        LimpiarFormulario();
                        MessageBox.Show("Usuario eliminado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Debido a un error no se pudo eliminar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    UsuariosForm.Cursor = Cursors.Default;
                    btn.Enabled = true;
                }

            }

        }

        public async void Reiniciar(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            UsuarioDto data = DatoSeleccionado();

            if (MessageBox.Show("¿Está seguro que desea reiniciar la clave del usuario " + data.Nombre + "?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    btn.Enabled = false;

                    UsuariosForm.Cursor = Cursors.WaitCursor;

                    var result = await _service.Reiniciar(data);
                    if (result)
                    {
                        MessageBox.Show("Clave de usuario reiniciada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Debido a un error no se pudo reiniciar la clave usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    UsuariosForm.Cursor = Cursors.Default;
                    btn.Enabled = true;
                }

            }
        }

        public async void Guardar(object sender, EventArgs e)
        {            
            Button btn = (Button)sender;

            try
            {
                if (string.IsNullOrWhiteSpace(View.Nombre))
                {
                    View.NombreFocus();
                    MessageBox.Show("El nombre no puede estar vacío", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (string.IsNullOrWhiteSpace(View.Usuario))
                {
                    View.UsuarioFocus();
                    MessageBox.Show("El usuario no puede estar vacío", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btn.Enabled = false;

                UsuariosForm.Cursor = Cursors.WaitCursor;

                UsuarioDto data = new UsuarioDto();

                if (View.Editando)
                {
                    data = DatoSeleccionado();
                }                

                data.Nombre = View.Nombre;
                data.Login = View.Usuario;
                data.Tipo = View.Tipo;

                if(_service.ExisteMismoLogin(data.Login, data.IdUsuario))
                {
                    MessageBox.Show("Ya existe otro usuario con este usuario de acceso", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    var result = await _service.Guardar(data);
                    if (result)
                    {                        
                        MostrarDatosGrid();
                        LimpiarFormulario();
                        MessageBox.Show("Usuario guardado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Debido a un error no se pudo guardar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UsuariosForm.Cursor = Cursors.Default;
                btn.Enabled = true;
            }

        }

        public frmUsuarios UsuariosForm
        {
            get { return View as frmUsuarios; }
        }

    }

    public interface IPresentUsuariosForm : IPresent
    {
        frmUsuarios UsuariosForm { get; }

        void ConfigurarComboTiposUsuario(ComboBox cmb);

        void ConfigurarGrid(DataGridView dgv);

        void Nuevo();

        void Deshacer();

        void Eliminar(object sender, EventArgs e);

        void Reiniciar(object sender, EventArgs e);

        void Guardar(object sender, EventArgs e);

    }
}
