using System;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Globalization;
using System.Threading.Tasks;


namespace WindowsFormsApplication1
{
    public partial class WinFormTimer : Form
    {

        public WinFormTimer()
        {
            InitializeComponent();

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName == "")
            {
                MessageBox.Show("Не выбран сигнал будильника");
                buttonMelody_Click(sender, e); 
            }
            SheduleHelper.Shedule();
            SheduleHelper.initWeekParity = SheduleHelper.GetWeekParity();

            AlarmCore.tokenSource = new CancellationTokenSource();
            Task task = Task.Factory.StartNew(AlarmCore.ThreadFunction, AlarmCore.tokenSource.Token);
           
            this.buttonStop.Enabled = true;
            this.buttonStart.Enabled = false;
            
        }

        private void buttonMelody_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "MP3 Files|*.mp3|All Files|*.*";
            openFileDialog1.Title = "Select an mp3";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            { FileInfo fi = new FileInfo(openFileDialog1.FileName); }
            string s = openFileDialog1.FileName;
            if(s.Length>60)
                labelFilePath.Text = s.Substring(0, s.IndexOf("\\") + 1) + "..." + s.Substring(s.LastIndexOf("\\"), s.Length - s.LastIndexOf("\\"));
            else labelFilePath.Text = openFileDialog1.FileName;
        }

        private void checkBoxWeekdays_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                checkedListBox1.SetItemChecked(i, this.checkBoxWeekdays.Checked);
                checkedListBox2.SetItemChecked(i, this.checkBoxWeekdays.Checked);
            }
            for (int i = 5; i < 7; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
                checkedListBox2.SetItemChecked(i, false);
            }
        }

        public void buttonStop_Click()
        {
            AlarmCore.CancelWaitableTimer(AlarmCore.handle);
            AlarmCore.tokenSource.Cancel();
            this.labelDateX.Text = "Задайте время сигнала";
            this.buttonStop.Enabled = false;
            this.buttonStart.Enabled = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStop_Click();
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIcon.Visible = false;
            this.ShowInTaskbar = true;
            this.Visible = true;
            WindowState = FormWindowState.Normal;
        }

        private void radioButtonSheduleBell_CheckedChanged(object sender, EventArgs e)
        {
            this.checkedListBox1.Visible = this.radioButtonSheduleBell.Checked;
            this.checkedListBox2.Visible = this.radioButtonSheduleBell.Checked;
            this.checkBoxWeekdays.Visible = this.radioButtonSheduleBell.Checked;
            this.labelWeek1.Visible = this.radioButtonSheduleBell.Checked;
            this.labelWeek2.Visible = this.radioButtonSheduleBell.Checked;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Программа \"Будильник\" v1.0 \r\n Автор Маслов Никита, г.Самара \r\n Просыпайтесь с удовольствием!", "О программе");
        }

        private void Form1_Closing(object sender, EventArgs e)
        {
            if(buttonStop.Enabled)
            buttonStop_Click();
        }
    }
}
