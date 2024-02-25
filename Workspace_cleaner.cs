using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Drawing;

namespace Workspace_cleaner
{
    public partial class Workspace_cleaner : Form
    {
        public Workspace_cleaner()
        {
            InitializeComponent();
        }

        //TODO Оптимизация кода - убрать повторения, перенести часть программы в мейн
        private void button1_Click(object sender, EventArgs e)
        {

            //Проверяем какие функции включены
            if (checkBox_temporary_files.Checked == true)
            {
                Change_image(pictureBox1, false);
                Temporary(pictureBox1);
            }
            if (checkBox_logs_30days.Checked == true)
            {
                Change_image(pictureBox2, false);
                int day_delete = 30;
                Logs_iikoFront(day_delete,pictureBox2);
            }
            if (checkBox_logs_posserver.Checked == true)

            {
                Change_image(pictureBox3, false);
                int day_delete = 10;
                string path_first = "C:\\Windows\\ServiceProfiles\\iikoCardPOS\\AppData\\Roaming\\iiko\\iikoCard5\\Logs";
                string path_second = "C:\\Users\\iikoCard5POS\\AppData\\Roaming\\iiko\\iikoCard5\\Logs";
                if (Directory.Exists(path_first) == true)
                {
                    Logs_Pos_2(path_first, day_delete,pictureBox3);
                }
                else
                {
                    if (Directory.Exists(path_second) == true)
                    {
                        Logs_Pos(path_second, day_delete, pictureBox3);
                    }
                    else
                    {
                        MessageBox.Show("Нет POS сервера на компьютере");
                    }
                }


            }
            // Проверяем наличие папки RMS
            if (checkBox_date_rms.Checked == true)
            {
                Change_image(pictureBox4, false);
                string path_RMS = "C:\\Users\\User\\AppData\\Roaming\\iiko\\RMS";

                if (Directory.Exists(path_RMS) == true)
                {
                    Delete_date_RMS(path_RMS, pictureBox4);
                }
                else
                {
                    MessageBox.Show("Нет данных о RMS на ПК");
                }

            }
            if (checkBox_loading.Checked == true)
            {
                Change_image(pictureBox5, false);
                Loading_deleted(pictureBox5);
            }

        }
        // Очистка временных файлов
        public static void Temporary(object pic_box_num)
        {
            var pic_box = pic_box_num as PictureBox;

            try
            {
                ProcessStartInfo ppt = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c del %temp% /s /f /q & del %programdata%\\Microsoft\\Diagnosis\\ETLLogs /s /f /q",
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process procCommand = Process.Start(ppt);
                procCommand.EnableRaisingEvents = true;
                procCommand.Exited += (sender, e) =>
                {
                    Change_image(pic_box, true); ;
                };


            } //Контроль выполнения процесса

            catch { }

        }
        //Очистка файлов iikoFront которым более 30 дней
        public static void Logs_iikoFront(int day, object pic_box_num)
        {
            var pic_box = pic_box_num as PictureBox;
            try
            {
                ProcessStartInfo ppt = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c ForFiles /p \"%userprofile%\\AppData\\Roaming\\iiko\\CashServer\\Logs\" /s /c \"cmd /c del @file /f /q\" /d -" + day,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                Process procCommand = Process.Start(ppt);
                procCommand.EnableRaisingEvents = true;
                procCommand.Exited += (sender, e) => { Change_image(pic_box, true); };
            }

            catch { }


        }
        //Очистка логов POS сервера, если путь 1
        public static void Logs_Pos(string Address, int day,object pic_box_num)
        {
            var pic_box = pic_box_num as PictureBox;

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
                procCommand.Exited += (sender, e) => { Change_image(pic_box, true); };


            }

            catch { };
        }
        //Очистка логов POS сервера, если путь 2
        public static void Logs_Pos_2(string Address, int day, object pic_box_num)
        {
            var pic_box = pic_box_num as PictureBox;

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
                procCommand.Exited += (sender, e) => { Change_image(pic_box, true); };


            }

            catch { };
        }

        //Очистка данные об RMS клиентов 
        public static void Delete_date_RMS(string Addres, object pic_box_num)
        {
            var pic_box = pic_box_num as PictureBox;

            try
            {
                ProcessStartInfo ppt = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c cd C:\\Users\\User\\AppData\\Roaming\\iiko & rd /s /q RMS",
                    WindowStyle = ProcessWindowStyle.Hidden


                };

                Process procCommand = Process.Start(ppt);

                procCommand.EnableRaisingEvents = true;
                procCommand.Exited += (sender, e) => { Change_image(pic_box, true); };


            }

            catch { };




        }
        public static void Loading_deleted(object pic_box_num)
        {
            var pic_box = pic_box_num as PictureBox;

            try
            {
                ProcessStartInfo ppt = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/c cd %userprofile% & rd /s /q Downloads",
                    WindowStyle = ProcessWindowStyle.Normal


                };

                Process procCommand = Process.Start(ppt);

                procCommand.EnableRaisingEvents = true;
                procCommand.Exited += (sender, e) => { Change_image(pic_box, true); };


            }

            catch { };
        }

        public static void Change_image(object img_box, bool ready)
        {
            var img_box_ = img_box as PictureBox;
            img_box_.SizeMode = PictureBoxSizeMode.StretchImage;
            if (ready == true)
            {
                img_box_.Image = Image.FromFile(@"img\correct.png");
            }
            else 
            {
                img_box_.Image = Image.FromFile(@"img\cross.png");
            }
            
            
        }

    }
}
