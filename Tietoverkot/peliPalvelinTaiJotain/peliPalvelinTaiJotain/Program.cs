using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace peliPalvelinTaiJotain
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket palvelin = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Loopback, 25000);
            palvelin.Bind(iep);
            string tila = "CLOSED";
            string[] palat = new string[3];
            List<EndPoint> asiakkaat = new List<EndPoint>();
            //List<IPEndPoint> asiakkaatIP = new List<IPEndPoint>();
            List<string> nimet = new List<string>();
            bool on = true;
            int pelaajia = 0;
            int vuoro = -1;
            int luku = -1;
            int kuittauksia = 0;
            
            while (on)
            {
                Console.WriteLine(tila);
                IPEndPoint jokuasiakas = new IPEndPoint(IPAddress.Any, 0);
                EndPoint remoteEP = (EndPoint)jokuasiakas; // viimeisimmän paketin lähettäjä.
                if (!tila.Equals("CLOSED"))
                {
                    palat = vastaanota(palvelin, ref remoteEP);
                }
                switch (tila)
                {
           
                    case "CLOSED":
                        tila = "WAIT"; //palvelin päällä mennään WAIT tilaan
                        break;
                    case "WAIT":
                        switch (palat[0])
                        {
                            case "JOIN":
                                switch (pelaajia)
                                {
                                    case 0:
                                        laheta(palvelin, remoteEP, "ACK", "201");
                                        pelaajia++;
                                        asiakkaat.Add(remoteEP);
                                        nimet.Add(palat[1]);
                                        break;
                                    case 1:
                                        if (!remoteEP.Equals(asiakkaat)) {
                                            asiakkaat.Add(remoteEP);
                                            nimet.Add(palat[1]);
                                            Random rand = new Random();
                                            vuoro = rand.Next(0, 1);
                                            luku = rand.Next(0, 1);
                                            Console.WriteLine("Oikea luku: " + luku.ToString());
                                            laheta(palvelin, asiakkaat[vuoro], "ACK", "202" + " " + nimet[vastustaja(vuoro)]);
                                            laheta(palvelin, asiakkaat[vastustaja(vuoro)], "ACK", "203" + " " + nimet[vuoro]);
                                            pelaajia++;
                                            tila = "GAME";
                                        }
                                        break;
                                    default:
                                        break;
                                }

                                break;
                            default:
                                Console.WriteLine("OIS HALUTTTU JOINI, EI SAATU.");
                                break;
                        }
                        break;
                    case "GAME":
                        if (palat[0].Equals("DATA") && remoteEP.Equals(asiakkaat[vuoro]))
                        {
                            try
                            {
                                if (luku == int.Parse(palat[1]))
                                {
                                    laheta(palvelin,asiakkaat[vuoro],"QUIT","501");
                                    laheta(palvelin, asiakkaat[vastustaja(vuoro)], "QUIT", "501" + " hävisiit peliin oikea luku oli "+palat[1]);
                                    tila = "END";
                                }
                                else
                                {
                                    laheta(palvelin, asiakkaat[vuoro], "ACK", "300");
                                    laheta(palvelin, asiakkaat[vastustaja(vuoro)], palat[0], palat[1]);//????
                                    vuoro = vastustaja(vuoro);
                                    tila = "WAIT_ACK";

                                }
                            }
                            catch
                            {
                                laheta(palvelin, remoteEP, "ACK", "407" + " Ei ollu numero :(" );
                            }
                        }                        
                        break;
                    case "WAIT_ACK":
                        if(palat[0].Equals("ACK") && palat[1].Equals("300") && remoteEP.Equals(asiakkaat[vuoro]))
                        {
                            tila = "GAME";
                        }
                        break;
                    case "END":
                        if (palat[0].Equals("ACK") && palat[1].Equals("500")) kuittauksia++;
                        if(kuittauksia == 2)
                        {
                            tila = "CLOSED";
                            on = false; // lopeteteaan ensimmäisen pelin jälkeen
                        }
                        break;
                }
            }
            Console.ReadKey();
            palvelin.Close();
        }
        static int vastustaja(int vuoro)
        {
            return 1 - vuoro;
        }

        private static void laheta(Socket s, EndPoint palvelin, string viesti, string arvo)
        {
            s.SendTo(Encoding.UTF8.GetBytes(viesti + " " + arvo), palvelin);
        }

        private static string[] vastaanota(Socket s, ref EndPoint mistaTuli)
        {
            byte[] rec = new byte[128];
            //IPEndPoint jokupalvelin = new IPEndPoint(IPAddress.Any, 0);
            //EndPoint remoteEP = (EndPoint)jokupalvelin;
            int received = s.ReceiveFrom(rec, ref mistaTuli);
            string palvelimelta = Encoding.UTF8.GetString(rec, 0, received);
            char[] delim = { ' ' }; // delimiter
            string[] osat = palvelimelta.Split(delim, 2);
            Console.WriteLine(osat[0] + ": " + osat[1]);
            return osat;
        }
    }
}
