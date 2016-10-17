namespace Pollo
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mustaLaatikko = new MustaLaatikko.UserControl1();
            this.userControl11 = new Scrolleri.UserControl1();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.Kello);
            // 
            // mustaLaatikko
            // 
            this.mustaLaatikko.BackColor = System.Drawing.Color.Black;
            this.mustaLaatikko.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mustaLaatikko.feed = null;
            this.mustaLaatikko.Location = new System.Drawing.Point(0, 524);
            this.mustaLaatikko.Name = "mustaLaatikko";
            this.mustaLaatikko.Size = new System.Drawing.Size(734, 66);
            this.mustaLaatikko.TabIndex = 0;
            // 
            // userControl11
            // 
            this.userControl11.color0 = System.Drawing.Color.Empty;
            this.userControl11.color1 = System.Drawing.Color.Empty;
            this.userControl11.Location = new System.Drawing.Point(0, 0);
            this.userControl11.Name = "userControl11";
            this.userControl11.sijainti = new System.Drawing.Point(0, 0);
            this.userControl11.Size = new System.Drawing.Size(1752, 275);
            this.userControl11.TabIndex = 1;
            this.userControl11.thikness = 0;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userControl11);
            this.Controls.Add(this.mustaLaatikko);
            this.DoubleBuffered = true;
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(734, 590);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private MustaLaatikko.UserControl1 mustaLaatikko;
        private Scrolleri.UserControl1 userControl11;
    }
}
