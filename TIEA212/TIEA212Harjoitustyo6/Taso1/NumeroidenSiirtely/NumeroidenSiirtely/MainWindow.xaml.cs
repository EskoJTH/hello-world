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

namespace NumeroidenSiirtely
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int summa=0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Label_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DataObject data = new DataObject();
                Label label = (Label)sender;
                StackPanel panel = (StackPanel)label.Parent;
                data.SetData("Label", sender);
                panel.Children.Remove(label);
                DragDrop.DoDragDrop(label, data, DragDropEffects.Copy | DragDropEffects.Move);
                
            }
        }

        private void Label_Drop(object sender, DragEventArgs e)
        {
            base.OnDrop(e);

            // Löytyykö oma data
            if (e.Data.GetDataPresent("Label"))
            {
                Label apu = (Label)e.Data.GetData("Label");
                MessageBox.Show(apu.Content.ToString());

            }
            e.Handled = true;
        }

        private void listCalcutable_Drop(object sender, DragEventArgs e)
        {
            base.OnDrop(e);

            // Löytyykö oma data
            if (e.Data.GetDataPresent("Label"))
            {
                Label apu = (Label)e.Data.GetData("Label");
                ListBox panel = (ListBox)sender;
                panel.Items.Add(apu);
                int summattava=0;
                Int32.TryParse(apu.Content.ToString(), out summattava);
                summa += summattava;
                Tulos.Content = "" + summa;
            }
            e.Handled = true;
        }
    }
}
