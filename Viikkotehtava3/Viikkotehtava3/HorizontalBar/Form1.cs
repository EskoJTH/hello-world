using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorizontalBar
{
    public partial class Form1 : Form
    {
        public Color color0 { get; set; }
        public Color color1 { get; set; }
        public int thikness { get; set; }
        public Point sijainti { get; set; }

        public UserControl1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            LinearGradientBrush linGrBrush0 = new LinearGradientBrush(new Point(0, (ClientSize.Height / 2)), new Point(0, 0), Color.LightBlue, Color.DarkBlue);

            e.Graphics.FillRectangle(linGrBrush0, new RectangleF(0, 0, ClientSize.Width, (ClientSize.Height / 2)));

        }
    }
}
