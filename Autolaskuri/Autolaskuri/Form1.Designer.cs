namespace Autolaskuri
{
    partial class Autolaskuri
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
            this.HenkiloautoLabel = new System.Windows.Forms.Label();
            this.HenkiloautoButton = new System.Windows.Forms.Button();
            this.PolkupyoraButton = new System.Windows.Forms.Button();
            this.polkupyoraLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lisäähenkilautoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lisääpolkupyöräToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.väriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.UusiIkkunaButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            splitContainer2.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // HenkiloautoLabel
            // 
            this.HenkiloautoLabel.AutoSize = true;
            this.HenkiloautoLabel.Location = new System.Drawing.Point(74, 15);
            this.HenkiloautoLabel.Name = "HenkiloautoLabel";
            this.HenkiloautoLabel.Size = new System.Drawing.Size(13, 13);
            this.HenkiloautoLabel.TabIndex = 0;
            this.HenkiloautoLabel.Text = "0";
            this.HenkiloautoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HenkiloautoButton
            // 
            this.HenkiloautoButton.AutoSize = true;
            this.HenkiloautoButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.HenkiloautoButton.Location = new System.Drawing.Point(9, 3);
            this.HenkiloautoButton.Name = "HenkiloautoButton";
            this.HenkiloautoButton.Size = new System.Drawing.Size(113, 25);
            this.HenkiloautoButton.TabIndex = 1;
            this.HenkiloautoButton.Text = "Lisaa &henkilöa-auto";
            this.HenkiloautoButton.UseVisualStyleBackColor = true;
            this.HenkiloautoButton.Click += new System.EventHandler(this.henkiloautoClick);
            // 
            // PolkupyoraButton
            // 
            this.PolkupyoraButton.AutoSize = true;
            this.PolkupyoraButton.Location = new System.Drawing.Point(0, 3);
            this.PolkupyoraButton.Name = "PolkupyoraButton";
            this.PolkupyoraButton.Size = new System.Drawing.Size(100, 25);
            this.PolkupyoraButton.TabIndex = 2;
            this.PolkupyoraButton.Text = "Lisää &polkupyörä";
            this.PolkupyoraButton.UseVisualStyleBackColor = true;
            this.PolkupyoraButton.Click += new System.EventHandler(this.PolkupyoraClick);
            // 
            // polkupyoraLabel
            // 
            this.polkupyoraLabel.AutoSize = true;
            this.polkupyoraLabel.Location = new System.Drawing.Point(59, 17);
            this.polkupyoraLabel.Name = "polkupyoraLabel";
            this.polkupyoraLabel.Size = new System.Drawing.Size(13, 13);
            this.polkupyoraLabel.TabIndex = 3;
            this.polkupyoraLabel.Text = "0";
            this.polkupyoraLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(413, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lisäähenkilautoToolStripMenuItem,
            this.lisääpolkupyöräToolStripMenuItem,
            this.autoBoxToolStripMenuItem,
            this.väriToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // lisäähenkilautoToolStripMenuItem
            // 
            this.lisäähenkilautoToolStripMenuItem.Name = "lisäähenkilautoToolStripMenuItem";
            this.lisäähenkilautoToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.lisäähenkilautoToolStripMenuItem.Text = "Lisää &henkilauto";
            this.lisäähenkilautoToolStripMenuItem.Click += new System.EventHandler(this.henkiloautoClick);
            // 
            // lisääpolkupyöräToolStripMenuItem
            // 
            this.lisääpolkupyöräToolStripMenuItem.Name = "lisääpolkupyöräToolStripMenuItem";
            this.lisääpolkupyöräToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.lisääpolkupyöräToolStripMenuItem.Text = "Lisää &polkupyörä";
            this.lisääpolkupyöräToolStripMenuItem.Click += new System.EventHandler(this.PolkupyoraClick);
            // 
            // autoBoxToolStripMenuItem
            // 
            this.autoBoxToolStripMenuItem.Name = "autoBoxToolStripMenuItem";
            this.autoBoxToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.autoBoxToolStripMenuItem.Text = "AutoBox";
            this.autoBoxToolStripMenuItem.Click += new System.EventHandler(this.AutoBoxClick);
            // 
            // väriToolStripMenuItem
            // 
            this.väriToolStripMenuItem.Name = "väriToolStripMenuItem";
            this.väriToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.väriToolStripMenuItem.Text = "Väri";
            this.väriToolStripMenuItem.Click += new System.EventHandler(this.Vari);
            // 
            // UusiIkkunaButton
            // 
            this.UusiIkkunaButton.AutoSize = true;
            this.UusiIkkunaButton.Location = new System.Drawing.Point(269, 3);
            this.UusiIkkunaButton.Name = "UusiIkkunaButton";
            this.UusiIkkunaButton.Size = new System.Drawing.Size(100, 25);
            this.UusiIkkunaButton.TabIndex = 5;
            this.UusiIkkunaButton.Text = "&Uusi ikkuna";
            this.UusiIkkunaButton.UseCompatibleTextRendering = true;
            this.UusiIkkunaButton.UseVisualStyleBackColor = true;
            this.UusiIkkunaButton.Click += new System.EventHandler(this.UusiIkkunaClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.splitContainer1);
            this.flowLayoutPanel1.Controls.Add(this.splitContainer2);
            this.flowLayoutPanel1.Controls.Add(this.UusiIkkunaButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(413, 236);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.HenkiloautoButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.HenkiloautoLabel);
            this.splitContainer1.Size = new System.Drawing.Size(132, 100);
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.splitContainer2.Location = new System.Drawing.Point(141, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.PolkupyoraButton);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.polkupyoraLabel);
            this.splitContainer2.Size = new System.Drawing.Size(122, 100);
            this.splitContainer2.TabIndex = 7;
            // 
            // Autolaskuri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 261);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Autolaskuri";
            this.Text = "Autolaskuri";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label HenkiloautoLabel;
        private System.Windows.Forms.Button HenkiloautoButton;
        private System.Windows.Forms.Button PolkupyoraButton;
        private System.Windows.Forms.Label polkupyoraLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lisäähenkilautoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lisääpolkupyöräToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem väriToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button UusiIkkunaButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}

