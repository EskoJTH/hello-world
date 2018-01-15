using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mylly
{

    /// <summary>
    /// Interaction logic for colorPicker.xaml
    /// </summary>
    public partial class ColorPicker : Window
    {
        public SolidColorBrush brush = new SolidColorBrush();
        private float brushR;
        private float brushB;
        private float brushG;
        
        public SolidColorBrush background = new SolidColorBrush();
        private float backgroundR;
        private float backgroundG;
        private float backgroundB;

        /// <summary>
        /// Updates the current colors to be visible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateBall(object sender, EventArgs e)
        {
            brush.Color = Color.FromArgb(255, (byte)redSlider.Value, (byte)greenSlider.Value, (byte)blueSlider.Value);
            ball.Fill = brush;

            background.Color = Color.FromArgb(255, (byte)r_background.Value, (byte)g_background.Value, (byte)b_background.Value);
            square.Fill = background;
        }

        /// <summary>
        /// Class that helps with picking the colors. 
        /// There is some bug with the background color still not bein pre selected correctly but otherwise should woek well.
        /// </summary>
        /// <param name="brush">1st color</param>
        /// <param name="background">2st color</param>
        public ColorPicker()
        {

            InitializeComponent();

        }

        public void initializeColors(SolidColorBrush newBrush, SolidColorBrush newBackground)
        {
            Console.WriteLine("kissa");
            Console.WriteLine(newBackground.Color.R + " " + newBackground.Color.G + " " + newBackground.Color.B);
            Console.WriteLine(background.Color.R + " " + background.Color.G  + " " + background.Color.B);

            redSlider.Value = newBrush.Color.R;
            greenSlider.Value = newBrush.Color.G;
            blueSlider.Value = newBrush.Color.B;

            r_background.Value = newBackground.Color.R;
            g_background.Value = newBackground.Color.G;
            b_background.Value = newBackground.Color.B;
        }

        /// <summary>
        /// exits
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
