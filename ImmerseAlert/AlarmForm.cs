using AudioSwitcher.AudioApi.CoreAudio;
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
        SoundPlayer alarmPlayer;
        public AlarmForm(string message)
        {
            InitializeComponent();
            Console.WriteLine("ALARM FORM STARTED");
            //PlayAlarmSound();
            mainLabel.Text = mainLabel.Text + "\n" + message;
            mainLabel.AccessibleDescription = mainLabel.Text;
            mainLabel.AccessibleName = mainLabel.Text;
            PlayAlarmSound();
            GetAttention();
            keepFrontThread = new Thread(KeepAttention);
            keepFrontThread.IsBackground = true;
            keepFrontThread.Start();

        }

        private void PlayAlarmSound()
        {
            //maximize audio volume
            CoreAudioDevice defaultAudioOut = new CoreAudioController().DefaultPlaybackDevice;
            defaultAudioOut.Mute(false);
            defaultAudioOut.Volume = 100;
            //play alarm
            if (alarmPlayer == null) {
                alarmPlayer = new SoundPlayer(Properties.Resources.Alarm2);
            }
            alarmPlayer.PlayLooping();
        }

        /// <summary>
        /// Looped in new thread to periodically force form to front.
        /// </summary>
        private void KeepAttention()
        {
            while (true)
            {
                try
                {
                    MethodInvoker mi = delegate ()
                    {
                        GetAttention();
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
        private void GetAttention()
        {
            /*try
            {
                PlayAlarmSound();
            } catch
            {

            }*/
            try
            {
                Program.SetWindowPos(this.Handle, Program.HWND_TOPMOST, 0, 0, 0, 0, Program.TOPMOST_FLAGS);
            }catch
            {

            }
            Console.WriteLine("Forcing Alarm to front");
            try
            {
                this.WindowState = FormWindowState.Minimized;
                //this.Show();
                this.WindowState = FormWindowState.Maximized;
                //this.TopMost = true;
                //this.Focus();
                this.BringToFront();
            }
            catch (Exception e)
            {
                Console.WriteLine("Force To Front Exception: " + e.GetBaseException().Message);
            }
        }

        private void AlarmForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alarmPlayer != null)
            {
                alarmPlayer.Stop();
            }
        }
    }
}
