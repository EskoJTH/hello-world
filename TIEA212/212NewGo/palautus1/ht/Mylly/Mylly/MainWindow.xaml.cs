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
        private bool adding = false;
        private bool moving = false;

        public MainWindow()
        {
            InitializeComponent();
            Board.OperationCompletedEvent += OperationCompleted;
        }

        /// <summary>
        /// Checks if we can add a new game piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NewCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (moving) return;
            if (adding) return;
            if (Board.FitNoMore()) return;
            e.CanExecute = true;

        }

        /// <summary>
        /// Adds a new game piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NewCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {

            adding = true;
            Board.AddPiece();
        }

        /// <summary>
        /// Called once addition or movement operations are completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OperationCompleted(object sender, EventArgs e)
        {
            adding = false;
            moving = false;

        }

        /// <summary>
        /// Checks wether we can delete a game piece
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DeleteCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (moving) return;
            if (adding) return;
            if (Board.HasChosenGamePiece()) e.CanExecute = true;
            return;
        }

        /// <summary>
        /// Deletes the game piece
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DeleteCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Board.RemovePiece();
        }

        /// <summary>
        /// Checks if we can move a game piece.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MoveCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (moving) return;
            if (adding) return;
            if (!(Board.HasChosenGamePiece())) return;
            if (Board.FitNoMore()) return;
            e.CanExecute = true;
        }

        /// <summary>
        /// Moves a game piece
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MoveCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            moving = true;
            Board.MovePiece();
        }

        /// <summary>
        /// initializes a new game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MyNewGame(object sender, EventArgs e)
        {
            adding = false;
            moving = false;
            Board.NewGame();
        }

        /// <summary>
        /// opens a printing window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MyPrint(object sender, EventArgs e)
        {
            System.Windows.Controls.PrintDialog dlg = new System.Windows.Controls.PrintDialog();
            dlg.PageRangeSelection = PageRangeSelection.AllPages;
            dlg.UserPageRangeEnabled = true;

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Print document
            }
        }

        /// <summary>
        /// sets custom colors.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MySettings(object sender, EventArgs e)
        {
            // Instantiate the dialog box
            ColorPicker colorPicker = new ColorPicker();

            // Configure the dialog box
            colorPicker.Owner = this;
            colorPicker.initializeColors(Board.getBrush().Clone(), Board.getBackground().Clone());

            // Open the dialog box modally 
            colorPicker.ShowDialog();

            if ((bool)colorPicker.DialogResult) {
                Board.SetColor(colorPicker.brush);
                Board.setBackGround(colorPicker.background);
            }

            
        }

        /// <summary>
        /// opens an about window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MyAbout(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        /// <summary>
        /// opens a web page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MyHelp(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://appro.mit.jyu.fi/gko/harkka/");
        }

    }
}
