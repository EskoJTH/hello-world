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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timeTextBox1 = new TimeTextBox.TimeTextBox();
            this.numeberTextBox1 = new OmaWindowsFormsComponenttiTaiJotainSemmosta.NumeberTextBox();
            this.TomaattiLabeli = new OmaLabeli.PaceLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "aika";
            // 
            // timeTextBox1
            // 
            this.timeTextBox1.Location = new System.Drawing.Point(11, 36);
            this.timeTextBox1.Name = "timeTextBox1";
            this.timeTextBox1.Size = new System.Drawing.Size(76, 20);
            this.timeTextBox1.TabIndex = 7;
            this.timeTextBox1.Text = "00:00:00";
            // 
            // numeberTextBox1
            // 
            this.numeberTextBox1.AccessibleDescription = "Syötä luku";
            this.numeberTextBox1.AccessibleName = "Kilometrit";
            this.numeberTextBox1.Location = new System.Drawing.Point(11, 11);
            this.numeberTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.numeberTextBox1.Max = 1.7976931348623157E+308D;
            this.numeberTextBox1.Min = 0D;
            this.numeberTextBox1.Name = "numeberTextBox1";
            this.numeberTextBox1.Size = new System.Drawing.Size(76, 20);
            this.numeberTextBox1.TabIndex = 1;
            this.numeberTextBox1.Text = "0";
            // 
            // TomaattiLabeli
            // 
            this.TomaattiLabeli.AutoSize = true;
            this.TomaattiLabeli.FastMin = 5D;
            this.TomaattiLabeli.Location = new System.Drawing.Point(8, 127);
            this.TomaattiLabeli.Name = "TomaattiLabeli";
            this.TomaattiLabeli.Size = new System.Drawing.Size(170, 13);
            this.TomaattiLabeli.SlowMin = 7D;
            this.TomaattiLabeli.TabIndex = 8;
            this.TomaattiLabeli.Text = "Lasken sulle sun kierrosajan tähän";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Nappula1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 104);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Km/h";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 206);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TomaattiLabeli);
            this.Controls.Add(this.timeTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numeberTextBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private OmaWindowsFormsComponenttiTaiJotainSemmosta.NumeberTextBox numeberTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private TimeTextBox.TimeTextBox timeTextBox1;
        private OmaLabeli.PaceLabel TomaattiLabeli;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
    }
}

