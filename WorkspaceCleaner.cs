using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.ComponentModel;

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
        private static readonly string _appDataUser = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static readonly string DataPathATOL = Path.Combine(_appDataUser, @"ATOL\drivers10\logs");
        private static readonly string DataPathSHTRIH = Path.Combine(_appDataUser, @"SHTRIH-M\DrvFR\Logs");
        private readonly object BalanceLock = new object(); //Объект заглушка для ограничения записи в файл

        private void button1_Click(object sender, EventArgs e)
        {
            //Проверяем какие функции включены
            if (checkBox_temporary_files.Checked) //Нужно удалить временные файлы?
            {
                var WorkerFirst = new BackgroundWorker();
                var WorkerSecond = new BackgroundWorker();
                WorkerFirst.DoWork += (obj, ea) => TemporaryFilesDel();
                WorkerSecond.DoWork += (obj, ea) => ProgramFilesDel();
                WorkerFirst.RunWorkerAsync();
                WorkerSecond.RunWorkerAsync();
            }

            if (checkBox_logs_30days.Checked) //Нужно удалить логи iikoFront?
            {
                var WorkerFirst = new BackgroundWorker();
                WorkerFirst.DoWork += (obj, ea) => LogsFilesDel();
                WorkerFirst.RunWorkerAsync();
            }

            if (checkBox_logs_posserver.Checked) //Нужно удалить логи POS сервера
            {
                PathForPos(out var path);
                var WorkerFirst = new BackgroundWorker();
                WorkerFirst.DoWork += (obj, ea) => DeletedFromInfoFiles(path, "iikoPosLogs", CheckPosDelLabel, -10);
                WorkerFirst.RunWorkerAsync();              
            }

            if (checkBox_date_rms.Checked) // Нужно удалить папку RMS
            {
                var WorkerFirst = new BackgroundWorker();
                WorkerFirst.DoWork += (obj, ea) => RMSFilesDel();
                WorkerFirst.RunWorkerAsync();
            }

            if (checkBox_loading.Checked) //Нужно удалить папку загрузки
            {
                var WorkerFirst = new BackgroundWorker();
                WorkerFirst.DoWork += (obj, ea) => LoadingFilesDel();
                WorkerFirst.RunWorkerAsync();
            }
            if (checkBoxKKT.Checked)
            {
                var WorkerFirst = new BackgroundWorker();
                WorkerFirst.DoWork += (obj, ea) => KKTLogsDel();
                WorkerFirst.RunWorkerAsync();
            }
        }

        //Удаление файлов из TEMP
        private void TemporaryFilesDel()
        {
            string DataPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            DataPath = $@"{DataPath}\AppData\Local\Temp";
            DeletedFromInfoFiles(DataPath, "TEMP", CheckTempDelLabel, 1);
        }

        //Удаление файлов из ETLLogs
        private void ProgramFilesDel()
        {
            string DataPath = @"C:\ProgramData\Microsoft\Diagnosis\ETLLogs";
            DeletedFromInfoFiles(DataPath, "ETLLogs", CheckETLLogsDelLabel, 1);
        }

        // Удаление логов POS
        private void LogsFilesDel()
        {
            string DataPath = Path.Combine(_appDataUser, @"iiko\CashServer\Logs");
            DeletedFromInfoFiles(DataPath, "iikoFrontLogs", CheckIikoFrontDelLabel, -30);
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
        async void RMSFilesDel()
        {
            string DataPath = Path.Combine(_appDataUser, @"iiko\RMS");
            DeletedFromInfoFiles(DataPath, "RMS", CheckRMSDelLabel, 1);
        }

        //Удаления файлов из загрузки
        async void LoadingFilesDel()
        {
            string DataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            DeletedFromInfoFiles(DataPath, "Loading", CheckLoadingDelLabel, 1);
        }
        private void KKTLogsDel()
        {
            PathForKKT(out var path);
            DeletedFromInfoFiles(path, "LogsKKT", LabelLogsKKT, 1);          
        }
        private bool PathForKKT(out string folderPath)
        {
            folderPath = "";
            if (Directory.Exists(DataPathATOL))
            {
                folderPath = DataPathATOL;
                return true;
            }
            if (Directory.Exists(DataPathSHTRIH))
            {
                folderPath = DataPathSHTRIH;
                return true;
            }
            MessageBox.Show("Нет POS Отсутствуют папки с логами ККТ на устройстве");
            return false;
        }

        private void DeletedFromInfoFiles(string PathForDel, string NameMethods, Label LabelMethods, sbyte DayAgo)
        {
            LabelMethods.BackColor = Color.Red;
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
                        lock(BalanceLock)
                        {
                            File.AppendAllText("..\\logs\\logs.log", $"{DateTime.Now} {DirForDel.FullName} INFO [{NameMethods}]  - {ex.Message}\n{ex.StackTrace}\n");
                        }
                    }
                }
            }
            FileInfo[] FilesForDel = DirectoryForDel.GetFiles(); //Информация о файлах, которые находятся в исходной папке 
            foreach (FileInfo FileDeleted in FilesForDel) //Удаление файлов
            {                
                    if (DateTime.Today.AddDays(DayAgo) >= FileDeleted.LastAccessTime)
                    {
                        try
                        {
                            FileDeleted.Delete();
                        }
                        catch (Exception ex)
                        {
                            lock (BalanceLock)
                            {
                                File.AppendAllText("..\\logs\\logs.log", $"{DateTime.Now} {FileDeleted.FullName} INFO [{NameMethods}]  - {ex.Message}\n{ex.StackTrace}\n");
                            }
                        }
                    }            
            }
            LabelMethods.BackColor = Color.Green;
        }
    }
}