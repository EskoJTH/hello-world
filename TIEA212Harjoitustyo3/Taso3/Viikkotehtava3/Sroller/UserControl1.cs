using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sroller
{
    public partial class UserControl1: UserControl
    {
        public List<String> feed { get; set; }

        public UserControl1()
        {
            InitializeComponent();
            Timer kellotin = new Timer();
            kellotin.Enabled = true;
            kellotin.Tick += Kellotin_Tick;
            kellotin.Interval = 1000;
            this.BackColor = Color.Black;
            Invalidate();
        }


        private void Kellotin_Tick(object sender, EventArgs e)
        {
            try
            {
                string eka = feed[0];
                feed.Remove(feed[0]);
                feed.Add(eka);
            }
            catch (NullReferenceException)
            {
                Console.Error.WriteLine("Yritettiin kirjoittaa sana, mutta sanoja ei ole vielä annettu yhtään.");
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush pensseli = new SolidBrush(Color.White);
            try
            {
                e.Graphics.DrawString(feed[0], new Font("Arial Regualar", 30), pensseli, 0, 0);
            }
            catch (NullReferenceException)
            {
                Console.Error.WriteLine("Yritettiin kirjoittaa sana, mutta sanoja ei ole vielä annettu yhtään.");
            }
        }
    }
}
