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
            this.armToggleButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // armToggleButton
            // 
            this.armToggleButton.Location = new System.Drawing.Point(268, 193);
            this.armToggleButton.Name = "armToggleButton";
            this.armToggleButton.Size = new System.Drawing.Size(135, 66);
            this.armToggleButton.TabIndex = 0;
            this.armToggleButton.Text = "Arm System";
            this.armToggleButton.UseVisualStyleBackColor = true;
            this.armToggleButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 425);
            this.Controls.Add(this.armToggleButton);
            this.Name = "MainForm";
            this.Text = "ImmerseAlert";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button armToggleButton;
    }
}