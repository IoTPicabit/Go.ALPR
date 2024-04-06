using System;
using System.IO;

using Microsoft.Extensions.Logging;

//using wgssSTU;
using Florentis;


namespace Go.ALPR.Sri.Signature
{
    public class SignatureService : ISignatureService
    {

        private readonly ILogger<SignatureService> _logger;

        private readonly object licencia = "eyJhbGciOiJSUzUxMiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImV4cCI6MjE0NzQ4MzY0NywiaWF0IjoxNTYwOTUwMjcyLCJyaWdodHMiOlsiU0lHX1NES19DT1JFIiwiU0lHQ0FQVFhfQUNDRVNTIl0sImRldmljZXMiOlsiV0FDT01fQU5ZIl0sInR5cGUiOiJwcm9kIiwibGljX25hbWUiOiJTaWduYXR1cmUgU0RLIiwid2Fjb21faWQiOiI3YmM5Y2IxYWIxMGE0NmUxODI2N2E5MTJkYTA2ZTI3NiIsImxpY191aWQiOiJiODUyM2ViYi0xOGI3LTQ3OGEtYTlkZS04NDlmZTIyNmIwMDIiLCJhcHBzX3dpbmRvd3MiOltdLCJhcHBzX2lvcyI6W10sImFwcHNfYW5kcm9pZCI6W10sIm1hY2hpbmVfaWRzIjpbXX0.ONy3iYQ7lC6rQhou7rz4iJT_OJ20087gWz7GtCgYX3uNtKjmnEaNuP3QkjgxOK_vgOrTdwzD-nm-ysiTDs2GcPlOdUPErSp_bcX8kFBZVmGLyJtmeInAW6HuSp2-57ngoGFivTH_l1kkQ1KMvzDKHJbRglsPpd4nVHhx9WkvqczXyogldygvl0LRidyPOsS5H2GYmaPiyIp9In6meqeNQ1n9zkxSHo7B11mp_WXJXl0k1pek7py8XYCedCNW5qnLi4UCNlfTd6Mk9qz31arsiWsesPeR9PN121LBJtiPi023yQU8mgb9piw_a-ccciviJuNsEuRDN3sGnqONG3dMSA";

        public SignatureService(ILogger<SignatureService> logger)
        {
            _logger = logger;
        }

        public bool IsSignaturePadConnected()
        {
            //_logger.LogTrace($"{this.TraceMethod(new { })} - INICIO");

            //bool result = false;

            //try
            //{
            //    UsbDevices usbDevices = new wgssSTU.UsbDevices();

            //    result = (usbDevices.Count > 0);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, this.TraceMethod(new { }));
            //}

            //_logger.LogTrace($"{this.TraceMethod(new { })} - FIN");

            //return result;
            return true;
        }

        public Stream CaputurarFirma(string quien, string titulo, int idOperacion)
        {
            _logger.LogTrace("INICIO");

            MemoryStream result = null;
                     
            try
            {

                SigCtl sigCtl = new SigCtl();
                sigCtl.Licence = licencia;

                DynamicCapture dc = new DynamicCaptureClass();
                DynamicCaptureResult res = dc.Capture(sigCtl, quien, titulo, null, null);
                if (res == DynamicCaptureResult.DynCaptOK)
                {
                    _logger.LogTrace("FIRMA CAPTURADA CON EXITO");
                    SigObj sigObj = (SigObj)sigCtl.Signature;

                    // Incluimos el id de la operacion como información adicional
                    sigObj.set_ExtraData("IdOperacion", idOperacion.ToString());
                    String filename = "FirmaTmp.png";

                    // Escribe el archivo anterior en la carpeta de la aplicación
                    sigObj.RenderBitmap(filename, 200, 150, "image/png", 0.5f, 0xff0000, 0xffffff, 10.0f, 10.0f, RBFlags.RenderOutputFilename | RBFlags.RenderColor32BPP | RBFlags.RenderEncodeData);

                    using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                    {
                        result = new MemoryStream();
                        fs.CopyTo(result);
                        fs.Close();
                    }
                    File.Delete(filename);
                }
                else
                {                    
                    switch (res)
                    {
                        case DynamicCaptureResult.DynCaptCancel:
                            _logger.LogTrace("CAPTURA FIRMA CANCELADA");
                            break;
                        case DynamicCaptureResult.DynCaptError:
                            throw new Exception("No está disponible el servicio de captura de firma");                            
                        case DynamicCaptureResult.DynCaptPadError:                            
                            throw new Exception("Error en dispositivo de firma");
                        default:
                            throw new Exception("Error inexperado " + (int)res + "  ( " + res + " )");
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new Exception(ex.Message, ex);
            }

            _logger.LogTrace("FIN");

            return result;
        }
    }

    public interface ISignatureService
    {
        bool IsSignaturePadConnected();

        Stream CaputurarFirma(string quien, string titulo, int idOperacion);

    }
}
