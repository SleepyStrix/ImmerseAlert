using System;
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
using ImmerseAlert.Models;
using Newtonsoft.Json;

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
            new NestRester().GetLocalToken();
        }

        private void nestPinLinkButton_Click(object sender, EventArgs e)
        {
            string pinGetUri = ConfigurationManager.AppSettings["Nest_Product_Authorization_URL"]; //Must exist in appSettings.
            Process.Start(pinGetUri);
        }

        private void nestPinSubmit_Click(object sender, EventArgs e)
        {
            new NestRester().GetNewToken(nestPinInputTextBox.Text);
            this.Close();
        }
    }
}
