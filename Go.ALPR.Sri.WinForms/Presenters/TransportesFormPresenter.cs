using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using MiniMVPNetCore;
using System.Threading.Tasks;

using Go.ALPR.Sri.Common;
using Go.ALPR.Sri.Business;

using X.PagedList;

namespace Go.ALPR.Sri.WinForms
{
    public class TransportesFormPresenter: Presenter<IViewTransportesForm>, IPresentTransportesForm
    {
        private bool _editando = false;

        private DataGridView _dgv;

        private int _pageNumber = 1;
        private int _pageSize = 10;

        private IPagedList<TransporteDto> listaTransportes;

        private List<TipoCargaDto> _tipoCargas;
        private ComboBox _cmbTipoCargas;

        private EmpresaDto _empresaVacia = new EmpresaDto { IdEmpresa = 0, Nombre = "Ninguna..." };
        private TipoCargaDto _tipoCargaVacio = new TipoCargaDto { IdTipoCarga = 0, Nombre = "Ninguno..." };

        private readonly ITransporteService _service;

        private readonly IEmpresaService _empresaService;
        private readonly ITipoCargaService _tipoCargaService;

        public TransportesFormPresenter(Func<IViewTransportesForm> viewFactory, 
                                        ITransporteService service,
                                        IEmpresaService empresaService,
                                        ITipoCargaService tipoCargaService)
            : base(viewFactory)
        {
            _service = service;
            _empresaService = empresaService;
            _tipoCargaService = tipoCargaService;
        }

        ~TransportesFormPresenter()
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

            _dgv.Columns["IdEmpresa"].Visible = false;
            _dgv.Columns["IdTipoCarga"].Visible = false;
            _dgv.Columns["IdTipoOperacion"].Visible = false;                       

            _dgv.Columns["NombreTipoOperacion"].HeaderText = "Tipo operación";
            _dgv.Columns["Matricula"].HeaderText = "Matrícula";
            _dgv.Columns["NombreEmpresa"].HeaderText = "Empresa";
            _dgv.Columns["NombreTipoCarga"].HeaderText = "Tipo carga";            

            _dgv.SelectionChanged += new EventHandler(dgv_SelectionChanged);
        }

        private async Task CargarDatosGrid()
        {
            TransportesForm.Cursor = Cursors.WaitCursor;


            listaTransportes = await _service.ObtenerListaPaginada(
                                                                    View.MatriculaFiltro,
                                                                    View.RemolqueFiltro,
                                                                    View.ConductorFiltro,
                                                                    View.EmpresaFiltro,                                                    
                                                                    View.TipoFiltro,
                                                                    View.TipoCargaFiltro,
                                                                    _pageNumber,
                                                                    _pageSize);
            _dgv.DataSource = listaTransportes.ToList();
            View.Pagina = string.Format("Página {0} de {1}", _pageNumber, listaTransportes.PageCount);

            View.PaginaPrimera = !listaTransportes.IsFirstPage;
            View.PaginaAnterior = listaTransportes.HasPreviousPage;
            View.PaginaSiguiente = listaTransportes.HasNextPage;
            View.PaginaUltima = !listaTransportes.IsLastPage;

            _dgv.ClearSelection();

            TransportesForm.Cursor = Cursors.Default;
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
            if (listaTransportes.HasPreviousPage)
            {
                Button btn = (Button)sender;
                btn.Enabled = false;
                _pageNumber = _pageNumber - 1;
                await CargarDatosGrid();
            }
        }

        public async void PaginaSiguiente(object sender, EventArgs e)
        {
            if (listaTransportes.HasNextPage)
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
            _pageNumber = listaTransportes.PageCount;
            await CargarDatosGrid();
        }

        public async void Buscar()
        {
            _pageNumber = 1;
            await CargarDatosGrid();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            TransporteDto data = DatoSeleccionado();

            View.HabilitarBotonesElemento(data != null);
        }

        public void ConfigurarComboEmpresas(ComboBox cmb)
        {
            List<EmpresaDto> empresas = _empresaService.ObtenerLista(true);            

            empresas.Insert(0, _empresaVacia);
             
            cmb.DataSource = empresas;
            cmb.DisplayMember = "Nombre";
            cmb.ValueMember = "IdEmpresa";
        }

        public void ConfigurarComboTipoCargas(ComboBox cmb)
        {
            _cmbTipoCargas = cmb;

            _tipoCargas = _tipoCargaService.ObtenerLista();

            CargarComboTipoCargas((byte)Enums.TipoOperacion.Carga);
        }

        private void CargarComboTipoCargas(byte tipoOperacion)
        {
            List<TipoCargaDto> tipoCargaDtos = _tipoCargas.Where(t => t.IdTipoOperacion == tipoOperacion & t.IdTipoCargaPadre == null).ToList();

            tipoCargaDtos.Insert(0, _tipoCargaVacio);

            _cmbTipoCargas.DataSource = tipoCargaDtos;
            _cmbTipoCargas.DisplayMember = "Nombre";
            _cmbTipoCargas.ValueMember = "IdTipoCarga";
        }

