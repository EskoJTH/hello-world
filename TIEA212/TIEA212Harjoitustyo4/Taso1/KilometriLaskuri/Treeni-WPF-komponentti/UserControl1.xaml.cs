using System;
using System.Collections.Generic;
using System.Globalization;
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

/// <summary>
/// @author Esko Hanell
/// @version 30.10.2016
/// </summary>
namespace Treeni_WPF_komponentti
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }



        public int Km
        {
            get { return (int)GetValue(KmProperty); }
            set { SetValue(KmProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Km.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KmProperty =
            DependencyProperty.Register("Km", typeof(int), typeof(UserControl1), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsRender));


        public int Aika
        {
            get { return (int)GetValue(AikaProperty); }
            set { SetValue(AikaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Aika.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AikaProperty =
            DependencyProperty.Register("Aika", typeof(int), typeof(UserControl1), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.AffectsRender));



        /// <summary>
        /// Laskee paljonko nopeus on ja asettaa sen Nopeuslabeliin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Laske(object sender, RoutedEventArgs e)
        {
            try
            {
                double nopeus = (double)Km / (double)Aika;
                NopeusLabel.Content = Math.Round(nopeus, 2);
            }
            catch (Exception)
            {
                NopeusLabel.Content = "Annetut luvut eivät kelpaa.";
            }
            
        }
    }

    /// <summary>
    /// tarkastaa onko validaation kutsuja Luonnollinen luku.
    /// </summary>
    public class MyValidationRulez : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int n;
            try
            {
                n=int.Parse((String)value);
                if (n < 0) throw new Exception();
                return new ValidationResult(true, "Everybody happy!");
            } catch(Exception)
            {
                return new ValidationResult(false, "Value not a natural number.");
            }
        }
    }
}
