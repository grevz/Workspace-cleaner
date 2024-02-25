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

        //TODO: Проверка мейн попробовать изменить
        private void button1_Click(object sender, EventArgs e)
        {
            //Проверяем какие функции включены
            if (checkBox_temporary_files.Checked == true) //Проверка на временные файлы
            {
                string comand_for_del = "/c del % temp % / s / f / q & del % programdata %\\Microsoft\\Diagnosis\\ETLLogs / s / f / q";
                Change_image(pictureBox1, false);
                Make_process(pictureBox1, comand_for_del);
            }
            if (checkBox_logs_30days.Checked == true) //Проверка на логи iikoFront
            {
                string comand_for_del = "/c ForFiles /p \"%userprofile%\\AppData\\Roaming\\iiko\\CashServer\\Logs\" /s /c \"cmd /c del @file /f /q\" /d -30";
                Change_image(pictureBox2, false);
                Make_process(pictureBox2, comand_for_del);
            }
            if (checkBox_logs_posserver.Checked == true) //Проверка на логи POS сервера

            {
                Change_image(pictureBox3, false);
                string path_first = "C:\\Windows\\ServiceProfiles\\iikoCard5POS\\AppData\\Roaming\\iiko\\iikoCard5\\Logs";
                string path_second = "C:\\Users\\iikoCard5POS\\AppData\\Roaming\\iiko\\iikoCard5\\Logs";
                if (Directory.Exists(path_first) == true)
                {
                    string command_for_del = "/c ForFiles /p " + path_first + " /s /c \"cmd /c del @file /f /q\" /d -10";
                    Make_process(pictureBox3, command_for_del);
                }
                else
                {
                    if (Directory.Exists(path_second) == true)
                    {
                        string command_for_del = "/c ForFiles /p " + path_second + " /s /c \"cmd /c del @file /f /q\" /d -10";
                        Make_process(pictureBox3, command_for_del);
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
                    string command_for_del = "/c cd C:\\Users\\User\\AppData\\Roaming\\iiko & rd /s /q RMS";
                    Make_process(pictureBox4, command_for_del);
                }
                else
                {
                    MessageBox.Show("Нет данных о RMS на ПК");
                }
            }
            if (checkBox_loading.Checked == true) //Проверка на папку загрузки
            {
                Change_image(pictureBox5, false);
                string command_for_del = "/c cd %userprofile% & rd /s /q Downloads";
                Make_process(pictureBox5, command_for_del);
            }

        }
        //Изменяем картинку
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
        public static void Make_process(object pic_box_num, string arguments)
        {
            var pic_box = pic_box_num as PictureBox;
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
                    Change_image(pic_box, true); ;
                };
            } //Контроль выполнения процесса
            catch { }

        }
    }
}
