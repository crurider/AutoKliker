using System;
using System.Windows.Forms;

namespace AutoKliker
{
    static class Program
    {
        public static string pozicijaX;
        public static string pozicijaY;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Kliker());
        }
    }
}
