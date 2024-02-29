using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Threading; //Удалить нужно для теста изменения цвета

//TODO Реализовать изменение цвета кнопки, сейчас только зеленый горит
//TODO Правила написания кода!!!

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
            //progressBar1.Value += 1;

            //Проверяем какие функции включены
            if (checkBox_temporary_files.Checked) //Нужно удалить временные файлы?
            {
                //ChangeStatus(label1, Color.Green);
                TemporaryFilesDel();
                //ProgramFilesDel();
            }
            if (checkBox_logs_30days.Checked) //Нужно удалить логи iikoFront?
            {
                LogsFilesDel();
            }
            if (checkBox_logs_posserver.Checked) //Нужно удалить логи POS сервера
            {
                PathForPos(out var path);
                DeletedFromInfoFiles(path, "iikoPosLogs", label3, -10);
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
        private void ChangeStatus(Label label_box, Color color)
        {
            label_box.Text = "  ";
            label_box.BackColor = color;        
        }
        private void DeleteFiles(Label LabelBox, IEnumerable<string> folders_full, string name, int DayAgo)
        {
            ChangeStatus(LabelBox, Color.Green);
            //ChangeStatus(LabelBox, Color.Red);

            foreach (string file in folders_full)
            {
                DirectoryInfo file_1 = new DirectoryInfo(_iikoPosUsersFolder);
                MessageBox.Show(file_1.LastAccessTime.ToString());


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
                //ChangeStatus(LabelBox, Color.Green);
            }
            

        }
        //Удаление файлов из TEMP
        private void TemporaryFilesDel()
        {
            Thread.Sleep(10000);
            string DataPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            DataPath = $@"{DataPath}\AppData\Local\Temp";
            DeletedFromInfoFiles(DataPath,"TEMP", label1,1);
        }

        //Удаление файлов из ETLLogs
        private void ProgramFilesDel()
        {
            string DataPath = @"C:\ProgramData\Microsoft\Diagnosis\ETLLogs";
            DeletedFromInfoFiles(DataPath, "ETLLogs", label1,1);
        }
        // Удаление логов POS
        private void LogsFilesDel()
        {
            string DataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            DataPath = $@"{DataPath}\iiko\CashServer\Logs";
            DeletedFromInfoFiles(DataPath, "iikoFrontLogs", label2,-30);
            
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
            string DataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"iiko\RMS");
            DeletedFromInfoFiles(DataPath, "RMS", label4, 1);
            //DeleteFiles(label4, Directory.EnumerateFileSystemEntries(DataPath), "RMS", 1);
        }
        //Удаления файлов из загрузки
        private void LoadingFilesDel()
        {
            string DataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            DeletedFromInfoFiles(DataPath, "Loading", label5, 1);
        }


        private void DeletedFromInfoFiles(string PathForDel,string NameMethods,Label LabelMethods, sbyte DayAgo)
        {
            ChangeStatus(label1, Color.Red);

            var DirectoryForDel = new DirectoryInfo(PathForDel); //Получил информацию об исходной дириктории
            DirectoryInfo[] Dirs = DirectoryForDel.GetDirectories(); // Какие папки находятся в искомой директории
            


            foreach (DirectoryInfo DirForDel in Dirs) //Удаление папок
            {
                if (DateTime.Today.AddDays(DayAgo) >= DirForDel.LastAccessTime)

                { 
                
                
                try
                {
                        DirForDel.Delete(true);
                    }
                    catch (Exception ex)
                {
                    File.AppendAllText("..\\logs\\logs.log", $"{DateTime.Now} {DirForDel.FullName} INFO [{NameMethods}]  - {ex.Message}\n");
                }
                }

            }

            FileInfo[] FilesForDel = DirectoryForDel.GetFiles(); //Информация о файлах, которые находятся в исходной папке 
            foreach (FileInfo FileDeleted in FilesForDel) //Удаление файлов
            {
                if (DateTime.Today.AddDays(DayAgo) >= FileDeleted.LastAccessTime)
                { 
                    if (DateTime.Today.AddDays(DayAgo) >= FileDeleted.LastAccessTime)
                    { 
                        try
                        {
                            //Console.WriteLine(FileDeleted.FullName);
                             FileDeleted.Delete();
                        }
                        catch (Exception ex)
                        {
                            File.AppendAllText("..\\logs\\logs.log", $"{DateTime.Now} {FileDeleted.FullName} INFO [{NameMethods}]  - {ex.Message}\n");
                        }
                    }

                }
                ChangeStatus(label1, Color.Green);


            }
        }

    }
}
