namespace TimesheetAssistant
{
    partial class FrmLogs
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.Calendar = new System.Windows.Forms.MonthCalendar();
            this.lblEntry = new System.Windows.Forms.TextBox();
            this.tlpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Controls.Add(this.Calendar, 0, 0);
            this.tlpMain.Controls.Add(this.lblEntry, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Size = new System.Drawing.Size(384, 361);
            this.tlpMain.TabIndex = 0;
            // 
            // Calendar
            // 
            this.Calendar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Calendar.BackColor = System.Drawing.SystemColors.Control;
            this.tlpMain.SetColumnSpan(this.Calendar, 2);
            this.Calendar.Location = new System.Drawing.Point(78, 9);
            this.Calendar.MaxSelectionCount = 1;
            this.Calendar.Name = "Calendar";
            this.Calendar.ShowToday = false;
            this.Calendar.TabIndex = 0;
            this.Calendar.TabStop = false;
            this.Calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Calendar_DateChanged);
            // 
            // lblEntry
            // 
            this.lblEntry.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEntry.Location = new System.Drawing.Point(3, 183);
            this.lblEntry.Multiline = true;
            this.lblEntry.Name = "lblEntry";
            this.lblEntry.ReadOnly = true;
            this.lblEntry.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblEntry.Size = new System.Drawing.Size(378, 175);
            this.lblEntry.TabIndex = 1;
            // 
            // FrmLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.tlpMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmLogs";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Log Entries";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmLogs_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.MonthCalendar Calendar;
        private System.Windows.Forms.TextBox lblEntry;
    }
}