namespace ImmerseAlert
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.armToggleButton = new System.Windows.Forms.Button();
            this.checkBox_co = new System.Windows.Forms.CheckBox();
            this.checkBox_smoke = new System.Windows.Forms.CheckBox();
            this.checkBox_Cam_Motion = new System.Windows.Forms.CheckBox();
            this.checkBox_Cam_Sound = new System.Windows.Forms.CheckBox();
            this.checkBox_Cam_Person = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.systemStatusLabel = new System.Windows.Forms.Label();
            this.nestAuthButton = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // armToggleButton
            // 
            this.armToggleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.armToggleButton.Location = new System.Drawing.Point(185, 175);
            this.armToggleButton.Name = "armToggleButton";
            this.armToggleButton.Size = new System.Drawing.Size(218, 129);
            this.armToggleButton.TabIndex = 0;
            this.armToggleButton.UseVisualStyleBackColor = true;
            this.armToggleButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_co
            // 
            this.checkBox_co.AutoSize = true;
            this.checkBox_co.Checked = true;
            this.checkBox_co.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_co.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_co.Location = new System.Drawing.Point(410, 175);
            this.checkBox_co.Name = "checkBox_co";
            this.checkBox_co.Size = new System.Drawing.Size(117, 24);
            this.checkBox_co.TabIndex = 1;
            this.checkBox_co.Text = "CO Detector";
            this.checkBox_co.UseVisualStyleBackColor = true;
            this.checkBox_co.CheckedChanged += new System.EventHandler(this.triggerCheckBox_CheckedChanged);
            // 
            // checkBox_smoke
            // 
            this.checkBox_smoke.AutoSize = true;
            this.checkBox_smoke.Checked = true;
            this.checkBox_smoke.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_smoke.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_smoke.Location = new System.Drawing.Point(410, 205);
            this.checkBox_smoke.Name = "checkBox_smoke";
            this.checkBox_smoke.Size = new System.Drawing.Size(144, 24);
            this.checkBox_smoke.TabIndex = 2;
            this.checkBox_smoke.Text = "Smoke Detector";
            this.checkBox_smoke.UseVisualStyleBackColor = true;
            this.checkBox_smoke.CheckedChanged += new System.EventHandler(this.triggerCheckBox_CheckedChanged);
            // 
            // checkBox_Cam_Motion
            // 
            this.checkBox_Cam_Motion.AutoSize = true;
            this.checkBox_Cam_Motion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Cam_Motion.Location = new System.Drawing.Point(409, 235);
            this.checkBox_Cam_Motion.Name = "checkBox_Cam_Motion";
            this.checkBox_Cam_Motion.Size = new System.Drawing.Size(80, 24);
            this.checkBox_Cam_Motion.TabIndex = 3;
            this.checkBox_Cam_Motion.Text = "Motion ";
            this.checkBox_Cam_Motion.UseVisualStyleBackColor = true;
            this.checkBox_Cam_Motion.CheckedChanged += new System.EventHandler(this.triggerCheckBox_CheckedChanged);
            // 
            // checkBox_Cam_Sound
            // 
            this.checkBox_Cam_Sound.AutoSize = true;
            this.checkBox_Cam_Sound.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Cam_Sound.Location = new System.Drawing.Point(409, 266);
            this.checkBox_Cam_Sound.Name = "checkBox_Cam_Sound";
            this.checkBox_Cam_Sound.Size = new System.Drawing.Size(75, 24);
            this.checkBox_Cam_Sound.TabIndex = 4;
            this.checkBox_Cam_Sound.Text = "Sound";
            this.checkBox_Cam_Sound.UseVisualStyleBackColor = true;
            this.checkBox_Cam_Sound.CheckedChanged += new System.EventHandler(this.triggerCheckBox_CheckedChanged);
            // 
            // checkBox_Cam_Person
            // 
            this.checkBox_Cam_Person.AutoSize = true;
            this.checkBox_Cam_Person.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Cam_Person.Location = new System.Drawing.Point(409, 296);
            this.checkBox_Cam_Person.Name = "checkBox_Cam_Person";
            this.checkBox_Cam_Person.Size = new System.Drawing.Size(78, 24);
            this.checkBox_Cam_Person.TabIndex = 5;
            this.checkBox_Cam_Person.Text = "Person";
            this.checkBox_Cam_Person.UseVisualStyleBackColor = true;
            this.checkBox_Cam_Person.CheckedChanged += new System.EventHandler(this.triggerCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(410, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Alarm Triggers";
            // 
            // systemStatusLabel
            // 
            this.systemStatusLabel.AutoSize = true;
            this.systemStatusLabel.BackColor = System.Drawing.Color.LightGreen;
            this.systemStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemStatusLabel.Location = new System.Drawing.Point(182, 94);
            this.systemStatusLabel.Name = "systemStatusLabel";
            this.systemStatusLabel.Size = new System.Drawing.Size(222, 37);
            this.systemStatusLabel.TabIndex = 7;
            this.systemStatusLabel.Text = "System Status";
            this.systemStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nestAuthButton
            // 
            this.nestAuthButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nestAuthButton.Location = new System.Drawing.Point(532, 12);
            this.nestAuthButton.Name = "nestAuthButton";
            this.nestAuthButton.Size = new System.Drawing.Size(150, 62);
            this.nestAuthButton.TabIndex = 8;
            this.nestAuthButton.Text = "Connect To Nest";
            this.nestAuthButton.UseVisualStyleBackColor = true;
            this.nestAuthButton.Click += new System.EventHandler(this.nestAuthButton_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "ImmerseAlert Mimimized";
            this.notifyIcon1.BalloonTipTitle = "ImmerseAlert";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(694, 425);
            this.Controls.Add(this.nestAuthButton);
            this.Controls.Add(this.systemStatusLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_Cam_Person);
            this.Controls.Add(this.checkBox_Cam_Sound);
            this.Controls.Add(this.checkBox_Cam_Motion);
            this.Controls.Add(this.checkBox_smoke);
            this.Controls.Add(this.checkBox_co);
            this.Controls.Add(this.armToggleButton);
            this.Name = "MainForm";
            this.Text = "ImmerseAlert";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button armToggleButton;
        private System.Windows.Forms.CheckBox checkBox_co;
        private System.Windows.Forms.CheckBox checkBox_smoke;
        private System.Windows.Forms.CheckBox checkBox_Cam_Motion;
        private System.Windows.Forms.CheckBox checkBox_Cam_Sound;
        private System.Windows.Forms.CheckBox checkBox_Cam_Person;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label systemStatusLabel;
        private System.Windows.Forms.Button nestAuthButton;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}