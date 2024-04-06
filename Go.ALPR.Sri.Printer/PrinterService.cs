using System;
using System.Drawing.Printing;
using System.IO;
using System.Linq;

namespace Go.ALPR.Sri.Printer
{
    public class PrinterService : IPrinterService
    {
        private readonly ICommandService _commandService;

        public PrinterService(ICommandService commandService)
        {
            _commandService = commandService;
        }

        public string[] GetInstalledPrinters()
            => PrinterSettings.InstalledPrinters.Cast<string>().ToArray();

        public void InstallPrinter(string printerPath)
        {
            if (string.IsNullOrEmpty(printerPath))
                throw new ArgumentException("Path cannot be null or empty", nameof(printerPath));

            string cmdPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "rundll32.exe");
            CommandExecutionResult executionResult = _commandService.Execute(cmdPath, "printui.dll,PrintUIEntry", "/in", $"/n\"{printerPath}\"");

            // ReSharper disable once InvertIf
            if (!executionResult.Success)
            {
                var message = string.Join(Environment.NewLine, executionResult.Output);
                throw new InstallPrinterFailedException(printerPath, message);
            }
        }

       
        public string GetDefaultPrinterName()
        {
            ////Con paquete System.Management
            //var query = new ObjectQuery("SELECT * FROM Win32_Printer");
            //var searcher = new ManagementObjectSearcher(query);

            //foreach (ManagementObject mo in searcher.Get())
            //{

            //    if (((bool?)mo["Default"]) ?? false)
            //    {
            //        return mo["Name"] as string;
            //    }
            //}

            //return null;

            string defaultPrinter = null;
            PrintDocument prtdoc = new PrintDocument();

            string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;

            try
            {
                foreach (string strPrinter in PrinterSettings.InstalledPrinters)
                {
                    if (strPrinter == strDefaultPrinter)
                    {
                        defaultPrinter = strPrinter;
                    }
                }
            }
            catch
            {

            }           

            return defaultPrinter;
        }


    }

    public interface IPrinterService
    {
        string[] GetInstalledPrinters();

        string GetDefaultPrinterName();

        void InstallPrinter(string printerPath);
    }

    public sealed class InstallPrinterFailedException : Exception
    {
        public InstallPrinterFailedException(string printerPath, string message)
            : base($"Failed to install printer '{printerPath}' with message: {message}")
        {
            PrinterPath = printerPath;
        }

        public string PrinterPath { get; }
    }
}
