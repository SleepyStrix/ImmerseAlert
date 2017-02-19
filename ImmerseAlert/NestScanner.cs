using ImmerseAlert.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImmerseAlert
{
    public class NestScanner : Control
    {
        public bool Started { get { return started; } }
        private bool started;
        private static Thread loopThread;
        public void Start()
        {
            if (started)
            {
                return;
            }
            Program.systemArmed = true;
            started = true;
            loopThread = new Thread(ScanLoop);
            loopThread.Start();
        }

        public void Stop()
        {
            if (!started)
            {
                return;
            }
            if (loopThread != null)
            {
                loopThread.Abort();
            }
            Program.systemArmed = false;
            started = false;
        }

        /// <summary>
        /// Check status of nest protect, startin alarm if necessary.
        /// </summary>
        private void Scan(NestRester nestRester)
        {
            JSON nestResponse = nestRester.GetNestData();
            if (nestResponse != null)
            {
                if (nestResponse.devices != null)
                {
                    if(nestResponse.devices.smoke_co_alarms != null && nestResponse.devices.smoke_co_alarms.Count > 0)
                    {
                        foreach (NestProtect np in nestResponse.devices.smoke_co_alarms.Values)
                        {
                            Console.WriteLine("co alarm state:" + np.co_alarm_state);
                            Console.WriteLine("smoke alarm state:" + np.smoke_alarm_state);
                            if (np.smoke_alarm_state.Equals("emergency"))
                            {
                                Program.ShowAlarm("SMOKE DETECTED");
                            } else if (np.co_alarm_state.Equals("emergency"))
                            {
                                Program.ShowAlarm("HIGH CO LEVEL.\nMOVE TO SAFETY.");
                            }
                        }
                    }
                }
            }
        }

        private void ScanLoop()
        {
            Console.WriteLine("System armed");
            NestRester nestRester = new NestRester();
            while (true)
            {
                if (string.IsNullOrWhiteSpace(nestRester.GetLocalToken()))
                {
                    break;
                }
                Scan(nestRester);
                Thread.Sleep(2000);
            }
        }
    }
}
