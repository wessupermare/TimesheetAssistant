using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace TimesheetAssistant
{
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public class TASettings : ApplicationSettingsBase
    {
        public TASettings()
        {
            try
            {
                Reload();
                uint tmpInt = (uint)this["NumProjects"];
            }
            catch
            {
                Initialize(new SettingsContext(), new SettingsPropertyCollection(), new SettingsProviderCollection());
                this["NumProjects"] = (uint)0;
                this["BillInterval"] = (uint)30;
                this["TrackInterval"] = (uint)60;
                this["Projects"] = new List<string>();
                Save();
                Reload();
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("0")]
        public uint NumProjects { get { return (uint)this["NumProjects"]; } set { this["NumProjects"] = value; } }

        [UserScopedSetting()]
        [DefaultSettingValue("30")]
        public uint BillInterval { get { return (uint)this["BillInterval"]; } set { this["BillInterval"] = value; } }

        [UserScopedSetting()]
        [DefaultSettingValue("60")]
        public uint TrackInterval { get { return (uint)this["TrackInterval"]; } set { this["TrackInterval"] = value; } }

        [UserScopedSetting()]
        public List<string> Projects { get { return (List<string>)this["Projects"]; } set { this["Projects"] = value; } }

        [UserScopedSetting()]
        public Dictionary<string, List<TimeEntry>> TimeSpent { get { return ReadTimes(); } set { WriteTimes(value); } }
        
        [UserScopedSetting()]
        public Dictionary<string, List<Log>> Logs { get { return ReadLogs(); } set { WriteLogs(value); } }

        private Dictionary<string, List<TimeEntry>> ReadTimes ()
        {
            Dictionary<string, List<TimeEntry>> retVal = new Dictionary<string, List<TimeEntry>>();
            string path = Application.LocalUserAppDataPath + "\\TimeEntries.TALog";
            if (!File.Exists(path)) return retVal;

            string[] timeStrings = File.ReadAllLines(path);

            foreach (string timeString in timeStrings)
            {
                string keyStr = timeString.Substring(0, timeString.IndexOf('>'));
                string valueStr = timeString.Substring(timeString.IndexOf('>') + 1);
                retVal.Add(keyStr, new List<TimeEntry>());

                foreach (string value in valueStr.Split('>'))
                    if (value != "")
                        retVal[keyStr].Add(TimeEntry.Parse(value));
            }

            return retVal;
        }

        private void WriteTimes(Dictionary<string, List<TimeEntry>> timeDictionary)
        {
            string path = Application.LocalUserAppDataPath + "\\TimeEntries.TALog";
            if (!File.Exists(path)) (File.CreateText(path)).Close();

            List<string> timeStrings = new List<string>();

            foreach(KeyValuePair<string, List<TimeEntry>> entryPair in timeDictionary)
            {
                List<TimeEntry> entries = entryPair.Value;

                string timeString = entryPair.Key + '>';
                foreach (TimeEntry entry in entries)
                    timeString += entry.ToString() + '>';

                timeString.TrimEnd('>');
                timeStrings.Add(timeString);
            }

            File.WriteAllLines(path, timeStrings.ToArray());
        }

        private Dictionary<string, List<Log>> ReadLogs()
        {
            Dictionary<string, List<Log>> retVal = new Dictionary<string, List<Log>>();
            string path = Application.LocalUserAppDataPath + "\\Logs.TALog";
            if (!File.Exists(path)) return retVal;

            string[] logStrings = File.ReadAllLines(path);

            foreach (string logString in logStrings)
            {
                string keyStr = logString.Substring(0, logString.IndexOf('>'));
                string valueStr = logString.Substring(logString.IndexOf('>') + 1);
                retVal.Add(keyStr, new List<Log>());

                foreach (string value in valueStr.Split(new string[] { ";LOG;LOG;" }, StringSplitOptions.RemoveEmptyEntries))
                    retVal[keyStr].Add(Log.Parse(value));
            }

            return retVal;
        }

        private void WriteLogs(Dictionary<string, List<Log>> logDictionary)
        {
            string path = Application.LocalUserAppDataPath + "\\Logs.TALog";
            if (!File.Exists(path)) (File.CreateText(path)).Close();

            List<string> logStrings = new List<string>();

            foreach (KeyValuePair<string, List<Log>> entryPair in logDictionary)
            {
                List<Log> entries = entryPair.Value;

                string logString = entryPair.Key + '>';
                foreach (Log entry in entries)
                    logString += entry.ToString() + ";LOG;LOG;";

                if (logString.EndsWith(";LOG;LOG;")) logString = logString.Remove(logString.Length - ";LOG;LOG;".Length);
                logStrings.Add(logString);
            }

            File.WriteAllLines(path, logStrings.ToArray());
        }
    }

    public class Log
    {
        public TASettings Settings = new TASettings();
        public string Text;
        public string Project;
        public TimeEntry Time;

        public Log()
        {
            Time = new TimeEntry();
        }

        public Log(string text, string project)
        {
            Text = text;
            Project = project;
            Time = new TimeEntry { StartTime = DateTime.Now.AddMinutes(-Settings.TrackInterval), Duration = TimeSpan.FromMinutes(Settings.TrackInterval) };
        }
        
        public Log(string text, string project, TimeEntry time) : this(text, project)
        {
            Time = time;
        }

        public override string ToString()
        {
            return Time.ToString() + "$#LIL#$" + Project + "$#LIL#$" + Text;
        }

        public static Log Parse(string str)
        {
            Log retVal = new Log();

            int lastIndex = str.Substring(str.IndexOf("$#LIL#$") + 7).IndexOf("$#LIL#$");

            retVal.Time = TimeEntry.Parse(str.Substring(0, str.IndexOf("$#LIL#$")));
            retVal.Project = str.Substring(str.IndexOf("$#LIL#$") + 7, lastIndex);
            retVal.Text = str.Substring(str.IndexOf("$#LIL#$") + lastIndex + 14);

            return retVal;
        }
    }

    public class TimeEntry
    {
        public DateTime StartTime;
        public TimeSpan Duration;

        public TimeEntry()
        {
            StartTime = new DateTime();
            Duration = new TimeSpan();
        }

        public TimeEntry(DateTime startTime, TimeSpan duration)
        {
            StartTime = startTime;
            Duration = duration;
        }

        public override string ToString()
        {
            return StartTime.ToString() + "_" + Duration.ToString();
        }

        public static TimeEntry Parse(string str)
        {
            return new TimeEntry
            {
                StartTime = DateTime.Parse(str.Substring(0, str.IndexOf('_'))),
                Duration = TimeSpan.Parse(str.Substring(str.IndexOf('_') + 1))
            };
        }
    }
}
