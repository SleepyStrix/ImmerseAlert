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

        public string GetLocalToken()
        {
            string tokenJson = Properties.Settings.Default.NestTokenJson;
            if (string.IsNullOrWhiteSpace(tokenJson))
            {
                Console.WriteLine("null local token");
                return null;
            }
            else
            {
                //Console.WriteLine("local token json: " + tokenJson);
                NestTokenModel model = JsonConvert.DeserializeObject<NestTokenModel>(tokenJson);
                //Console.WriteLine("local token:" + model.access_token);
                return model.access_token;
            }
        }

        public JSON GetNestData()
        {
            Console.WriteLine("Getting Nest Data");
            //only make a request if there is a token stored locally.
            string token = GetLocalToken();
            if (string.IsNullOrWhiteSpace(token))
            {
                Console.WriteLine("null token");
                return null;
            }
            string uri = string.Format("https://developer-api.nest.com");
            string jsonResponse = GetNestJson(token, uri, false);
            JSON restResponse = JsonConvert.DeserializeObject<JSON>(jsonResponse);
            //Console.WriteLine("YEET:" + jsonResponse);
            //Console.WriteLine("Complete");
            return restResponse;
        }

        private string GetNestJson(string token, string uri, bool isRedirect)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Headers[HttpRequestHeader.Authorization] = string.Format("Bearer {0}", token);
            request.ContentType = "application/json";
            request.Method = "GET";
            request.AllowAutoRedirect = false;
            HttpStatusCode reponseStatus;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                reponseStatus = response.StatusCode;
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string result = reader.ReadToEnd();
                stream.Close();
                //Console.WriteLine("Result: " + result);

                //Handle ugly Nest redirects with limited recursion
                if (!isRedirect && reponseStatus.Equals(HttpStatusCode.TemporaryRedirect))
                {
                    //Console.WriteLine(response.Headers[HttpResponseHeader.Location]);
                    result = GetNestJson(token, response.Headers[HttpResponseHeader.Location], true);
                }

                return result;
            }
        }

        /// <summary>
        /// Check status of nest protect, startin alarm if necessary.
        /// </summary>
        private void Scan()
        {
            JSON nestResponse = GetNestData();
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

        public void Test()
        {
            Console.WriteLine("System armed");
        }

        private void ScanLoop()
        {
            //Dispatcher
            /*this.Invoke((MethodInvoker)delegate
            {
                this.Test();
            });*/
            Console.WriteLine("System armed");
            
            while (true)
            {
                Scan();
                Thread.Sleep(2000);
            }
        }
    }
}
