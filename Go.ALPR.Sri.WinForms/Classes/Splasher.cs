using System;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace Go.ALPR.Sri.WinForms
{
    public class Splasher
    {
        static int intMostrarNumeroSegundos = 5;

        static frmSplashScreen MySplashForm = null;
        static Thread MySplashThread = null;
        static Stopwatch timeMeasure;

        //	internally used as a thread function - showing the form and
        //	starting the messageloop for it
        static private void ShowThread()
        {
            MySplashForm = new frmSplashScreen();
            Application.Run(MySplashForm);
        }

        //	public Method to show the SplashForm
        static public void Show()
        {
            if (MySplashThread != null)
                return;

            timeMeasure = new Stopwatch();
            timeMeasure.Start();

            MySplashThread = new Thread(new ThreadStart(Splasher.ShowThread));
            MySplashThread.IsBackground = true;
            MySplashThread.SetApartmentState(ApartmentState.STA);
            MySplashThread.Start();
        }

        //	public Method to hide the SplashForm
        static public void Close()
        { 
            if (MySplashThread == null) return;
            if (MySplashForm == null) return;

            timeMeasure.Stop();

            int sleepMilliseconds = (intMostrarNumeroSegundos * 1000) - (int)timeMeasure.ElapsedMilliseconds;

            Thread.Sleep(sleepMilliseconds);

            try
            {
                MySplashForm.Invoke(new MethodInvoker(MySplashForm.Close));
            }
            catch (Exception)
            {
            }
            MySplashThread = null;
            MySplashForm = null;
        }
        
    }
}
