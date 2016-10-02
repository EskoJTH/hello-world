namespace TIEA212Harjoitustyo2
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Tunnit = new OmaWindowsFormsComponenttiTaiJotainSemmosta.NumeberTextBox();
            this.Kilometrit = new OmaWindowsFormsComponenttiTaiJotainSemmosta.NumeberTextBox();
            this.timeTextBox1 = new TimeTextBox.TimeTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AccessibleName = "Nappula1";
            this.button1.Location = new System.Drawing.Point(11, 61);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 19);
            this.button1.TabIndex = 0;
            this.button1.Text = "Laske km/h";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Nappula1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Km";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "h";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "km/h";
            // 
            // Tunnit
            // 
            this.Tunnit.AccessibleDescription = "Syötä luku";
            this.Tunnit.AccessibleName = "Tunnit";
            this.Tunnit.Location = new System.Drawing.Point(11, 36);
            this.Tunnit.Max = 1.7976931348623157E+308D;
            this.Tunnit.Min = 0D;
            this.Tunnit.Name = "Tunnit";
            this.Tunnit.Size = new System.Drawing.Size(76, 20);
            this.Tunnit.TabIndex = 2;
            this.Tunnit.Text = "0";
            // 
            // Kilometrit
            // 
            this.Kilometrit.AccessibleDescription = "Syötä luku";
            this.Kilometrit.AccessibleName = "Kilometrit";
            this.Kilometrit.Location = new System.Drawing.Point(11, 11);
            this.Kilometrit.Margin = new System.Windows.Forms.Padding(2);
            this.Kilometrit.Max = 1.7976931348623157E+308D;
            this.Kilometrit.Min = 0D;
            this.Kilometrit.Name = "Kilometrit";
            this.Kilometrit.Size = new System.Drawing.Size(76, 20);
            this.Kilometrit.TabIndex = 1;
            this.Kilometrit.Text = "0";
            // 
            // timeTextBox1
            // 
            this.timeTextBox1.Location = new System.Drawing.Point(14, 128);
            this.timeTextBox1.Name = "timeTextBox1";
            this.timeTextBox1.Size = new System.Drawing.Size(100, 20);
            this.timeTextBox1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 206);
            this.Controls.Add(this.timeTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Tunnit);
            this.Controls.Add(this.Kilometrit);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private OmaWindowsFormsComponenttiTaiJotainSemmosta.NumeberTextBox Kilometrit;
        private OmaWindowsFormsComponenttiTaiJotainSemmosta.NumeberTextBox Tunnit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private TimeTextBox.TimeTextBox timeTextBox1;
    }
}

