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

namespace MyllyActual
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Insert = new RoutedUICommand("Insert", "Insert", typeof(CustomCommands));
        public static readonly RoutedUICommand Manual = new RoutedUICommand("Manual", "Manual", typeof(CustomCommands));
        public static readonly RoutedUICommand About = new RoutedUICommand("About", "About", typeof(CustomCommands));
        public static readonly RoutedUICommand Remove = new RoutedUICommand("Remove", "Remove", typeof(CustomCommands));
        public static readonly RoutedUICommand Move = new RoutedUICommand("Move", "Move", typeof(CustomCommands));
        public static readonly RoutedUICommand Settings = new RoutedUICommand("Settings", "Settings", typeof(CustomCommands));
    }

}
