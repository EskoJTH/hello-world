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
            IPEndPoint palvelin = new IPEndPoint(IPAddress.Loopback, 25000);
            bool on = true;
            string TILA = "CLOSED";
            char[] erotinmerkki = {' '};
            string[] palat = new string[3];
            while (on)
            {
                if (!TILA.Equals("CLOSED")) palat = Vastaanota(s);
                switch (TILA)                     
                {
                    case "CLOSED":
                        Console.Write("Anna nimesi > ");
                        string nimi = Console.ReadLine();
                        Laheta(s, palvelin, "JOIN", nimi, erotinmerkki);
                        TILA = "JOIN";  //nuoli tilasta toise, erotinmerkkien
                        break;

                    case "JOIN":
                        if (palat[0].Equals("ACK"))
                        {
                            switch (palat[1])
                            {
                                case "201": // ei thedä mitään
                                    Console.WriteLine("Odottaa.");
                                    break;
                                case "202":
                                    Laheta(s,palvelin,"DATA", ArvaaLuku(), erotinmerkki);
                                    TILA = "GAME";
                                    break;
                                case "203":
                                    Console.WriteLine("Kaverin vuoro.");
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
                                        Console.WriteLine("Vastustajan vuoro...");
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
                                if (palat[1].Equals("501")) Console.WriteLine("Peli loppui.");
                                else Console.WriteLine("Vastustaja voitti :( "+ palat[2]);
                                Laheta(s, palvelin, "ACK", "500", erotinmerkki);
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
            
            IPEndPoint jokupalvelin = new IPEndPoint(IPAddress.Any, 0);
            EndPoint remoteEP = (EndPoint)jokupalvelin;
            StringBuilder palvelimelta = new StringBuilder("");
            int received;
            byte[] rec = new byte[64*4];
            received = s.ReceiveFrom(rec, ref remoteEP);
            palvelimelta.Append(Encoding.UTF8.GetString(rec, 0, received));
            char[] delim = { ' ' }; // delimiter
            string[] osat = palvelimelta.ToString().Split(delim);
            for(int i =0; i<osat.Length; i++)
            {
                Console.Write(osat[i] + " ");
            }
            Console.WriteLine();
            return osat;
        }

        private static string ArvaaLuku()
        {
            Console.Write("Arvaa Luku > ");
            return Console.ReadLine();
        }
    }
}
