
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
            this.Temporary_files = new System.Windows.Forms.CheckBox();
            this.Logs_30days = new System.Windows.Forms.CheckBox();
            this.Logs_PosServer = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Date_RMS = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Temporary_files
            // 
            this.Temporary_files.AutoSize = true;
            this.Temporary_files.Location = new System.Drawing.Point(13, 13);
            this.Temporary_files.Name = "Temporary_files";
            this.Temporary_files.Size = new System.Drawing.Size(218, 17);
            this.Temporary_files.TabIndex = 0;
            this.Temporary_files.Text = "Очистить временные файлы Windows";
            this.Temporary_files.UseVisualStyleBackColor = true;
            // 
            // Logs_30days
            // 
            this.Logs_30days.AutoSize = true;
            this.Logs_30days.Location = new System.Drawing.Point(13, 37);
            this.Logs_30days.Name = "Logs_30days";
            this.Logs_30days.Size = new System.Drawing.Size(199, 17);
            this.Logs_30days.TabIndex = 1;
            this.Logs_30days.Text = "Очистить логи iikoFront за 30 дней";
            this.Logs_30days.UseVisualStyleBackColor = true;
            // 
            // Logs_PosServer
            // 
            this.Logs_PosServer.AutoSize = true;
            this.Logs_PosServer.Location = new System.Drawing.Point(13, 61);
            this.Logs_PosServer.Name = "Logs_PosServer";
            this.Logs_PosServer.Size = new System.Drawing.Size(247, 17);
            this.Logs_PosServer.TabIndex = 2;
            this.Logs_PosServer.Text = "Очистить логи Pos сервера старше 10 дней";
            this.Logs_PosServer.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Выполнить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Date_RMS
            // 
            this.Date_RMS.AutoSize = true;
            this.Date_RMS.Location = new System.Drawing.Point(13, 85);
            this.Date_RMS.Name = "Date_RMS";
            this.Date_RMS.Size = new System.Drawing.Size(191, 17);
            this.Date_RMS.TabIndex = 4;
            this.Date_RMS.Text = "Очистить данные RMS клиентов";
            this.Date_RMS.UseVisualStyleBackColor = true;
            // 
            // Workspace_cleaner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 159);
            this.Controls.Add(this.Date_RMS);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Logs_PosServer);
            this.Controls.Add(this.Logs_30days);
            this.Controls.Add(this.Temporary_files);
            this.Name = "Workspace_cleaner";
            this.Text = "Workspace cleaner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Temporary_files;
        private System.Windows.Forms.CheckBox Logs_30days;
        private System.Windows.Forms.CheckBox Logs_PosServer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox Date_RMS;
    }
}