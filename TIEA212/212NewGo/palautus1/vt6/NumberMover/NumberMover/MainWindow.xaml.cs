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

namespace NumberMover
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int TheNumber { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void UpdateTheNumber()
        {
            int number = 0;
            foreach(Label child in DropPanel.Children)
            {
                number += Int32.Parse(child.Content.ToString());
            }

            TheNumber = number;
            NumberLabel.Content = TheNumber;
        }

        public void AddNumbers(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("AddToTheNumber"))
            {
                Label label = (Label)e.Data.GetData("AddToTheNumber");
                StackPanel panel = (StackPanel)label.Parent;
                panel.Children.Remove(label);
                DropPanel.Children.Add(label); 
                UpdateTheNumber();
            }
        }

        public void DragLabel(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Label label = (Label)sender;
                DataObject data = new DataObject("AddToTheNumber", label);
                DragDrop.DoDragDrop(label, data, DragDropEffects.Move);
            }
        }
    }
}
