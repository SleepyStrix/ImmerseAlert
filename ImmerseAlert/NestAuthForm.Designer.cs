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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NestAuthForm));
            this.nestPinLinkButton = new System.Windows.Forms.Button();
            this.nestPinSubmit = new System.Windows.Forms.Button();
            this.nestPinInputTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nestPinLinkButton
            // 
            this.nestPinLinkButton.Location = new System.Drawing.Point(135, 12);
            this.nestPinLinkButton.Name = "nestPinLinkButton";
            this.nestPinLinkButton.Size = new System.Drawing.Size(175, 44);
            this.nestPinLinkButton.TabIndex = 0;
            this.nestPinLinkButton.Text = "Get NEST PIN";
            this.nestPinLinkButton.UseVisualStyleBackColor = true;
            this.nestPinLinkButton.Click += new System.EventHandler(this.nestPinLinkButton_Click);
            // 
            // nestPinSubmit
            // 
            this.nestPinSubmit.Location = new System.Drawing.Point(135, 112);
            this.nestPinSubmit.Name = "nestPinSubmit";
            this.nestPinSubmit.Size = new System.Drawing.Size(175, 44);
            this.nestPinSubmit.TabIndex = 1;
            this.nestPinSubmit.Text = "Finish";
            this.nestPinSubmit.UseVisualStyleBackColor = true;
            this.nestPinSubmit.Click += new System.EventHandler(this.nestPinSubmit_Click);
            // 
            // nestPinInputTextBox
            // 
            this.nestPinInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nestPinInputTextBox.Location = new System.Drawing.Point(135, 62);
            this.nestPinInputTextBox.Name = "nestPinInputTextBox";
            this.nestPinInputTextBox.Size = new System.Drawing.Size(175, 44);
            this.nestPinInputTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "1. Get your PIN";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "2. Type it in";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "3. That\'s it!";
            // 
            // NestAuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 177);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nestPinInputTextBox);
            this.Controls.Add(this.nestPinSubmit);
            this.Controls.Add(this.nestPinLinkButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NestAuthForm";
            this.Text = "Nest Authorization";
            this.Load += new System.EventHandler(this.NestAuthForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nestPinLinkButton;
        private System.Windows.Forms.Button nestPinSubmit;
        private System.Windows.Forms.TextBox nestPinInputTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}