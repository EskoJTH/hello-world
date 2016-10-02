using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

/// <summary>
/// @author Esko Hanell
/// @version 3.10.2016
/// </summary>
namespace OmaLabeli
{

    /// <summary>
    /// Tekee aika älykkään labelin.
    /// </summary>
    public partial class PaceLabel : Label
    {

        private double distance;
        private TimeSpan time;
        private double pace;
        public double FastMin { get; set; } = 5;
        public double SlowMin { get; set; } = 7;


        public event EventHandler calculate;
        public event EventHandler Fast;
        public event EventHandler Slow;
        public event EventHandler Avarage;


        /// <summary>
        /// Initialisoi labelin ja Eventhandlerin.
        /// </summary>
        public PaceLabel()
        {
            InitializeComponent();
            calculate += new EventHandler(calculator);

        }

        /// <summary>
        /// Asettaa ajan josta labeli laskee.
        /// </summary>
        /// <param name="aika">aika</param>
        public void SetTime(TimeSpan aika)
        {
            time = aika;
            calculate(this, EventArgs.Empty);
        }

        /// <summary>
        /// asettaa matkan jota labeli laskee
        /// </summary>
        /// <param name="matka">matka</param>
        public void SetDistance(double matka)
        {
                distance = matka;
            calculate(this, EventArgs.Empty);
        }

        /// <summary>
        /// Laskee kuinka monta minuuttia kilomeriin kuluu ja
        /// Päätää oliko kierros nopea, keskiverto vai hidas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculator(Object sender, EventArgs e)
        {
            pace = Math.Round(time.TotalMinutes / distance, 1);
            if (pace < FastMin)
            {
                Fast(this, e);
            }
            else if (pace < SlowMin)
            {
                Avarage(this, e);
            }
            else if (pace >= SlowMin)
            {
                Slow(this, e);
            }
            this.Text = pace + " : min/km";
        }
    }
}

