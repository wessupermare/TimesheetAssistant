namespace TimesheetAssistant
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnTime = new System.Windows.Forms.Button();
            this.BtnShowLogs = new System.Windows.Forms.Button();
            this.BtnSettings = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.BtnTime, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnShowLogs, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnSettings, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(280, 57);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BtnTime
            // 
            this.BtnTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnTime.Location = new System.Drawing.Point(3, 3);
            this.BtnTime.Name = "BtnTime";
            this.BtnTime.Size = new System.Drawing.Size(87, 51);
            this.BtnTime.TabIndex = 0;
            this.BtnTime.Text = "Start";
            this.BtnTime.UseVisualStyleBackColor = true;
            this.BtnTime.Click += new System.EventHandler(this.BtnTime_Click);
            // 
            // BtnShowLogs
            // 
            this.BtnShowLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnShowLogs.Location = new System.Drawing.Point(96, 3);
            this.BtnShowLogs.Name = "BtnShowLogs";
            this.BtnShowLogs.Size = new System.Drawing.Size(87, 51);
            this.BtnShowLogs.TabIndex = 2;
            this.BtnShowLogs.Text = "Logs";
            this.BtnShowLogs.UseVisualStyleBackColor = true;
            this.BtnShowLogs.Click += new System.EventHandler(this.BtnShowLogs_Click);
            // 
            // BtnSettings
            // 
            this.BtnSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSettings.Location = new System.Drawing.Point(189, 3);
            this.BtnSettings.Name = "BtnSettings";
            this.BtnSettings.Size = new System.Drawing.Size(88, 51);
            this.BtnSettings.TabIndex = 3;
            this.BtnSettings.Text = "Settings";
            this.BtnSettings.UseVisualStyleBackColor = true;
            this.BtnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // Timer
            // 
            this.Timer.Interval = 60000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 57);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "TA Dashboard";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BtnTime;
        private System.Windows.Forms.Button BtnShowLogs;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Button BtnSettings;
    }
}

