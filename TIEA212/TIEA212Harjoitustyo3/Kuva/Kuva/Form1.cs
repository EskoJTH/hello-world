using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuva
{
    public partial class Form1 : Form
    {
        Image kuva;

        public Form1()
        {
            InitializeComponent();

            kuva = Image.FromFile("owl.png");

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
            // piirtää kuvan todellisessa koossa eli fyysisessä koossa mitattuna riippumatta käytetyn näyttölaitteen
            // pikselien koosta ja tiheydestä
            dc.DrawImageUnscaled(kuva, new Point(0, 0));
            // piirtää kuvan halutussa koossa eli annetaan kuvan alkuperäinen leveys ja korkeus (pikseleitä)
            dc.DrawImage(kuva, 0,0, kuva.Width, kuva.Height);

        }
    }
}
