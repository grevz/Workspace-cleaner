using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace WorkspaceCleaner
{
    public partial class WorkspaceCleaner : Form
    {
        public WorkspaceCleaner()
        {
            InitializeComponent();
        }

        private const string _iikoPosBase = @"iikoCard5POS\AppData\Roaming\iiko\iikoCard5\Logs";
        private static readonly string _iikoPosServiceProfileFolder = Path.Combine(@"C:\Windows\ServiceProfiles", _iikoPosBase);
        private static readonly string _iikoPosUsersFolder = Path.Combine(@"C:\Users\iikoCard5POS", _iikoPosBase);

        private void button1_Click(object sender, EventArgs e)
        {

            //Проверяем какие функции включены
            if (checkBox_temporary_files.Checked) //Нужно удалить временные файлы?
            {
                TemporaryFilesDel();
                ProgramFilesDel();
            }
            if (checkBox_logs_30days.Checked) //Нужно удалить логи iikoFront?
            {
                LogsFilesDel();
            }
            if (checkBox_logs_posserver.Checked & true) //Нужно удалить логи POS сервера
            { 
            }


            if (checkBox_date_rms.Checked) // Нужно удалить папку RMS
                {
                    string path_RMS = "C:\\Users\\User\\AppData\\Roaming\\iiko\\RMS";
                    if (Directory.Exists(path_RMS))
                    {
                        string command_for_del = "/c cd C:\\Users\\User\\AppData\\Roaming\\iiko & rd /s /q RMS";
                        MakeProcess(label4, command_for_del);
                    }
                    else
                    {
                        MessageBox.Show("Нет данных о RMS на ПК");
                    }
                }
            if (checkBox_loading.Checked) //Нужно удалить папку загрузки
            {
                string command_for_del = "/c cd %userprofile% & rd /s /q Downloads";
                MakeProcess(label5, command_for_del);
            }

        }

        private void MakeProcess(object pic_box_num, string arguments)
        {
            var pic_box = pic_box_num as Label;
            ChangeStatus(pic_box, false);
            try
            {
                ProcessStartInfo ppt = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = arguments,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                Process procCommand = Process.Start(ppt);
                procCommand.EnableRaisingEvents = true;
                procCommand.Exited += (sender, e) =>
                {
                    ChangeStatus(pic_box, true);
                };
            } //Контроль выполнения процесса
            catch { }

        }
        // Меняем статус
        private void ChangeStatus(object label_box, bool ready)
        {

            var label_box_ = label_box as Label;
            label_box_.Text = "  ";
            if (ready)
            {
                label_box_.BackColor = Color.Green;
            }
            else
            {
                label_box_.BackColor = Color.Red;
            }
        }
        private void DeleteFiles(object pic_box, IEnumerable<string> folders_full, string name, int DayAgo)
        {
            ChangeStatus(pic_box, false);
            foreach (string file in folders_full)
            {
                var a = DateTime.Today.AddDays(DayAgo);

                if (DateTime.Today.AddDays(DayAgo) >= Directory.GetLastAccessTime(file))
                {

                    try
                    {
                        File.Delete(file);
                    }
                    catch (Exception ex)
                    {

                        File.AppendAllText("..\\logs\\logs.log", $"{DateTime.Now} {file} INFO [{name}]  - {ex}\n");
                    }
                    try
                    {
                        Directory.Delete(file, true);
                    }
                    catch (Exception ex)
                    {

                        File.AppendAllText("..\\logs\\logs.log", $"{DateTime.Now} {file} INFO [{name}]  - {ex}\n");
                    }


                }

            }
            ChangeStatus(pic_box, true);

        }
        //Удаление файлов из TEMP
        private void TemporaryFilesDel()
        {
            string DataPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            DataPath = $"{DataPath}\\AppData\\Local\\Temp";
            DeleteFiles(label1, FilesNames(DataPath), "TEMP", 1);
        }
        private IEnumerable<string> FilesNames(string DataPath)
        {
            return Directory.EnumerateFileSystemEntries(DataPath); //Возвращаем список путей для всех файлов и папок
        }

        //Удаление файлов из ETLLogs
        private void ProgramFilesDel()
        {
            string DataPath = "C:\\ProgramData\\Microsoft\\Diagnosis\\ETLLogs";
            DeleteFiles(label1, FilesNames(DataPath), "ETLLogs", 1);
        }
        // Удаление логов POS
        private void LogsFilesDel()
        {
            string DataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            DataPath = $"{DataPath}\\iiko\\CashServer\\Logs";
            DeleteFiles(label2, FilesNames(DataPath), "iikoFrontLogs", -30);
        }

        private void POSFilesDel()
        {

        }

        private bool PathForPos()
        {
            return false;
        }


    }
}