        public void CambiarTipoOperacion(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;

            if(rdb.Name == "rdbCarga")
            {
                CargarComboTipoCargas((byte)Enums.TipoOperacion.Carga);
            }
            else
            {
                CargarComboTipoCargas((byte)Enums.TipoOperacion.Descarga);
            }
        }

       
       
        private TransporteDto DatoSeleccionado()
        {
            TransporteDto data = null;

            if (_dgv.Rows.Count > 0 && _dgv.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in _dgv.SelectedRows)
                {
                    data = row.DataBoundItem as TransporteDto;
                }
            }

            return data;
        }

        private void LimpiarFormulario()
        {
            View.Matricula = "";
            View.Remolque = "";
            View.Carga = true;
            View.Conductor = "";
            View.Empresa = 0;
            View.TipoCarga = 0;

            _dgv.ClearSelection();
            _editando = false;
        }             

        public void Nuevo()
        {
            LimpiarFormulario();
            View.MostrarOcultarDetalle(true);
            View.MatriculaFocus();
        }

        public void Editar()
        {
            TransporteDto data = DatoSeleccionado();

            if (data != null)
            {
                View.Matricula = data.Matricula;
                View.Remolque = data.Remolque;
                View.Carga = (data.IdTipoOperacion == (byte)Enums.TipoOperacion.Carga);
                View.Descarga = (data.IdTipoOperacion == (byte)Enums.TipoOperacion.Descarga);
                View.Conductor = data.Conductor;
                View.Empresa = data.IdEmpresa == null ? 0 : data.IdEmpresa;
                View.TipoCarga = data.IdTipoCarga == null ? 0 : data.IdTipoCarga;
                _editando = true;
                View.MostrarOcultarDetalle(true);
                View.RemolqueFocus();
            }
        }

        public void CerrarFormulario()
        {
            View.MostrarOcultarDetalle(false);
        }

        public async void Eliminar(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            TransporteDto data = DatoSeleccionado();

            if (MessageBox.Show("¿Está seguro que desea eliminar el transporte " + data.Matricula + "?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    btn.Enabled = false;

                    TransportesForm.Cursor = Cursors.WaitCursor;

                    var result = _service.Eliminar(data);
                    if (result)
                    {
                        _pageNumber = 1;
                        await CargarDatosGrid();
                        LimpiarFormulario();
                        MessageBox.Show("Transporte eliminado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Debido a un error no se pudo eliminar el transporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    TransportesForm.Cursor = Cursors.Default;
                    btn.Enabled = true;
                }

            }

        }       

        public async void Guardar(object sender, EventArgs e)
        {            
            Button btn = (Button)sender;

            try
            {
                string matricula = String.Concat(View.Matricula.Where(c => !Char.IsWhiteSpace(c)));

                if (!_editando)
                {
                    if (string.IsNullOrWhiteSpace(matricula))
                    {
                        View.MatriculaFocus();
                        MessageBox.Show("La matrícula no puede estar vacía", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if(_service.CheckTransporteExiste(matricula))
                    {
                        View.MatriculaFocus();
                        MessageBox.Show("Ya existe un transporte para esta matrícula", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                btn.Enabled = false;

                TransportesForm.Cursor = Cursors.WaitCursor;

                TransporteDto data = new TransporteDto();

                if (_editando)
                {
                    data = DatoSeleccionado();
                }
                else
                {
                    data.Matricula = matricula;
                }
                
                data.Remolque = String.Concat(View.Remolque.Where(c => !Char.IsWhiteSpace(c)));
                data.IdTipoOperacion = (View.Carga ? (byte)Enums.TipoOperacion.Carga : (byte)Enums.TipoOperacion.Descarga);
                data.Conductor = View.Conductor;
                int empresa = (int)View.Empresa;
                if(empresa == 0)
                {
                    data.IdEmpresa = null;
                }
                else
                {
                    data.IdEmpresa = empresa;
                }

                int tipocarga = (int)View.TipoCarga;
                if(tipocarga == 0)
                {
                    data.IdTipoCarga = null;
                }
                else
                {
                    data.IdTipoCarga = tipocarga;
                }                               

                var result = _service.Guardar(data);
                if (result)
                {
                    await CargarDatosGrid();
                    LimpiarFormulario();
                    View.MostrarOcultarDetalle(false);
                    MessageBox.Show("Transporte guardado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debido a un error no se pudo guardar el transporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                TransportesForm.Cursor = Cursors.Default;
                btn.Enabled = true;
            }

        }

        public frmTransportes TransportesForm
        {
            get { return View as frmTransportes; }
        }

    }

    public interface IPresentTransportesForm : IPresent
    {
        frmTransportes TransportesForm { get; }

        void ConfigurarComboTipo(ComboBox cmb);

        void ConfigurarComboEmpresas(ComboBox cmb);

        void ConfigurarComboTipoCargas(ComboBox cmb);

        void ConfigurarGrid(DataGridView dgv);

        void CambiarTipoOperacion(object sender, EventArgs e);
                
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
