using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        public static WinFormTimer myForm;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            myForm = new WinFormTimer();
            Application.EnableVisualStyles();
            Application.Run(myForm);
        }
    }
}
