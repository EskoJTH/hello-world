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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Label_MouseMove(object sender, MouseEventArgs e)
        {
            DataObject data = new DataObject();
            data.SetData("Label", 10);
            System.Windows.DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);

        }

        private void Label_Drop(object sender, DragEventArgs e)
        {
            base.OnDrop(e);

            // Löytyykö oma data
            if (e.Data.GetDataPresent("OmaData"))
            {
                int luku = (int)e.Data.GetData("OmaData");
                MessageBox.Show(luku.ToString());
                

            }
            if (e.Data.GetDataPresent("Label"))
            {
                Label apu = (Label)e.Data.GetData("Label");
                MessageBox.Show(apu.Content.ToString());

            }
            e.Handled = true;
        }
    }
}
