using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading.Tasks;
using MiniMVPNetCore;
using Go.ALPR.Sri.Business;

using X.PagedList;


namespace Go.ALPR.Sri.WinForms
{
    public class EmpresasFormPresenter: Presenter<IViewEmpresasForm>, IPresentEmpresasForm
    {

        private int _pageNumber = 1;
        private int _pageSize = 10;
        private bool _editando = false;

        private IPagedList<EmpresaDto> listaEmpresas;

        private DataGridView _dgv;
       
        private readonly IEmpresaService _service;

        public EmpresasFormPresenter(Func<IViewEmpresasForm> viewFactory, IEmpresaService service)
            : base(viewFactory)
        {
            _service = service;
        }

        ~EmpresasFormPresenter()
        {
            _dgv.SelectionChanged -= new EventHandler(dgv_SelectionChanged);
            _dgv.Dispose();
        }

        public async void ConfigurarGrid(DataGridView dgv)
        {
            _dgv = dgv;                                

            await CargarDatosGrid();

            _dgv.Columns["IdEmpresa"].Visible = false;
            _dgv.Columns["Direccion"].Visible = false;

            _dgv.Columns["Cif"].HeaderText = "CIF";
            _dgv.Columns["Nima"].HeaderText = "NIMA";
            _dgv.Columns["Habilitado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            _dgv.SelectionChanged += new EventHandler(dgv_SelectionChanged);
        }
                
        private async Task CargarDatosGrid()
        {
            EmpresasForm.Cursor = Cursors.WaitCursor;


            listaEmpresas = await _service.ObtenerListaPaginada(
                                                                View.NombreFiltro,
                                                                View.CIFFiltro,
                                                                View.NIMAFiltro,
                                                                View.HabilitadoFiltro,
                                                                _pageNumber,
                                                                _pageSize);
            _dgv.DataSource = listaEmpresas.ToList();
            View.Pagina = string.Format("Página {0} de {1}", _pageNumber, listaEmpresas.PageCount);

            View.PaginaPrimera = !listaEmpresas.IsFirstPage;
            View.PaginaAnterior = listaEmpresas.HasPreviousPage;
            View.PaginaSiguiente = listaEmpresas.HasNextPage;
            View.PaginaUltima = !listaEmpresas.IsLastPage;

            _dgv.ClearSelection();

            EmpresasForm.Cursor = Cursors.Default;
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
            if (listaEmpresas.HasPreviousPage)
            {
                Button btn = (Button)sender;
                btn.Enabled = false;
                _pageNumber = _pageNumber - 1;
                await CargarDatosGrid();
            }
        }

        public async void PaginaSiguiente(object sender, EventArgs e)
        {
            if (listaEmpresas.HasNextPage)
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
            _pageNumber = listaEmpresas.PageCount;
            await CargarDatosGrid();
        }

        public async void Buscar()
        {
            _pageNumber = 1;
            await CargarDatosGrid();
        }


        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            EmpresaDto data = DatoSeleccionado();

            View.HabilitarBotonesElemento(data != null);           
        }

        private EmpresaDto DatoSeleccionado()
        {
            EmpresaDto data = null;

            if (_dgv.Rows.Count > 0 && _dgv.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in _dgv.SelectedRows)
                {
                    data = row.DataBoundItem as EmpresaDto;
                }
            }

            return data;
        }

        private void LimpiarFormulario()
        {
            View.Nombre = "";
            View.CIF = "";
            View.Direccion = "";
            View.NIMA = "";
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
            EmpresaDto data = DatoSeleccionado();

            if (data != null)
            {
                View.Nombre = data.Nombre;
                View.CIF = data.Cif;
                View.Direccion = data.Direccion;
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

            EmpresaDto data = DatoSeleccionado();

            if (MessageBox.Show("¿Está seguro que desea eliminar la empresa " + data.Nombre + "?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    btn.Enabled = false;

                    EmpresasForm.Cursor = Cursors.WaitCursor;

                    var result = _service.Eliminar(data);
                    if (result)
                    {
                        View.DatosModificados = true;
                        _pageNumber = 1;
                        await CargarDatosGrid();
                        LimpiarFormulario();
                        MessageBox.Show("Empresa eliminada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Debido a un error no se pudo eliminar la empresa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    EmpresasForm.Cursor = Cursors.Default;
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

                EmpresasForm.Cursor = Cursors.WaitCursor;

                EmpresaDto data = new EmpresaDto();

                if (_editando)
                {
                    data = DatoSeleccionado();                    
                }                               

                data.Nombre = View.Nombre;
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
                    MessageBox.Show("Empresa guardada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debido a un error no se pudo guardar la empresa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EmpresasForm.Cursor = Cursors.Default;
                btn.Enabled = true;
            }

        }

        public frmEmpresas EmpresasForm
        {
            get { return View as frmEmpresas; }
        }

    }

    public interface IPresentEmpresasForm : IPresent
    {
        frmEmpresas EmpresasForm { get; }

        void ConfigurarGrid(DataGridView dgv);       

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
