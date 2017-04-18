using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace SMTPmailProtocol
{
    class Program
    { 
        static void Main(string[] args)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect("localhost", 25000); //smtpauth.jyu.fi tai jotain
            NetworkStream ns = new NetworkStream(s);
            StreamReader read = new StreamReader(ns);
            StreamWriter write = new StreamWriter(ns);
            String luettu = "";
            bool on = true;
            while (on)
            {
                luettu = read.ReadLine();
                String[] palat = luettu.Split(' ');
                Console.WriteLine(luettu);
                switch (palat[0])
                {
                    case "220":
                        write.WriteLine("HELO Esko");
                        break;
                    case "221":
                        on = false;
                        break;
                    case "250":
                        switch (palat[1])
                        {
                            case "2.0.0":
                                write.WriteLine("QUIT");
                                break;
                            case "2.1.0":
                                write.WriteLine("RCPT TO: esjutaha@student.jyu.fi");
                                break;
                            case "2.1.5":
                                write.WriteLine("DATA");
                                break;
                            default:
                                write.WriteLine("MAIL FROM: esjutaha@student.jyu.fi");
                                break;
                        }
                        break;
                    case "354":
                        string email = "";
                        do
                        {
                            write.Write(email+"\n");
                            email = Console.ReadLine();
                        } while (email != ".");
                        write.Write("Eskon Sähköposti ohjelma!");
                        write.Write("\n.\n");
                        break;
                    default:
                        write.WriteLine("QUIT");
                        break;
                }
                write.Flush();
            }
            Console.ReadKey();
            write.Close();
            read.Close();
            ns.Close();
            s.Close();
        }
    }
}
