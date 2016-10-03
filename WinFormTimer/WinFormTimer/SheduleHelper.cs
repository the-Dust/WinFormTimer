using System;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Globalization;

namespace WindowsFormsApplication1
{
    static class SheduleHelper
    {
        public static DateTime dateX;
        public static bool[] sheduleArr = new bool[14];
        public static int initWeekParity;

        public static int GetRestTime()
        {
            DateTime dateToday = DateTime.Now;
            
            double daysToBell = 0;
            dateX = DateTime.Today;
            //Добавляем часы и минуты, введенные на элементах numericUpDown1 и 2
            dateX = dateX.AddHours((double)Program.myForm.numericUpDown1.Value);
            dateX = dateX.AddMinutes((double)Program.myForm.numericUpDown2.Value);
            //j - день на карте двухнедельного расписания
            int j = ((int)dateToday.DayOfWeek - 1);
            //у них воскресенье - нулевой день недели, у нас - шестой
            if (j < 0)
            { j = 6; }
            //если текущая неделя - вторая
            if (GetWeekParity() != initWeekParity)
            { j = j + 7; }
            if (dateX <= dateToday)
            {
                j = j + 1;
                daysToBell++;
                if (j > 13)
                    j = 0;
            }

            if (Program.myForm.radioButtonSheduleBell.Checked)
            {
                if (sheduleArr.All(x => !x))
                {
                    MessageBox.Show("Ошибка! Не выбраны дни для будильника");
                    return 0;
                }
                while (!sheduleArr[j])
                {
                    daysToBell++;
                    j++;
                    if (j > 13)
                        j = 0;
                }
            }
            dateX = dateX.AddDays(daysToBell);
            return (int)(dateX - dateToday).TotalSeconds;
            
        }

        public static int GetWeekParity()
        {
            DateTime date = DateTime.Now;
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday) % 2;
        }

        public static void Shedule()
        {
            for (int k = 0; k < 7; k++)
            {
                sheduleArr[k] = Convert.ToBoolean(Program.myForm.checkedListBox1.GetItemCheckState(k));
            }
            for (int k = 7; k < 14; k++)
            {
                sheduleArr[k] = Convert.ToBoolean(Program.myForm.checkedListBox2.GetItemCheckState(k - 7));
            }
        }
    }
}
