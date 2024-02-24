using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Workspace_cleaner
{
    public partial class Workspace_cleaner : Form
    {
        public Workspace_cleaner()
        {
            InitializeComponent();
        }

        //TODO: Удаление RMS (для сотрудников)
        //TODO: Отредактировать приложение (чтобя тянуть не могли)
        //TODO: Галки по умолчанию
        //TODO: del %programdata%\Microsoft\Diagnosis\ETLLogs /s /f /q
        //TODO Dism.exe /Online /Cleanup-Image /AnalyzeComponentStore
        //TODO Dism.exe /Online /Cleanup-Image /StartComponentCleanup
        private void button1_Click(object sender, EventArgs e)
        {

            if (Temporary_files.Checked == true)
            {
                Temporary();
            }
            if (Logs_30days.Checked == true)
            {
                Logs_iikoFront();
            }
            if (Logs_PosServer.Checked == true)

            {
                int day_delete = 10;
                string path_first = "C:\\Windows\\ServiceProfiles\\iikoCardPOS\\AppData\\Roaming\\iiko\\iikoCard5\\Logs";
                string path_second = "C:\\Users\\iikoCard5POS\\AppData\\Roaming\\iiko\\iikoCard5\\Logs";
                if (Directory.Exists(path_first) == true)
                {
                    Logs_Pos_2(path_first, day_delete);
                }
                else
                {
                    if (Directory.Exists(path_second) == true)
                    {
                        Logs_Pos(path_second, day_delete);
                    }
                    else
                    {
                        MessageBox.Show("Нет POS сервера на компьютере");
                    }
                }
                

            }
            if (Date_RMS.Checked == true)
            {
                int day_delete = 10;
                string path_RMS = "C:\\Users\\User\\AppData\\Roaming\\iiko\\RMS";

                if (Directory.Exists(path_RMS) == true)
                {
                    Delete_date_RMS(path_RMS);
                }
                else
                {
                    MessageBox.Show("Нет данных о RMS на ПК");
                }

            }

        }
        // Очистка временных файлов
        public static void Temporary()
        {
            try
            {
                ProcessStartInfo ppt = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c del %temp% /s /f /q",
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process procCommand = Process.Start(ppt);
                procCommand.EnableRaisingEvents = true;
                procCommand.Exited += (sender, e) => { MessageBox.Show("Очистка временных файлов завершена"); };
            } //Контроль выполнения процесса

            catch { }


        }
        //Очистка файлов iikoFront которым более 30 дней
        public static void Logs_iikoFront()
        {
            try
            {
                ProcessStartInfo ppt = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c ForFiles /p \"%userprofile%\\AppData\\Roaming\\iiko\\CashServer\\Logs\" /s /c \"cmd /c del @file /f /q\" /d -30",
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process procCommand = Process.Start(ppt);
                procCommand.EnableRaisingEvents = true;
                procCommand.Exited += (sender, e) => { MessageBox.Show("Очистка логов iikoFront завершена"); };
            }

            catch { }


        }
        //Очистка логов POS сервера
        public static void Logs_Pos(string Address, int day)
        {

            try
            {
                ProcessStartInfo ppt = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c ForFiles /p " + Address + " /s /c \"cmd /c del @file /f /q\" /d -" + day,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process procCommand = Process.Start(ppt);
                procCommand.EnableRaisingEvents = true;
                procCommand.Exited += (sender, e) => { MessageBox.Show("Очистка логов POS завершена"); };


            }

            catch { };
        }
        public static void Logs_Pos_2(string Address, int day)
        {

            try
            {
                ProcessStartInfo ppt = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/k ForFiles /p " + Address + " /s /c \"cmd /c del @file /f /q\" /d -" + day,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardOutput = true

                };

                Process procCommand = Process.Start(ppt);
                procCommand.EnableRaisingEvents = true;
                procCommand.Exited += (sender, e) => { MessageBox.Show("Очистка логов POS завершена"); };


            }

            catch { };
        }

        //Очистка данные об RMS клиентов 
        public static void Delete_date_RMS(string Addres)
        {
            
            try
            {
                ProcessStartInfo ppt = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    //cd C:\Users\User\AppData\Roaming\iiko & rd /s /q RMS
                    Arguments = "/c cd C:\\Users\\User\\AppData\\Roaming\\iiko & rd /s /q RMS",
                    WindowStyle = ProcessWindowStyle.Normal
                    

                };

                Process procCommand = Process.Start(ppt);

                procCommand.EnableRaisingEvents = true;
                procCommand.Exited += (sender, e) => { MessageBox.Show("Очистка данных RMS завершена"); };


            }

            catch { };




        }
    }
}
