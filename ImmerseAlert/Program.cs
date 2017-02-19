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
        public static bool hasToken;
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

        }

        private static void ShowNestAuth()
        {
            Application.Run(new NestAuthForm());
        }

        public static void ShowAlarm(string message)
        {
            //Thread.Sleep(60000);
            //alarmActive = true;
            AlarmForm alarmForm = new AlarmForm(message);
            Application.Run(alarmForm);
        }

        public static void TestHasToken()
        {
            if (string.IsNullOrWhiteSpace(new NestRester().GetLocalToken()))
            {
                hasToken = false;
            } else
            {
                hasToken = true;
            }
        }

        /// <summary>
        /// Toggle the system on or off.
        /// </summary>
        /// <returns>true if system has been toggled on, false if off</returns>
        public static bool ArmSystemToggle()
        {
            TestHasToken();
            if (!hasToken)
            {
                return false;
            }
            //dont turn on system if no local token.
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
