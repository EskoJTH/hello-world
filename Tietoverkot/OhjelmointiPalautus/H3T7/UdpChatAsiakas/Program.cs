using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace UdpChatAsiakas
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Loopback, 25000);
            Console.Write("Anna nimesi > ");
            string nimi = Console.ReadLine();
            bool on = true;
            s.ReceiveTimeout = 1000;
            do
            {
                Console.Write("> ");
                string viesti = Console.ReadLine();
                if (viesti.Equals("end"))
                {
                    on = false;
                }
                else
                {
                    s.SendTo(Encoding.UTF8.GetBytes(nimi + ';' + viesti), iep);
                    while (!Console.KeyAvailable)
                    {
                        byte[] rec = new byte[128];
                        IPEndPoint tyhja = new IPEndPoint(IPAddress.Any, 0);
                        EndPoint remoteEP = (IPEndPoint)tyhja;
                        try
                        {
                            int received = s.ReceiveFrom(rec, ref remoteEP);
                            string palvelimelta = Encoding.UTF8.GetString(rec, 0, received);
                            char[] delim = { ';' }; // delimiter
                            string[] osat = palvelimelta.Split(delim, 2);
                            Console.WriteLine(osat[0] + ": " + osat[1]);
                        }
                        catch (SocketException){ }
                    }
                }
            } while (on);


        }
    }
}
