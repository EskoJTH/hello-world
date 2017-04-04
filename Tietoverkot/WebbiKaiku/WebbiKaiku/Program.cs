using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebbiKaiku
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket palvelin = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 25000);
            palvelin.Bind(iep);
            palvelin.Listen(2);
            while (true)
            {
                Socket asiakas = palvelin.Accept();
                IPEndPoint a = (IPEndPoint)asiakas.RemoteEndPoint;
                Console.WriteLine("Asiakas osoitteesta {0} portista {25000}" +  a.Address + a.Port);
                //vastaanota
                string viesti = "";
                while (!viesti.Equals("exit"))
                {
                    byte[] rec = new byte[128];
                    int paljon = asiakas.Receive(rec);
                    viesti =Encoding.ASCII.GetString(rec, 0, paljon);
                    asiakas.Send(Encoding.ASCII.GetBytes("viestejä viestejä viestejä ja ääkkösiä:  " +viesti+ "\n"));
                }
                //lähetä
                asiakas.Send(Encoding.ASCII.GetBytes(viesti));

                asiakas.Close();
            }

            Console.ReadKey();
            palvelin.Close();
        }
    }
}
