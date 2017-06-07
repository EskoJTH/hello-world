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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static bool insertPiece = false;
        private static bool movePiece = false;
        private List<Ellipse> GamePlayPieces = new List<Ellipse>();
        private Ellipse theChosenOne;
        private int GamePlayPiecePositions = 6 * 4;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenericCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void InsertCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            movePiece = false;
            insertPiece = true;
        }

        private void AboutCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var about = new About();
            about.Show();
        }

        private void ManualCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://appro.mit.jyu.fi/gko/harkka/");
        }

        private void InsertCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

            if (GamePlayPieces.Count<GamePlayPiecePositions)
                if(!insertPiece)
                    e.CanExecute = true;
        }

        private void RemoveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (theChosenOne!=null)
            e.CanExecute = true;
        }

        private void RemoveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            movePiece = false;
            RemoveTheChosenOne();
        }



        private void RemoveTheChosenOne()
        {
            if (theChosenOne != null)
            {
                theChosenOne.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                theChosenOne.Fill = new SolidColorBrush((Color.FromArgb(255, 0, 0, 0)));
                theChosenOne = null;
            }
        }

        private void MoveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (GamePlayPieces.Count < GamePlayPiecePositions)
                if (theChosenOne != null)
                    if(!movePiece)
                        e.CanExecute = true;
        }

        private void MoveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            insertPiece = false;
            movePiece = true;
            
        }

        private void MousePressOverGamePosition(object sender, MouseEventArgs e)
        {
            Ellipse pallo = (Ellipse)sender;
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                if (insertPiece)
                {
                    AddPiece(pallo);
                }
                else if (movePiece)
                {
                    AddPiece(pallo);
                    RemoveTheChosenOne();
                }
                else
                {
                    if (GamePlayPieces.IndexOf(pallo) > -1)
                    {
                        if (theChosenOne != null)
                        {
                            theChosenOne.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                            theChosenOne = null;
                        }
                        pallo.Stroke = pallo.Fill;
                        theChosenOne = pallo;

                    }
                }
            }
        }

        private void AddPiece(Ellipse pallo)
        { 
            pallo.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            pallo.Fill = new SolidColorBrush((Color.FromArgb(255, 0, 255, 0)));
            GamePlayPieces.Add(pallo);
            insertPiece = false;
            movePiece = false;
        }
    }
}

