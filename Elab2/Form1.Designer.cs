namespace Elab
{
    partial class Form1
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
            this.WButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.IPAddress = new System.Windows.Forms.TextBox();
            this.SButton = new System.Windows.Forms.Button();
            this.ReceivedTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // WButton
            // 
            this.WButton.Location = new System.Drawing.Point(96, 115);
            this.WButton.Name = "WButton";
            this.WButton.Size = new System.Drawing.Size(83, 36);
            this.WButton.TabIndex = 0;
            this.WButton.Text = "W";
            this.WButton.UseVisualStyleBackColor = true;
            this.WButton.Click += new System.EventHandler(this.W_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(265, 38);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(108, 36);
            this.ConnectButton.TabIndex = 3;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.Connect_Click);
            // 
            // IPAddress
            // 
            this.IPAddress.Location = new System.Drawing.Point(96, 45);
            this.IPAddress.Name = "IPAddress";
            this.IPAddress.ReadOnly = true;
            this.IPAddress.Size = new System.Drawing.Size(148, 22);
            this.IPAddress.TabIndex = 5;
            this.IPAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SButton
            // 
            this.SButton.Location = new System.Drawing.Point(290, 115);
            this.SButton.Name = "SButton";
            this.SButton.Size = new System.Drawing.Size(83, 36);
            this.SButton.TabIndex = 6;
            this.SButton.Text = "S";
            this.SButton.UseVisualStyleBackColor = true;
            this.SButton.Click += new System.EventHandler(this.S_Click);
            // 
            // ReceivedTextBox
            // 
            this.ReceivedTextBox.Location = new System.Drawing.Point(96, 184);
            this.ReceivedTextBox.Name = "ReceivedTextBox";
            this.ReceivedTextBox.ReadOnly = true;
            this.ReceivedTextBox.Size = new System.Drawing.Size(277, 22);
            this.ReceivedTextBox.TabIndex = 7;
            this.ReceivedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 243);
            this.Controls.Add(this.ReceivedTextBox);
            this.Controls.Add(this.SButton);
            this.Controls.Add(this.IPAddress);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.WButton);
            this.Name = "Form1";
            this.Text = "ArduinoSocketTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button WButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.TextBox IPAddress;
        private System.Windows.Forms.Button SButton;
        private System.Windows.Forms.TextBox ReceivedTextBox;
    }
}

