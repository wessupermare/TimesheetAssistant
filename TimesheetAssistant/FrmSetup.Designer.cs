namespace TimesheetAssistant
{
    partial class FrmSetup
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnDelProjects = new System.Windows.Forms.Button();
            this.BtnInterval = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnAddProjects = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.BtnDelProjects, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BtnInterval, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnOK, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BtnAddProjects, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 361);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BtnDelProjects
            // 
            this.BtnDelProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDelProjects.Location = new System.Drawing.Point(3, 183);
            this.BtnDelProjects.Name = "BtnDelProjects";
            this.BtnDelProjects.Size = new System.Drawing.Size(186, 175);
            this.BtnDelProjects.TabIndex = 5;
            this.BtnDelProjects.Text = "Delete Project";
            this.BtnDelProjects.UseVisualStyleBackColor = true;
            this.BtnDelProjects.Click += new System.EventHandler(this.BtnDelProjects_Click);
            // 
            // BtnInterval
            // 
            this.BtnInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnInterval.Location = new System.Drawing.Point(195, 3);
            this.BtnInterval.Name = "BtnInterval";
            this.BtnInterval.Size = new System.Drawing.Size(186, 174);
            this.BtnInterval.TabIndex = 4;
            this.BtnInterval.Text = "Change Billing/Logging Interval";
            this.BtnInterval.UseVisualStyleBackColor = true;
            this.BtnInterval.Click += new System.EventHandler(this.BtnInterval_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnOK.Location = new System.Drawing.Point(195, 183);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(186, 175);
            this.BtnOK.TabIndex = 3;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnAddProjects
            // 
            this.BtnAddProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAddProjects.Location = new System.Drawing.Point(3, 3);
            this.BtnAddProjects.Name = "BtnAddProjects";
            this.BtnAddProjects.Size = new System.Drawing.Size(186, 174);
            this.BtnAddProjects.TabIndex = 2;
            this.BtnAddProjects.Text = "Add Project";
            this.BtnAddProjects.UseVisualStyleBackColor = true;
            this.BtnAddProjects.Click += new System.EventHandler(this.BtnAddProjects_Click);
            // 
            // FrmSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmSetup";
            this.Text = "Settings";
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BtnDelProjects;
        private System.Windows.Forms.Button BtnInterval;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnAddProjects;
    }
}