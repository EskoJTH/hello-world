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
using HorizontalBar;

namespace KuvaJaLiike
{
    public partial class Form1 : Form
    {
        public int howManyBars = 10;

        private Image bunny = Properties.Resources.bunny;
        private float location;
        private float x = 0;
        private List<horizontalBar> bars = new List<horizontalBar>();
        private const int delay = 10;
        private int delayCurrent = delay;


        public Form1()
        {
            InitializeComponent();

            this.BackColor = Color.Black;
            location = this.Width / 2;
            this.DoubleBuffered = true;
            texti1.text = "Tämä on graafisten käyttöliittymien (TIEA212) ohjelmointi -kurssin viikkotehtävä...";
            Timer clock = new Timer();
            clock.Interval = 1000 / 120;
            clock.Tick += UpdateImage;
            clock.Enabled = true;
            Invalidate();
        }

        private void BuildBars(int count)
        {

        }

        private void UpdateImage(object sender, EventArgs e)
        {
            location = Convert.ToSingle(((Math.Sin(x) + 1) / 2 * (this.Width - bunny.Width)));
            x += 0.01f;
            UpdateBars();
            Invalidate();

            foreach (horizontalBar bar in bars)
            {
                bar.Width = this.Width;
                bar.Top = Convert.ToInt32(Math.Sin(bar.locationForSin) * this.Height);
                bar.locationForSin += 0.01f;
            }

            if (howManyBars < 1) return;
            switch (delayCurrent)
            {
                case delay:
                    horizontalBar bar = new horizontalBar();
                    bar.Width = this.Width;
                    bars.Add(bar);
                    this.Controls.Add(bar);
                    bar.Location = new System.Drawing.Point(0,this.Height+200);
                    bar.locationForSin = 2;
                    howManyBars--;
                    delayCurrent--;
                    break;

                case 0:
                    delayCurrent = delay;
                    break;

                default:
                    delayCurrent--;
                    break;
            }


        }

        private void UpdateBars()
        {
            for (int i = 0; i < bars.Count; i++)
            {

            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            canvas.DrawImage(bunny, location, 0);
            //this.
        }
    }
}
