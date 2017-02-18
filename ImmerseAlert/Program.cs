using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;


namespace ImmerseAlert
{
    static class Program
    {
        //private static bool alarmActive = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread.Sleep(2000);
            //ShowAlarm();

        }

        private static void ShowNestAuth()
        {

            //HttpWebRequest authReq =;
        }

        private static void ShowAlarm()
        {
            //alarmActive = true;
            AlarmForm alarmForm = new AlarmForm();
            Application.Run(alarmForm);
        }
    }
}
