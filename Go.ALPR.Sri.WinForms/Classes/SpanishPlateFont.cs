using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace Go.ALPR.Sri.WinForms
{
    public class SpanishPlateFont
    {
        PrivateFontCollection _pfc;

        public SpanishPlateFont()
        {
            _pfc = new PrivateFontCollection();

            //Select your font from the resources.
            //My font here is "MESPREG.ttf"
            int fontLength = Properties.Resources.MESPREG.Length;

            // create a buffer to read in to
            byte[] fontdata = Properties.Resources.MESPREG;

            // create an unsafe memory block for the font data
            IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            ///IMPORTANT line to register font in system
            uint cFonts = 0;
            NativeMethods.AddFontMemResourceEx(data, (uint)fontdata.Length, IntPtr.Zero, ref cFonts);

            // pass the font to the font collection
            _pfc.AddMemoryFont(data, fontLength);

            // free up the unsafe memory
            Marshal.FreeCoTaskMem(data);

        }

        public FontFamily GetFontFamily()
        {
            return _pfc.Families[0];
        }
    }
}
