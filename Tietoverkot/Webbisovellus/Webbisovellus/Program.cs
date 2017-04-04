using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Webbisovellus
{
    class Program
    {
        static void Main(string[] args)
        {
                //Client client = new Client();
                Client.Connect(args[1], "GET " + "html" + " HTTP/1.1\r\nHost:" + "www.example.com" + "\r\nConnection:Close\r\n\r\n");
        }
        
    }
}
