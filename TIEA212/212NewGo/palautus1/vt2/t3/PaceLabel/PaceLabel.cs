using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaceLabel
{
    public partial class PaceLabel : Label
    {
        /// <summary>
        /// eventti joka tapahtuu kun arvoja joist labelin sisältö lasketaan muutetaan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void EventHandlerTextChanged(object sender, EventArgs e);
        public event EventHandlerTextChanged paceChangeCheck;

        /// <summary>
        /// eventi joka tapahtuu kun labelin laskema nopeus on tarpeeksi suuri (suurempaa kuin fastMin)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void EventHandlerFast(object sender, EventArgs e);
        public event EventHandlerFast Fast;

        /// <summary>
        /// tapahtuu kun nopeus on pienempää tai yhtäsuurta kuin fastMin mutta suurempaa kuin slowMin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void EventHandlerAverage(object sender, EventArgs e);
        public event EventHandlerAverage Average;

        /// <summary>
        /// Tapahtuu kun nopeus on pienempää tai yhtäsuurta kuin slowmin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void EventHandlerSlow(object sender, EventArgs e);
        public event EventHandlerSlow Slow;
        private TimeSpan time;

        /// <summary>
        /// pääseet käsiksi aikaan josta nopeus lasketaan labeliin. Aiheuttaa eventin nopeuden laskemiseksi.
        /// </summary>
        public TimeSpan Time
        {
            get { return time; }
            set { time = value; RaiseTextChangedEvent(this, new EventArgs()); }
        }
        private double distance;

        /// <summary>
        /// pääseet käsiksi matkaan josta nopeus lasketaan labeliin. Aiheuttaa eventin nopeuden laskemiseksi.
        /// </summary>
        public double Distance
        {
            get { return distance; }
            set { distance = value; RaiseTextChangedEvent(this, new EventArgs()); }
        }
        private double fastMin = 7;
        public double FastMin
        {
            get { return fastMin; }
            set { slowMin = value; }
        }
        private double slowMin = 5;
        public double SlowMin
        {
            get { return slowMin; }
            set { slowMin = value; }
        }


        /// <summary>
        /// PaceLabel on label luokasta peritty labeli joka siältää ajan ja matkan joista lasketaan labeliin min/km tyyppinen nopeus.
        /// </summary>
        public PaceLabel()
        {
            InitializeComponent();
            paceChangeCheck += tarkastaSisalto;
        }

        /// <summary>
        /// eventti joka tapahtuu kun nopeuteen liittyvät arvot muuttuvat.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void RaiseTextChangedEvent(object sender, EventArgs e)
        {
            if (paceChangeCheck != null)
                paceChangeCheck(this, new EventArgs());
        }

        /// <summary>
        /// Fast eventti.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void RaiseFast(object sender, EventArgs e)
        {
            if (Fast != null)
                Fast(this, new EventArgs());
        }

        /// <summary>
        ///  Average eventti.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void RaiseAverage(object sender, EventArgs e)
        {
            if (Average != null)
                Average(this, new EventArgs());
        }

        /// <summary>
        /// Slow eventti.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void RaiseSlow(object sender, EventArgs e)
        {
            if (Slow != null)
                Slow(this, new EventArgs());
        }

        /// <summary>
        /// kutsutaan kun nopeuteen liittyvät PaceLabelin arvot muuttuvat. Laskee mitä labelissa näkyy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tarkastaSisalto(object sender, EventArgs e)
        {
            double minuutit = time.TotalMinutes;
            if (minuutit==0 || distance==0)
            {
                this.Text = "0" + " min/km";
                return;
            }
            double luku = minuutit / distance;
            if (luku < slowMin)
            {
                RaiseFast(this, new EventArgs());
            }
            else if (luku < fastMin)
            {
                RaiseAverage(this, new EventArgs());
            }
            else
            {
                RaiseSlow(this, new EventArgs());
            }
            this.Text = luku + " min/km";
        }
    }
}
