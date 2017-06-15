using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimesheetAssistant
{
    public partial class FrmLogs : Form
    {
        public static TASettings Settings = FrmMain.Settings;

        public FrmLogs()
        {
            InitializeComponent();
        }

        private void FrmLogs_Load(object sender, EventArgs e)
        {
            Calendar.TodayDate = DateTime.Today;
            Width = Calendar.Width * 2;
            Height = (int)(Calendar.Height * 2.5);
            tlpMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpMain.AutoSize = true;
            lblEntry.Height = tlpMain.Height - Calendar.Height;
            Calendar.SetSelectionRange(DateTime.Today, DateTime.Today);
        }

        private void Calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime date = e.Start;

            //Speed up access times
            Dictionary<string, List<TimeEntry>> TimeSpent = Settings.TimeSpent;
            Dictionary<string, List<Log>> Logs = Settings.Logs;
            Logs.Reverse();

            Dictionary<string, uint> projectTimes = new Dictionary<string, uint>();
            foreach (KeyValuePair<string, List<TimeEntry>> entryPair in TimeSpent)
            {
                if (DateTime.Parse(entryPair.Key.Substring(entryPair.Key.IndexOf(';') + 1)) == date)
                {
                    if (!projectTimes.ContainsKey(entryPair.Key)) projectTimes.Add(entryPair.Key, 0);
                    foreach (TimeEntry entry in entryPair.Value) projectTimes[entryPair.Key] += (uint)entry.Duration.TotalMinutes;
                }
            }

            lblEntry.Text = "Time spent:\n";
            foreach (KeyValuePair<String, uint> pair in projectTimes)
            {
                lblEntry.Text += $"  {pair.Key.Substring(0, pair.Key.IndexOf(';'))}: {TimeSpan.FromMinutes(pair.Value).ToString()}\n";
            }

            Dictionary<string, Dictionary<TimeSpan, string>> logList = new Dictionary<string, Dictionary<TimeSpan, string>>();
            foreach (KeyValuePair<string, List<Log>> logPair in Logs)
            {
                DateTime locKey = DateTime.Parse(logPair.Key.Substring(logPair.Key.IndexOf(';') + 1));
                if (locKey == date)
                {
                    foreach (Log log in logPair.Value)
                    {
                        if (!logList.ContainsKey(log.Project)) logList.Add(log.Project, new Dictionary<TimeSpan, string>());
                        logList[log.Project].Add(log.Time.StartTime.TimeOfDay, log.Text);
                    }
                }
            }

            lblEntry.Text += "\nLogs:\n";
            foreach (KeyValuePair<string, Dictionary<TimeSpan, string>> logPair in logList)
            {
                lblEntry.Text += $"  {logPair.Key}:\n";
                foreach (KeyValuePair<TimeSpan, string> log in logPair.Value)
                {
                    lblEntry.Text += $"    {log.Key}: {log.Value}\n";
                }
            }
        }
    }
}
