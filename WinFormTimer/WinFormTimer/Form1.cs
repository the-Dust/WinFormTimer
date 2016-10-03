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

        static IntPtr handle;

        public Form1()
        {
            InitializeComponent();
        }
        
        void ThreadFunction()
        {
            long duetime = -Convert.ToInt64(SheduleHelper.GetRestTime()) * 10000000;
            if (InvokeRequired)
            Invoke((Action)(()=>label2.Text="Дата следующего сигнала " + SheduleHelper.date_X));

            handle = CreateWaitableTimer(IntPtr.Zero, true, "MyWaitabletimer");
            SetWaitableTimer(handle, ref duetime, 0, IntPtr.Zero, IntPtr.Zero, true);
            uint INFINITE = 0xFFFFFFFF;
            int ret = WaitForSingleObject(handle, INFINITE);

            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

            wplayer.URL = Program.myForm.openFileDialog1.FileName;
            wplayer.controls.play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName == "")
            {
                MessageBox.Show("Не выбран сигнал будильника");
                button2_Click(sender, e); 
            }
            SheduleHelper.Shedule();
            SheduleHelper.initWeekParity = SheduleHelper.GetWeekParity();
            Task task = new Task(ThreadFunction);
            task.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "MP3 Files|*.mp3|All Files|*.*";
            openFileDialog1.Title = "Select an mp3";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            { FileInfo fi = new FileInfo(openFileDialog1.FileName); }
            label1.Text = openFileDialog1.FileName;
        }
    }
}
