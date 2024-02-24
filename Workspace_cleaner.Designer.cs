
namespace Workspace_cleaner
{
    partial class Workspace_cleaner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBox_temporary_files = new System.Windows.Forms.CheckBox();
            this.checkBox_logs_30days = new System.Windows.Forms.CheckBox();
            this.checkBox_logs_posserver = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox_date_rms = new System.Windows.Forms.CheckBox();
            this.checkBox_dism = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBox_temporary_files
            // 
            this.checkBox_temporary_files.AutoSize = true;
            this.checkBox_temporary_files.Location = new System.Drawing.Point(13, 13);
            this.checkBox_temporary_files.Name = "checkBox_temporary_files";
            this.checkBox_temporary_files.Size = new System.Drawing.Size(218, 17);
            this.checkBox_temporary_files.TabIndex = 0;
            this.checkBox_temporary_files.Text = "Очистить временные файлы Windows";
            this.checkBox_temporary_files.UseVisualStyleBackColor = true;
            // 
            // checkBox_logs_30days
            // 
            this.checkBox_logs_30days.AutoSize = true;
            this.checkBox_logs_30days.Location = new System.Drawing.Point(13, 37);
            this.checkBox_logs_30days.Name = "checkBox_logs_30days";
            this.checkBox_logs_30days.Size = new System.Drawing.Size(199, 17);
            this.checkBox_logs_30days.TabIndex = 1;
            this.checkBox_logs_30days.Text = "Очистить логи iikoFront за 30 дней";
            this.checkBox_logs_30days.UseVisualStyleBackColor = true;
            // 
            // checkBox_logs_posserver
            // 
            this.checkBox_logs_posserver.AutoSize = true;
            this.checkBox_logs_posserver.Location = new System.Drawing.Point(13, 61);
            this.checkBox_logs_posserver.Name = "checkBox_logs_posserver";
            this.checkBox_logs_posserver.Size = new System.Drawing.Size(247, 17);
            this.checkBox_logs_posserver.TabIndex = 2;
            this.checkBox_logs_posserver.Text = "Очистить логи Pos сервера старше 10 дней";
            this.checkBox_logs_posserver.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Выполнить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_date_rms
            // 
            this.checkBox_date_rms.AutoSize = true;
            this.checkBox_date_rms.Location = new System.Drawing.Point(13, 85);
            this.checkBox_date_rms.Name = "checkBox_date_rms";
            this.checkBox_date_rms.Size = new System.Drawing.Size(191, 17);
            this.checkBox_date_rms.TabIndex = 4;
            this.checkBox_date_rms.Text = "Очистить данные RMS клиентов";
            this.checkBox_date_rms.UseVisualStyleBackColor = true;
            // 
            // checkBox_dism
            // 
            this.checkBox_dism.AutoSize = true;
            this.checkBox_dism.Location = new System.Drawing.Point(13, 109);
            this.checkBox_dism.Name = "checkBox_dism";
            this.checkBox_dism.Size = new System.Drawing.Size(94, 17);
            this.checkBox_dism.TabIndex = 5;
            this.checkBox_dism.Text = "Очистка Dism";
            this.checkBox_dism.UseVisualStyleBackColor = true;
            // 
            // Workspace_cleaner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 196);
            this.Controls.Add(this.checkBox_dism);
            this.Controls.Add(this.checkBox_date_rms);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox_logs_posserver);
            this.Controls.Add(this.checkBox_logs_30days);
            this.Controls.Add(this.checkBox_temporary_files);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Workspace_cleaner";
            this.Text = "Workspace cleaner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_temporary_files;
        private System.Windows.Forms.CheckBox checkBox_logs_30days;
        private System.Windows.Forms.CheckBox checkBox_logs_posserver;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox_date_rms;
        private System.Windows.Forms.CheckBox checkBox_dism;
    }
}