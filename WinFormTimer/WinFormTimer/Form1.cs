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

        static CancellationTokenSource tokenSource2;

        public static bool isStarted;
        
        
        
        public Form1()
        {
            InitializeComponent();
        }

        void PlayMusic()
        {
            WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
            wplayer.URL = Program.myForm.openFileDialog1.FileName;
            wplayer.controls.play();
        }

        void ThreadFunction()
        {
            CancellationToken ct = tokenSource2.Token;
            ct.ThrowIfCancellationRequested();
            while (true)
            {
                long duetime = -Convert.ToInt64(SheduleHelper.GetRestTime()) * 10000000;
                if (InvokeRequired)
                    Invoke((Action)(() => labelDateX.Text = "Дата следующего сигнала " + SheduleHelper.dateX));

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

            tokenSource2 = new CancellationTokenSource();
            Task task = Task.Factory.StartNew(ThreadFunction, tokenSource2.Token);
            isStarted = true;
            
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

        private void buttonStop_Click(object sender, EventArgs e)
        {
            CancelWaitableTimer(handle);
            tokenSource2.Cancel();
            isStarted = false;
        }

        

    }
}
