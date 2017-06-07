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

namespace MyllyActual
{
    /// <summary>
    /// Pelinappula
    /// </summary>
    public partial class GamePiece : UserControl
    {
        public double HalfHeight { get; private set; }
        public double HalfWidth { get; private set; }
        public Brush PieceColor { get; private set; }
        public bool chosen { get; private set; }
        private Brush black;
        public GamePiece()
        {
            InitializeComponent();
            PieceColor = Ballin.Fill;
            HalfHeight = 18;
            HalfWidth = 18;
            black = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));

        }

        /// <summary>
        /// Eventti Hiiren painalluksesta. Että saadaan kiinni siellä missä pitää.
        /// </summary>
        /// <param name="sender"></param>
        public delegate void GamePiecePressedEvent(object sender);
        public event GamePiecePressedEvent MousePress;
        public void RaiseMousePressEvent()
        {
            if (MousePress != null)
            {
                MousePress(this);
            }
        }

        /// <summary>
        /// Aseta nappula valituksi.
        /// </summary>
        /// <param name="choose"></param>
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
                Ballout.Width = 36;
                Ballout.Height = 36;
            }
        }

        /// <summary>
        /// muuta nappulan väriä
        /// </summary>
        /// <param name="brush"></param>
        public void SetColor(Brush brush)
        {
            Ballin.Fill = brush;
            if (chosen)
            {
                Ballout.Fill = brush;
            }
            PieceColor = brush;
        }

        /// <summary>
        /// siirtää mouse evnttit eteen päin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseDownHandler(object sender, MouseButtonEventArgs e)
        {
            RaiseMousePressEvent();
        }
    }
}
