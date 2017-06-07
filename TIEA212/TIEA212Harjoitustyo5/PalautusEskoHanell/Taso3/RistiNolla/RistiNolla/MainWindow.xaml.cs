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

namespace RistiNolla
{
    public partial class MainWindow : Window
    {
        private List<Henkilo> henkilot;

        public List<Henkilo> Henkilot
        {
            get { return henkilot; }
            set { henkilot = value; }
        }

        public MainWindow()
        {
            henkilot = new List<Henkilo>();
            for (int i = 0; i < 32; i++)
            {
                henkilot.Add(new Henkilo());
            }

            InitializeComponent();

        }

        private void Label_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }

    public class Henkilo
    {
        private string etunimi;
        private string sukunimi;
        private int ika = 11;
        private string kansallisuus;
        private static Random r = new Random(2016);
        public Henkilo()
        {
            string[] etunimet = { "John", "Jane", "Jack", "Jill", "Jules", "Jake", "Julian", "Jonathan", "Julia", "Judith" };
            string[] sukunimet = { "Doe", "Smith", "Jones", "Taylor", "Brown", "Wilson", "Davis", "Johnson", "Robinson" };
            string[] kansat = { "USA", "Kanada", "Australia" };
            Ika = r.Next(1, 110);
            Kansallisuus = kansat[r.Next(0, kansat.Length)];
            Etunimi = etunimet[r.Next(0, etunimet.Length)];
            Sukunimi = sukunimet[r.Next(0, sukunimet.Length)];
        }

        public string Kansallisuus
        {
            get { return kansallisuus; }
            set { kansallisuus = value; }
        }

        public string Etunimi
        {
            get { return etunimi; }
            set { etunimi = value; }
        }

        public string Sukunimi
        {
            get { return sukunimi; }
            set { sukunimi = value; }
        }

        public int Ika
        {
            get { return ika; }
            set { if (value > 0 && value <= 110) ika = value; }
        }



    }

    [ValueConversion(typeof(string), typeof(SolidColorBrush))]
    public class CountryColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string arvo = (string)value;
            Color keltainen = Color.FromRgb(255, 255, 0);
            Color VSininen = Color.FromRgb(100, 100, 255);
            Color TSininen = Color.FromRgb(0, 0, 255);
            Color Oranssi = Color.FromRgb(255, 100, 100);
            Color Musta = Color.FromRgb(0, 0, 0);
            SolidColorBrush pikachu = new SolidColorBrush(keltainen);
            SolidColorBrush squirtle = new SolidColorBrush(VSininen);
            SolidColorBrush blastoise = new SolidColorBrush(TSininen);
            SolidColorBrush charizard = new SolidColorBrush(Oranssi);
            SolidColorBrush mewtoo = new SolidColorBrush(Oranssi);
            if (arvo.Equals("USA")) return pikachu;
            if (arvo.Equals("Kanada")) return squirtle;
            if (arvo.Equals("Englanti")) return blastoise;
            if (arvo.Equals("Australia")) return charizard;
            return mewtoo;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            Color arvo = (Color)value;
            if (arvo.Equals(Color.FromRgb(255, 255, 0))) return "USA";
            if (arvo.Equals(Color.FromRgb(100, 100, 255))) return "Kanada";
            if (arvo.Equals(Color.FromRgb(0, 0, 255))) return "Englanti";
            if (arvo.Equals(Color.FromRgb(255, 100, 100))) return "Australia";
            return "Yarr Harr Pirates";
        }
    }


    [ValueConversion(typeof(string), typeof(SolidColorBrush))]
    public class IkaColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color vari = Color.FromRgb(000, 000, 000);
            int ika = 0;
            try
            {
                ika = (int)value;
            }
            catch (Exception) { }

            if (0 < ika && ika < 20) vari = Color.FromRgb(255, 000, 000);
            if (20 <= ika && ika < 60) vari = Color.FromRgb(000, 255, 000);
            if (60 <= ika && ika < 122) vari = Color.FromRgb(000, 000, 255);

            return  new SolidColorBrush(vari);
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            //TODO
            return null;
        }
    }

    public class RuutuLogiikkaKonvertti : IMultiValueConverter
    {
        private object[] values;
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            this.values = values;
            bool voittajaLoydetty = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (!(bool)values[i]) continue;
                if (isTru(i, "N") && isTru(i, "S")) voittajaLoydetty = true;
                if (isTru(i, "NW") && isTru(i, "SE")) voittajaLoydetty = true;
                if (isTru(i, "NE") && isTru(i, "SW")) voittajaLoydetty = true;
                if (isTru(i, "E") && isTru(i, "W")) voittajaLoydetty = true;
            }
            if (voittajaLoydetty) return "Valmis rivi!";
            return "Peli kesken";
        }

        /// <summary>
        /// Kertoo onko pisteeseen ilmansuunassa oleva piste tosi tai epätosi. Palauttaa epätosi jos pistettä ei ole olemassa.
        /// </summary>
        /// <param name="paikka">Indeksi josta katsotaan.</param>
        /// <param name="ilmansuunta">Mihin suuntaan katsotaan.</param>
        /// <returns>true jos tosi, false jos muuta</returns>
        private bool isTru(int paikka, string ilmansuunta)
        {
            int kohta = -1;
            switch (ilmansuunta)
            {
                case "N":
                    kohta = paikka - 5;
                    break;
                case "NE":
                    kohta = paikka - 4;
                    break;
                case "E":
                    kohta = paikka + 1;
                    break;
                case "SE":
                    kohta = paikka + 6;
                    break;
                case "S":
                    kohta = paikka + 5;
                    break;
                case "SW":
                    kohta = paikka + 4;
                    break;
                case "W":
                    kohta = paikka - 1;
                    break;
                case "NW":
                    kohta = paikka - 6;
                    break;
                default:
                    break;
            }
            if (!(kohta >= 0 && kohta <= 30)) return false;
            try
            {
                return (bool)values[kohta];
            }
            catch (Exception)
            {
                Console.Error.WriteLine("Huono value tai kohta saatu kun yritettiin ratkaista ristinollaa");
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            //Impassabrew
            throw new NotImplementedException();
        }
    }

    public class SliderToColorConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            byte r = 0, g = 0, b = 0;
            try
            {
                r = System.Convert.ToByte((Double)values[0]);
                g = System.Convert.ToByte((Double)values[1]);
                b = System.Convert.ToByte((Double)values[2]);
            }
            catch (Exception) { }
            return Color.FromRgb(r, g, b);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            //eitarvita toivottavasti.
            throw new NotImplementedException();
        }
    }
}

