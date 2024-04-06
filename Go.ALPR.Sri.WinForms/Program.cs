using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

using Go.ALPR.Sri.SqlServer;
using Go.ALPR.Sri.Business;
using Go.ALPR.Sri.Printer;
using Go.ALPR.Sri.Signature;
using Go.ALPR.Sri.PlcComm;

namespace Go.ALPR.Sri.WinForms
{
    static class Program
    {        
        static Mutex mutex = new Mutex(true, Assembly.GetExecutingAssembly().GetType().GUID.ToString());

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var config = new ConfigurationBuilder()
                        .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .Build();               

                // NLog: setup the logger first to catch all errors
                var logger = LogManager.Setup()              
                            .LoadConfigurationFromSection(config)
                            .GetCurrentClassLogger();

                try
                {                    
                    logger.Trace("INICIO APLICACION SRI");

                    Splasher.Show();

                    var host = CreateHostBuilder(config).Build();

                    Splasher.Close();

                    var serviceProvider = host.Services;
                                       
                    var loginForm = serviceProvider.GetRequiredService<LoginFormPresenter>();
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        Application.Exit();
                        return;
                    }
                    
                    bool bArrancarControlAcceso = bool.Parse(config.GetSection("ControlAcceso").Value);
                    if (bArrancarControlAcceso)
                    {
                        var mainForm = serviceProvider.GetRequiredService<ControlAccesoFormPresenter>();
                        mainForm.Show();
                        Application.Run(mainForm.MainForm);
                    }
                    else
                    {
                        var mainForm = serviceProvider.GetRequiredService<MainFormPresenter>();
                        mainForm.Show();
                        Application.Run(mainForm.MainForm);
                    }                    

                    mutex.ReleaseMutex();

                    logger.Trace("FIN APLICACION SRI");
                }
                catch (Exception ex)
                {
                    //NLog: catch setup errors
                    logger.Fatal(ex, "Programa detenido debido a una excepción");
                    throw;
                }
                finally
                {
                    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                    LogManager.Shutdown();
                }                               
            }
            else
            {
                // send our Win32 message to make the currently running instance
                // jump on top of all the other windows
                NativeMethods.PostMessage(
                    (IntPtr)NativeMethods.HWND_BROADCAST,
                    NativeMethods.WM_SHOWME,
                    IntPtr.Zero,
                    IntPtr.Zero);
            }
        }

        public static IHostBuilder CreateHostBuilder(IConfiguration config) =>
            Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, builder) =>
            {
                // Add other configuration files...
                builder.AddJsonFile("plcsettings.json", optional: true, reloadOnChange: true);

            })
            .ConfigureServices((context, services) =>
            {
                ConfigureServices(context.Configuration, services);
            });

        private static void ConfigureServices(IConfiguration config, IServiceCollection services)
        {
            services.AddLogging(configure =>
            {
                configure.ClearProviders();
                configure.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                configure.AddNLog(config);
            });

            services.AddTransient<frmMessage>();

            services.AddSingleton<frmMain>();
            services.AddSingleton<Func<IViewMainForm>>(x => () => x.GetRequiredService<frmMain>());
            services.AddSingleton<MainFormPresenter>();

            services.AddSingleton<frmControlAcceso>();
            services.AddSingleton<Func<IViewControlAccesoForm>>(x => () => x.GetRequiredService<frmControlAcceso>());
            services.AddSingleton<ControlAccesoFormPresenter>();

            services.AddTransient<frmLogin>();
            services.AddTransient<Func<IViewLoginForm>>(x => () => x.GetRequiredService<frmLogin>());
            services.AddTransient<LoginFormPresenter>();

            services.AddTransient<frmCambiarClave>();
            services.AddTransient<Func<IViewCambiarClaveForm>>(x => () => x.GetRequiredService<frmCambiarClave>());
            services.AddTransient<CambiarClaveFormPresenter>();

            services.AddTransient<frmUsuarios>();
            services.AddTransient<Func<IViewUsuariosForm>>(x => () => x.GetRequiredService<frmUsuarios>());
            services.AddTransient<UsuariosFormPresenter>();

            services.AddTransient<frmLocalizaciones>();
            services.AddTransient<Func<IViewLocalizacionesForm>>(x => () => x.GetRequiredService<frmLocalizaciones>());
            services.AddTransient<LocalizacionesFormPresenter>();

            services.AddTransient<frmEmpresas>();
            services.AddTransient<Func<IViewEmpresasForm>>(x => () => x.GetRequiredService<frmEmpresas>());
            services.AddTransient<EmpresasFormPresenter>();

            services.AddTransient<frmTipoCargas>();
            services.AddTransient<Func<IViewTipoCargasForm>>(x => () => x.GetRequiredService<frmTipoCargas>());
            services.AddTransient<TipoCargasFormPresenter>();

            services.AddTransient<frmContactos>();
            services.AddTransient<Func<IViewContactosForm>>(x => () => x.GetRequiredService<frmContactos>());
            services.AddTransient<ContactosFormPresenter>();

            services.AddTransient<frmTransportes>();
            services.AddTransient<Func<IViewTransportesForm>>(x => () => x.GetRequiredService<frmTransportes>());
            services.AddTransient<TransportesFormPresenter>();

            services.AddTransient<frmOperaciones>();
            services.AddTransient<Func<IViewOperacionesForm>>(x => () => x.GetRequiredService<frmOperaciones>());
            services.AddTransient<OperacionesFormPresenter>();

            services.AddTransient<SpanishPlateFont>();

            services.AddTransient<frmPicture>();
            services.AddTransient<frmIdentificacionManual>();
            services.AddTransient<frmPesoManual>();
            services.AddTransient<frmValidacionSalida>();

            services.AddAutoMapper(typeof(Business.AutoMapper.ProfileConfiguration));

            services.AddSingleton<IMainFormBusiness, MainFormBusiness>();
            services.AddSingleton<IIdentificacionService, IdentificacionService>();

            services.AddSingleton<IControlAccesoFormBusiness, ControlAccesoFormBusiness>();
            services.AddSingleton<IIdentificacionAccesoService, IdentificacionAccesoService>();

            services.AddSingleton<IBasculaService, BasculaService>();
            services.AddSingleton<ISeguridadService, SeguridadService>();
            services.AddSingleton<IUsuarioService, UsuarioService>();
            services.AddSingleton<ILocalizacionService, LocalizacionService>();
            services.AddSingleton<IEmpresaService, EmpresaService>();
            services.AddSingleton<ITipoCargaService, TipoCargaService>();
            services.AddSingleton<IContactoService, ContactoService>();
            services.AddSingleton<ITransporteService, TransporteService>();
            services.AddSingleton<IOperacionService, OperacionService>();
            services.AddSingleton<IAccesoService, AccesoService>();

            services.AddSingleton<ICommandService, CommandService>();
            services.AddSingleton<IPdfPrintService, PdfPrintService>();
            services.AddSingleton<IPrinterService, PrinterService>();
            services.AddSingleton<ISignatureService, SignatureService>();
            services.AddSingleton<IClienteSMTP, ClienteSMTP>();
            services.AddSingleton<IPLCService, PLCService>();

            services.AddSingleton<UsuarioSesionDto>();            

            services.AddDbContext<SRIDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("MainDatabase"));
                options.EnableSensitiveDataLogging(Debugger.IsAttached);
            });
        }
    }
}
