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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class LabelThatHasDragEvent : Label
    {
        public LabelThatHasDragEvent()
        {
            InitializeComponent();
        }

        public static readonly RoutedEvent DragEvent = EventManager.RegisterRoutedEvent(
"Moving", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Label));

        // Provide CLR accessors for the event
        public event RoutedEventHandler Moving
        {
            add { AddHandler(DragEvent, value); }
            remove { RemoveHandler(DragEvent, value); }
        }

        public void RaiseDragEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(null);
            RaiseEvent(newEventArgs);
        }
    }
}
