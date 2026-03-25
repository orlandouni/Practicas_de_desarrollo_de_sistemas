using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FRMLogin login = new FRMLogin();

            // mostrar login como ventana modal
            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FRMPrincipal());
            }
        }
    }
}
