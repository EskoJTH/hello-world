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
using static MyllyActual.Settings;

/// <summary>
/// @author Esko Hanell
/// @Version 12.12.2016
/// </summary>
namespace MyllyActual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            Settings.AcceptedColor += new ColorChangedEvent(BackgroundColorChanged);
        }

        /// <summary>
        /// Eventti jolla asetetaan taustaväri.
        /// </summary>
        /// <param name="pieces"></param>
        /// <param name="background"></param>
        private void BackgroundColorChanged(Brush pieces, Brush background)
        {
            this.Background = background;
        }

        //PRINT
        private void PrintCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PrintDialog print = new PrintDialog();
            print.ShowDialog();
        }

        //NEW
        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Background =new SolidColorBrush(Color.FromRgb(255, 255, 255));
            Lauta.restart();
        }

        //EXIT
        private void GenericCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }



        //ABOUT
        private void AboutCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var about = new About();
            about.Show();
        }

        //help
        private void ManualCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://appro.mit.jyu.fi/gko/harkka/");
        }

        //SetColor
        private void SettingsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var settings = new Settings();
            settings.Show();
        }


        //INSERT
        private void InsertCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute =Lauta.CanInsert();
        }

        
        private void InsertCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Lauta.Insert();
        }


        //REMOVE
        private void RemoveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Lauta.CanRemove();
        }

        private void RemoveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Lauta.Remove();
        }





        //MOVE
        private void MoveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Lauta.CanMove();
        }

        private void MoveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Lauta.Move();
        }
    }
}

