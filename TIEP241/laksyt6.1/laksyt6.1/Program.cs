using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laksyt6._1
{
    /// <summary>
    /// anna ohjelmalle argumentteina a ja b kirjaimista koostuvia sanoja ja ohjelma kertoo,
    /// onko kussakin yhtenäisessä välilyönnillä erottamattomassa merkkijonossa merkkijono "babaa"
    /// </summary>
    class Program
    {
        private static Tila automaatti;
        private static List<char> syote = new List<char>();

        public static void Main(string[] args)
        {

#if DEBUG
            args = new[] { "ababaa" };
#endif
            //luodaan oikeanlainen automaatti.
            LuoAutomaatti();

            //puretaan komentoriviltä saadut syötteet.
            for (int i = 0; i < args.Length; i++)
            {
                char[] argsX = args[i].ToCharArray();
                for (int ii = 0; ii < argsX.Length; ii++)
                {
                    syote.Add(argsX[ii]);
                }

                //Kirjoitetaan konsoliin automaatin tulos.
                Console.WriteLine(automaatti.GiveParameters(syote));

                //puhdistetaan Lista mahdollista seuraavaa komentorivi argumenttia varten.
                syote.Clear();
            }
        }

        /// <summary>
        /// luodaan halutunmallinen automaatti.
        /// </summary>
        private static void LuoAutomaatti()
        {
            Tila q4 = new Tila("q4");
            Tila q3 = new Tila("q3");
            q3.SetA(q4);
            Tila q2 = new Tila("q2");
            q2.SetA(q3);
            q3.SetB(q2);
            Tila q1 = new Tila("q1");
            q1.SetB(q2);
            Tila q0 = new Tila("q0");
            q0.SetA(q1);
            Tila q5 = new Tila("q5");
            q5.SetB(q0);
            q1.SetA(q5);
            q2.SetB(q0);
            q3.SetB(q2);
            q4.Loppu();

            //asetetaan alkutila
            automaatti = q5;
        }
    }
    //--------------------------------------------------------------------------------------------------------------------------------------------
    /// <summary>
    /// Olio joka tallentaa kaiken yksittäiseen tilaan liittyvän datan.
    /// </summary>
    class Tila
    {

        // jos lisäät tiloja muista päivittää switch case osa.
        private Tila a;
        private Tila b;
        // jos lisäät tiloja muista päivittää switch case osa.

        public string name { get; }
        private bool loppu = false;


        /// <summary>
        /// yksittäinen tila joka tietää mihin siirrytään syötteella a tai b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public Tila(string name,Tila a, Tila b)
        {
            this.name = name;
            this.a = a;
            this.b = b;
        }

        /// <summary>
        /// Constructoi tila olion jolla molemmat viitteet osoittaa itseensä.
        /// </summary>
        public Tila(string name)
        {
            this.name = name;
            a = this;
            b = this;
        }

        /// <summary>
        /// Tällä merkataan olio hyvöksyttäväksi lopputilaksi
        /// </summary>
        public void Loppu()
        {
            this.loppu = true;
        }

        /// <summary>
        /// Asettaa alapuolella olevan Tilan "A"
        /// </summary>
        /// <param name="a"></param>
        public void SetA(Tila a)
        {
            this.a = a;
        }

        /// <summary>
        /// Asettaa alapuolella olevan tilan "B"
        /// </summary>
        /// <param name="b"></param>
        public void SetB(Tila b)
        {
            this.b = b;
        }

        /// <summary>
        /// käsitellää annettu syöte rekursiivisesti ja haetaan viesti viimeiseltä tilalta johon päädytään.
        /// </summary>
        /// <param name="parameters">syöte</param>
        /// <returns>hyväksyttiinkö syöte</returns>
        public string GiveParameters(List<char> parameters)
        {
            if (parameters.Count > 0)
            {
                char parameter = parameters.First();
                parameters.Remove(parameters.First());

                switch (parameter)
                {
                    case 'a':
                        {
                            return a.GiveParameters(parameters);
                        }
                    case 'b':
                        {
                            return b.GiveParameters(parameters);
                        }
                }
            }
            else
            {
                if (loppu)
                {
                    return "Hyväksytty";
                }
                return "Kelvoton";
            }
            return "Virhe: merkkisyötteessä merkkejä jotka rikkovat automaatin";
        }
    }
}

