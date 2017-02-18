﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Configuration;
using System.Diagnostics;

namespace ImmerseAlert
{
    public partial class NestAuthForm : Form
    {
        public NestAuthForm()
        {
            InitializeComponent();
        }

        private void NestAuthForm_Load(object sender, EventArgs e)
        {
        }

        private void nestPinLinkButton_Click(object sender, EventArgs e)
        {
            string pinGetUri = ConfigurationManager.AppSettings["Nest_Product_Authorization_URL"]; //Must exist in app settings.
            Process.Start(pinGetUri);
        }

        private void nestPinSubmit_Click(object sender, EventArgs e)
        {
            string nestPIN = nestPinInputTextBox.Text;
            if (string.IsNullOrWhiteSpace(nestPIN))
            {
                return;
            }
            using (WebClient authClient = new WebClient())
            {
                authClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string uri = string.Format("https://api.home.nest.com/oauth2/access_token?client_id={0}&client_secret={1}&code={2}&grant_type=authorization_code",
                    ConfigurationManager.AppSettings["Nest_Product_ID"],
                    ConfigurationManager.AppSettings["Nest_Product_Secret"],
                    nestPIN);
                string data = string.Format("");
                string result = authClient.UploadString(uri, data);
                Console.WriteLine("Result: " + result);
            }
        }
    }
}
