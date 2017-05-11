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
            string viesti = "";
            while (!viesti.Equals("exit"))
            {
                Socket asiakas = palvelin.Accept();
                IPEndPoint a = (IPEndPoint)asiakas.RemoteEndPoint;
                Console.WriteLine("Asiakas osoitteesta {0} portista {25000}" + a.Address + a.Port);
                //vastaanota

                while (!viesti.Equals("exit"))
                {
                    byte[] rec = new byte[255];
                    int paljon = asiakas.Receive(rec);
                    viesti = Encoding.ASCII.GetString(rec, 0, paljon);
                    Console.WriteLine("Saatiin viesti: " + viesti + "; osoitteesta: " + a.Address +a.Port);
                    asiakas.Send(Encoding.ASCII.GetBytes("Kaiku palvelimelta: " + viesti));
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