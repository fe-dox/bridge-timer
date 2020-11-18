using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace TCTimer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("pl-Pl");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("pl-Pl");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TimerForm());
        }
    }
}