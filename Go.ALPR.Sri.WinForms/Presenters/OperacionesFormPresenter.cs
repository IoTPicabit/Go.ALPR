using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using MiniMVPNetCore;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using X.PagedList;

using Go.ALPR.Sri.Common;
using Go.ALPR.Sri.Business;
using Go.ALPR.Sri.Printer;
using System.IO;

namespace Go.ALPR.Sri.WinForms
{
    public class OperacionesFormPresenter: Presenter<IViewOperacionesForm>, IPresentOperacionesForm
    {
        private int _pageNumber = 1;
        private int _pageSize = 10;

        private IPagedList<OperacionDto> listaOperaciones;

        private DataGridView _dgv;

        private string _printerName;
        private bool _correoHabilitado = false;

        private readonly IConfiguration _config;
        private readonly IServiceProvider _serviceProvider;
        private readonly IOperacionService _service;
        private readonly IPdfPrintService _pdfPrinterService;
        private readonly IClienteSMTP _clienteSMTP;

        public OperacionesFormPresenter(Func<IViewOperacionesForm> viewFactory,
                                        IConfiguration configuration,
                                        IServiceProvider serviceProvider,
                                        IPdfPrintService pdfPrinterService,
                                        IClienteSMTP clienteSMTP,
                                        IOperacionService service)
            : base(viewFactory)
        {
            _service = service;
            _config = configuration;
            _serviceProvider = serviceProvider;
            _pdfPrinterService = pdfPrinterService;
            _clienteSMTP = clienteSMTP;
        }

        ~OperacionesFormPresenter()
        {
            _dgv.SelectionChanged -= new EventHandler(dgv_SelectionChanged);
            _dgv.Dispose();
        }        
       
        public string NombreImpresora
        {           
            set
            {
                _printerName = value;
            }
        }

        public bool ImpresionHabilitada
        {
            get
            {
                return _printerName != null;
            }
        }

        public bool CorreoHabilitado
        {
            get
            {
                return _correoHabilitado;
            }
            set
            {
                _correoHabilitado = value;
            }
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

            _dgv.Columns["IdTipoOperacion"].Visible = false;
            _dgv.Columns["MatriculaEntradaManual"].Visible = false;
            _dgv.Columns["MotivoMatriculaEntradaManual"].Visible = false;
            _dgv.Columns["PesoEntradaManual"].Visible = false;
            _dgv.Columns["MotivoPesoEntradaManual"].Visible = false;
            _dgv.Columns["UsuarioEntrada"].Visible = false;
            _dgv.Columns["MatriculaSalidaManual"].Visible = false;
            _dgv.Columns["MotivoMatriculaSalidaManual"].Visible = false;
            _dgv.Columns["PesoSalidaManual"].Visible = false;
            _dgv.Columns["MotivoPesoSalidaManual"].Visible = false;
            _dgv.Columns["UsuarioSalida"].Visible = false;
            _dgv.Columns["FirmaProductor"].Visible = false;
            _dgv.Columns["FirmaTransportista"].Visible = false;
            _dgv.Columns["FirmaProductorImagen"].Visible = false;
            _dgv.Columns["FirmaConductorImagen"].Visible = false;

            _dgv.Columns["IdEmpresa"].Visible = false;
            _dgv.Columns["EmpresaDireccion"].Visible = false;
            _dgv.Columns["EmpresaCif"].Visible = false;
            _dgv.Columns["EmpresaNima"].Visible = false;
            _dgv.Columns["EmpresaContactos"].Visible = false;
            _dgv.Columns["IdTipoCarga"].Visible = false;
            _dgv.Columns["CodigoLer"].Visible = false;
            _dgv.Columns["DenominacionAdr"].Visible = false;

            _dgv.Columns["OrigenDireccion"].Visible = false;
            _dgv.Columns["OrigenCif"].Visible = false;
            _dgv.Columns["OrigenNima"].Visible = false;
            _dgv.Columns["DestinoDireccion"].Visible = false;
            _dgv.Columns["DestinoCif"].Visible = false;
            _dgv.Columns["DestinoNima"].Visible = false;

            _dgv.Columns["Expedidor"].Visible = false;
            _dgv.Columns["ExpedidorDireccion"].Visible = false;
            _dgv.Columns["ExpedidorCif"].Visible = false;


            _dgv.Columns["IdOperacion"].HeaderText = "Núm.";
            _dgv.Columns["NombreTipoOperacion"].HeaderText = "Tipo";
            _dgv.Columns["Matricula"].HeaderText = "Matrícula";
            _dgv.Columns["FechaHoraEntrada"].HeaderText = "Entrada";
            _dgv.Columns["FechaHoraEntrada"].Width = 160;
            _dgv.Columns["PesoEntrada"].HeaderText = "P.Entrada";
            _dgv.Columns["FechaHoraSalida"].HeaderText = "Salida";
            _dgv.Columns["FechaHoraSalida"].Width = 160;
            _dgv.Columns["PesoSalida"].HeaderText = "P.Salida";
            _dgv.Columns["TipoCarga"].HeaderText = "Carga";

            _dgv.SelectionChanged += new EventHandler(dgv_SelectionChanged);
        }
          

