using System;
using System.Drawing;
using System.Speech.Recognition;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimesheetAssistant
{
    public partial class FrmSetup : Form
    {
        public static TASettings Settings = FrmMain.Settings;

        public FrmSetup()
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

        private void BtnAddProjects_Click(object sender, EventArgs e)
        {
            uint numProjects = Settings.NumProjects;

            ErrorCheck:
            string projName = Prompt.ShowDialog("Project Name?", "Add Project");
            if (projName == "") goto ErrorCheck;

            Settings.Projects.Add(projName);
            Settings.NumProjects = ++numProjects;
            Settings.Save();
            Settings.Reload();
        }

        private void BtnDelProjects_Click(object sender, EventArgs e)
        {
            Settings.Reload();
            uint numProjects = Settings.NumProjects;
            
            string projName = Prompt.ShowDialog("Project Name?", "Remove Project", Settings.Projects.ToArray());
            if (projName == "") return;


            Settings.Projects.Remove(projName);
            Settings.NumProjects = --numProjects;
            Settings.Save();
            Settings.Reload();
        }

        private void BtnInterval_Click(object sender, EventArgs e)
        {
            ErrorCheck:
            string promptRet = Prompt.ShowDialog("Set Billing/Logging Interval", TimeSpan.FromMinutes(Settings.BillInterval), TimeSpan.FromMinutes(Settings.TrackInterval));
            if (promptRet == "") goto ErrorCheck;
            TimeSpan billInt = TimeSpan.Parse(promptRet.Substring(0, promptRet.IndexOf(';')));
            TimeSpan trackInt = TimeSpan.Parse(promptRet.Substring(promptRet.IndexOf(';') + 1));
            
            Settings.BillInterval = (uint)billInt.TotalMinutes;
            Settings.TrackInterval = (uint)trackInt.TotalMinutes;
            Settings.Save();
            Settings.Reload();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Settings.Save();
            Close();
        }
    }

    public static partial class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 350 };
            Button voice = new Button() { Left = 405, Top = 48, Width = 45, BackgroundImage = Image.FromFile("mic.png"), BackgroundImageLayout = ImageLayout.Zoom};
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            voice.Click += (sender, e) =>
            {
                prompt.Enabled = false;
                SpeechRecognitionEngine recog = new SpeechRecognitionEngine();
                recog.LoadGrammar(new DictationGrammar());
                recog.SetInputToDefaultAudioDevice();
                RecognitionResult res = null;
                while (res == null)
                {
                    System.Media.SystemSounds.Beep.Play();
                    res = Task.Run(() => recog.Recognize()).Result;
                }
                textBox.Text = char.ToUpper(res.Text[0]) + res.Text.Substring(1);
                prompt.Enabled = true;
            };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(voice);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        public static string ShowDialog(string text, string caption, string[] autoCompleteOptions)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            acsc.AddRange(autoCompleteOptions);
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, AutoSize = true };
            ComboBox project = new ComboBox() { Left = 50, Top = 50, Width = 350, AutoCompleteMode = AutoCompleteMode.SuggestAppend, AutoCompleteCustomSource = acsc, AutoCompleteSource = AutoCompleteSource.CustomSource };
            Button voice = new Button() { Left = 405, Top = 48, Width = 45, BackgroundImage = Image.FromFile("mic.png"), BackgroundImageLayout = ImageLayout.Zoom };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            voice.Click += (sender, e) =>
            {
                prompt.Enabled = false;
                SpeechRecognitionEngine recog = new SpeechRecognitionEngine();
                GrammarBuilder gb = new GrammarBuilder();
                foreach (string entry in autoCompleteOptions) gb.Append(entry);
                recog.LoadGrammar(new Grammar(gb));
                recog.SetInputToDefaultAudioDevice();
                RecognitionResult res = null;
                while (res == null)
                { 
                    System.Media.SystemSounds.Beep.Play();
                    res = Task.Run(() => recog.Recognize()).Result;
                }
                project.Text = res.Text;
                prompt.Enabled = true;
            };
            prompt.Controls.Add(project);
            prompt.Controls.Add(voice);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? project.Text : "";
        }

        public static string ShowDialog(string caption, TimeSpan billInterval, TimeSpan trackInterval)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabelBill = new Label() { Left = 30, Top = 20, Text = "Billing interval (mins):", Width = 120 };
            Label textLabelTrack = new Label() { Left = 30, Top = 50, Text = "Logging interval (mins):", Width = 120 };
            NumericUpDown nudBillInt = new NumericUpDown() { Left = 170, Top = 20, Width = 40, Value = (int)billInterval.TotalMinutes };
            NumericUpDown nudTrackInt = new NumericUpDown() { Left = 170, Top = 50, Width = 40, Value = (int)trackInterval.TotalMinutes };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(nudBillInt);
            prompt.Controls.Add(nudTrackInt);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabelBill);
            prompt.Controls.Add(textLabelTrack);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? TimeSpan.FromMinutes((double)nudBillInt.Value).ToString() + ";" + TimeSpan.FromMinutes((double)nudTrackInt.Value).ToString() : "";
        }
    }
}
