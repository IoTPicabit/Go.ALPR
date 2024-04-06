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
    public class ContactosFormPresenter: Presenter<IViewContactosForm>, IPresentContactosForm
    {

        private int _pageNumber = 1;
        private int _pageSize = 10;
        private bool _editando = false;

        private IPagedList<ContactoDto> listaContactos;

        private DataGridView _dgv;

        private EmpresaDto _empresaVacia = new EmpresaDto { IdEmpresa = 0, Nombre = "Ninguna..." };
        private TipoCargaDto _tipoCargaVacio = new TipoCargaDto { IdTipoCarga = 0, Nombre = "Ninguno..." };

        private readonly IContactoService _service;
        private readonly IEmpresaService _empresaService;
        private readonly ITipoCargaService _tipoCargaService;

        public ContactosFormPresenter(Func<IViewContactosForm> viewFactory, 
                                        IContactoService service,
                                        IEmpresaService empresaService,
                                        ITipoCargaService tipoCargaService)
            : base(viewFactory)
        {
            _service = service;
            _empresaService = empresaService;
            _tipoCargaService = tipoCargaService;
        }

        ~ContactosFormPresenter()
        {
            _dgv.SelectionChanged -= new EventHandler(dgv_SelectionChanged);
            _dgv.Dispose();
        }

        public async void ConfigurarGrid(DataGridView dgv)
        {
            _dgv = dgv;                                

            await CargarDatosGrid();

            _dgv.Columns["IdContacto"].Visible = false;
            _dgv.Columns["IdEmpresa"].Visible = false;
            _dgv.Columns["IdTipoCarga"].Visible = false;

            _dgv.Columns["NombreEmpresa"].HeaderText = "Empresa";
            _dgv.Columns["NombreTipoCarga"].HeaderText = "Tipo carga";

            _dgv.Columns["Habilitado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            _dgv.SelectionChanged += new EventHandler(dgv_SelectionChanged);
        }
                
        private async Task CargarDatosGrid()
        {
            ContactosForm.Cursor = Cursors.WaitCursor;

            listaContactos = await _service.ObtenerListaPaginada(
                                                                View.NombreFiltro,
                                                                View.EmailFiltro,
                                                                View.HabilitadoFiltro,
                                                                _pageNumber,
                                                                _pageSize);
            _dgv.DataSource = listaContactos.ToList();
            View.Pagina = string.Format("Página {0} de {1}", _pageNumber, listaContactos.PageCount);

            View.PaginaPrimera = !listaContactos.IsFirstPage;
            View.PaginaAnterior = listaContactos.HasPreviousPage;
            View.PaginaSiguiente = listaContactos.HasNextPage;
            View.PaginaUltima = !listaContactos.IsLastPage;

            _dgv.ClearSelection();

            ContactosForm.Cursor = Cursors.Default;
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
            if (listaContactos.HasPreviousPage)
            {
                Button btn = (Button)sender;
                btn.Enabled = false;
                _pageNumber = _pageNumber - 1;
                await CargarDatosGrid();
            }
        }

        public async void PaginaSiguiente(object sender, EventArgs e)
        {
            if (listaContactos.HasNextPage)
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
            _pageNumber = listaContactos.PageCount;
            await CargarDatosGrid();
        }

        public async void Buscar()
        {
            _pageNumber = 1;
            await CargarDatosGrid();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            ContactoDto data = DatoSeleccionado();

            View.HabilitarBotonesElemento(data != null);           
        }

        public void ConfigurarComboEmpresas(ComboBox cmb)
        {
            List<EmpresaDto> empresas = _empresaService.ObtenerLista();

            empresas.Insert(0, _empresaVacia);

            cmb.DataSource = empresas;
            cmb.DisplayMember = "Nombre";
            cmb.ValueMember = "IdEmpresa";
        }

        public void ConfigurarComboTipoCargas(ComboBox cmb)
        {
            List<TipoCargaDto> tiposCarga = _tipoCargaService.ObtenerLista();

            tiposCarga.Insert(0, _tipoCargaVacio);

            cmb.DataSource = tiposCarga;
            cmb.DisplayMember = "Nombre";
            cmb.ValueMember = "IdTipoCarga";
        }

        private ContactoDto DatoSeleccionado()
        {
            ContactoDto data = null;

            if (_dgv.Rows.Count > 0 && _dgv.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in _dgv.SelectedRows)
                {
                    data = row.DataBoundItem as ContactoDto;
                }
            }

            return data;
        }

        private void LimpiarFormulario()
        {
            View.Nombre = "";
            View.Email = "";
            View.Empresa = 0;
            View.TipoCarga = 0;
            View.Habilitado = true;
            _dgv.ClearSelection();          

            _editando = false;
        }

        public void Nuevo()
        {
            LimpiarFormulario();
            View.MostrarOcultarDetalle(true);
            View.EmailFocus();
        }

        public void Editar()
        {
            ContactoDto data = DatoSeleccionado();

            if (data != null)
            {
                View.Email = data.Email;
                View.Nombre = data.Nombre;
                View.Empresa = data.IdEmpresa == null ? 0 : data.IdEmpresa;
                View.TipoCarga = data.IdTipoCarga == null ? 0 : data.IdTipoCarga;
                View.Habilitado =  (bool)data.Habilitado;

                _editando = true;
                View.MostrarOcultarDetalle(true);
                View.EmailFocus();
            }
        }

        public void CerrarFormulario()
        {
            View.MostrarOcultarDetalle(false);
        }

       
        public async void Eliminar(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            ContactoDto data = DatoSeleccionado();

            if (MessageBox.Show("¿Está seguro que desea eliminar el contacto " + data.Nombre + "?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    btn.Enabled = false;

                    ContactosForm.Cursor = Cursors.WaitCursor;

                    var result = _service.Eliminar(data);
                    if (result)
                    {
                        View.DatosModificados = true;
                        _pageNumber = 1;
                        await CargarDatosGrid();
                        LimpiarFormulario();
                        MessageBox.Show("Contacto eliminado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Debido a un error no se pudo eliminar el contacto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    ContactosForm.Cursor = Cursors.Default;
                    btn.Enabled = true;
                }

            }

        }       

        public async void Guardar(object sender, EventArgs e)
        {            
            Button btn = (Button)sender;

            try
            {
                if (string.IsNullOrWhiteSpace(View.Email))
                {
                    View.EmailFocus();
                    MessageBox.Show("El email no puede estar vacío", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btn.Enabled = false;

                ContactosForm.Cursor = Cursors.WaitCursor;

                ContactoDto data = new ContactoDto();

                if (_editando)
                {
                    data = DatoSeleccionado();                    
                }                               

                data.Nombre = View.Nombre;
                data.Email = View.Email;
                int empresa = (int)View.Empresa;
                if (empresa == 0)
                {
                    data.IdEmpresa = null;
                }
                else
                {
                    data.IdEmpresa = empresa;
                }

                int tipocarga = (int)View.TipoCarga;
                if (tipocarga == 0)
                {
                    data.IdTipoCarga = null;
                }
                else
                {
                    data.IdTipoCarga = tipocarga;
                }
                data.Habilitado = View.Habilitado;                

                var result = _service.Guardar(data);
                if (result)
                {
                    View.DatosModificados = true;
                    await CargarDatosGrid();
                    LimpiarFormulario();
                    View.MostrarOcultarDetalle(false);
                    MessageBox.Show("Contacto guardado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debido a un error no se pudo guardar el contacto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ContactosForm.Cursor = Cursors.Default;
                btn.Enabled = true;
            }

        }

        public frmContactos ContactosForm
        {
            get { return View as frmContactos; }
        }

    }

    public interface IPresentContactosForm : IPresent
    {
        frmContactos ContactosForm { get; }

        void ConfigurarGrid(DataGridView dgv);

        void ConfigurarComboEmpresas(ComboBox cmb);

        void ConfigurarComboTipoCargas(ComboBox cmb);

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
