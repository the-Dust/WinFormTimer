﻿using System;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    class SheduleHelper
    {
        public static DateTime dateX;
        public static bool[] sheduleArr = new bool[14];
        public static int initWeekParity;
        

        public static int[] GetRestTime()
        {
            DateTime dateToday = DateTime.Now;
            bool error = false;
            bool match = true;
            double stpHours = 0;
            double stpMinutes = 0;
            double daysToBell = 0;
            dateX = DateTime.Today;
            //j - день на карте двухнедельного расписания
            int j = 0;

            if (Regex.IsMatch(Program.myForm.maskedTextBox.Text, "^[0-9]{2}:[0-9]{2}$"))
            {
                stpHours = Convert.ToInt64(Program.myForm.maskedTextBox.Text.Substring(0, 2));
                stpMinutes = Convert.ToInt64(Program.myForm.maskedTextBox.Text.Substring(3, 2));
            }
            else
                match = false;

            if (stpHours > 23 || stpMinutes > 59 || !match)
            {
                Program.myForm.Invoke((Action)(() =>
                {
                    Program.myForm.maskedTextBox.Text = "0000";
                    MessageBox.Show("Ошибка! Введено некорректное время сигнала");
                }));
                error = true;
                goto EndOfGetRestTime;
            }

            dateX = dateX.AddHours(stpHours);
            dateX = dateX.AddMinutes(stpMinutes);
            
            
            j = ((int)dateToday.DayOfWeek - 1);
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
                    error = true;
                    goto EndOfGetRestTime;
                }
                while (!sheduleArr[j]&&!error)
                {
                    daysToBell++;
                    j++;
                    if (j > 13)
                        j = 0;
                }
            }
            dateX = dateX.AddDays(daysToBell);
            EndOfGetRestTime:
            return new int[] {error?-1:(int)(dateX - dateToday).TotalSeconds, j};
            
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
