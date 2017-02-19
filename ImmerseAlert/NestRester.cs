using ImmerseAlert.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ImmerseAlert
{
    /// <summary>
    /// Class that actually hits the Nest API and provides related utility.
    /// </summary>
    public class NestRester
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

        public void GetNewToken(string nestPIN)
        {
            if (string.IsNullOrWhiteSpace(nestPIN))
            {
                return;
            }
            using (WebClient authClient = new WebClient())
            {
                authClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string uri = string.Format("https://api.home.nest.com/oauth2/access_token?client_id={0}&client_secret={1}&code={2}&grant_type=authorization_code",
                    ConfigurationManager.AppSettings["Nest_Product_ID"], //Must exist in app settings.
                    ConfigurationManager.AppSettings["Nest_Product_Secret"], //Must exist in app settings.
                    nestPIN);
                string data = string.Format("");
                string result = authClient.UploadString(uri, data);
                Console.WriteLine("Result: " + result);
                NestTokenModel tokenResult = JsonConvert.DeserializeObject<NestTokenModel>(result);
                tokenResult.timestamp = DateTimeOffset.UtcNow;
                string tokenJson = JsonConvert.SerializeObject(tokenResult);
                Console.WriteLine("Reserialized: " + result);
                Properties.Settings.Default.NestTokenJson = tokenJson;
                Properties.Settings.Default.Save();
                GetLocalToken();
                Console.WriteLine("Saved");
            }
        }
    }
}
