using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Workspace_cleaner
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
            Application.Run(new Workspace_cleaner());
        }
        public static double Prize(int price_car, double bonus)
        {

            double price_bonus = Convert.ToDouble(price_car) * bonus;
            return price_bonus;
        }
    }



}
