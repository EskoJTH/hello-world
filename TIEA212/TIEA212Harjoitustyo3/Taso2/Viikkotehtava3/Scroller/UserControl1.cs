using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pollo
{
    public partial class UserControl1 : UserControl
    {
        private Bitmap kuva;

        private double x;
        private double intervalli = 0.02;
        private float pollonPaikka;
        private SoundPlayer Player = new SoundPlayer();
        private Image pollo = Scroller.Properties.Resources.owl;


        public UserControl1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            x = 0;
            this.Size = new System.Drawing.Size(pollo.Width /*+ pollo.Width / 2*/, pollo.Height /*+ pollo.Width / 2*/);
            this.mustaLaatikko.feed = new List<string>();
            this.mustaLaatikko.feed.Add("Tämä");
            this.mustaLaatikko.feed.Add("on");
            this.mustaLaatikko.feed.Add("graafisten");
            this.mustaLaatikko.feed.Add("Käyttöliittymien");
            this.mustaLaatikko.feed.Add("ohjelmointi");
            this.mustaLaatikko.feed.Add("(TIEA212)");
            this.mustaLaatikko.feed.Add("-kurssin");
            this.mustaLaatikko.feed.Add("viikkotehtävä");
            this.mustaLaatikko.feed.Add("...");
        }

        private void Kello(object sender, EventArgs e)
        {
            double paikka = ClientSize.Width / 2;
            x = x + intervalli;
            if (x > 2 * Math.PI) x = 0;
            paikka = paikka + Math.Sin(x) * pollo.Width / 4 - pollo.Width / 2;
            pollonPaikka = Convert.ToSingle(paikka);
            Invalidate();

        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            canvas.DrawImage(pollo, pollonPaikka, 0);
        }

        private void GDI_rezize(object sender, EventArgs e)
        {
            kuva = new Bitmap(this.ClientSize.Width, this.ClientSize.Height, this.CreateGraphics());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
