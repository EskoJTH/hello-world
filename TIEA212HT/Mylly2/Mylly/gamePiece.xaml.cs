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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mylly
{

    /// <summary>
    /// Interaction logic for gamePiece.xaml
    /// </summary>
    public partial class GamePiece : UserControl
    {
        public double HalfHeight { get; }
        public double HalfWidth { get; }
        public Brush PieceColor { get; private set; }
        public bool chosen { get; private set; }
        private Brush black;
        public GamePiece()
        {
            InitializeComponent();
            HalfHeight = gridi.ActualHeight;
            HalfWidth = gridi.ActualWidth;
            PieceColor = Ballin.Fill;
            black = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        }

        public void IsTheChosenOne(bool choose)
        {
            if (choose)
            {
                Ballout.Fill = PieceColor;
                Ballout.Width = 40;
                Ballout.Height = 40;
            }
            else
            {
                Ballout.Fill = black;
                Ballout.Width = 35;
                Ballout.Height = 35;
            }
        }

        public void IsEmpty()
        {
            PieceColor = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            Ballin.Fill = PieceColor;
            Ballout.Fill = PieceColor;
            Ballout.Width = 35;
            Ballout.Height = 35;
            Ballin.Width = 30;
            Ballin.Height = 30;
        }

        public void SetColor(Brush brush)
        {
            Ballin.Fill = brush;
            if (chosen)
            {
                Ballout.Fill = brush;
            }
            PieceColor = brush;
        }


    }
}
