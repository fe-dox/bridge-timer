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
            var currentCulture = Settings.Read(Settings.SettingsLanguageRegister) ?? "en-EN";
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(currentCulture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(currentCulture);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TimerForm());
        }
    }
}