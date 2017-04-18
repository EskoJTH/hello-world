using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace kaikua
{
    class Program
    {
        static void Main(string[] args)
        {
            String server = "localhost";

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            s.Connect(server,25000);

            string message = "";
            byte[] snd = Encoding.ASCII.GetBytes(message);
            string sivu;
            int paljon;
            byte[] rec;
            while (!message.Equals("exit"))
            {
                message = Console.ReadLine();
                snd = Encoding.ASCII.GetBytes(message);
                s.Send(snd);
                paljon = 0;
                rec = new byte[256];
                paljon = s.Receive(rec);
                sivu = Encoding.ASCII.GetString(rec, 0, paljon);
                string[] palaset = sivu.Split();
                string[] loput = palaset;
                loput = loput.Skip(1).ToArray();

                Console.Write("nimi on: " + palaset[0] + "\nviesti oli: " + String.Join(" ", loput));
            }
            /*paljon = 0;
            rec = new byte[256];
            snd = Encoding.ASCII.GetBytes(message);
            sivu = Encoding.ASCII.GetString(rec, 0, paljon);*/
            s.Close();
        }
    }
}
