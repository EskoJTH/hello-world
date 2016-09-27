using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laksyt4._4
{
    class Program
    {
        private static Tila alku;
        private static List<char> syote = new List<char>();

        public static void Main(string[] args)
        {
            #if DEBUG
            args = new[] { "abba" };
#endif

            Console.WriteLine(args[0]);

            LuoAutomaatti();
            for (int i = 0; i < args.Length; i++)
            {
                char[] argsX = args[i].ToCharArray();
                for (int ii = 0; ii < argsX.Length; ii++)
                {
                    syote.Add(argsX[ii]);
                }
                Console.WriteLine(alku.GiveParameters(syote));
                syote.Clear();
            }
        }

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
            alku = q5;
        }
    }
    class Tila
    {
        private Tila a;
        private Tila b;
        // jos lisäät tiloja muista päivittää switch case osa.
        //private char siirtymaA = 'a';
        //private char siirtymaB = 'b';
        private bool loppu = false;
        private string nimi;

        public Tila(Tila a, Tila b)
        {
            this.a = a;
            this.b = b;
        }
        public Tila(String nimi)
        {
            this.nimi = nimi;
            a = this;
            b = this;
        }

        public void Loppu()
        {
            this.loppu = true;
        }

        public void SetA(Tila a)
        {
            this.a = a;
        }

        public void SetB(Tila b)
        {
            this.b = b;
        }

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
                            return a.GiveParameters(parameters);
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
