using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using MiniMVPNetCore;

using Go.ALPR.Sri.Common;
using Go.ALPR.Sri.Business;

using X.PagedList;


namespace Go.ALPR.Sri.WinForms
{
    public class LocalizacionesFormPresenter: Presenter<IViewLocalizacionesForm>, IPresentLocalizacionesForm
    {
        private bool _editando = false;

        private DataGridView _dgv;

        private int _pageNumber = 1;
        private int _pageSize = 10;

        private IPagedList<LocalizacionDto> listaLocalizaciones;

        private readonly ILocalizacionService _service;

        public LocalizacionesFormPresenter(Func<IViewLocalizacionesForm> viewFactory, ILocalizacionService service)
            : base(viewFactory)
        {
            _service = service;
        }

        ~LocalizacionesFormPresenter()
        {
            _dgv.SelectionChanged -= new EventHandler(dgv_SelectionChanged);
            _dgv.Dispose();
        }

        public void ConfigurarComboTipo(ComboBox cmb)
        {
            Dictionary<byte, string> listaTipos = new Dictionary<byte, string>();
            listaTipos.Add(0, "Ambos");
            listaTipos.Add((byte)Enums.TipoOperacion.Carga, "Carga");
            listaTipos.Add((byte)Enums.TipoOperacion.Descarga, "Descarga");

            cmb.DataSource = new BindingSource(listaTipos, null);
            cmb.DisplayMember = "Value";
            cmb.ValueMember = "Key";
        }

        public async void ConfigurarGrid(DataGridView dgv)
        {
            _dgv = dgv;

            await CargarDatosGrid();

            _dgv.Columns["IdLocalizacion"].Visible = false;
            _dgv.Columns["IdTipoOperacion"].Visible = false;
            _dgv.Columns["Direccion"].Visible = false;

            _dgv.Columns["NombreTipoOperacion"].HeaderText = "Tipo operación";
            _dgv.Columns["Cif"].HeaderText = "CIF";
            _dgv.Columns["Nima"].HeaderText = "NIMA";

            _dgv.SelectionChanged += new EventHandler(dgv_SelectionChanged);
        }

        private async Task CargarDatosGrid()
        {
            LocalizacionesForm.Cursor = Cursors.WaitCursor;


            listaLocalizaciones = await _service.ObtenerListaPaginada(View.NombreFiltro,
                                                                    View.TipoFiltro,
                                                                    View.CIFFiltro,
                                                                    View.NIMAFiltro,
                                                                    View.HabilitadoFiltro,
                                                                    _pageNumber,
                                                                    _pageSize);
            _dgv.DataSource = listaLocalizaciones.ToList();
            View.Pagina = string.Format("Página {0} de {1}", _pageNumber, listaLocalizaciones.PageCount);

            View.PaginaPrimera = !listaLocalizaciones.IsFirstPage;
            View.PaginaAnterior = listaLocalizaciones.HasPreviousPage;
            View.PaginaSiguiente = listaLocalizaciones.HasNextPage;
            View.PaginaUltima = !listaLocalizaciones.IsLastPage;

            _dgv.ClearSelection();

            LocalizacionesForm.Cursor = Cursors.Default;
        }
               
        public void ConfiguraComboTamanioPagina(ComboBox cmb)
        {
            Dictionary<int, string> lista = new Dictionary<int, string>();
            lista.Add(10, "10");
            lista.Add(25, "25");
            lista.Add(50, "50");
            lista.Add(100, "100");

            cmb.DataSource = new BindingSource(lista, null);
            cmb.DisplayMember = "Value";
            cmb.ValueMember = "Key";
        }

        public async void CambioTamanioPagina(int pageSize)
        {
            _pageNumber = 1;
            _pageSize = pageSize;
            await CargarDatosGrid();
        }

        public async void PaginaPrimera(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;
            _pageNumber = 1;
            await CargarDatosGrid();
        }

        public async void PaginaAnterior(object sender, EventArgs e)
        {
            if (listaLocalizaciones.HasPreviousPage)
            {
                Button btn = (Button)sender;
                btn.Enabled = false;
                _pageNumber = _pageNumber - 1;
                await CargarDatosGrid();
            }
        }

        public async void PaginaSiguiente(object sender, EventArgs e)
        {
            if (listaLocalizaciones.HasNextPage)
            {
                Button btn = (Button)sender;
                btn.Enabled = false;
                _pageNumber = _pageNumber + 1;
                await CargarDatosGrid();
            }
        }

