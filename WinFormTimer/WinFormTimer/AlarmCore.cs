using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Globalization;
using System.Threading.Tasks;
using WMPLib;
using System.Security.Permissions;

namespace WindowsFormsApplication1
{
    class AlarmCore
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

        public static IntPtr handle;

        public static CancellationTokenSource tokenSource;

        

        static void PlayMusic()
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
            MessageBox.Show("Пора вставать! Отключить сигнал будильника?", "Просыпайся!"); 
            wplayer.controls.stop();
        }

        public static void ThreadFunction()
        {
            CancellationToken ct = tokenSource.Token;
            ct.ThrowIfCancellationRequested();
            while (true)
            {
                int[] restTime = SheduleHelper.GetRestTime();
                if (restTime[0] == -1)
                {
                    Program.myForm.Invoke((Action)(() => Program.myForm.buttonStop_Click()));
                    break;
                }
                long duetime = -Convert.ToInt64(restTime[0]) * 10000000;
                if (Program.myForm.InvokeRequired)
                    Program.myForm.Invoke((Action)(() =>
                    {
                        Program.myForm.labelDateX.Text = "Дата следующего сигнала: \r\n" + SheduleHelper.dateX.DayOfWeek + " " + SheduleHelper.dateX;
                        if (Program.myForm.radioButtonSheduleBell.Checked)
                            Program.myForm.labelDateX.Text += String.Format(", {0}-я неделя", restTime[1] > 6 ? 2 : 1);
                    }));

                handle = CreateWaitableTimer(IntPtr.Zero, true, "MyWaitabletimer");
                SetWaitableTimer(handle, ref duetime, 0, IntPtr.Zero, IntPtr.Zero, true);
                uint INFINITE = 0xFFFFFFFF;
                int ret = WaitForSingleObject(handle, INFINITE);

                if (ct.IsCancellationRequested)
                    break;

                PlayMusic();
                Thread.Sleep(1000);

                if (Program.myForm.radioButtonSingleBell.Checked)
                    Program.myForm.Invoke((Action)(() => Program.myForm.buttonStop_Click()));
                break;
            }
        }
    }
}