        private async Task CargarDatosGrid()
        {
            OperacionesForm.Cursor = Cursors.WaitCursor;

            int Numero = 0;
            if(View.Numero.Length > 0)
            {
                Numero = int.Parse(View.Numero);
            }

            listaOperaciones = await _service.ObtenerListaPaginada(Numero,
                                                                    View.Matricula,
                                                                    View.Remolque,
                                                                    View.Conductor,
                                                                    View.Empresa,
                                                                    View.Tipo,
                                                                    View.FechaInicio,
                                                                    View.FechaFin,
                                                                    View.TipoCarga,
                                                                    _pageNumber, 
                                                                    _pageSize);
            _dgv.DataSource = listaOperaciones.ToList();
            View.Pagina = string.Format("Página {0} de {1}", _pageNumber, listaOperaciones.PageCount);

            View.PaginaPrimera = !listaOperaciones.IsFirstPage;
            View.PaginaAnterior = listaOperaciones.HasPreviousPage;
            View.PaginaSiguiente = listaOperaciones.HasNextPage;
            View.PaginaUltima = !listaOperaciones.IsLastPage;

            _dgv.ClearSelection();

            OperacionesForm.Cursor = Cursors.Default;
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
            if (listaOperaciones.HasPreviousPage)
            {
                Button btn = (Button)sender;
                btn.Enabled = false;
                _pageNumber = _pageNumber - 1;
                await CargarDatosGrid();
            }
        }

        public async void PaginaSiguiente(object sender, EventArgs e)
        {
            if (listaOperaciones.HasNextPage)
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
            _pageNumber = listaOperaciones.PageCount;
            await CargarDatosGrid();
        }

        public async void Buscar()
        {
            _pageNumber = 1;
            await CargarDatosGrid();
        }

