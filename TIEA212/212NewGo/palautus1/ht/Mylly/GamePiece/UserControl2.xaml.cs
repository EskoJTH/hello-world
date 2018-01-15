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

namespace GamePiece
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        private SolidColorBrush black = new SolidColorBrush();
        private SolidColorBrush piece = new SolidColorBrush();
        private SolidColorBrush pieceChoose = new SolidColorBrush();
        private SolidColorBrush choose = new SolidColorBrush();
        private SolidColorBrush transparent = new SolidColorBrush();
        public event EventHandler PieceChosenEvent;
        public bool gamepiece = false;
        private bool chosen = false;

        /// <summary>
        /// A control that holds the logic of a single game piece.
        /// </summary>
        public UserControl2()
        {
            InitializeComponent();
            black.Color = Color.FromArgb(255, 0, 0, 0);
            choose.Color = Color.FromArgb(0, 200, 100, 0);
            transparent.Color = Color.FromArgb(0, 0, 0, 0);
        pieceChoose.Color = Color.FromArgb(255, 255, 150, 0);
        }

        /// <summary>
        /// Does what the name says
        /// </summary>
        /// <param name="piece"></param>
        public void insertPiece(SolidColorBrush piece)
        {
            this.piece = piece;
            gamepiece = true;
            chosen = false;
            ellipse.Fill = piece;
            ellipse.Stroke = piece;
        }

        public void removePiece()
        {
            gamepiece = false;
            chosen = false;
            ellipse.Fill = transparent;
            ellipse.Stroke = black;

        }


        /// <summary>
        /// if a game piece has been selected this can be used to unselect.
        /// </summary>
        public void UnChoose()
        {
            chosen = false;
            if (gamepiece)
            {
                ellipse.Fill = piece;
            }
            else
            {
                ellipse.Fill = transparent;
            }
        }

        /// <summary>
        /// mouse Down on top of a piece
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BigDotMouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                chosen = true;
                if (gamepiece)
                {
                    ellipse.Fill = pieceChoose;
                }
                else
                {
                    ellipse.Fill = choose;
                }
                OnRaisePieceChosenEvent(new EventArgs());
            }
        }

        /// <summary>
        /// a location for a game piece has been chosen.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnRaisePieceChosenEvent(EventArgs e)
        {
            EventHandler handler = PieceChosenEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Mouse over event for the game piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BigDotMouseOver(object sender, MouseEventArgs e)
        {
            if(gamepiece) ellipse.Fill = pieceChoose;
            else ellipse.Fill = choose;
        }

        /// <summary>
        /// Mouse goes away from top of the game piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BigDotMouseOut(object sender, MouseEventArgs e)
        {
            if (!chosen)
            {
                if (gamepiece) ellipse.Fill = piece;
                else ellipse.Fill = transparent;
            }
        }
    }
}
