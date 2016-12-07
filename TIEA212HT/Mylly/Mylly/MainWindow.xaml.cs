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

        private void ReSize(object sender, SizeChangedEventArgs e)
        {
            DrawingBrush Viivat = new DrawingBrush();

           // Luodaan taustalle neliöt
            //uloin neliö
            GeometryDrawing backgroundSquareStrokes0 = UusiNelio(7,7,6.0/7.0,6.0/7.0);

            //toiseksi uloin neliö
            GeometryDrawing backgroundSquareStrokes1 = UusiNelio(7, 7, 6.0 / 7.0, 6.0 / 7.0);

            //sisin uloin neliö
            GeometryDrawing backgroundSquareStrokes2 = UusiNelio(7, 7, 6.0 / 7.0, 6.0 / 7.0);

            //Ensimmäinen sisäviiva
            GeometryDrawing backgroundStroke0 = UusiNelio(7, 7, 6.0 / 7.0, 6.0 / 7.0);

            //Toinen sisäviiva
            GeometryDrawing backgroundStroke1 = UusiNelio(7, 7, 6.0 / 7.0, 6.0 / 7.0);

            // Kolmas sisäviiva
            GeometryDrawing backgroundStroke2 = UusiNelio(7, 7, 6.0 / 7.0, 6.0 / 7.0);

            //neljäs sisäviiva
            GeometryDrawing backgroundStroke3 = UusiNelio(7, 7, 6.0 / 7.0, 6.0 / 7.0);

            GeometryDrawing tausta = new GeometryDrawing(

Brushes.Brown,
null,
new RectangleGeometry(new Rect(grid.Width, grid.Height, grid.Width, grid.Height)));
            DrawingGroup yhdessa = new DrawingGroup();
            yhdessa.Children.Add(tausta);
            yhdessa.Children.Add(backgroundSquareStrokes0);
            yhdessa.Children.Add(backgroundSquareStrokes1);
            yhdessa.Children.Add(backgroundSquareStrokes2);
            yhdessa.Children.Add(backgroundStroke0);
            yhdessa.Children.Add(backgroundStroke1);
            yhdessa.Children.Add(backgroundStroke2);
            yhdessa.Children.Add(backgroundStroke3);
            Viivat.Drawing = yhdessa;
            grid.Background = Viivat;
        }

/// <summary>
/// Piirtää neliön ruudun suhteiden perusteella
/// </summary>
/// <param name="x0">neliön alkupisteen suhde koko sivun pituuteen</param>
/// <param name="y0"></param>
/// <param name="x1"></param>
/// <param name="y1"></param>
/// <returns></returns>
        private GeometryDrawing UusiNelio(double x0, double y0, double x1, double y1)
        {

            return new GeometryDrawing(
null,
new Pen(Brushes.Black, 10),
new RectangleGeometry(new Rect(grid.ActualWidth/x0, grid.ActualHeight/y0, grid.ActualWidth / x1, grid.ActualHeight / y1)));

        }







        /*
I have an idea you could try: Within a Grid, items will overlap each other.
So you could create an outer Grid which contains your grid and also a Canvas with a transparent background.
On the Canvas, you could draw lines which would look like they are connecting your Grid's elements
https://msdn.microsoft.com/en-us/magazine/ff646962.aspx
         */
        //TODO
        /*
        private void onLayoutUpdated(object sender, EventArgs e)
        {
            //Size size = RenderSize;
            //Point ofs = new Point(size.Width / 2, isInput ? 0 : size.Height);
            //AnchorPoint = TransformToVisual(node.canvas).Transform(ofs);
        }

        private void Resize(object sender, SizeChangedEventArgs e)
        {

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
        */
    }
}

