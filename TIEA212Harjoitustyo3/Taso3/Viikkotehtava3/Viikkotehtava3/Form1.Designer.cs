namespace Viikkotehtava3
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
            this.userControl12 = new HorizontalBox.UserControl1();
            this.userControl11 = new Pollo.UserControl1();
            this.SuspendLayout();
            // 
            // userControl12
            // 
            this.userControl12.color0 = System.Drawing.Color.Empty;
            this.userControl12.color1 = System.Drawing.Color.Empty;
            this.userControl12.Location = new System.Drawing.Point(0, 133);
            this.userControl12.Name = "userControl12";
            this.userControl12.sijainti = new System.Drawing.Point(0, 0);
            this.userControl12.Size = new System.Drawing.Size(1461, 150);
            this.userControl12.TabIndex = 1;
            this.userControl12.thikness = 0;
            // 
            // userControl11
            // 
            this.userControl11.BackColor = System.Drawing.Color.Transparent;
            this.userControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl11.Location = new System.Drawing.Point(0, 0);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(951, 618);
            this.userControl11.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 618);
            this.Controls.Add(this.userControl12);
            this.Controls.Add(this.userControl11);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private Pollo.UserControl1 userControl11;
        private HorizontalBox.UserControl1 userControl12;
    }
}

