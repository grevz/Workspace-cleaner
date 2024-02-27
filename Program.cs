using System;
using System.Windows.Forms;
using System.IO;


namespace WorkspaceCleaner
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Directory.CreateDirectory("..\\Logs");
            File.Delete("..\\logs\\logs.log");
            Application.Run(new WorkspaceCleaner());
            
        }

    }



}
