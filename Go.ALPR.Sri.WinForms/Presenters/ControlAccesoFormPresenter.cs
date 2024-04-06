using System;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections.Generic;

using X.PagedList;

using System.Windows.Forms;
using MiniMVPNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using Go.ALPR.Sri.Business;
using Go.ALPR.Sri.Common;

namespace Go.ALPR.Sri.WinForms
{
    public class ControlAccesoFormPresenter: Presenter<IViewControlAccesoForm>, IPresentControlAccesoForm
    {

        private int _pageNumber = 1;
        private int _pageSize = 10;

        private IPagedList<AccesoDto> listaAccesos;

        private DataGridView _dgv;

        private readonly IConfiguration _config;
        private readonly IServiceProvider _serviceProvider;
        private readonly IControlAccesoFormBusiness _business;
        private readonly UsuarioSesionDto _usuarioSesion;      

        private MainFormDto _mainData;

        private IProgress<string> _progresoIdentificacion;
        private Timer _temporizadorLimpiaProgreso;

        public ControlAccesoFormPresenter(Func<IViewControlAccesoForm> viewFactory,
                                    IConfiguration configuration,
                                    IServiceProvider serviceProvider,
                                    IControlAccesoFormBusiness business,
                                    UsuarioSesionDto usuarioSesion)
            : base(viewFactory)
        {
            _config = configuration;
            _serviceProvider = serviceProvider;
            _business = business;
            _usuarioSesion = usuarioSesion;
        }

        ~ControlAccesoFormPresenter()
        {
            _mainData = null;
            _progresoIdentificacion = null;
            _temporizadorLimpiaProgreso.Tick -= LimpiarProgresoIdentificacion;
            _temporizadorLimpiaProgreso.Dispose();
            _dgv.Dispose();
        }

        private void ShowToast(string msg, frmMessage.enmType type)
        {
            var frm = _serviceProvider.GetRequiredService<frmMessage>();
            frm.showAlert(msg, type);
        }

        public frmControlAcceso MainForm
        {
            get { return View as frmControlAcceso; }
        }

        public void InicializarFormulario()
        {
            _progresoIdentificacion = new Progress<string>(MostrarProgresoIdentificacion);
            
            _temporizadorLimpiaProgreso = new Timer();
            _temporizadorLimpiaProgreso.Tick += LimpiarProgresoIdentificacion;
            _temporizadorLimpiaProgreso.Interval = 5000;

            _business.Inicializar();      

            string urlCamara1 = _config.GetSection("UrlCamaraStreaming1").Value;
            if(urlCamara1 != "")
            {
                View.IniciarCamara1(urlCamara1);
            }
            else
            {
                View.OcultarCamara1();
            }

            string urlCamara2 = _config.GetSection("UrlCamaraStreaming2").Value;
            if (urlCamara2 != "")
            {
                View.IniciarCamara2(urlCamara2);
            }
            else
            {
                View.OcultarCamara2();
            }

            string urlCamara3 = _config.GetSection("UrlCamaraStreaming3").Value;
            if (urlCamara3 != "")
            {
                View.IniciarCamara3(urlCamara3);
            }
            else
            {
                View.OcultarCamara3();
            }

            MostrarProgresoIdentificacion("");
        }

        public void EstablecerFechaHora()
        {
            DateTime fechaHora = DateTime.Now;
            View.Fecha = fechaHora.ToShortDateString();
            View.Hora = fechaHora.ToShortTimeString();
        }

        public void EstablecerOperario()
        {
            View.Operario = _usuarioSesion.Nombre;
        }

