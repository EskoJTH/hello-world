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

namespace HorizontalBar
{
    public partial class horizontalBar: UserControl
    {
        LinearGradientBrush gradient;
        ColorBlend blend = new ColorBlend();

        public float locationForSin { get; set; } //can be used to track how much the bar should move.

        /// <summary>
        /// makes a bar that has a specific color
        /// </summary>
        public horizontalBar()
        {
            InitializeComponent();

            locationForSin = 0;

            this.DoubleBuffered = true;
            gradient = new LinearGradientBrush(this.ClientRectangle, Color.Transparent, Color.Transparent, 90, false);
            blend.Colors = new[] { Color.Red, Color.Yellow, Color.Red };
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            blend.Positions = new[] { 0, 1 / 2f, 1f };
            gradient.InterpolationColors = blend;
            e.Graphics.FillRectangle(gradient, this.ClientRectangle);
        }
    }
}
