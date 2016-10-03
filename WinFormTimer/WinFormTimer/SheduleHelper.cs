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
        public static DateTime date_X = DateTime.Today;
        public static bool[] shedule_arr = new bool[14];
        public static int initWeekParity;

        public static int GetRestTime()
        {
            DateTime dateToday = DateTime.Now;
            
            double daysToBell = 0;

            //Добавляем часы и минуты, введенные на элементах numericUpDown1 и 2
            date_X = date_X.AddHours((double)Program.myForm.numericUpDown1.Value);
            date_X = date_X.AddMinutes((double)Program.myForm.numericUpDown2.Value);
            //j - день на карте двухнедельного расписания
            int j = ((int)dateToday.DayOfWeek - 1);
            //у них воскресенье - нулевой день недели, у нас - шестой
            if (j < 0)
            { j = 6; }
            //если текущая неделя - вторая
            if (GetWeekParity() != initWeekParity)
            { j = j + 7; }
            if (date_X <= dateToday)
            {
                j = j + 1;
                daysToBell++;
                if (j > 13)
                    j = 0;
            }

            if (Program.myForm.radioButtonSheduleBell.Checked)
            {
                if (shedule_arr.All(x => !x))
                {
                    MessageBox.Show("Ошибка! Не выбраны дни для будильника");
                    return 0;
                }
                while (!shedule_arr[j])
                {
                    daysToBell++;
                    j++;
                    if (j > 13)
                        j = 0;
                }
            }
            date_X = date_X.AddDays(daysToBell);
            return (int)(date_X - dateToday).TotalSeconds;
            
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
                shedule_arr[k] = Convert.ToBoolean(Program.myForm.checkedListBox1.GetItemCheckState(k));
            }
            for (int k = 7; k < 14; k++)
            {
                shedule_arr[k] = Convert.ToBoolean(Program.myForm.checkedListBox2.GetItemCheckState(k - 7));
            }
        }
    }
}
