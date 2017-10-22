using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuvaJaLiike
{
    public partial class Form1 : Form
    {
        private Image bunny = Properties.Resources.bunny;
        private double location;
        private int x=0;
        public Form1()
        {
            InitializeComponent();
            location = this.Width / 2;
            texti1.displayList =new string[] { "Tämä", "on", "graafisten", "käyttöliittymien", "(TIEA212)", "ohjelmointi", "-kurssin", "viikkotehtävä", "..."};
            Timer clock = new Timer();
            clock.Interval = 1000/60;
            clock.Tick += updateImage;
            Invalidate();
        }

        private void updateImage(object sender, EventArgs e)
        {

            location = (Math.Sin(x/(this.Width / 2)));
            x++;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.
        }
    }
}
