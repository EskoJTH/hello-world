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
    /// Oma canvas-luokka, joka lisää pari propertya avuksi. HalfWidth ja HalfHeight antavat puolitetun todellisen leveyden ja korkeuden ja näihin voi bindata xamlista
    /// </summary>
    public class OmaCanvas : Canvas
    {
        public OmaCanvas()
        {
            HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            SizeChanged += OwnCanvas_SizeChanged;
        }

        void OwnCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            HalfWidth = ActualWidth / 2;
            HalfHeight = ActualHeight / 2;
        }


        public double HalfWidth
        {
            get { return (double)GetValue(HalfWidthProperty); }
            set { SetValue(HalfWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HalfWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HalfWidthProperty =
            DependencyProperty.Register("HalfWidth", typeof(double), typeof(OmaCanvas), new PropertyMetadata(0.0));


        public double HalfHeight
        {
            get { return (double)GetValue(HalfHeightProperty); }
            set { SetValue(HalfHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HalfHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HalfHeightProperty =
            DependencyProperty.Register("HalfHeight", typeof(double), typeof(OmaCanvas), new PropertyMetadata(0.0));



    }
}
