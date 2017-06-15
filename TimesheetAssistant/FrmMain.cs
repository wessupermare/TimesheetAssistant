using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TimesheetAssistant
{
    public partial class FrmMain : Form
    {
        public static TASettings Settings;
        private string ActiveProject;
        private DateTime SessionStartTime;

        public FrmMain()
        {
            InitializeComponent();
            try
            {
                Settings.Reload();
                uint tmpInt = Settings.NumProjects;
            }
            catch
            {
                Settings = new TASettings();
                Settings.Save();
                Settings.Reload();
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (Settings.NumProjects == 0)
            {
                using (Form frmSetup = new FrmSetup())
                {
                    frmSetup.ShowDialog();
                }
                Settings.Reload();
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            using (Form frmSetup = new FrmSetup())
            {
                frmSetup.ShowDialog();
            }
            Settings.Reload();
        }

        private void BtnTime_Click(object sender, EventArgs e)
        {
            if (BtnTime.Text == "Start")
            {
                ActiveProject = Prompt.ShowDialog("What project are you working on?", "Select Active Project", Settings.Projects.ToArray());
                if (ActiveProject == "") return;

                BtnTime.Text = "Stop";
                Timer.Interval = (int)new TimeSpan(0, (int)Settings.TrackInterval, 0).TotalMilliseconds;
                SessionStartTime = DateTime.Now;
                Timer.Enabled = true;
            }
            else
            {
                Timer.Enabled = false;
                DateTime SessionEndTime = DateTime.Now;
                BtnTime.Text = "Start";
                Dictionary<string, List<TimeEntry>> tmpDic = Settings.TimeSpent;
                List<TimeEntry> tmpList = null;

                try
                {
                    tmpList = tmpDic[$"{ActiveProject};{DateTime.Today.Date}"];
                    tmpList.Add(new TimeEntry { StartTime = SessionStartTime, Duration = TimeSpan.FromMinutes((int)Math.Round(SessionEndTime.Subtract(SessionStartTime).TotalMinutes, 0)) });
                    tmpDic[$"{ActiveProject};{DateTime.Today.Date}"] = tmpList;
                    Settings.TimeSpent = tmpDic;
                }
                catch
                {
                    try
                    {
                        tmpList = new List<TimeEntry> { new TimeEntry { StartTime = SessionStartTime, Duration = TimeSpan.FromMinutes((int)Math.Round(SessionEndTime.Subtract(SessionStartTime).TotalMinutes, 0)) } };
                        tmpDic.Add($"{ActiveProject};{DateTime.Today.Date}", tmpList);
                        Settings.TimeSpent = tmpDic;
                    }
                    catch
                    {
                        Settings.TimeSpent = new Dictionary<string, List<TimeEntry>>
                        {
                            { $"{ActiveProject};{DateTime.Today.Date}", tmpList }
                        };
                    }
                }

                Dictionary<string, List<Log>> tmpLogDic = Settings.Logs;
                List<Log> tmpLogList = null;
                try
                {
                    tmpLogList = tmpLogDic[$"{ActiveProject};{DateTime.Today.Date}"];
                    tmpLogList.Add(new Log(Prompt.ShowDialog($"What have you done since {SessionStartTime.Hour}:{SessionStartTime.Minute}?", $"Log Entry For {DateTime.Now}"), ActiveProject, new TimeEntry { StartTime = SessionStartTime, Duration = TimeSpan.FromMinutes((int)Math.Round(SessionEndTime.Subtract(SessionStartTime).TotalMinutes, 0)) }));
                    tmpLogDic[$"{ActiveProject};{DateTime.Today.Date}"] = tmpLogList;
                    Settings.Logs = tmpLogDic;
                }
                catch
                {
                    try
                    {
                        tmpLogList = new List<Log> { new Log(Prompt.ShowDialog($"What have you done since {SessionStartTime.Hour}:{SessionStartTime.Minute}?", $"Log Entry For {DateTime.Now}"), ActiveProject, new TimeEntry { StartTime = SessionStartTime, Duration = TimeSpan.FromMinutes((int)Math.Round(SessionEndTime.Subtract(SessionStartTime).TotalMinutes, 0)) }) };
                        tmpLogDic.Add($"{ActiveProject};{DateTime.Today.Date}", tmpLogList);
                        Settings.Logs = tmpLogDic;
                    }
                    catch
                    {
                        Settings.Logs = new Dictionary<string, List<Log>>
                        {
                            { $"{ActiveProject};{DateTime.Today.Date}", new List<Log>
                            {
                                new Log(Prompt.ShowDialog($"What have you done since {SessionStartTime.Hour}:{SessionStartTime.Minute}?", $"Log Entry For {DateTime.Now}"), ActiveProject, new TimeEntry
                                {
                                    StartTime = SessionStartTime, Duration = TimeSpan.FromMinutes((int)Math.Round(SessionEndTime.Subtract(SessionStartTime).TotalMinutes, 0))
                                }
                                )
                            }
                            }
                        };
                    }
                }
                Settings.Save();
                Settings.Reload();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Timer.Enabled = false;
            DateTime SessionEndTime = DateTime.Now;

            try
            {
                Settings.TimeSpent[$"{ActiveProject};{DateTime.Today.Date}"].Add(new TimeEntry { StartTime = SessionStartTime, Duration = TimeSpan.FromMinutes((int)Math.Round(SessionEndTime.Subtract(SessionStartTime).TotalMinutes, 0)) });
            }
            catch
            {
                Settings.TimeSpent.Add($"{ActiveProject};{DateTime.Today.Date}", new List<TimeEntry>());
                Settings.TimeSpent[$"{ActiveProject};{DateTime.Today.Date}"].Add(new TimeEntry { StartTime = SessionStartTime, Duration = TimeSpan.FromMinutes((int)Math.Round(SessionEndTime.Subtract(SessionStartTime).TotalMinutes, 0)) });
            }

            try
            {
                Settings.Logs[$"{ActiveProject};{DateTime.Today.Date}"].Add(new Log(Prompt.ShowDialog($"What have you done since {SessionStartTime.Hour}:{SessionStartTime.Minute}?", $"Log Entry For {DateTime.Now}"), ActiveProject, new TimeEntry { StartTime = SessionStartTime, Duration = TimeSpan.FromMinutes((int)Math.Round(SessionEndTime.Subtract(SessionStartTime).TotalMinutes, 0)) }));
            }
            catch
            {
                Settings.Logs.Add($"{ActiveProject};{DateTime.Today.Date}", new List<Log>());
                Settings.Logs[$"{ActiveProject};{DateTime.Today.Date}"].Add(new Log(Prompt.ShowDialog($"What have you done since {SessionStartTime.Hour}:{SessionStartTime.Minute}?", $"Log Entry For {DateTime.Now}"), ActiveProject, new TimeEntry { StartTime = SessionStartTime, Duration = TimeSpan.FromMinutes((int)Math.Round(SessionEndTime.Subtract(SessionStartTime).TotalMinutes, 0)) }));
            }

            SessionStartTime = DateTime.Now;
            Timer.Enabled = true;
        }

        private void BtnShowLogs_Click(object sender, EventArgs e)
        {
            using (FrmLogs frmLogs = new FrmLogs())
            {
                frmLogs.ShowDialog();
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}