        public async void ImprimirAlbaran()
        {
            OperacionDto data = DatoSeleccionado();
            
            if (data != null)
            {
                OperacionesForm.Cursor = Cursors.WaitCursor;

                string rutaGuardadoAlbaranes = _config.GetSection("RutaGuardadoAlbaranes").Value;
                if (!rutaGuardadoAlbaranes.EndsWith(@"\"))
                {
                    rutaGuardadoAlbaranes = rutaGuardadoAlbaranes + @"\";
                }

                var pdfBytesAlbaran = await _service.ObtenerAlbaran(data.IdOperacion);

                if (pdfBytesAlbaran != null)
                {
                    
                    string nombreArchivo = string.Format("{0}Operacion_{1}.pdf", rutaGuardadoAlbaranes, data.IdOperacion);

                    File.WriteAllBytes(nombreArchivo, pdfBytesAlbaran);

                    try
                    {
                        MemoryStream stream = new MemoryStream(pdfBytesAlbaran);
                        _pdfPrinterService.Print(stream, _printerName);
                    }
                    catch
                    {
                        MessageBox.Show("Error al imprimir el albarán. Revise el log para mas detalles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Error al generar el albarán. Revise el log para mas detalles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                var pdfBytesCarta = await _service.ObtenerCartaPorte(data.IdOperacion);

                if (pdfBytesCarta != null)
                {
                    if(pdfBytesCarta.Length > 0)
                    {                        
                        string nombreArchivo = string.Format("{0}CartaPorte_{1}.pdf", rutaGuardadoAlbaranes, data.IdOperacion);

                        File.WriteAllBytes(nombreArchivo, pdfBytesCarta);

                        try
                        {
                            MemoryStream stream = new MemoryStream(pdfBytesCarta);
                            _pdfPrinterService.Print(stream, _printerName);
                        }
                        catch
                        {
                            MessageBox.Show("Error al imprimir la carta de porte. Revise el log para mas detalles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }                    

                }
                else
                {
                    MessageBox.Show("Error al generar la carta de porte. Revise el log para mas detalles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                OperacionesForm.Cursor = Cursors.Default;
            }            
        }

        public async void GuardarAlbaran()
        {
            OperacionDto data = DatoSeleccionado();            

            if (data != null)
            {
                OperacionesForm.Cursor = Cursors.WaitCursor;

                var pdfBytesAlbaran = await _service.ObtenerAlbaran(data.IdOperacion);
                
                if (pdfBytesAlbaran != null)
                {
                    string nombreArchivoAlbaran = SolicitarNombreArchivo(string.Format("Operacion_{0}.pdf", data.IdOperacion));
                    if (nombreArchivoAlbaran != "")
                    {
                        File.WriteAllBytes(nombreArchivoAlbaran, pdfBytesAlbaran);
                    }
                }
                else
                {
                    MessageBox.Show("Error al generar el albarán. Revise el log para mas detalles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                var pdfBytesCarta = await _service.ObtenerCartaPorte(data.IdOperacion);

                if (pdfBytesCarta != null)
                {
                    if (pdfBytesCarta.Length > 0)
                    {
                        string nombreArchivoCarta = SolicitarNombreArchivo(string.Format("CartaPorte_{0}.pdf", data.IdOperacion));
                        if (nombreArchivoCarta != "")
                        {
                            File.WriteAllBytes(nombreArchivoCarta, pdfBytesCarta);
                        } 
                    }
                }
                else
                {
                    MessageBox.Show("Error al generar la carta de porte. Revise el log para mas detalles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                OperacionesForm.Cursor = Cursors.Default;
            }
        }

        public async void EnviarAlbaran()
        {
            OperacionDto data = DatoSeleccionado();

            if (data != null)
            {
                OperacionesForm.Cursor = Cursors.WaitCursor;

                var contactos = await _service.ObtenerListaEmails(data.IdOperacion);

                if(contactos.Count > 0)
                {
                    var pdf = await _service.ObtenerAlbaran(data.IdOperacion);

                    if (pdf != null)
                    {
                        string nombreArchivo = string.Format("Operacion_{0}.pdf", data.IdOperacion);

                        var resultado = await _clienteSMTP.EnviarAlbaran(nombreArchivo, pdf, contactos);

                        if (resultado)
                        {  
                            MessageBox.Show("Se envió el albarán correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Se produjo un error al enviar el correo electrónico. Consulte el log para más detallles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al generar el albarán. Revise el log para mas detalles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No existen contactos a los que enviar el albarán", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                

                OperacionesForm.Cursor = Cursors.Default;
            }
        }


        public void MostrarDetalle()
        {
            OperacionDto data = DatoSeleccionado();

            if (data != null)
            {
                FotosOperacionDto fotos = _service.ObtenerFotosOperacion(data.IdOperacion);

                if (fotos.Camara1Entrada != null && fotos.Camara1Entrada != "" && File.Exists(fotos.Camara1Entrada))
                {
                    View.Camara1Entrada = fotos.Camara1Entrada;
                }
                else
                {
                    View.Camara1Entrada = null;
                }

                if (fotos.Camara2Entrada != null && fotos.Camara2Entrada != "" && File.Exists(fotos.Camara2Entrada))
                {
                    View.Camara2Entrada = fotos.Camara2Entrada;
                }
                else
                {
                    View.Camara2Entrada = null;
                }

                if (fotos.Camara3Entrada != null && fotos.Camara3Entrada != "" && File.Exists(fotos.Camara3Entrada))
                {
                    View.Camara3Entrada = fotos.Camara3Entrada;
                }
                else
                {
                    View.Camara3Entrada = null;
                }

                if (fotos.Camara1Salida != null && fotos.Camara1Salida != "" && File.Exists(fotos.Camara1Salida))
                {
                    View.Camara1Salida = fotos.Camara1Salida;
                }
                else
                {
                    View.Camara1Salida = null;
                }

                if (fotos.Camara2Salida != null && fotos.Camara2Salida != "" && File.Exists(fotos.Camara2Salida))
                {
                    View.Camara2Salida = fotos.Camara2Salida;
                }
                else
                {
                    View.Camara2Salida = null;
                }

                if (fotos.Camara3Salida != null && fotos.Camara3Salida != "" && File.Exists(fotos.Camara3Salida))
                {
                    View.Camara3Salida = fotos.Camara3Salida;
                }
                else
                {
                    View.Camara3Salida = null;
                }


                View.MostrarOcultarDetalle(true);

            }
               
        }

        public void OcultarDetalle()
        {

            View.MostrarOcultarDetalle(false);
        }

        private string SolicitarNombreArchivo(string defaultName)
        {
            SaveFileDialog saveAlbaran = new SaveFileDialog();
            saveAlbaran.Filter = "Archivo Pdf|*.pdf";
            saveAlbaran.Title = "Guardar albarán como...";
            saveAlbaran.DefaultExt = "pdf";
            saveAlbaran.FileName = defaultName;
            saveAlbaran.ShowDialog();
            return saveAlbaran.FileName;
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            OperacionDto data = DatoSeleccionado();

            View.HabilitarBotonesElemento(data != null);           
        }

        private OperacionDto DatoSeleccionado()
        {
            OperacionDto data = null;

            if (_dgv.Rows.Count > 0 && _dgv.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in _dgv.SelectedRows)
                {
                    data = row.DataBoundItem as OperacionDto;
                }
            }

            return data;
        }

        public frmOperaciones OperacionesForm
        {
            get { return View as frmOperaciones; }
        }

        public void AmpliarFotoCamara1Entrada(object sender, EventArgs e)
        {
            if (((PictureBox)sender).ImageLocation == null)
            {
                return;
            }

            var frm = _serviceProvider.GetRequiredService<frmPicture>();

            frm.Titulo = "Cámara 1";
            frm.Path = ((PictureBox)sender).ImageLocation;

            frm.ShowDialog();
        }

        public void AmpliarFotoCamara2Entrada(object sender, EventArgs e)
        {
            if (((PictureBox)sender).ImageLocation == null)
            {
                return;
            }

            var frm = _serviceProvider.GetRequiredService<frmPicture>();

            frm.Titulo = "Cámara 2";
            frm.Path = ((PictureBox)sender).ImageLocation;

            frm.ShowDialog();
        }

        public void AmpliarFotoCamara3Entrada(object sender, EventArgs e)
        {
            if (((PictureBox)sender).ImageLocation == null)
            {
                return;
            }

            var frm = _serviceProvider.GetRequiredService<frmPicture>();

            frm.Titulo = "Cámara 3";
            frm.Path = ((PictureBox)sender).ImageLocation;

            frm.ShowDialog();
        }

        public void AmpliarFotoCamara1Salida(object sender, EventArgs e)
        {
            if (((PictureBox)sender).ImageLocation == null)
            {
                return;
            }

            var frm = _serviceProvider.GetRequiredService<frmPicture>();

            frm.Titulo = "Cámara 1";
            frm.Path = ((PictureBox)sender).ImageLocation;

            frm.ShowDialog();
        }

        public void AmpliarFotoCamara2Salida(object sender, EventArgs e)
        {
            if (((PictureBox)sender).ImageLocation == null)
            {
                return;
            }

            var frm = _serviceProvider.GetRequiredService<frmPicture>();

            frm.Titulo = "Cámara 2";
            frm.Path = ((PictureBox)sender).ImageLocation;

            frm.ShowDialog();
        }

        public void AmpliarFotoCamara3Salida(object sender, EventArgs e)
        {
            if (((PictureBox)sender).ImageLocation == null)
            {
                return;
            }

            var frm = _serviceProvider.GetRequiredService<frmPicture>();

            frm.Titulo = "Cámara 3";
            frm.Path = ((PictureBox)sender).ImageLocation;

            frm.ShowDialog();
        }

    }

    public interface IPresentOperacionesForm : IPresent
    {
        frmOperaciones OperacionesForm { get; }

        void ConfigurarComboTipo(ComboBox cmb);

        void ConfigurarGrid(DataGridView dgv);

        void ConfiguraComboTamanioPagina(ComboBox cmb);
        void CambioTamanioPagina(int _pageSize);
        void PaginaPrimera(object sender, EventArgs e);
        void PaginaAnterior(object sender, EventArgs e);
        void PaginaSiguiente(object sender, EventArgs e);
        void PaginaUltima(object sender, EventArgs e);

        void Buscar();
        void ImprimirAlbaran();
        void GuardarAlbaran();
        void EnviarAlbaran();

        void MostrarDetalle();
        void OcultarDetalle();

        string NombreImpresora { set; }

        bool CorreoHabilitado { get; set; }
        bool ImpresionHabilitada { get; }


        void AmpliarFotoCamara1Entrada(object sender, EventArgs e);
        void AmpliarFotoCamara2Entrada(object sender, EventArgs e);
        void AmpliarFotoCamara3Entrada(object sender, EventArgs e);
        void AmpliarFotoCamara1Salida(object sender, EventArgs e);
        void AmpliarFotoCamara2Salida(object sender, EventArgs e);
        void AmpliarFotoCamara3Salida(object sender, EventArgs e);

    }
}
