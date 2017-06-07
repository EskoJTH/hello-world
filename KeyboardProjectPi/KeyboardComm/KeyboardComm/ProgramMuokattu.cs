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
            while (true)
            {
                Socket asiakas = palvelin.Accept();
                IPEndPoint a = (IPEndPoint)asiakas.RemoteEndPoint;
                Console.WriteLine("Asiakas osoitteesta {0} portista {25000}" + a.Address + a.Port);
                //vastaanota
                string viesti = "";
                while (!viesti.Equals("exit"))
                {
                    byte[] rec = new byte[128];
                    int paljon = asiakas.Receive(rec);
                    viesti = Encoding.ASCII.GetString(rec, 0, paljon);
                    asiakas.Send(Encoding.ASCII.GetBytes("EskoHanell; " + viesti));
                    ////////////SendKeys.Send("{a}");
                }
                //lähetä
                asiakas.Send(Encoding.ASCII.GetBytes(viesti));

                asiakas.Close();
            }

            Console.ReadKey();
            palvelin.Close();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);


        ///Code Found on stack overFlow from user Tono Nam
        /// <summary>
        /// simulate key press
        /// </summary>
        /// <param name="keyCode"></param>
        public static void SendKeyPress(KeyCode keyCode)
        {
            INPUT input = new INPUT
            {
                Type = 1
            };
            input.Data.Keyboard = new KEYBDINPUT()
            {
                Vk = (ushort)keyCode,
                Scan = 0,
                Flags = 0,
                Time = 0,
                ExtraInfo = IntPtr.Zero,
            };

            INPUT input2 = new INPUT
            {
                Type = 1
            };
            input2.Data.Keyboard = new KEYBDINPUT()
            {
                Vk = (ushort)keyCode,
                Scan = 0,
                Flags = 2,
                Time = 0,
                ExtraInfo = IntPtr.Zero
            };
            INPUT[] inputs = new INPUT[] { input, input2 };
            if (SendInput(2, inputs, Marshal.SizeOf(typeof(INPUT))) == 0)
                throw new Exception();
        }

        /// <summary>
        /// Send a key down and hold it down until sendkeyup method is called
        /// </summary>
        /// <param name="keyCode"></param>
        public static void SendKeyDown(KeyCode keyCode)
        {
            INPUT input = new INPUT
            {
                Type = 1
            };
            input.Data.Keyboard = new KEYBDINPUT();
            input.Data.Keyboard.Vk = (ushort)keyCode;
            input.Data.Keyboard.Scan = 0;
            input.Data.Keyboard.Flags = 0;
            input.Data.Keyboard.Time = 0;
            input.Data.Keyboard.ExtraInfo = IntPtr.Zero;
            INPUT[] inputs = new INPUT[] { input };
            if (SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT))) == 0)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Release a key that is being hold down
        /// </summary>
        /// <param name="keyCode"></param>
        public static void SendKeyUp(KeyCode keyCode)
        {
            INPUT input = new INPUT
            {
                Type = 1
            };
            input.Data.Keyboard = new KEYBDINPUT();
            input.Data.Keyboard.Vk = (ushort)keyCode;
            input.Data.Keyboard.Scan = 0;
            input.Data.Keyboard.Flags = 2;
            input.Data.Keyboard.Time = 0;
            input.Data.Keyboard.ExtraInfo = IntPtr.Zero;
            INPUT[] inputs = new INPUT[] { input };
            if (SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT))) == 0)
                throw new Exception();

        }
    }
}