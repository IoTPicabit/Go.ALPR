﻿using System;
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
    public class TipoCargasFormPresenter: Presenter<IViewTipoCargasForm>, IPresentTipoCargasForm
    {
        private bool _editando = false;

        private DataGridView _dgv;

        private int _pageNumber = 1;
        private int _pageSize = 10;

        private IPagedList<TipoCargaDto> _listaTiposCarga;

        private ComboBox _cmbTipoCargasPadre;
        private TipoCargaDto _tipoCargaVacio = new TipoCargaDto { IdTipoCarga = 0, Nombre = "" };

        private readonly ITipoCargaService _service;
        private readonly IEmpresaService _empresaService;

        public TipoCargasFormPresenter(Func<IViewTipoCargasForm> viewFactory, ITipoCargaService service, IEmpresaService empresaService)
            : base(viewFactory)
        {
            _service = service;
            _empresaService = empresaService;
        }

        ~TipoCargasFormPresenter()
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

        public void ConfiguarComboTipoCargaPadre(ComboBox cmb)
        {
            _cmbTipoCargasPadre = cmb;
        }

        private void CargarComboTipoCargasPadre(int idTipoCarga, int NumeroSubproductos)
        {
            _cmbTipoCargasPadre.SelectedIndexChanged -= new EventHandler(cmbTipoCargasPadre_SelectedIndexChanged);

            List<TipoCargaDto> tipoCargaDtos;
            if (NumeroSubproductos == 0)
            {
                tipoCargaDtos = _service.ObtenerListaPadres(idTipoCarga);                
            }
            else
            {
                tipoCargaDtos = new List<TipoCargaDto>();
            }

            tipoCargaDtos.Insert(0, _tipoCargaVacio);

            _cmbTipoCargasPadre.DataSource = tipoCargaDtos;
            _cmbTipoCargasPadre.DisplayMember = "Nombre";
            _cmbTipoCargasPadre.ValueMember = "IdTipoCarga";

            _cmbTipoCargasPadre.SelectedIndexChanged += new EventHandler(cmbTipoCargasPadre_SelectedIndexChanged);
        }

        public void ConfigurarComboExpedidores(ComboBox cmb)
        {
            List<EmpresaDto> empresas = _empresaService.ObtenerExpedidores();            

            empresas.Insert(0, new EmpresaDto { IdEmpresa = 0, Nombre = "" });

            cmb.DataSource = empresas;
            cmb.DisplayMember = "Nombre";
            cmb.ValueMember = "IdEmpresa";

        }

        private void cmbTipoCargasPadre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((int)_cmbTipoCargasPadre.SelectedValue == _tipoCargaVacio.IdTipoCarga)
            {
                View.Carga = true;
                View.HabilitarTipoOperacion(true);
            }
            else
            {
                TipoCargaDto data = (TipoCargaDto)_cmbTipoCargasPadre.SelectedItem;
                View.Carga = (data.IdTipoOperacion == (byte)Enums.TipoOperacion.Carga);
                View.Descarga = (data.IdTipoOperacion == (byte)Enums.TipoOperacion.Descarga);
                View.HabilitarTipoOperacion(false);
            }
        }

        public async void ConfigurarGrid(DataGridView dgv)
        { 
            _dgv = dgv;

            await CargarDatosGrid();

            _dgv.Columns["IdTipoCarga"].Visible = false;
            _dgv.Columns["IdTipoOperacion"].Visible = false;
            _dgv.Columns["DenominacionAdr"].Visible = false;
            _dgv.Columns["IdTipoCargaPadre"].Visible = false;
            _dgv.Columns["IdEmpresaExpedicion"].Visible = false;
            _dgv.Columns["NombreEmpresaExpedicion"].Visible = false;

            _dgv.Columns["CodigoLer"].HeaderText = "Código LER";
            _dgv.Columns["NombreTipoOperacion"].HeaderText = "Tipo operación";
            _dgv.Columns["NombrePadre"].HeaderText = "Subproducto de";
                       

            _dgv.SelectionChanged += new EventHandler(dgv_SelectionChanged);
        }


        private async Task CargarDatosGrid()
        {
            TipoCargasForm.Cursor = Cursors.WaitCursor;

            _listaTiposCarga = await _service.ObtenerListaPaginada(View.NombreFiltro,
                                                                    View.TipoFiltro,
                                                                    View.LERFiltro,
                                                                    View.ADRFiltro,                                                                    
                                                                    _pageNumber,
                                                                    _pageSize);
            _dgv.DataSource = _listaTiposCarga.ToList();
            View.Pagina = string.Format("Página {0} de {1}", _pageNumber, _listaTiposCarga.PageCount);

            View.PaginaPrimera = !_listaTiposCarga.IsFirstPage;
            View.PaginaAnterior = _listaTiposCarga.HasPreviousPage;
            View.PaginaSiguiente = _listaTiposCarga.HasNextPage;
            View.PaginaUltima = !_listaTiposCarga.IsLastPage;

            _dgv.ClearSelection();

            TipoCargasForm.Cursor = Cursors.Default;
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
            if (_listaTiposCarga.HasPreviousPage)
            {
                Button btn = (Button)sender;
                btn.Enabled = false;
                _pageNumber = _pageNumber - 1;
                await CargarDatosGrid();
            }
        }

        public async void PaginaSiguiente(object sender, EventArgs e)
        {
            if (_listaTiposCarga.HasNextPage)
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
            _pageNumber = _listaTiposCarga.PageCount;
            await CargarDatosGrid();
        }

        public async void Buscar()
        {
            _pageNumber = 1;
            await CargarDatosGrid();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            TipoCargaDto data = DatoSeleccionado();            

            View.HabilitarBotonesElemento(data != null);
        }

        private TipoCargaDto DatoSeleccionado()
        {
            TipoCargaDto data = null;

            if (_dgv.Rows.Count > 0 && _dgv.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in _dgv.SelectedRows)
                {
                    data = row.DataBoundItem as TipoCargaDto;
                }
            }

            return data;
        }

        private void LimpiarFormulario()
        {
            View.Nombre = "";
            View.CodigoLer = "";
            View.DenominacionAdr = "";
            View.Carga = true;
            View.TipoCargaPadre = 0;
            View.EmpresaExpedicion = 0;
            View.HabilitarTipoOperacion(true);
            _dgv.ClearSelection();
            _editando = false;
        }

        public void Nuevo()
        {
            LimpiarFormulario();
            CargarComboTipoCargasPadre(0, 0);
            View.MostrarOcultarDetalle(true);
            View.NombreFocus();
        }

        public void Editar()
        {
            TipoCargaDto data = DatoSeleccionado();

            if (data != null)
            {
                CargarComboTipoCargasPadre(data.IdTipoCarga, data.Subproductos.Count);
                View.Nombre = data.Nombre;
                View.Carga = (data.IdTipoOperacion == (byte)Enums.TipoOperacion.Carga);
                View.Descarga = (data.IdTipoOperacion == (byte)Enums.TipoOperacion.Descarga);
                View.CodigoLer = data.CodigoLer;
                View.DenominacionAdr = data.DenominacionAdr;
                View.TipoCargaPadre = data.IdTipoCargaPadre == null ? 0 : data.IdTipoCargaPadre;
                View.EmpresaExpedicion = data.IdEmpresaExpedicion == null ? 0 : data.IdEmpresaExpedicion;

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

            TipoCargaDto data = DatoSeleccionado();

            if (MessageBox.Show("¿Está seguro que desea eliminar el tipo de carga " + data.Nombre + "?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                try
                {
                    btn.Enabled = false;

                    TipoCargasForm.Cursor = Cursors.WaitCursor;

                    var result = await _service.Eliminar(data);
                    if (result)
                    {
                        View.DatosModificados = true;
                        _pageNumber = 1;
                        await CargarDatosGrid();
                        LimpiarFormulario();
                        MessageBox.Show("Tipo de carga eliminado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Debido a un error no se pudo eliminar el tipo de carga", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    TipoCargasForm.Cursor = Cursors.Default;
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

                TipoCargasForm.Cursor = Cursors.WaitCursor;

                TipoCargaDto data = new TipoCargaDto();

                if (_editando)
                {
                    data = DatoSeleccionado();
                }

                data.Nombre = View.Nombre;
                data.CodigoLer = View.CodigoLer;
                data.DenominacionAdr = View.DenominacionAdr;
                data.IdTipoOperacion = (View.Carga ? (byte)Enums.TipoOperacion.Carga : (byte)Enums.TipoOperacion.Descarga);
                data.IdTipoCargaPadre = (int)View.TipoCargaPadre;
                data.IdEmpresaExpedicion = (int)View.EmpresaExpedicion;

                var result = await _service.Guardar(data);
                if (result)
                {
                    View.DatosModificados = true;
                    await CargarDatosGrid();
                    LimpiarFormulario();
                    View.MostrarOcultarDetalle(false);
                    MessageBox.Show("Tipo de carga guardado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debido a un error no se pudo guardar el tipo de carga", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                TipoCargasForm.Cursor = Cursors.Default;
                btn.Enabled = true;
            }

        }

        public frmTipoCargas TipoCargasForm
        {
            get { return View as frmTipoCargas; }
        }

    }

    public interface IPresentTipoCargasForm : IPresent
    {
        frmTipoCargas TipoCargasForm { get; }

        void ConfigurarGrid(DataGridView dgv);

        void ConfigurarComboTipo(ComboBox cmb);
        void ConfiguarComboTipoCargaPadre(ComboBox cmb);
        void ConfigurarComboExpedidores(ComboBox cmb);

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
