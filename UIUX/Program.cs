using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIUX.View;

namespace UIUX
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NNaF5cWWNCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXpedHVTRGlYU0x2WEFWYUA=");
            //AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
