using System;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Globalization;
using System.Threading.Tasks;
using WMPLib;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr CreateWaitableTimer(IntPtr lpTimerAttributes,
        bool bManualReset, string lpTimerName);

        [DllImport("kernel32.dll")]
        public static extern bool SetWaitableTimer(IntPtr hTimer, [In] ref long
        pDueTime, int lPeriod, IntPtr pfnCompletionRoutine, IntPtr
        lpArgToCompletionRoutine, bool fResume);

        [DllImport("kernel32", SetLastError = true, ExactSpelling = true)]
        public static extern Int32 WaitForSingleObject(IntPtr handle, uint
        milliseconds);

        [DllImport("kernel32.dll")]
        public static extern bool CancelWaitableTimer(IntPtr hTimer);

        static IntPtr handle;

        static CancellationTokenSource tokenSource;

      
        
        
        public Form1()
        {
            InitializeComponent();
        }

        void PlayMusic()
        {
            WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
            wplayer.URL = Program.myForm.openFileDialog1.FileName;
            (wplayer.settings as WMPLib.IWMPSettings).setMode("loop", true);
            wplayer.controls.play();

            //Устанавливаем автоотключение после 10мин, если пользователь не выключил сигнал
            Action action = () =>
                {
                    Thread.Sleep(600000);
                    wplayer.controls.stop();
                };
            var task = Task.Factory.StartNew(action);

            if (MessageBox.Show("Пора вставать! Отключить сигнал будильника?", "Просыпайся!") == DialogResult.OK);
                wplayer.controls.stop();
        }

        void ThreadFunction()
        {
            CancellationToken ct = tokenSource.Token;
            ct.ThrowIfCancellationRequested();
            while (true)
            {
                int[] restTime = SheduleHelper.GetRestTime();
                if (restTime[0] == -1)
                {
                    Invoke((Action)(() => buttonStop_Click()));
                    break;
                }
                long duetime = -Convert.ToInt64(restTime[0]) * 10000000;
                if (InvokeRequired)
                    Invoke((Action)(() => labelDateX.Text = "Дата следующего сигнала " + SheduleHelper.dateX
                        + String.Format(" {0}-я неделя", restTime[1]>6?2:1)));

                handle = CreateWaitableTimer(IntPtr.Zero, true, "MyWaitabletimer");
                SetWaitableTimer(handle, ref duetime, 0, IntPtr.Zero, IntPtr.Zero, true);
                uint INFINITE = 0xFFFFFFFF;
                int ret = WaitForSingleObject(handle, INFINITE);

                if (ct.IsCancellationRequested)
                    break;

                PlayMusic();
                Thread.Sleep(1000);

                if (Program.myForm.radioButtonSingleBell.Checked)
                    break;
            }
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

            tokenSource = new CancellationTokenSource();
            Task task = Task.Factory.StartNew(ThreadFunction, tokenSource.Token);
 
            Program.myForm.buttonStop.Enabled = true;
            Program.myForm.buttonStart.Enabled = false;
            
        }

        private void buttonMelody_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "MP3 Files|*.mp3|All Files|*.*";
            openFileDialog1.Title = "Select an mp3";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            { FileInfo fi = new FileInfo(openFileDialog1.FileName); }
            labelFilePath.Text = openFileDialog1.FileName;
        }

        private void checkBoxWeekdays_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                checkedListBox1.SetItemChecked(i, Program.myForm.checkBoxWeekdays.Checked);
                checkedListBox2.SetItemChecked(i, Program.myForm.checkBoxWeekdays.Checked);
            }
            for (int i = 5; i < 7; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
                checkedListBox2.SetItemChecked(i, false);
            }
            
        }

        private void buttonStop_Click()
        {
            CancelWaitableTimer(handle);
            tokenSource.Cancel();
            Program.myForm.labelDateX.Text = "Задайте время сигнала";
            Program.myForm.buttonStop.Enabled = false;
            Program.myForm.buttonStart.Enabled = true;
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
            WindowState = FormWindowState.Normal;
        }

        private void radioButtonSheduleBell_CheckedChanged(object sender, EventArgs e)
        {
            Program.myForm.checkedListBox1.Visible = Program.myForm.radioButtonSheduleBell.Checked;
            Program.myForm.checkedListBox2.Visible = Program.myForm.radioButtonSheduleBell.Checked;
            Program.myForm.checkBoxWeekdays.Visible = Program.myForm.radioButtonSheduleBell.Checked;
            Program.myForm.labelWeek1.Visible = Program.myForm.radioButtonSheduleBell.Checked;
            Program.myForm.labelWeek2.Visible = Program.myForm.radioButtonSheduleBell.Checked;
        }

    }
}
