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
        private static readonly string _iikoPosUsersFolder = Path.Combine(@"C:\Users\", _iikoPosBase);

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
            if (checkBox_logs_posserver.Checked & PathForPos(out var path)) //Нужно удалить логи POS сервера
            {
                DeleteFiles(label3, FilesNames(path), "iikoPosLogs", -10);
            }


            if (checkBox_date_rms.Checked) // Нужно удалить папку RMS
            {
                RMSFilesDel();
            }
            if (checkBox_loading.Checked) //Нужно удалить папку загрузки
            {
                LoadingFilesDel();
            }

        }

        // Меняем статус работы
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
        //Возвращаем список путей для всех файлов и папок 
        private IEnumerable<string> FilesNames(string DataPath)
        {
                return Directory.EnumerateFileSystemEntries(DataPath);
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

        //Удаления файлов из загрузки
        private void LoadingFilesDel()
        {
            string DataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            DeleteFiles(label5, FilesNames(DataPath), "Loading", 1);
        }

        //Определяем путь для POS сервера
        private bool PathForPos(out string folderPath)
        {
            folderPath = "";
            if (Directory.Exists(_iikoPosUsersFolder))
            {
                folderPath = _iikoPosUsersFolder;
                return true;
            }

            if (Directory.Exists(_iikoPosServiceProfileFolder))
            {
                folderPath = _iikoPosServiceProfileFolder;
                return true;
            }

            MessageBox.Show("Нет POS сервера на компьютере");
            return false;
        }

        //Удаление данных по RMS
        private void RMSFilesDel()
        {
            string DataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "iiko\\RMS");
            DeleteFiles(label4, FilesNames(DataPath), "RMS", 1);
        }
    }
}