        public async void PaginaUltima(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;
            _pageNumber = listaLocalizaciones.PageCount;
            await CargarDatosGrid();
        }

        public async void Buscar()
        {
            _pageNumber = 1;
            await CargarDatosGrid();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            LocalizacionDto data = DatoSeleccionado();

            View.HabilitarBotonesElemento(data != null);          
        }

        private LocalizacionDto DatoSeleccionado()
        {
            LocalizacionDto data = null;

            if (_dgv.Rows.Count > 0 && _dgv.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in _dgv.SelectedRows)
                {
                    data = row.DataBoundItem as LocalizacionDto;
                }
            }

            return data;
        }

        private void LimpiarFormulario()
        {
            View.Nombre = "";
            View.Direccion = "";
            View.CIF = "";
            View.NIMA = "";
            View.Carga = true;
            View.Habilitado = true;
            _dgv.ClearSelection();
            _editando = false;
        }              

        public void Nuevo()
        {
            LimpiarFormulario();
            View.MostrarOcultarDetalle(true);
            View.NombreFocus();
        }

        public void Editar()
        {
            LocalizacionDto data = DatoSeleccionado();

            if (data != null)
            {
                View.Nombre = data.Nombre;
                View.Carga = (data.IdTipoOperacion == (byte)Enums.TipoOperacion.Carga);
                View.Descarga = (data.IdTipoOperacion == (byte)Enums.TipoOperacion.Descarga);
                View.Direccion = data.Direccion;
                View.CIF = data.Cif;
                View.NIMA = data.Nima;
                View.Habilitado = data.Habilitado;
                _editando = true;
                View.MostrarOcultarDetalle(true);
                View.NombreFocus();
            }
        }

        public void CerrarFormulario()
        {
            View.MostrarOcultarDetalle(false);
        }

        public async void Eliminar(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            LocalizacionDto data = DatoSeleccionado();

            if (MessageBox.Show("¿Está seguro que desea eliminar la localización " + data.Nombre + "?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    btn.Enabled = false;

                    LocalizacionesForm.Cursor = Cursors.WaitCursor;

                    var result = _service.Eliminar(data);
                    if (result)
                    {
                        View.DatosModificados = true;
                        _pageNumber = 1;
                        await CargarDatosGrid();
                        LimpiarFormulario();
                        MessageBox.Show("Localizacion eliminado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Debido a un error no se pudo eliminar la localización", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    LocalizacionesForm.Cursor = Cursors.Default;
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

                btn.Enabled = false;

                LocalizacionesForm.Cursor = Cursors.WaitCursor;

                LocalizacionDto data = new LocalizacionDto();

                if (_editando)
                {
                    data = DatoSeleccionado();
                }                

                data.Nombre = View.Nombre;
                data.IdTipoOperacion = (View.Carga ? (byte)Enums.TipoOperacion.Carga : (byte)Enums.TipoOperacion.Descarga);
                data.Cif = View.CIF;
                data.Direccion = View.Direccion;
                data.Nima = View.NIMA;
                data.Habilitado = View.Habilitado;

                var result = _service.Guardar(data);
                if (result)
                {
                    View.DatosModificados = true;
                    await CargarDatosGrid();
                    LimpiarFormulario();
                    View.MostrarOcultarDetalle(false);
                    MessageBox.Show("Localización guardada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debido a un error no se pudo guardar la localización", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LocalizacionesForm.Cursor = Cursors.Default;
                btn.Enabled = true;
            }

        }

        public frmLocalizaciones LocalizacionesForm
        {
            get { return View as frmLocalizaciones; }
        }

    }

    public interface IPresentLocalizacionesForm : IPresent
    {
        frmLocalizaciones LocalizacionesForm { get; }
               
        void ConfigurarGrid(DataGridView dgv);

        void ConfigurarComboTipo(ComboBox cmb);

        void ConfiguraComboTamanioPagina(ComboBox cmb);
        void CambioTamanioPagina(int _pageSize);
        void PaginaPrimera(object sender, EventArgs e);
        void PaginaAnterior(object sender, EventArgs e);
        void PaginaSiguiente(object sender, EventArgs e);
        void PaginaUltima(object sender, EventArgs e);

        void Buscar();

        void Nuevo();

        void Editar();

        void Eliminar(object sender, EventArgs e);

        void Guardar(object sender, EventArgs e);

        void CerrarFormulario();

    }
}
