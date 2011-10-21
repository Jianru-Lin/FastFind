using System;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace FastFind
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                MainForm mf = new MainForm();
                MainFormLogic cl = new MainFormLogic(mf);
                Application.Run(mf);
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
                try
                {
                    DebugHelper.LogDebugInfo(ex.ToString());
                }
                catch (System.Exception ex2)
                {
                    System.Diagnostics.Trace.WriteLine(ex2);
                }
            }
        }

    }
}
