using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImmerseAlert
{
    static class Program
    {
        private static bool alarmActive = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread.Sleep(20000);
            ShowAlarm();

        }

        private static void ShowAlarm()
        {
            alarmActive = true;
            AlarmForm alarmForm = new AlarmForm();
            Application.Run(alarmForm);
        }
    }
}
