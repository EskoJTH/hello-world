using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace MyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect("www.example.com",80);
            String snd = "GET / HTTP/1.1\nHost: www.example.com\r\n\r\n";
            byte[] buffer = Encoding.ASCII.GetBytes(snd);
            s.Send(buffer);
            String sivu = "";
            int count;
            //do
            {
                byte[] rec = new byte[1024 * 10000];
                count = s.Receive(rec);
                Console.Write("Tavuaja vastaanotettu: " + count + "\n");
                sivu += Encoding.ASCII.GetString(rec, 0, count);
            } //while (count > 0);
            Console.Write(sivu);
            Console.ReadKey();

            s.Close();
        }
    }
}
