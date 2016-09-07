using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autolaskuri
{
    class Kuva : PictureBox
    {
        private int nopeus = 5;
        private Timer ajastin = new Timer();
        private int parentWidth;

        public Kuva(Image image)
        {
            this.Image = image;
            this.SizeMode = PictureBoxSizeMode.AutoSize;
            this.ParentChanged += new EventHandler(this.OnParentChanged);
            this.Visible = true;

            ajastin.Enabled = true;
            ajastin.Tick += new EventHandler(this.AjastinTick);
        }

        private void OnParentChanged(object sender, EventArgs e)
        {
            Random random = new Random();
            this.parentWidth = this.Parent.Size.Width;
            int y = random.Next(0, this.Parent.Size.Height-Image.Height);
            int x = random.Next(0, this.Parent.Size.Width - Image.Width);
            System.Drawing.Point paikka = new System.Drawing.Point(x, y);
                this.Location = paikka;
        }

        private void AjastinTick(object sender, EventArgs e)
        {
            if (this.Left + this.Size.Width + nopeus > this.parentWidth)
                nopeus = -nopeus;
            if (this.Left + nopeus < 0)
                nopeus = -nopeus;
            this.Left += nopeus;
        }
    }
}
