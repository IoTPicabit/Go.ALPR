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

//using Go.ALPR.Sri.Signature;
using Go.ALPR.Sri.PlcComm;

namespace Go.ALPR.Sri.Tests
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
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .Build();

                // NLog: setup the logger first to catch all errors
                var logger = LogManager.Setup()
                            .LoadConfigurationFromSection(config)
                            .GetCurrentClassLogger();

                try
                {
                    logger.Trace("Inicio");

                    var host = CreateHostBuilder(config).Build();

                    var serviceProvider = host.Services;

                    //var mainForm = serviceProvider.GetRequiredService<frmMain>();
                    var mainForm = serviceProvider.GetRequiredService<frmPLC>();
                    Application.Run(mainForm);

                    mutex.ReleaseMutex();

                    logger.Trace("Fin");
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

            //services.AddSingleton<frmMain>();
            services.AddSingleton<frmPLC>();


            services.AddAutoMapper(typeof(Business.AutoMapper.ProfileConfiguration));

            services.AddSingleton<IMainFormBusiness, MainFormBusiness>();
            services.AddSingleton<IIdentificacionService, IdentificacionService>();
            services.AddSingleton<IBasculaService, BasculaService>();
            services.AddSingleton<ISeguridadService, SeguridadService>();
            services.AddSingleton<IUsuarioService, UsuarioService>();
            services.AddSingleton<ILocalizacionService, LocalizacionService>();
            services.AddSingleton<IEmpresaService, EmpresaService>();
            services.AddSingleton<ITipoCargaService, TipoCargaService>();
            services.AddSingleton<ITransporteService, TransporteService>();
            services.AddSingleton<IOperacionService, OperacionService>();

            //services.AddSingleton<ISignatureService, SignatureService>();

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
