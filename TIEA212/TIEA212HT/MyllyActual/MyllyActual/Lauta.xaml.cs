using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using static MyllyActual.GamePiece;
using static MyllyActual.Settings;

namespace MyllyActual
{
    /// <summary>
    /// Pelilauta
    /// </summary>
    public partial class Lauta : UserControl
    {

        private static List<GamePiece> GamePlayPieces = new List<GamePiece>();
        private static Brush pieceColor = new SolidColorBrush(Color.FromRgb(0, 255, 0));
        private static GamePiece theChosenOne = null;
        private static int BoardLocations = 6 * 4;
        internal static bool insert;
        internal static bool move;
        private static SoundPlayer player;

        public Lauta()
        {
            InitializeComponent();
            Settings.AcceptedColor += new ColorChangedEvent(NewPieceColorChanged);
            player = new SoundPlayer(MyllyActual.Properties.Resources.heres_your_winner);
        }

        /// <summary>
        /// restart
        /// </summary>
        public static void restart()
        {
            pieceColor = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            RemoveTheChosenOne();
            while (0 < GamePlayPieces.Count)
            {
                theChosenOne = GamePlayPieces.First();
                RemoveTheChosenOne();
            }
        }

        /// <summary>
        /// lisää nappulan tiettyyn kohtaan.
        /// </summary>
        /// <param name="pallo"></param>
        /// <returns></returns>
        private static GamePiece AddPiece(Ellipse pallo)
        {
            OmaCanvas canvas = (OmaCanvas)pallo.Parent;
            GamePiece nappula = new GamePiece();
            nappula.HorizontalAlignment= HorizontalAlignment.Center;
            nappula.VerticalAlignment = VerticalAlignment.Center;
            canvas.Children.Add(nappula);
            Canvas.SetLeft(nappula, canvas.HalfWidth - nappula.HalfWidth);
            Canvas.SetTop(nappula, canvas.HalfHeight - nappula.HalfWidth);
            GamePlayPieces.Add(nappula);
            nappula.MousePress += new GamePiecePressedEvent(PieceChosen);
            insert = false;
            move = false;
            if (GamePlayPieces.Count == 5) player.Play();
            return nappula;

        }

        /// <summary>
        /// Eventti värien hallintaan.
        /// </summary>
        /// <param name="pieces"></param>
        /// <param name="background"></param>
        private static void NewPieceColorChanged(Brush pieces, Brush background)
        {
            pieceColor = pieces;
        }

        /// <summary>
        ///  Kutsutaan kun halutaan valita nappula tai epä valita nappula.
        /// </summary>
        /// <param name="sender"></param>
        private static void PieceChosen(object sender)
        {
            if (theChosenOne!=null)theChosenOne.IsTheChosenOne(false);
            theChosenOne = (GamePiece)sender;
            theChosenOne.IsTheChosenOne(true);
        }

        /// <summary>
        /// poistaa valitun nappulan
        /// </summary>
        private static void RemoveTheChosenOne()
        {
            if (theChosenOne == null) return;
            theChosenOne.Visibility = Visibility.Hidden;
            GamePlayPieces.Remove(theChosenOne);
            theChosenOne = null;
        }

        /// <summary>
        /// Tapahtuu aina kun hiirellä oainetaan pelilaudan ympyrästä.
        /// Tarkastaa pitäääkö nappuloita lisätä tai siirtäö.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MousePressOverGamePosition(object sender, MouseEventArgs e)
        {
            Ellipse pallo = (Ellipse)sender;
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                if (insert)
                {
                    GamePiece nappula = AddPiece(pallo);
                    nappula.SetColor(pieceColor);
                }

                if (move)
                {
                    GamePiece nappula = AddPiece(pallo);
                    nappula.SetColor(theChosenOne.PieceColor);
                    RemoveTheChosenOne();
                }
            }
        }

//Seuraavat asettavat arvot oikeita toimintoja varten Mainwindowista.
        internal static void Insert()
        {
            Lauta.insert = true;
            Lauta.move = false;
        }

        internal static void Remove()
        {
            RemoveTheChosenOne();
            Lauta.insert = false;
            Lauta.move = false;
        }

        internal static void Move()
        {
            Lauta.move = true;
            Lauta.insert = false;
        }

        internal static bool CanRemove()
        {
            return (theChosenOne != null);
        }

        internal static bool CanInsert()
        {
            return (GamePlayPieces.Count < BoardLocations && !insert);
        }

        internal static bool CanMove()
        {
            return (theChosenOne != null);
        }


    }
}
