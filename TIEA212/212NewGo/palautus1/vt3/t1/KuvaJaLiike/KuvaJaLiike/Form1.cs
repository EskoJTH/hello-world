using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace KuvaJaLiike
{
    public partial class Form1 : Form
    {
        private Image bunny = Properties.Resources.bunny;
        private float location;
        private float x=0;

        public Form1()
        {
            InitializeComponent();
            location = this.Width / 2;
            this.DoubleBuffered = true;
            texti1.displayList =new string[] { "Tämä", "on", "graafisten", "käyttöliittymien", "(TIEA212)", "ohjelmointi", "-kurssin", "viikkotehtävä", "..."};
            Timer clock = new Timer();
            clock.Interval = 1000/120;
            clock.Tick += updateImage;
            clock.Enabled=true;
            Invalidate();
        }

        private void updateImage(object sender, EventArgs e)
        {

            location =Convert.ToSingle(((Math.Sin(x) + 1)/2 * (this.Width - bunny.Width)) );
            x +=0.01f;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush gradient = new LinearGradientBrush(this.ClientRectangle, Color.Black, Color.Black, 90, false);
            ColorBlend blend = new ColorBlend();
            blend.Positions = new[] { 0, 1 / 2f, 1f };
            blend.Colors = blend.Colors = new[] { Color.DarkBlue, Color.LightBlue, Color.DarkBlue};
            gradient.InterpolationColors = blend;
            e.Graphics.FillRectangle(gradient, this.ClientRectangle);
            Graphics canvas = e.Graphics;
            canvas.DrawImage(bunny, location, 0);
            //this.
        }
    }
}
