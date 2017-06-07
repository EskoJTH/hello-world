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
        private int summa;
        private int siirtojaYht;
        private Random random;
        //private double X;
        //private double Y;

 /*       public static readonly RoutedEvent DragEvent = EventManager.RegisterRoutedEvent(
"Moving", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(LabelThatHasDragEvent));

        // Provide CLR accessors for the event
        public event RoutedEventHandler Moving
        {
            add { AddHandler(DragEvent, value); }
            remove { RemoveHandler(DragEvent, value); }
        }

        public void RaiseDragEvent(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs EventArgs = new RoutedEventArgs(DragEvent);
            EventArgs.Source = sender;
            RaiseEvent(EventArgs);
        }*/

        public MainWindow()
        {
            InitializeComponent();
            random = new Random();
        }

        /// <summary>
        /// When drag and drop is started on the label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                LabelThatHasDragEvent label = (LabelThatHasDragEvent)sender;
                try
                {
                    DataObject data = new DataObject();

                    Canvas panel = (Canvas)label.Parent;
                    label.Margin = new Thickness(0,0,0,0);
                    data.SetData("LabelThatHasDragEvent", sender);
                    panel.Children.Remove(label);
                    DragDrop.DoDragDrop(label, data, DragDropEffects.Copy | DragDropEffects.Move);
                } catch (Exception) { }
                 try
                {
                    DataObject data = new DataObject();

                    DockPanel panel = (DockPanel)label.Parent;
                    label.Margin = new Thickness(0, 0, 0, 0);
                    data.SetData("LabelThatHasDragEvent", sender);
                    panel.Children.Remove(label);
                    DragDrop.DoDragDrop(label, data, DragDropEffects.Copy | DragDropEffects.Move);
                } catch (Exception) { }
                label.RaiseDragEvent();
            }
        }

        /// <summary>
        /// When data is dropped to the DockPanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calcutable_Drop(object sender, DragEventArgs e)
        {
            //base.OnDrop(e);

            // Löytyykö oma data
            if (e.Data.GetDataPresent("LabelThatHasDragEvent"))
            {
                LabelThatHasDragEvent label = (LabelThatHasDragEvent)e.Data.GetData("LabelThatHasDragEvent");
                DockPanel panel = (DockPanel)sender;
                panel.Children.Add(label);
                panel.Background = Brushes.White;
            }
            //e.Handled = true;
        }

        /// <summary>
        /// Restarts or starts she game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reset(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            int numbers = random.Next(2, 5);
            summa = 0;
            siirtojaYht = 0;
            bool[] miinusta = new bool[numbers - 1];

            for (int i = 0; i < numbers - 1; i++)
            {
                string merkki = "+";
                if (random.Next(0, 2) == 0)
                {
                    miinusta[i] = true;
                    merkki = "-";
                }
                LabelThatHasDragEvent label = new LabelThatHasDragEvent();
                label.FontSize = 20;
                label.MouseMove += Label_MouseMove;
                label.Background = Brushes.Black;
                label.Foreground = Brushes.Yellow;
                label.Content = merkki;
                canvas.Children.Add(label);
                label.Margin = new Thickness(random.Next(0, (int)canvas.ActualWidth), random.Next(0, (int)canvas.ActualHeight), 0, 0);
            }

            for (int i = 0; i < numbers; i++)
            {
                int value = random.Next(0, 20);
                LabelThatHasDragEvent label = new LabelThatHasDragEvent();
                label.FontSize = 20;
                label.MouseMove += Label_MouseMove;
                label.Background = Brushes.Black;
                label.Foreground = Brushes.Yellow;
                label.Content = "" + value;
                canvas.Children.Add(label);
                label.Margin = new Thickness(random.Next(0, (int)canvas.ActualWidth), random.Next(0, (int)canvas.ActualHeight), 0, 0);
                if (i > 0 && miinusta[i - 1] == true) value = -value;
                summa += value;
            }
            tulos.Content = summa + " Yhteensä";
        }

        private void Drop_Back(Object sender, DragEventArgs e)
        {
            //base.OnDrop(e);

            // Löytyykö oma data
            if (e.Data.GetDataPresent("LabelThatHasDragEvent"))
            {
                LabelThatHasDragEvent label = (LabelThatHasDragEvent)e.Data.GetData("LabelThatHasDragEvent");
                Canvas panel = (Canvas)sender;
                panel.Children.Add(label);
                Mouse.Capture(canvas);//jost tämän poistaa niin kaikki hajoo
                label.Margin = new Thickness(Mouse.GetPosition(canvas).X, Mouse.GetPosition(canvas).Y, 0, 0);
                Mouse.Capture(null);
            }
            //e.Handled = true;
        }

        private void undo(object sender, RoutedEventArgs e)
        {

        }



        private void LaskeSiirrot(object sender, RoutedEventArgs e)
        {
            siirtojaYht++;
            siirrot.Content=siirtojaYht + " Siirtoa";
            e.Handled = true;
        }

        /*    private void MouseDown_Event(object sender, MouseButtonEventArgs e)
            {
                var point = e.GetPosition(canvas);
                X = point.X;
                Y = point.Y;
            }*/
    }
}
