using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace floatingText
{
    public partial class texti : UserControl
    {
        public string[] displayList = { "oletus", "teksti", "tähän" };
        private int displayPointer = 0;
        public texti()
        {
            InitializeComponent();
            this.BackColor = Color.Black;
            Timer clock = new Timer();
            clock.Interval = 500;
            clock.Enabled = true;
            clock.Tick += clock_Cycle;
            Invalidate();
        }

        private void clock_Cycle(object sender, EventArgs e)
        {
            displayPointer++;
            if (displayPointer >= displayList.Length) displayPointer = 0;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush pensseli = new SolidBrush(Color.White);
            e.Graphics.DrawString(displayList[displayPointer], new Font(FontFamily.GenericMonospace, 22), pensseli,0,0);
        }
    }
}
