using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImmerseAlert
{
    public partial class MainForm : Form
    {
        private NestAuthForm authForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.ArmSystemToggle();
            UpdateArmingStatus();
            UpdateTokenStatus();

        }

        void UpdateTokenStatus()
        {
            Program.TestHasToken();
            if (!Program.hasToken)
            {
                systemStatusLabel.Text = "System NOT connected to Nest";
                //armToggleButton.Text = "Cannot Arm System";
                systemStatusLabel.BackColor = Color.Red;
            }
        }

        void UpdateArmingStatus()
        {
            if(Program.systemArmed)
            {
                systemStatusLabel.Text = "System is ON";
                systemStatusLabel.BackColor = Color.LightGreen;
                armToggleButton.Text = "Disarm System";
            } else
            {
                systemStatusLabel.Text = "System is OFF";
                systemStatusLabel.BackColor = Color.Red;
                armToggleButton.Text = "Arm System";
            }
        }

        private void triggerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Co_Alarm = checkBox_co.Checked;
            Properties.Settings.Default.Smoke_Alarm = checkBox_smoke.Checked;
            Properties.Settings.Default.Motion_Alarm = checkBox_Cam_Motion.Checked;
            Properties.Settings.Default.Sound_Alarm = checkBox_Cam_Sound.Checked;
            Properties.Settings.Default.Person_Alarm = checkBox_Cam_Person.Checked;
            Properties.Settings.Default.Save();
        }

        private void nestAuthButton_Click(object sender, EventArgs e)
        {
            if (authForm == null)
            {
                authForm = new NestAuthForm();
            } try
            {
                authForm.Show();
            } catch (System.ObjectDisposedException)
            {
                authForm = new NestAuthForm();
                authForm.Show();
            }

            authForm.FormClosing += AuthFormClosed;
        }

        public void AuthFormClosed(object sender, FormClosingEventArgs args)
        {
            Program.TestHasToken();
            UpdateArmingStatus();
            UpdateTokenStatus();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateArmingStatus();
            UpdateTokenStatus();
            checkBox_co.Checked = Properties.Settings.Default.Co_Alarm;
            checkBox_smoke.Checked = Properties.Settings.Default.Smoke_Alarm;
            checkBox_Cam_Motion.Checked = Properties.Settings.Default.Motion_Alarm;
            checkBox_Cam_Sound.Checked = Properties.Settings.Default.Sound_Alarm;
            checkBox_Cam_Person.Checked = Properties.Settings.Default.Person_Alarm;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            Console.WriteLine("Minimized");
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(2000);
                ShowInTaskbar = false;
                //Hide();
            } else
            {
                notifyIcon1.Visible = false;
                ShowInTaskbar = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            notifyIcon1.Visible = false;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.EndProgram();
        }
    }
}
