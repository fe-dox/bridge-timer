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
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-EN");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-EN");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TimerForm());
        }
    }
}