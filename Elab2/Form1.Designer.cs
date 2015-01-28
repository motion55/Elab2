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
            this.AnalogReadButton = new System.Windows.Forms.Button();
            this.PortComboBox = new System.Windows.Forms.ComboBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.LEDcheckBox = new System.Windows.Forms.CheckBox();
            this.AnalogVal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AnalogReadButton
            // 
            this.AnalogReadButton.Location = new System.Drawing.Point(183, 137);
            this.AnalogReadButton.Name = "AnalogReadButton";
            this.AnalogReadButton.Size = new System.Drawing.Size(108, 36);
            this.AnalogReadButton.TabIndex = 0;
            this.AnalogReadButton.Text = "Analog Read";
            this.AnalogReadButton.UseVisualStyleBackColor = true;
            this.AnalogReadButton.Click += new System.EventHandler(this.AnalogRead_Click);
            // 
            // PortComboBox
            // 
            this.PortComboBox.FormattingEnabled = true;
            this.PortComboBox.Location = new System.Drawing.Point(27, 45);
            this.PortComboBox.Name = "PortComboBox";
            this.PortComboBox.Size = new System.Drawing.Size(114, 24);
            this.PortComboBox.TabIndex = 2;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(183, 38);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(108, 36);
            this.ConnectButton.TabIndex = 3;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.Connect_Click);
            // 
            // LEDcheckBox
            // 
            this.LEDcheckBox.AutoSize = true;
            this.LEDcheckBox.Location = new System.Drawing.Point(343, 48);
            this.LEDcheckBox.Name = "LEDcheckBox";
            this.LEDcheckBox.Size = new System.Drawing.Size(57, 21);
            this.LEDcheckBox.TabIndex = 4;
            this.LEDcheckBox.Text = "LED";
            this.LEDcheckBox.UseVisualStyleBackColor = true;
            this.LEDcheckBox.CheckedChanged += new System.EventHandler(this.LEDcheckBox_CheckedChanged);
            // 
            // AnalogVal
            // 
            this.AnalogVal.Location = new System.Drawing.Point(27, 144);
            this.AnalogVal.Name = "AnalogVal";
            this.AnalogVal.ReadOnly = true;
            this.AnalogVal.Size = new System.Drawing.Size(114, 22);
            this.AnalogVal.TabIndex = 5;
            this.AnalogVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 243);
            this.Controls.Add(this.AnalogVal);
            this.Controls.Add(this.LEDcheckBox);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.PortComboBox);
            this.Controls.Add(this.AnalogReadButton);
            this.Name = "Form1";
            this.Text = "ArduinoSocketTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AnalogReadButton;
        private System.Windows.Forms.ComboBox PortComboBox;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.CheckBox LEDcheckBox;
        private System.Windows.Forms.TextBox AnalogVal;
    }
}

