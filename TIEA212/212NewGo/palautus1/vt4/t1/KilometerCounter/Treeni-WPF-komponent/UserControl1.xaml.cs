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

namespace Treeni_WPF_komponent
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {

        public double Km { get; set; }
        public double H { get; set; }

        public UserControl1()
        {
            InitializeComponent();
            this.DataContext = this;
            SpeedLabel.Content = Math.Round((Km / H), 2);
        }

        private void Count(object sender, RoutedEventArgs e)
        {
            SpeedLabel.Content = Math.Round((Km / H), 2);
        }

    }
}
//<Treeni_WPF_komponent:UserControl1 HorizontalAlignment="Left" Height="Auto" Margin="5,5,5,5" VerticalAlignment="Top" Width="Auto"/>