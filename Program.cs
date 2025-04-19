using System;
using System.Windows.Forms;

namespace PersonelMaasApp
{
    static class Program
    {
        // Program giriş noktası
        [STAThread]
        static void Main()
        {
            // Uygulama için temel ayarları yap
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Ana formu başlat
            Application.Run(new FormMain());
        }
    }
}
