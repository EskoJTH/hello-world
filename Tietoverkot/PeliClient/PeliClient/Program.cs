using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace PeliClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint palvelin = new IPEndPoint(IPAddress.Loopback, 9999);
            Console.Write("Anna nimesi > ");
            bool on = true;
            string nimi = Console.ReadLine();
            string TILA = "CLOSED";
            char[] erotinmerkki = {' '};
            string[] palat = new string[3];
            while (on)
            {
                if (!TILA.Equals("CLOSED")) palat = Vastaanota(s);
                switch (TILA)                     
                {
                    case "CLOSED":
                        Laheta(s, palvelin, "JOIN", nimi, erotinmerkki);
                        TILA = "JOIN";  //nuoli tilasta toise, erotinmerkkien
                        break;

                    case "JOIN":
                        if (palat[0].Equals("ACK"))
                        {
                            switch (palat[1])
                            {
                                case "201": // ei thedä mitään
                                    break;
                                case "202":
                                    Laheta(s,palvelin,"DATA", ArvaaLuku(), erotinmerkki);
                                    TILA = "GAME";
                                    break;
                                case "203":
                                    TILA = "GAME";
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Virhe");
                            on = false;
                            TILA = "CLOSED";
                        }
                        break;

                    case "GAME":
                        switch (palat[0])
                        {
                            case "ACK":
                                switch (palat[1])
                                {
                                    case "300": // ei tehdä mitään
                                        break;
                                    default:
                                        Console.WriteLine("Virhe");
                                        on = false;
                                        TILA = "CLOSED";
                                        break;
                                }
                                break;
                            case "DATA":
                                Console.WriteLine("Vastustaja arvasi: " + palat[1]);
                                Laheta(s, palvelin, "ACK", "300", erotinmerkki);
                                Laheta(s, palvelin, "DATA", ArvaaLuku(), erotinmerkki);
                                break;
                            case "QUIT":
                                if (palat[1].Equals("501")) Console.WriteLine("Voitit!");
                                else Console.WriteLine("Vastustaja voitti :( "+ palat[2]);
                                TILA = "CLOSED";
                                break;
                        }
                        break;
                }

            }
            Console.ReadKey();
            s.Close();
        }

        private static void Laheta(Socket s,IPEndPoint palvelin, string viesti, string arvo, char[] erotin)
        {
            s.SendTo(Encoding.UTF8.GetBytes(viesti + " " + arvo), palvelin);
        }

        private static string[] Vastaanota(Socket s)
        {
            byte[] rec = new byte[128];
            IPEndPoint jokupalvelin = new IPEndPoint(IPAddress.Any, 0);
            EndPoint remoteEP = (EndPoint)jokupalvelin;
            int received = s.ReceiveFrom(rec, ref remoteEP);
            string palvelimelta = Encoding.UTF8.GetString(rec, 0, received);
            char[] delim = { ' ' }; // delimiter
            string[] osat = palvelimelta.Split(delim, 2);
            Console.WriteLine(osat[0] + ": " + osat[1]);
            return osat;
        }

        private static string ArvaaLuku()
        {
            Console.Write("Arvaa Luku > ");
            return Console.ReadLine();
        }
    }
}
