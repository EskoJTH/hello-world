using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFinds
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Knot> roots = new List<Knot>();
            string[] syote0 = { "kallo", "kalkkuna", "kukka", "kuikka", "kuinka" };
            string[] syote1 = { "karppa", "janis", "pollo", "poolo", "janne" };

            for (int i = 0; i < syote0.Length; i++)
            {
                roots.Add(TeeTrie(syote0[i]));
            }

            for (int i = 0; i < syote0.Length; i++)
            {
                roots.Add(TeeTrie(syote1[i]));
            }

            if (Find(roots[0]) != Find(roots[1]))
            {
                Console.WriteLine("solmut 0 ja 1 eri joukkoa.");
            }

            Union(roots[0], roots[1]);

            if (Find(roots[0]) == Find(roots[1]))
            {
                Console.WriteLine("nyt 0 ja 1 ovat osa samaa joukkoa.");
            }

            if (Find(roots[1]) != Find(roots[2]))
            {
                Console.WriteLine("solmut 1 ja 2 eri joukkoa.");
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Löytää päälimmäisen Knot olion joka yksilöi mihin TRIE puuhun sanan solmu kuuluu.
        /// </summary>
        /// <param name="knot">solmu joka kuuluu? johonkin joukkoon</param>
        /// <returns></returns>
        public static Knot Find(Knot knot)
        {
            if (knot.super != null)
            {
                return Find(knot.super);
            }
            return knot;
        }


        /// <summary>
        /// Yhdistää kaksi Knot olion yllä olevaa TRIE puuta.
        /// </summary>
        /// <param name="knot1"></param>
        /// <param name="knot2"></param>
        /// <returns></returns>
        private static Knot[] Union(Knot knot1, Knot knot2)
        {
            if (knot1.super == null || knot2.super == null)
            {
                if (knot1.ReadValue().Equals(knot2.ReadValue()))
                {
                    return (new Knot[] { knot1 });
                }
                else { return new Knot[] { knot1, knot2 }; }
            }

            Knot left = FindTopData(knot1);
            Knot right = FindTopData(knot2);
            Knot super = left.super;

            if (left.ReadValue().Equals(right.ReadValue()))
            {
                left.super = null;
                right.super = null;
                Union(knot1, knot2);      
            }
            left.super = super;
            right.super = super;
            return new Knot[]{knot1,knot2};

        }

        //Apumetodi.
        private static Knot FindTopData(Knot knot)
        {
            if (knot.super.super != null)
            {
                return FindTopData(knot.super);
            }
            return knot;
        }

        /// <summary>
        /// Asettaa saadut sanat Trie puuhun.
        /// </summary>
        /// <param name="syote"></param>
        /// <returns></returns>
        public static Knot TeeTrie(string syote)
        {
                char[] data = syote.ToCharArray(0, syote.Length);
                Knot previous = new Knot();

                for (int ii = 0; ii < data.Length; ii++)
                {
                    if (previous == null) previous = new Knot(data[ii]);
                    else if (ii + 1 == data.Length)
                    {
                        return new Knot(data[ii], previous);
                    }
                    else previous = new Knot(data[ii], previous);
                }
            return null;
        }
    }


    class Knot
    {
        public char value;
        public Knot super;
        public Knot(char value, Knot super)
        {
            this.value = value;
            this.super = super;
        }

        public Knot(char value)
        {
            value = this.value;
        }

        public Knot()
        {
        }

        public char ReadValue()
        {
            return value;
        }

    }
}
