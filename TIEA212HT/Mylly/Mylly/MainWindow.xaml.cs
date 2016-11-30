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
        public MainWindow()
        {
            InitializeComponent();
        }

        /*
I have an idea you could try: Within a Grid, items will overlap each other.
So you could create an outer Grid which contains your grid and also a Canvas with a transparent background.
On the Canvas, you could draw lines which would look like they are connecting your Grid's elements
https://msdn.microsoft.com/en-us/magazine/ff646962.aspx
         */
        //TODO
        private void onLayoutUpdated(object sender, EventArgs e)
        {
            //Size size = RenderSize;
            //Point ofs = new Point(size.Width / 2, isInput ? 0 : size.Height);
            //AnchorPoint = TransformToVisual(node.canvas).Transform(ofs);
        }
    }

    public sealed class GraphEdge : UserControl
    {
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(Point), typeof(GraphEdge), new FrameworkPropertyMetadata(default(Point)));
        public Point Source { get { return (Point)this.GetValue(SourceProperty); } set { this.SetValue(SourceProperty, value); } }

        public static readonly DependencyProperty DestinationProperty = DependencyProperty.Register("Destination", typeof(Point), typeof(GraphEdge), new FrameworkPropertyMetadata(default(Point)));
        public Point Destination { get { return (Point)this.GetValue(DestinationProperty); } set { this.SetValue(DestinationProperty, value); } }

        public GraphEdge()
        {
            LineSegment segment = new LineSegment(default(Point), true);
            PathFigure figure = new PathFigure(default(Point), new[] { segment }, false);
            PathGeometry geometry = new PathGeometry(new[] { figure });
            BindingBase sourceBinding = new Binding { Source = this, Path = new PropertyPath(SourceProperty) };
            BindingBase destinationBinding = new Binding { Source = this, Path = new PropertyPath(DestinationProperty) };
            BindingOperations.SetBinding(figure, PathFigure.StartPointProperty, sourceBinding);
            BindingOperations.SetBinding(segment, LineSegment.PointProperty, destinationBinding);
            Content = new Path
            {
                Data = geometry,
                StrokeThickness = 5,
                Stroke = Brushes.White,
                MinWidth = 1,
                MinHeight = 1
            };
        }
    }
}

