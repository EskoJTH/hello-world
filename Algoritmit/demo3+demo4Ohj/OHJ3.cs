using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursiota
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("" + laskeX(new int[] { 1, 2, 3 }, 3));
            Console.WriteLine("" + MylaskeX(new int[] { 1, 2, 3 }, 3));
            Console.WriteLine("" + laskeY(new int[] { 1, 2, 3 }, 3));
            Console.WriteLine("" + MyLaskeY(new int[] { 1, 2, 3 }, 3));
            Console.WriteLine("" + laskeY(new int[] { 2, 2, 2 }, 3));
            Console.WriteLine("" + MyLaskeY(new int[] { 2, 2, 2}, 3));
            Console.WriteLine("" + laskeY(new int[] { 10, 3, 2 }, 3));
            Console.WriteLine("" + MyLaskeY(new int[] { 10, 3, 2 }, 3));
            Console.WriteLine("" + 15/3);
            Console.ReadKey();
        }


        /// <summary>
        /// kertoo keskenään kaikkin t:n alkiot.
        /// 
        /// Suoritusajan kertaluokka on n
        /// </summary>
        /// <param name="t"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int laskeX(int[] t, int n)
        {
            if (n == 1)
                return t[0];
            else
                return (laskeX(t, n - 1) * t[n - 1]);
        }

        private static int MylaskeX(int[] t, int n)
        {
            int tulos = t[0];
            for (int i = 1; i < n; i++)
            {
                tulos *= t[i];
            }
            return tulos;
        }

        /// <summary>
        ///  laske (x:xs) 1 = x
        ///  laske (x:xs) n = (laske xs (n-1) * (n-1) + x) `div` n
        /// Tämähän yrittää laskea Keskiarvoa. Pseudokoodissa ei ollut määritelty 
        /// jakolaskun toimintaa kokonaisluvuilla. Oletan sitten että se toimii kuten haskelin div tai c# (/).
        /// Ei tule keskiarvoa tästä. Meni kauan aikaa yrittää keksiä mikä järki tässä vempeleessä on.
        /// 
        /// Suoritusajan kertaluokka on n
        /// </summary>
        /// <param name="t"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int laskeY(int[] t, int n)
        {
            if (n == 1)
                return t[0];
            else
                return ((laskeY(t, n - 1) * (n - 1)
                + t[n - 1]) / n);
        }        private static int MyLaskeY(int[] t, int n)
        {
            int tulos = t[0];
            for (int i = 1; i < n; i++)
            {
                tulos = (tulos*i+t[i])/(i+1);
            }
            return tulos;
        }
    }
    
}
