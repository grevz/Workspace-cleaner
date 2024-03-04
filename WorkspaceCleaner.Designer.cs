
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
            this.CheckTempDelLabel = new System.Windows.Forms.Label();
            this.CheckIikoFrontDelLabel = new System.Windows.Forms.Label();
            this.CheckPosDelLabel = new System.Windows.Forms.Label();
            this.CheckRMSDelLabel = new System.Windows.Forms.Label();
            this.CheckLoadingDelLabel = new System.Windows.Forms.Label();
            this.CheckETLLogsDelLabel = new System.Windows.Forms.Label();
            this.checkBoxKKT = new System.Windows.Forms.CheckBox();
            this.LabelLogsKKT = new System.Windows.Forms.Label();
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
            this.button1.Location = new System.Drawing.Point(129, 156);
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
            // CheckTempDelLabel
            // 
            this.CheckTempDelLabel.AutoSize = true;
            this.CheckTempDelLabel.Location = new System.Drawing.Point(267, 13);
            this.CheckTempDelLabel.Name = "CheckTempDelLabel";
            this.CheckTempDelLabel.Size = new System.Drawing.Size(13, 13);
            this.CheckTempDelLabel.TabIndex = 12;
            this.CheckTempDelLabel.Text = "  ";
            // 
            // CheckIikoFrontDelLabel
            // 
            this.CheckIikoFrontDelLabel.AutoSize = true;
            this.CheckIikoFrontDelLabel.Location = new System.Drawing.Point(267, 37);
            this.CheckIikoFrontDelLabel.Name = "CheckIikoFrontDelLabel";
            this.CheckIikoFrontDelLabel.Size = new System.Drawing.Size(13, 13);
            this.CheckIikoFrontDelLabel.TabIndex = 13;
            this.CheckIikoFrontDelLabel.Text = "  ";
            // 
            // CheckPosDelLabel
            // 
            this.CheckPosDelLabel.AutoSize = true;
            this.CheckPosDelLabel.Location = new System.Drawing.Point(267, 62);
            this.CheckPosDelLabel.Name = "CheckPosDelLabel";
            this.CheckPosDelLabel.Size = new System.Drawing.Size(13, 13);
            this.CheckPosDelLabel.TabIndex = 14;
            this.CheckPosDelLabel.Text = "  ";
            // 
            // CheckRMSDelLabel
            // 
            this.CheckRMSDelLabel.AutoSize = true;
            this.CheckRMSDelLabel.Location = new System.Drawing.Point(267, 86);
            this.CheckRMSDelLabel.Name = "CheckRMSDelLabel";
            this.CheckRMSDelLabel.Size = new System.Drawing.Size(13, 13);
            this.CheckRMSDelLabel.TabIndex = 15;
            this.CheckRMSDelLabel.Text = "  ";
            // 
            // CheckLoadingDelLabel
            // 
            this.CheckLoadingDelLabel.AutoSize = true;
            this.CheckLoadingDelLabel.Location = new System.Drawing.Point(267, 110);
            this.CheckLoadingDelLabel.Name = "CheckLoadingDelLabel";
            this.CheckLoadingDelLabel.Size = new System.Drawing.Size(13, 13);
            this.CheckLoadingDelLabel.TabIndex = 16;
            this.CheckLoadingDelLabel.Text = "  ";
            // 
            // CheckETLLogsDelLabel
            // 
            this.CheckETLLogsDelLabel.AutoSize = true;
            this.CheckETLLogsDelLabel.Location = new System.Drawing.Point(291, 13);
            this.CheckETLLogsDelLabel.Name = "CheckETLLogsDelLabel";
            this.CheckETLLogsDelLabel.Size = new System.Drawing.Size(13, 13);
            this.CheckETLLogsDelLabel.TabIndex = 17;
            this.CheckETLLogsDelLabel.Text = "  ";
            // 
            // checkBoxKKT
            // 
            this.checkBoxKKT.AutoSize = true;
            this.checkBoxKKT.Location = new System.Drawing.Point(13, 133);
            this.checkBoxKKT.Name = "checkBoxKKT";
            this.checkBoxKKT.Size = new System.Drawing.Size(119, 17);
            this.checkBoxKKT.TabIndex = 18;
            this.checkBoxKKT.Text = "Удалить логи ККТ";
            this.checkBoxKKT.UseVisualStyleBackColor = true;
            // 
            // LabelLogsKKT
            // 
            this.LabelLogsKKT.AutoSize = true;
            this.LabelLogsKKT.Location = new System.Drawing.Point(267, 134);
            this.LabelLogsKKT.Name = "LabelLogsKKT";
            this.LabelLogsKKT.Size = new System.Drawing.Size(13, 13);
            this.LabelLogsKKT.TabIndex = 19;
            this.LabelLogsKKT.Text = "  ";
            // 
            // WorkspaceCleaner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 199);
            this.Controls.Add(this.LabelLogsKKT);
            this.Controls.Add(this.checkBoxKKT);
            this.Controls.Add(this.CheckETLLogsDelLabel);
            this.Controls.Add(this.CheckLoadingDelLabel);
            this.Controls.Add(this.CheckRMSDelLabel);
            this.Controls.Add(this.CheckPosDelLabel);
            this.Controls.Add(this.CheckIikoFrontDelLabel);
            this.Controls.Add(this.CheckTempDelLabel);
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
        private System.Windows.Forms.Label CheckTempDelLabel;
        private System.Windows.Forms.Label CheckIikoFrontDelLabel;
        private System.Windows.Forms.Label CheckPosDelLabel;
        private System.Windows.Forms.Label CheckRMSDelLabel;
        private System.Windows.Forms.Label CheckLoadingDelLabel;
        private System.Windows.Forms.Label CheckETLLogsDelLabel;
        private System.Windows.Forms.CheckBox checkBoxKKT;
        private System.Windows.Forms.Label LabelLogsKKT;
    }
}