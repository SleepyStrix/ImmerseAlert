namespace ImmerseAlert
{
    partial class NestAuthForm
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
            this.nestPinLinkButton = new System.Windows.Forms.Button();
            this.nestPinSubmit = new System.Windows.Forms.Button();
            this.nestPinInputTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nestPinLinkButton
            // 
            this.nestPinLinkButton.Location = new System.Drawing.Point(12, 12);
            this.nestPinLinkButton.Name = "nestPinLinkButton";
            this.nestPinLinkButton.Size = new System.Drawing.Size(125, 23);
            this.nestPinLinkButton.TabIndex = 0;
            this.nestPinLinkButton.Text = "Get NEST PIN";
            this.nestPinLinkButton.UseVisualStyleBackColor = true;
            this.nestPinLinkButton.Click += new System.EventHandler(this.nestPinLinkButton_Click);
            // 
            // nestPinSubmit
            // 
            this.nestPinSubmit.Location = new System.Drawing.Point(12, 68);
            this.nestPinSubmit.Name = "nestPinSubmit";
            this.nestPinSubmit.Size = new System.Drawing.Size(75, 23);
            this.nestPinSubmit.TabIndex = 1;
            this.nestPinSubmit.Text = "Submit PIN";
            this.nestPinSubmit.UseVisualStyleBackColor = true;
            this.nestPinSubmit.Click += new System.EventHandler(this.nestPinSubmit_Click);
            // 
            // nestPinInputTextBox
            // 
            this.nestPinInputTextBox.Location = new System.Drawing.Point(12, 42);
            this.nestPinInputTextBox.Name = "nestPinInputTextBox";
            this.nestPinInputTextBox.Size = new System.Drawing.Size(125, 20);
            this.nestPinInputTextBox.TabIndex = 2;
            // 
            // NestAuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 361);
            this.Controls.Add(this.nestPinInputTextBox);
            this.Controls.Add(this.nestPinSubmit);
            this.Controls.Add(this.nestPinLinkButton);
            this.Name = "NestAuthForm";
            this.Text = "NestAuthForm";
            this.Load += new System.EventHandler(this.NestAuthForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nestPinLinkButton;
        private System.Windows.Forms.Button nestPinSubmit;
        private System.Windows.Forms.TextBox nestPinInputTextBox;
    }
}