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

namespace KirjainClickeri
{
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
    }

    [ValueConversion(typeof(string), typeof(SolidColorBrush))]
    public class CountryColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string arvo = (string)value;
            Color keltainen = Color.FromRgb(255, 255, 0);
            Color VSininen = Color.FromRgb(100,100, 255);
            Color TSininen = Color.FromRgb(0, 0, 255);
            Color Oranssi = Color.FromRgb(255, 100, 100);
            SolidColorBrush pikachu = new SolidColorBrush(keltainen);
            SolidColorBrush squirtle = new SolidColorBrush(VSininen);
            SolidColorBrush blastoise = new SolidColorBrush(TSininen);
            SolidColorBrush charizard = new SolidColorBrush(Oranssi);
            if (arvo.Equals("USA")) return pikachu;
            if (arvo.Equals("Kanada")) return squirtle;
            if (arvo.Equals("Englanti")) return blastoise;
            if (arvo.Equals("Australia")) return charizard;
            return Color.FromRgb(0, 255, 0);
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
}
