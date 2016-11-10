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
using Treeni_WPF_komponentti;

namespace KilometriLaskuri
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        void NewCmdExecuted(object s, ExecutedRoutedEventArgs e)
        {
            UserControl1 ikkuna = new UserControl1();
            this.LajitteluPaneeli.Children.Add(ikkuna);
        }
        void NewCmdCanExecute(object s, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
            void CloseCmdExecuted(object s, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        void CloseCmdCanExecute(object s, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
