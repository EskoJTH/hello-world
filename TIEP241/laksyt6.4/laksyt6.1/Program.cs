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

        public static event EventHandler printAll;

        public static void Main(string[] args)
        {

#if DEBUG
            args = new[] { "aabaa", "babaa" };
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
                Console.WriteLine("..........................................................................................................");
                Console.WriteLine("..........................................................................................................");
                Console.WriteLine("..........................................................................................................");
                Console.WriteLine("..........................................................................................................");
                Console.WriteLine("..........................................................................................................");
                Console.WriteLine("..........................................................................................................");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// luodaan halutunmallinen automaatti.
        /// </summary>
        private static void LuoAutomaatti()
        {
            /*
            a4: < b->a4 > < a->a4 >
            a1: < b->a2 >
            a2: < a->a3 >
            a3: < b->a4 >
            a0: < b->a0 > < a->a1 a0 >
            -----
            a1: < a->a2 >
            a0: < b->a1 a0 > < a->a0 >
            a4: < a->a5 >
            a2: < b->a3 >
            a3: < a->a4 >
            a5: < b->a5 > < a->a5 >
            */

            Tila a0 = new Tila("a0");
            Tila a1 = new Tila("a1");
            Tila a2 = new Tila("a2");
            Tila a3 = new Tila("a3");
            Tila a4 = new Tila("a4");
            Tila a5 = new Tila("a5");

            a0.newSiiryma('b', a0);
            a0.newSiiryma('a', a0);
            a0.newSiiryma('a', a1);
            a1.newSiiryma('b', a2);
            a2.newSiiryma('b', a3);
            a3.newSiiryma('b', a4);
            a4.newSiiryma('b', a4);
            a4.newSiiryma('a', a4);

            Tila b0 = new Tila("a0");
            Tila b1 = new Tila("a1");
            Tila b2 = new Tila("a2");
            Tila b3 = new Tila("a3");
            Tila b4 = new Tila("a4");
            Tila b5 = new Tila("a5");

            b1.newSiiryma('a', a2);
            b0.newSiiryma('b', a1);
            b0.newSiiryma('b', a0);
            b0.newSiiryma('a', a0);
            b4.newSiiryma('a', a5);
            b2.newSiiryma('b', a3);
            b3.newSiiryma('a', a4);
            b5.newSiiryma('b', a5);
            b5.newSiiryma('a', a5); //aabaa

            a5.Loppu();
            automaatti = a0;

            printAll?.Invoke(null, EventArgs.Empty);

        }
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------

    /// <summary>
    /// Olio joka tallentaa kaiken yksittäiseen tilaan liittyvän datan.
    /// </summary>
    class Tila
    {

        // jos lisäät tiloja muista päivittää switch case osa.
        private Siirtymat<char, Tila> siirtymat = new Siirtymat<char, Tila>();
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
            Program.printAll += new EventHandler(printConnections);
            this.siirtymat.AddDic(siirtymat);
            this.name = name;
        }

        /// <summary>
        /// Luodaan tila ja annetaan sille valmiiksi siirtymiä.
        /// </summary>
        /// <param name="name">Tilan nimi</param>
        /// <param name="siirtymayt">Siirtymät</param>
        public Tila(string name, char a, Tila A)
        {
            Program.printAll += new EventHandler(printConnections);
            this.siirtymat.Lisaa(a, A);
            this.name = name;
        }

        /// <summary>
        /// Luodaan tila ja annetaan sille valmiiksi siirtymiä.
        /// </summary>
        /// <param name="name">Tilan nimi</param>
        /// <param name="siirtymayt">Siirtymät</param>
        public Tila(string name)
        {
            Program.printAll += new EventHandler(printConnections);
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
            this.siirtymat.Lisaa(a, A);
        }

        /// <summary>
        /// käsitellää annettu syöte rekursiivisesti ja haetaan viesti viimeiseltä tilalta johon päädytään.
        /// hyppää kelpaamattoman syötteen yli.
        /// </summary>
        /// <param name="parameters">syöte</param>
        /// <returns>hyväksyttiinkö syöte</returns>
        public string GiveParameters(List<char> syote)
        {
            List<char> parameters = new List<char>(syote);
            if (parameters.Count > 0)
            {
                char parameter = parameters.First();
                parameters.Remove(parameters.First());

                // jos ei sopiva parametri
                if (!siirtymat.ContainsKey(parameter))
                {
                    Console.Error.WriteLine("Annettiin siirtymä jota ei ole määritelty.");

                    //käsitellään palaute
                    string palaute = this.GiveParameters(parameters);
                    if (null == palaute) return null;
                } //sopiva
                else
                {
                    //kunnollinen parametri löytyi
                    List<Tila> kohteet = siirtymat[parameter]; //voi olla monta
                    foreach (Tila kohde in kohteet)
                    {
                        Console.WriteLine("inspecting: " + parameter);
                        Console.WriteLine(this.name + " -> " + kohde.name);
                        //käsitellään palaute
                        string palaute = kohde.GiveParameters(parameters);
                        if (null == palaute) return null;
                        Console.WriteLine(palaute);
                    }
                    return "Tyhjä kerros mennään taakseppäin";
                }
            }
            else
            {
                if (loppu)
                {
                    Console.WriteLine("Hyväksytty");
                    return null;
                }
                Console.WriteLine("ei loppu");
                return "kokeillaan seuraavaa";
            }
            return "tämä ei saa lukea missään";
        }

        /// <summary>
        /// tulostaa kaikki tämän olion yhteydet.
        /// </summary>
        public void printConnections(Object o, EventArgs e)
        {
            List<Tila> lista = new List<Tila>();
            foreach (char a in siirtymat.Keys)
            {
                foreach (Tila t in siirtymat[a])
                {
                    Console.WriteLine(this.name + ": " + a + " -> " + t.name);
                }
            }
        }
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
            if (lista == null) lista = new List<Ttarget>();
            lista.Add(A);
            this[a] = lista;
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
        public void  AddSiirtymat(Siirtymat<Tkey, Ttarget> siir)
        {
            foreach (KeyValuePair<Tkey, List<Ttarget>> a in siir)
            {
                this.Lisaa(a.Key, a.Value);
            }
        }
    }
}


