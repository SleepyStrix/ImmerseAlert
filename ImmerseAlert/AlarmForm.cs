using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImmerseAlert
{
    public partial class AlarmForm : Form
    {
        Thread keepFrontThread;
        public AlarmForm()
        {
            InitializeComponent();

            Console.WriteLine("ALARM FORM STARTED");
            PlayAlarmSound();
            //start thread forcing form to front
            keepFrontThread = new Thread(KeepFront);
            keepFrontThread.Start();

        }

        private void PlayAlarmSound()
        {
            SoundPlayer alarmPlayer = new SoundPlayer(@"C:\Users\Dan\Source\Repos\ImmerseAlert\ImmerseAlert\Audio\Alarm1.wav");
            alarmPlayer.PlayLooping();
        }

        /// <summary>
        /// Looped in new thread to periodically force form to front.
        /// </summary>
        private void KeepFront()
        {
            while (true)
            {
                try
                {
                    MethodInvoker mi = delegate ()
                    {
                        ForceToFront();
                    };
                    this.Invoke(mi);
                } catch (Exception e)
                {
                    Console.WriteLine("Keep Front Exception: " + e.GetBaseException().Message);
                    break;
                }                
                Thread.Sleep(5000);
            }
        }

        /// <summary>
        /// Forces the form to the front.
        /// Ugly, but necessary to ensure alarm is noticed.
        /// </summary>
        private void ForceToFront()
        {
            Console.WriteLine("Forcing Alarm to front");
            try
            {
                this.WindowState = FormWindowState.Minimized;
                this.Show();
                this.WindowState = FormWindowState.Maximized;
                this.Focus();
                this.BringToFront();
            }
            catch (Exception e)
            {
                Console.WriteLine("Force To Front Exception: " + e.GetBaseException().Message);
            }
        }
    }
}
