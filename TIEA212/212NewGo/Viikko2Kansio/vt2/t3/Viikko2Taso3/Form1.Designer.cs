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
            this.matkaBox = new OmaTextBox.NumberTextBox();
            this.aikaBox = new TimeTextBox.TimeTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.paceLabel = new PaceLabel.PaceLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.matkaLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // matkaBox
            // 
            this.matkaBox.Location = new System.Drawing.Point(43, 38);
            this.matkaBox.max = 1.7976931348623157E+308D;
            this.matkaBox.min = -1.7976931348623157E+308D;
            this.matkaBox.Name = "matkaBox";
            this.matkaBox.Size = new System.Drawing.Size(100, 20);
            this.matkaBox.TabIndex = 2;
            this.matkaBox.Text = "0";
            // 
            // aikaBox
            // 
            this.aikaBox.Location = new System.Drawing.Point(43, 12);
            this.aikaBox.Name = "aikaBox";
            this.aikaBox.Size = new System.Drawing.Size(100, 20);
            this.aikaBox.TabIndex = 1;
            this.aikaBox.Text = "00:00:00";
            this.aikaBox.value = "00:00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Aika";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Laske";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Matka";
            // 
            // paceLabel
            // 
            this.paceLabel.AutoSize = true;
            this.paceLabel.Distance = 0D;
            this.paceLabel.FastMin = 7D;
            this.paceLabel.Location = new System.Drawing.Point(2, 61);
            this.paceLabel.Name = "paceLabel";
            this.paceLabel.Size = new System.Drawing.Size(51, 13);
            this.paceLabel.SlowMin = 5D;
            this.paceLabel.TabIndex = 7;
            this.paceLabel.Text = "0 min/km";
            this.paceLabel.Time = System.TimeSpan.Parse("00:00:00");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "km";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "HH:MM:SS";
            // 
            // matkaLabel
            // 
            this.matkaLabel.AutoSize = true;
            this.matkaLabel.Location = new System.Drawing.Point(2, 87);
            this.matkaLabel.Name = "matkaLabel";
            this.matkaLabel.Size = new System.Drawing.Size(37, 13);
            this.matkaLabel.TabIndex = 10;
            this.matkaLabel.Text = "Matka";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 148);
            this.Controls.Add(this.matkaLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.paceLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.matkaBox);
            this.Controls.Add(this.aikaBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TimeTextBox.TimeTextBox aikaBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private PaceLabel.PaceLabel paceLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label matkaLabel;
        private OmaTextBox.NumberTextBox matkaBox;
    }
}

