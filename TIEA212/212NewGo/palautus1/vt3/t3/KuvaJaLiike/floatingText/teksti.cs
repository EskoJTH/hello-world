using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace floatingText
{
    public partial class texti : UserControl
    {
        /// <summary>
        /// text that the scroller displays
        /// </summary>
        public string text { get; set; } 

        /// <summary>
        /// size of the font
        /// </summary>
        public int fontSize {get; set;}

        /// <summary>
        /// speed the text moves in the x-axis
        /// </summary>
        public float speed { get; set; }

        private float[] position = { 0 , 0 };
        private Label label = new Label();
        private double x = 0;
        private int m = 1;

        private System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        private System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
        private System.Drawing.Font drawFont;

        /// <summary>
        /// creates a black bar that has a text floating inside it
        /// </summary>
        public texti()
        {
            //<default settings>
            speed = 1;
            fontSize = 10;
            text = "undefined";
            //<\defaults settings>

            this.DoubleBuffered = true;
            position[0] = this.Width;
            position[1] = 0;
            label.Text = text;
            InitializeComponent();
            this.BackColor = Color.Black;
            Timer clock = new Timer();
            clock.Interval = 1000/120;
            clock.Enabled = true;
            clock.Tick += Clock_Cycle;
            drawFont = new System.Drawing.Font("Arial", fontSize);
            Invalidate();
        }

        private void Clock_Cycle(object sender, EventArgs e)
        {


            if (position[0] < - text.Length * fontSize)
                    position[0] = this.Width;
            

            position[0] -= speed;
            position[1] = Convert.ToSingle((Math.Sin(x)+1)/2 * (this.Height - fontSize * 2));
            x+=0.1f;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            float x = position[0];
            float y = position[1];
            e.Graphics.DrawString(text, drawFont, drawBrush, x, y, drawFormat);
        }
    }
}
