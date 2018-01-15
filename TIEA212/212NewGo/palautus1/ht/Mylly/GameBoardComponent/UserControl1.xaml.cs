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

namespace GameBoardComponent
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {

        //PointLocationMap[Point location number in order from left to rigth and up to down][0 => Top value and 1 => Left value]
        private int[][] pointLocationMap = new int[][] { new int[] { 9, 9 }, new int[] { 9, 39 }, new int[] { 9, 69 }, new int[] { 19, 39 }, new int[] { 19, 19 }, new int[] { 19, 59 }, new int[] { 29, 39 }, new int[] { 29, 49 }, new int[] { 29, 29 }, new int[] { 39, 29 }, new int[] { 39, 49 }, new int[] { 39, 59 }, new int[] { 39, 69 }, new int[] { 39, 19 }, new int[] { 39, 9 }, new int[] { 49, 29 }, new int[] { 49, 39 }, new int[] { 49, 49 }, new int[] { 59, 59 }, new int[] { 59, 19 }, new int[] { 59, 39 }, new int[] { 69, 39 }, new int[] { 69, 9 }, new int[] { 69, 69 } };

        /// <summary>
        /// Tells if there is room for more pieces.
        /// </summary>
        /// <returns>bool true if space</returns>
        public bool FitNoMore()
        {
            return (space < 1);
        }

        /// <summary>
        /// A game piece has been chosen by the palyer?
        /// </summary>
        /// <returns></returns>
        public bool HasChosenGamePiece()
        {
            try
            {
                return chosen.gamepiece;
            }
            catch (NullReferenceException) {}
            return false;
        }

        private SolidColorBrush background = new SolidColorBrush();
        private SolidColorBrush piece = new SolidColorBrush();
        public event EventHandler OperationCompletedEvent;
        private GamePiece.UserControl2 chosen;

        public List<object> pieces = new List<object>();
        private bool addPiece = false;
        private bool movePiece = false;
        private int space = 24;

        /// <summary>
        /// A class for handling the game board and game logic.
        /// </summary>
        public UserControl1()
        {
            InitializeComponent();
            background.Color = Color.FromArgb(255, 255, 255, 255);
            piece.Color = Color.FromArgb(255, 255, 0, 0);

            for (int i = 0; i < pointLocationMap.Length; i++)
            {
               GamePiece.UserControl2 circle = new GamePiece.UserControl2();
                Canvas.SetTop(circle, pointLocationMap[i][0] - 2);
                Canvas.SetLeft(circle, pointLocationMap[i][1] - 2);
                canvas.Children.Add(circle);
                circle.PieceChosenEvent += PieceChosen;
                pieces.Add(circle);
            }
            setBackGround(background);
        }

        /// <summary>
        /// removes history and lets a new game begin.
        /// </summary>
        public void NewGame()
        {
            space = 24;
            addPiece = false;
            movePiece = false;
            foreach (GamePiece.UserControl2 circle in pieces)
            {
                circle.UnChoose();
                circle.removePiece();
            }
        }

        /// <summary>
        /// sets the background color.
        /// </summary>
        /// <param name="background"></param>
        public void setBackGround(SolidColorBrush background)
        {
            canvas.Background = background;
        }

        /// <summary>
        /// Starts to do the actions related to a "Move"
        /// </summary>
        public void MovePiece()
        {
            movePiece = true;
        }

        /// <summary>
        /// removes the currently selected game piece
        /// </summary>
        public void RemovePiece()
        {
            space += 1;
            chosen.removePiece();
            chosen.UnChoose();
            addPiece = false;
            movePiece = false;
        }

        /// <summary>
        /// Add a piece to the next chosen position.
        /// </summary>
        public void AddPiece()
        {
            addPiece = true;
            try
            {
                chosen.UnChoose();
            } catch(NullReferenceException) { }
        }


        /// <summary>
        /// Event that happens once a game piece has been selected.
        /// holds mainly logic related to teh movement and addition of elements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PieceChosen(object sender, EventArgs e)
        {
            GamePiece.UserControl2 circle = (GamePiece.UserControl2)sender;
            try
            {
                if (chosen != circle) chosen.UnChoose();
            }
            catch (NullReferenceException) { }

            if (movePiece)
            {
                if (!(circle.gamepiece))
                {
                    RemovePiece();
                    addPiece = true;
                }
            }

            chosen = circle;

            if (addPiece)
            {
                circle.insertPiece(piece.Clone());

                space -= 1;
                if (space < 20)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(GameBoardComponent.Properties.Resources.heres_your_winner);
                    player.Load();
                    player.Play();
                }
            }

            if(addPiece || movePiece)
            {
                circle.UnChoose();
                addPiece = false;
                movePiece = false;
                chosen = null;
            }
            
            OnRaiseOperationCompletedEvent(new EventArgs());
        }

        /// <summary>
        /// returns background color.
        /// </summary>
        /// <returns></returns>
        public SolidColorBrush getBackground()
        {
            return (SolidColorBrush)canvas.Background;
        }

        /// <summary>
        /// returns the color of the pieces
        /// </summary>
        /// <returns></returns>
        public SolidColorBrush getBrush()
        {
            return piece;
        }

        /// <summary>
        /// sets the color of the game pieces
        /// </summary>
        /// <param name="brush"></param>
        public void SetColor(SolidColorBrush brush)
        {
            piece = brush;
        }

        /// <summary>
        /// event for when a game piece location or a game piece has been chosen.
        /// </summary>
        /// <param name="e"></param>
        private void OnRaiseOperationCompletedEvent(EventArgs e)
        {
            EventHandler handler = OperationCompletedEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