        public void SalirAplicacion()
        {           
            if (MessageBox.Show("¿Está seguro que desea salir de la aplicación?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }            
        }

        public void CambiarUsuario()
        {
            var loginForm = _serviceProvider.GetRequiredService<LoginFormPresenter>();
            loginForm.CambioUsuario = true;
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                EstablecerOperario();
            }
        }

        public void CambiarClave()
        {
            var cambiarClaveForm = _serviceProvider.GetRequiredService<CambiarClaveFormPresenter>();
            if (cambiarClaveForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Clave cambiada", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }               

        public void GestionLocalizaciones()
        {
            var frm = _serviceProvider.GetRequiredService<LocalizacionesFormPresenter>();
            frm.ShowDialog();
        }

        public void GestionEmpresas()
        {
            var frm = _serviceProvider.GetRequiredService<EmpresasFormPresenter>();
            frm.ShowDialog();
        }

        public void GestionTipoCargas()
        {
            var frm = _serviceProvider.GetRequiredService<TipoCargasFormPresenter>();
            frm.ShowDialog();
        }

        public void GestionTransportes()
        {
            var frm = _serviceProvider.GetRequiredService<TransportesFormPresenter>();
            frm.ShowDialog();
        }

        public async Task NuevaEntrada(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            try
            {
                MainForm.Cursor = Cursors.WaitCursor;
                btn.Enabled = false;

                View.LimpiarFormulario();

                await NuevaIdentificacion((byte)Enums.TipoIdentificacion.Entrada, _progresoIdentificacion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MainForm.Cursor = Cursors.Default;
                btn.Enabled = true;
            }

        }

        private void MostrarProgresoIdentificacion(string progreso)
        {
            View.ProgresoIdentificacion = progreso;
        }               

        private void LimpiarProgresoIdentificacion(object sender, EventArgs e)
        {
            View.ProgresoIdentificacion = "";            
        }

        private async Task NuevaIdentificacion(byte tipo, IProgress<string> progreso)
        {
            try
            {
                MostrarProgresoIdentificacion("Iniciando identificación...");
                await Task.Delay(500);                               

                if (tipo == (byte)Enums.TipoIdentificacion.Entrada)
                {
                    _mainData = await _business.NuevaEntrada(progreso);
                }               

                if (_mainData.Estado < (byte)Enums.TipoEstado.Correcto)
                {
                    //Si se producen los timeout
                    if (_mainData.Estado == (byte)Enums.TipoEstado.Inicial)
                    {
                        MessageBox.Show("El sistema de visión no respondió en el tiempo establecido. Posiblemente no esté funcionando", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);                        
                    }
                    else
                    {
                        MessageBox.Show("El sistema de visión no pudo realizar la identificación del transporte", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }                    
                }
                else
                {
                    //Si la identificación fue correcta o fallida o sistema apagado
                    ProcesarIdentificacion();                    
                }

                MostrarProgresoIdentificacion("Identificación finalizada");
                _temporizadorLimpiaProgreso.Start();

                if(View.FechaFin.Date == DateTime.Now.Date)
                {
                    await CargarDatosGrid();
                }


            }
            catch
            {
                MostrarProgresoIdentificacion("");               

                throw new Exception("Se ha producido un error inesperado. Consulte el log para más información");
            }
        }
               
        private void ProcesarIdentificacion()
        {
            if (_mainData.Estado != (byte)Enums.TipoEstado.SistemaApagado)
            {
                View.Matricula = _mainData.Transporte.Matricula;
            }                       

            if (_mainData.Estado == (byte)Enums.TipoEstado.Fallo)
            {
                View.IdentificacionIncorrecta(_mainData.Transporte.Matricula);
                ShowToast("El sistema de visión no identificó de forma correcta al transporte", frmMessage.enmType.Warning);                
            }
            else
            {
                if (_mainData.TransporteReconocido)
                {
                    View.IdentificacionOk(_mainData.Transporte.Matricula);
                    MostrarDatosFormularioIdentificacion();
                }
                else
                {
                    View.IdentificacionIncorrecta(_mainData.Transporte.Matricula);
                    View.LimpiarFormularioIdentificacion();
                }
            }                
                      
        } 

        private void MostrarDatosFormularioIdentificacion()
        {
            View.Empresa = _mainData.Transporte.Empresa.Nombre;
            View.Conductor = _mainData.Transporte.Conductor;            
        }             
       
 
        public void CapturaPantalla()
        {
            try
            {
                //obtenemos la resolución de pantalla
                Rectangle tamanioFormulario = Screen.GetBounds(MainForm.ClientRectangle);

                //creamos un Bitmap del tamaño de nuestra pantalla
                Bitmap objBitmap = new Bitmap(tamanioFormulario.Width, tamanioFormulario.Height);

                //creamos el gráifco en base al Bitmap objBitmap 
                Graphics objGrafico = Graphics.FromImage(objBitmap);

                //transferimos la captura al objeto objGrafico en 
                //base a las medidas del bitmap
                objGrafico.CopyFromScreen(0, 0, 0, 0, objBitmap.Size);

                //liberamos el gráfico de memoria                            
                objGrafico.Flush();

                string defaultName = string.Format("Captura_{0}.jpg", DateTime.Now.ToString("yyyyMMddHHmmss"));

                SaveFileDialog saveCaptura = new SaveFileDialog();
                saveCaptura.Filter = "Archivo Jpeg|*.jpg";
                saveCaptura.Title = "Guardar captura como...";
                saveCaptura.DefaultExt = "jpg";
                saveCaptura.FileName = defaultName;
                if (saveCaptura.ShowDialog() == DialogResult.OK)
                {
                    string nombreArchivo = saveCaptura.FileName;
                    if (nombreArchivo != "")
                    {
                        objBitmap.Save(nombreArchivo);
                    }
                }

            }
            catch
            {

            }
            
        }


        public void ConfigurarComboAcceso(ComboBox cmb)
        {
            Dictionary<int, string> listaTipos = new Dictionary<int, string>();
            listaTipos.Add(int.MinValue, "Ambos");
            listaTipos.Add(0, "No permitido");
            listaTipos.Add(1, "Permitido");

            cmb.DataSource = new BindingSource(listaTipos, null);
            cmb.DisplayMember = "Value";
            cmb.ValueMember = "Key";
        }


        public async void ConfigurarGrid(DataGridView dgv)
        {
            _dgv = dgv;

            await CargarDatosGrid();

            _dgv.Columns["Id"].Visible = false;
            _dgv.Columns["Tipo"].Visible = false;
            _dgv.Columns["Estado"].Visible = false;
            _dgv.Columns["EstadoNombre"].Visible = false;
            _dgv.Columns["Resultado"].Visible = false;

            _dgv.Columns["ResultadoNombre"].HeaderText = "Acceso";
            _dgv.Columns["Matricula"].HeaderText = "Matrícula";
        }

        private async Task CargarDatosGrid()
        {
            MainForm.Cursor = Cursors.WaitCursor;

            
            listaAccesos = await _business.ObtenerListaAccesos(View.FechaInicio,
                                                                View.FechaFin,
                                                                View.MatriculaFiltro,
                                                                View.AccesoFiltro,
                                                                _pageNumber,
                                                                _pageSize);
            _dgv.DataSource = listaAccesos.ToList();
            View.Pagina = string.Format("Página {0} de {1}", _pageNumber, listaAccesos.PageCount);

            View.PaginaPrimera = !listaAccesos.IsFirstPage;
            View.PaginaAnterior = listaAccesos.HasPreviousPage;
            View.PaginaSiguiente = listaAccesos.HasNextPage;
            View.PaginaUltima = !listaAccesos.IsLastPage;

            _dgv.ClearSelection();

            MainForm.Cursor = Cursors.Default;
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
            if (listaAccesos.HasPreviousPage)
            {
                Button btn = (Button)sender;
                btn.Enabled = false;
                _pageNumber = _pageNumber - 1;
                await CargarDatosGrid();
            }
        }

        public async void PaginaSiguiente(object sender, EventArgs e)
        {
            if (listaAccesos.HasNextPage)
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
            _pageNumber = listaAccesos.PageCount;
            await CargarDatosGrid();
        }

        public async void Buscar()
        {
            _pageNumber = 1;
            await CargarDatosGrid();
        }

    }


    public interface IPresentControlAccesoForm : IPresent
    {
        frmControlAcceso MainForm { get; }

        void InicializarFormulario();

        void EstablecerFechaHora();

        void EstablecerOperario();

        void SalirAplicacion();

        void CambiarUsuario();

        void CambiarClave();

        void GestionLocalizaciones();

        void GestionEmpresas();

        void GestionTipoCargas();

        void GestionTransportes();
        
        Task NuevaEntrada(object sender, EventArgs e);

        void CapturaPantalla();

        void ConfigurarComboAcceso(ComboBox cmb);

        void ConfigurarGrid(DataGridView dgv);

        void ConfiguraComboTamanioPagina(ComboBox cmb);
        void CambioTamanioPagina(int _pageSize);
        void PaginaPrimera(object sender, EventArgs e);
        void PaginaAnterior(object sender, EventArgs e);
        void PaginaSiguiente(object sender, EventArgs e);
        void PaginaUltima(object sender, EventArgs e);

        void Buscar();

    }
}
