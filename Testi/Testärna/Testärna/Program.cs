using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testärna
{
    class Program
    {

        static void Main(string[] args)
        {
            Kissa kissa = new Kissa();
            KissanKutsuja kutsuja = new KissanKutsuja(kissa);
            string teksti = "";
            while (!teksti.Equals("exit"))
            {
                teksti = Console.ReadLine();
                kissa.Kutsu();
            }
            Console.WriteLine("Exited");
        }


    }

    public class KissanKutsuja
    {
        private Kissa kissa;
        public KissanKutsuja(Kissa kissa)
        {
            this.kissa = kissa;
            kissa.SampleEvent += HandlaaEventti;
        }

        public void HandlaaEventti(object o, MyEventArgs e)
        {
            Console.WriteLine("HandlaaEventti");
            Console.WriteLine(e.Viesti);
        }
    }

    public class Kissa
    {
        //public event EventHandler<MyEventArgs> RaiseMunEvent;
        public Kissa(){}

        /**
        public void JotainTapahtui()
        {
            RaiseMunEvent(new MyEventArgs("Jotain tapahtui"));
        }
    */

        // Declare the delegate (if using non-generic pattern).
        public delegate void MunEventHandleri (object sender, MyEventArgs e);

        // Declare the event. Subscribe to this.
        public event MunEventHandleri SampleEvent;

        // Wrap the event in a protected virtual method
        // to enable derived classes to raise the event.
        protected virtual void RaiseMunEvent()
        {
            // Raise the event by using the () operator.
            if (SampleEvent != null)
                SampleEvent(this, new MyEventArgs("Hello"));
        }

        internal void Kutsu()
        {
            RaiseMunEvent();
        }
    }

    public class MyEventArgs : EventArgs
    {

        private string viesti;
        public string Viesti
        {
            get { return viesti; }
            set { viesti = value; }
        }

        public MyEventArgs(string s)
        {
            viesti = s;
        }
    }
}
