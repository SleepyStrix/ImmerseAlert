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
        private static NestScanner nestScanner;
        public static bool systemArmed = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            nestScanner = new NestScanner();
            Application.Run(new MainForm());
            //NestScanner scanner = new NestScanner();
            //scanner.GetAllData();
            //ShowNestAuth();
            //ShowAlarm();

        }

        private static void ShowNestAuth()
        {
            Application.Run(new NestAuthForm());
            //HttpWebRequest authReq =;
        }

        public static void ShowAlarm(string message)
        {
            //Thread.Sleep(60000);
            //alarmActive = true;
            AlarmForm alarmForm = new AlarmForm(message);
            Application.Run(alarmForm);
        }

        /// <summary>
        /// Toggle the system on or off.
        /// </summary>
        /// <returns>true if system has been toggled on, false if off</returns>
        public static bool ArmSystemToggle()
        {
            Console.WriteLine("Arming system");
            if (nestScanner.Started)
            {
                nestScanner.Stop();
                return false;
            } else
            {
                nestScanner.Start();
                return true;
            }
        }


    }
}
