﻿namespace KuvaJaLiike
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
            this.texti1 = new floatingText.texti();
            this.SuspendLayout();
            // 
            // texti1
            // 
            this.texti1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.texti1.BackColor = System.Drawing.Color.Black;
            this.texti1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.texti1.fontSize = 10;
            this.texti1.Location = new System.Drawing.Point(0, 507);
            this.texti1.Margin = new System.Windows.Forms.Padding(0);
            this.texti1.Name = "texti1";
            this.texti1.Size = new System.Drawing.Size(624, 50);
            this.texti1.speed = 1F;
            this.texti1.TabIndex = 0;
            this.texti1.text = "undefined";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 557);
            this.Controls.Add(this.texti1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private floatingText.texti texti1;
    }
}
