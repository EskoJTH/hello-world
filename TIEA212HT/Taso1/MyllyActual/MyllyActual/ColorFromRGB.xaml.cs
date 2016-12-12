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

namespace MyllyActual
{
    /// <summary>
    /// Settings ikkunan logiikka
    /// </summary>
    public partial class Settings : Window
    {
        private byte pR = 0;
        private byte pG = 255;
        private byte pB = 0;
        private byte bR = 255;
        private byte bG = 255;
        private byte bB = 255;
        private SolidColorBrush pieces = new SolidColorBrush(Color.FromRgb(0, 255, 0));
        private SolidColorBrush background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        public Settings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tapahtuu painettaessa Apply nappulaa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Apply(object sender, RoutedEventArgs e)
        {
            RaiseAcceptedColorEvent();
            this.Close();
        }

        /// <summary>
        /// Eventti värien perille viemiseksi.
        /// </summary>
        /// <param name="pieces"></param>
        /// <param name="background"></param>
        public delegate void ColorChangedEvent(Brush pieces, Brush background);
        public static event ColorChangedEvent AcceptedColor;
        public void RaiseAcceptedColorEvent()
        {
            if (AcceptedColor != null)
            {
                AcceptedColor(pieces, background);
            }
        }

        /// <summary>
        /// tekee mitä sanoo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Katsotaan mitä värejä on valittu
        /// </summary>
        private void ExamineColor()
        {
            try
            {
                pieces = new SolidColorBrush(Color.FromRgb(pR, pG, pB));
                background = new SolidColorBrush(Color.FromRgb(bR, bG, bB));
                pieceListBox.Background = pieces;
                backgroundListBox.Background = background;

            } catch (Exception) { }
        }

        //Handlaillaan muutokset tekstitssä
        private void ChangeColorPR(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            byte.TryParse(textBox.Text, out pR);
            ExamineColor();
        }

        private void ChangeColorPG(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            byte.TryParse(textBox.Text, out pG);
            ExamineColor();
        }
        private void ChangeColorPB(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            byte.TryParse(textBox.Text, out pB);
            ExamineColor();
        }
        private void ChangeColorBR(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            byte.TryParse(textBox.Text, out bR);
            ExamineColor();
        }
        private void ChangeColorBG(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            byte.TryParse(textBox.Text, out bG);
            ExamineColor();
        }
        private void ChangeColorBB(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            byte.TryParse(textBox.Text, out bB);
            ExamineColor();
        }
    }
}
