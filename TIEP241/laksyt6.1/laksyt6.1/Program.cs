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
        private new Siirtymat<char, Tila> siirtymat;
        // jos lisäät tiloja muista päivittää switch case osa.

        public string name { get; }
        private bool loppu = false;


        /// <summary>
        /// Luodaan tila ja annetaan sille valmiiksi siirtymiä.
        /// </summary>
        /// <param name="name">Tilan nimi</param>
        /// <param name="siirtymayt">Siirtymät</param>
        public Tila(string name, Dictionary<char, Tila> siirtymat)
        {
            this.siirtymat.AddDic(siirtymat);
            this.name = name;
        }

        /// <summary>
        /// Luodaan tila ja annetaan sille valmiiksi siirtymiä.
        /// </summary>
        /// <param name="name">Tilan nimi</param>
        /// <param name="siirtymayt">Siirtymät</param>
        public Tila(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// tekee hyvin tyhjän tilan.
        /// </summary>
        public Tila()
        {
        }

        /// <summary>
        /// Tällä merkataan olio hyvöksyttäväksi lopputilaksi
        /// </summary>
        public void Loppu()
        {
            this.loppu = true;
        }

        /// <summary>
        /// luodaan uusi siirtymä, jollakin syotteellä a tilaan A
        /// </summary>
        /// <param name="a">a</param>
        /// <param name="A">A</param>
        public void newSiiryma(char a, Tila A)
        {
            this.siirtymat.Add(a, A);
        }

        /// <summary>
        /// käsitellää annettu syöte rekursiivisesti ja haetaan viesti viimeiseltä tilalta johon päädytään.
        /// hyppää kelpaamattoman syötteen yli.
        /// </summary>
        /// <param name="parameters">syöte</param>
        /// <returns>hyväksyttiinkö syöte</returns>
        public string GiveParameters(List<char> parameters)
        {
            if (parameters.Count > 0)
            {
                char parameter = parameters.First();
                parameters.Remove(parameters.First());
                if (!siirtymat.ContainsKey(parameter))
                {
                    Console.Error.WriteLine("Annettiin siirtymä jota ei olle määritelty.");
                    this.GiveParameters(parameters);
                }
                else
                {
                    List<Tila> kohteet = siirtymat[parameter];
                    foreach (Tila kohde in kohteet)
                    {
                        string palaute = kohde.GiveParameters(parameters);
                        if (null == palaute) return null;
                        Console.WriteLine(palaute);
                    }

                }
            }
            else
            {
                if (loppu)
                {
                    Console.WriteLine("Hyväksytty");
                    return null;
                    
                }
                return "Katsotaan taakeseppäin";
            }
                return "Virhe: merkkisyötteessä merkkejä jotka rikkovat automaatin";
            

        }

        /// <summary>
        /// Hauska luokka joka tallentaa yhden key olion ja monta Value oliota toivottavasti. Ja tekee kaiken ehkä vaikeimman kautta.
        /// </summary>
        /// <typeparam name="Tkey">avain Olion tyyppi</typeparam>
        /// <typeparam name="Ttarget">Arvo Olioiden tyyppi</typeparam>
        class Siirtymat<Tkey, Ttarget> : Dictionary<Tkey, List<Ttarget>> where Tkey : new() where Ttarget : new()
        {

            /// <summary>
            /// Luodaan suhteellisen tyhjä Siirtymäläjän.
            /// </summary>
            public Siirtymat()
            {

            }

            /// <summary>
            /// Lisää avaimelle a Arvon A
            /// </summary>
            /// <param name="a">avain</param>
            /// <param name="A">arvo joka lisätään</param>
            public void Lisaa(Tkey a, Ttarget A)
            {
                List<Ttarget> lista = new List<Ttarget>();
                bool tuliko = this.TryGetValue(a, out lista);
                if (tuliko)
                {
                    lista.Add(A);
                    this[a] = lista;
                }
                else this.Add(a, lista);
            }

            /// <summary>
            /// Lisää avaimelle a Listan arvoja A
            /// </summary>
            /// <param name="a">avain</param>
            /// <param name="A">arvo joka lisätään</param>
            public void Lisaa(Tkey a, List<Ttarget> A)
            {
                List<Ttarget> lista = new List<Ttarget>();
                bool tuliko = this.TryGetValue(a, out lista);
                if (tuliko)
                {
                    lista.AddRange(A);
                    this[a] = lista;
                }
                else this.Add(a, lista);
            }

            /// <summary>
            /// Palauttaa listan jossa kaikki arvot tietylle avaimelle.
            /// </summary>
            /// <param name="a">avain jolla etsitään</param>
            /// <returns>lista jossa haetut arvot</returns>
            public List<Ttarget> Lue(Tkey a)
            {
                List<Ttarget> lista = new List<Ttarget>();
                bool tuliko = this.TryGetValue(a, out lista);
                if (!tuliko) lista = new List<Ttarget>();
                return lista;
            }

            /// <summary>
            /// lisää Siirtymät tietueeseen dictionaryn.
            /// </summary>
            /// <param name="dic">dictionary joka lisätään</param>
            public void AddDic(Dictionary<Tkey, Ttarget> dic)
            {
                foreach (KeyValuePair<Tkey, Ttarget> a in dic)
                {
                    this.Lisaa(a.Key, a.Value);
                }
            }

            /// <summary>
            /// Lisää kokonaisen siirtymä tietueen tähän.
            /// </summary>
            /// <param name="siir">Siirtymät joka lisätään.</param>
            public void AddSiirtymat(Siirtymat<Tkey, Ttarget> siir)
            {
                foreach (KeyValuePair<Tkey, List<Ttarget>> a in siir)
                {
                    this.Lisaa(a.Key, a.Value);
                }
            }
        }
    }

