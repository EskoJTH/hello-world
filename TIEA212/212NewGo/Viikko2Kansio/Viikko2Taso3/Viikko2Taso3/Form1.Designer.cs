namespace Viikko2Taso3
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
            this.timeTextBoxi1 = new TimeTextBox.TimeTextBox();
            this.timeTextBoxi2 = new TimeTextBox.TimeTextBox();
            this.numberTextBox1 = new OmaTextBox.NumberTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timeTextBoxi1
            // 
            this.timeTextBoxi1.Location = new System.Drawing.Point(43, 64);
            this.timeTextBoxi1.Name = "timeTextBoxi1";
            this.timeTextBoxi1.Size = new System.Drawing.Size(100, 20);
            this.timeTextBoxi1.TabIndex = 0;
            this.timeTextBoxi1.value = "00:00:00";
            // 
            // timeTextBoxi2
            // 
            this.timeTextBoxi2.Location = new System.Drawing.Point(43, 12);
            this.timeTextBoxi2.Name = "timeTextBoxi2";
            this.timeTextBoxi2.Size = new System.Drawing.Size(100, 20);
            this.timeTextBoxi2.TabIndex = 1;
            this.timeTextBoxi2.value = "00:00:00";
            // 
            // numberTextBox1
            // 
            this.numberTextBox1.Location = new System.Drawing.Point(43, 38);
            this.numberTextBox1.max = 1.7976931348623157E+308D;
            this.numberTextBox1.min = -1.7976931348623157E+308D;
            this.numberTextBox1.Name = "numberTextBox1";
            this.numberTextBox1.Size = new System.Drawing.Size(100, 20);
            this.numberTextBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(68, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberTextBox1);
            this.Controls.Add(this.timeTextBoxi2);
            this.Controls.Add(this.timeTextBoxi1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TimeTextBox.TimeTextBox timeTextBoxi1;
        private TimeTextBox.TimeTextBox timeTextBoxi2;
        private OmaTextBox.NumberTextBox numberTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

