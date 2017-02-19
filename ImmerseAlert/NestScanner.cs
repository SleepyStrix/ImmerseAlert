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
using System.Threading.Tasks;

namespace ImmerseAlert
{
    public class NestScanner
    {
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
                Console.WriteLine("local token json: " + tokenJson);
                NestTokenModel model = JsonConvert.DeserializeObject<NestTokenModel>(tokenJson);
                Console.WriteLine("local toke:" + model.access_token);
                return model.access_token;
            }
        }

        public void GetAllData()
        {
            Console.WriteLine("Getting Nest Data");
            //only make a request if there is a token stored locally.
            string token = GetLocalToken();
            if (string.IsNullOrWhiteSpace(token))
            {
                Console.WriteLine("null token");
                return;
            }
            string uri = string.Format("https://developer-api.nest.com");
            string jsonResponse = GetNestJson(token, uri, false);
            JSON restResponse = JsonConvert.DeserializeObject<JSON>(jsonResponse);
            Console.WriteLine("YEET:" + jsonResponse);
            Console.WriteLine("Complete");
        }


        private string GetNestJson(string token, string uri, bool isRedirect)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Headers[HttpRequestHeader.Authorization] = string.Format("Bearer {0}", token);
            //Console.WriteLine
            request.ContentType = "application/json";
            //request.Headers[HttpRequestHeader.ContentType] = "application/json";
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
                Console.WriteLine("Result: " + result);
                //Handle ugly Nest redirects with limited recursion
                if (!isRedirect && reponseStatus.Equals(HttpStatusCode.TemporaryRedirect))
                {
                    Console.WriteLine(response.Headers[HttpResponseHeader.Location]);
                    result = GetNestJson(token, response.Headers[HttpResponseHeader.Location], true);
                }
                return result;
            }
        }
    }
}
