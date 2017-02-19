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

                    if (nestResponse.devices.cameras != null && nestResponse.devices.cameras.Count > 0)
                    {
                        foreach (NestCam cam in nestResponse.devices.cameras.Values)
                        {
                            CamEvent lastEvent = cam.last_event;
                            if (lastEvent != null)
                            {
                                DateTimeOffset endTime = DateTimeOffset.Parse(lastEvent.end_time);
                                //Invalidate camera events after 20 seconds.
                                if (DateTimeOffset.UtcNow.Subtract(endTime.UtcDateTime).Seconds < 20f)
                                {
                                    Console.WriteLine("cam motion:" + cam.last_event.has_motion);
                                    Console.WriteLine("cam sound:" + cam.last_event.has_sound);
                                    Console.WriteLine("cam person:" + cam.last_event.has_person);
                                    if (Properties.Settings.Default.Person_Alarm && cam.last_event.has_person)
                                    {
                                        Program.ShowAlarm("CAMERA DETECTED PERSON");
                                    }
                                    else if (Properties.Settings.Default.Motion_Alarm && cam.last_event.has_motion)
                                    {
                                        Program.ShowAlarm("CAMERA DETECTED MOTION");
                                    }
                                    else if (Properties.Settings.Default.Sound_Alarm && cam.last_event.has_sound)
                                    {
                                        Program.ShowAlarm("CAMERA DETECTED SOUND");
                                    }
                                }
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
