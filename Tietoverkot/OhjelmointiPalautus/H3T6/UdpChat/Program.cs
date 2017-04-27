using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace UdpChat
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket palvelin = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Loopback, 25000);
            palvelin.Bind(iep);
            List<EndPoint> asiakkaat = new List<EndPoint>();
            while (true)
            {
                byte[] rec = new byte[128];
                IPEndPoint tyhja = new IPEndPoint(IPAddress.Any, 0);
                EndPoint remoteEP = (IPEndPoint)tyhja;
                int received = palvelin.ReceiveFrom(rec, ref remoteEP);
                string viesti = Encoding.UTF8.GetString(rec, 0, received);
                char[] delim = { ';' }; // delimiter
                string[] osat = viesti.Split(delim, 2);
                if (osat.Length == 2)
                {
                    if (!asiakkaat.Contains(remoteEP))
                    {
                        asiakkaat.Add(remoteEP);
                        Console.WriteLine("uusi asiakas! [{0}]:[]", ((IPEndPoint)remoteEP).Address, ((IPEndPoint)remoteEP).Port, osat[0]);
                    }
                    Console.WriteLine(osat[0] + ": " + osat[1]);
                    foreach (EndPoint klientti in asiakkaat)
                    {
                        palvelin.SendTo(Encoding.UTF8.GetBytes(viesti), klientti);
                    }
                }
                else
                {
                    palvelin.SendTo(Encoding.UTF8.GetBytes("virhe"), remoteEP); //lähettää virheen
                } //palvelin.Close();

            }

        }


    }
}
