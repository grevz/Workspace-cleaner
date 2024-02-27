
namespace WorkspaceCleaner
{
    partial class WorkspaceCleaner
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
            this.checkBox_loading = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            // checkBox_loading
            // 
            this.checkBox_loading.AutoSize = true;
            this.checkBox_loading.Location = new System.Drawing.Point(13, 109);
            this.checkBox_loading.Name = "checkBox_loading";
            this.checkBox_loading.Size = new System.Drawing.Size(122, 17);
            this.checkBox_loading.TabIndex = 5;
            this.checkBox_loading.Text = "Очистить загрузки";
            this.checkBox_loading.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 16;
            // 
            // WorkspaceCleaner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 177);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_loading);
            this.Controls.Add(this.checkBox_date_rms);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox_logs_posserver);
            this.Controls.Add(this.checkBox_logs_30days);
            this.Controls.Add(this.checkBox_temporary_files);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorkspaceCleaner";
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
        private System.Windows.Forms.CheckBox checkBox_loading;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}