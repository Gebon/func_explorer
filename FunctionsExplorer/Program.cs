using System;
using System.Windows.Forms;

namespace FunctionsExplorer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new MainForm();
            var controller = new Controller(form);
            Application.Run(form);
        }
    }
}
