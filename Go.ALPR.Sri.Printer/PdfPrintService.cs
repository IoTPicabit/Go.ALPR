using System;
using System.Drawing.Printing;
using System.IO;
using Microsoft.Extensions.Logging;

namespace Go.ALPR.Sri.Printer
{
    
    public class PdfPrintService : IPdfPrintService
    {
        private readonly ILogger<PdfPrintService> _logger;

        public PdfPrintService(ILogger<PdfPrintService> logger)
        {
            _logger = logger;
        }

        public void Print(Stream pdfStream, string printerName, string pageRange = null)
        {
            if (pdfStream == null)
                throw new ArgumentNullException(nameof(pdfStream));

            try
            {
                // Create the printer settings for our printer
                var printerSettings = new PrinterSettings
                {
                    PrinterName = printerName,
                    Copies = 1,
                };

                // Create our page settings for the paper size selected
                var pageSettings = new PageSettings(printerSettings)
                {
                    Margins = new Margins(0, 0, 0, 0)
                };
                foreach (PaperSize paperSize in printerSettings.PaperSizes)
                {
                    if (paperSize.PaperName == "A4")
                    {
                        pageSettings.PaperSize = paperSize;
                        break;
                    }
                }

                // Now print the PDF document
                using (var document = PdfiumViewer.PdfDocument.Load(pdfStream))
                {
                    _logger.LogInformation($"Imprimiendo PDF que contiene {document.PageCount} página(s) a la impresora '{printerName}'");

                    using (var printDocument = document.CreatePrintDocument())
                    {
                        printDocument.PrinterSettings = printerSettings;
                        printDocument.DefaultPageSettings = pageSettings;
                        printDocument.PrintController = new StandardPrintController();                        
                        printDocument.Print();
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new Exception("Error al imprimir", ex);
            }

            //PdfDocument document = PdfDocument.Open(pdfStream);

            //_logger.LogInformation($"Imprimiendo PDF que contiene {document.PageCount} página(s) a la impresora '{printerName}'");

            //using var printDocument = new PrintDocument();
            //printDocument.PrinterSettings.PrinterName = printerName;
            //PrintState state = PrintStateFactory.Create(document, pageRange);
            //printDocument.PrintPage += (_, e) => PrintDocumentOnPrintPage(e, state);
            //printDocument.Print();
        }

        //private void PrintDocumentOnPrintPage(PrintPageEventArgs e, PrintState state)
        //{
        //    var destinationRect = new RectangleF(
        //        x: e.Graphics.VisibleClipBounds.X * e.Graphics.DpiX / 100.0f,
        //        y: e.Graphics.VisibleClipBounds.Y * e.Graphics.DpiY / 100.0f,
        //        width: e.Graphics.VisibleClipBounds.Width * e.Graphics.DpiX / 100.0f,
        //        height: e.Graphics.VisibleClipBounds.Height * e.Graphics.DpiY / 100.0f);
        //    using PdfPage page = state.Document.OpenPage(state.CurrentPageIndex);
        //    page.RenderTo(e.Graphics, destinationRect);
        //    e.HasMorePages = state.AdvanceToNextPage();
        //}
    }

    public interface IPdfPrintService
    {
        void Print(Stream pdfStream, string printerName, string pageRange = null);
    }
}
