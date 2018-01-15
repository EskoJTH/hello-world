using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viikko2Taso3
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// Tehtävän annon mukainen formi.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            aikaBox.TextChanged += LabelCompute;
            matkaBox.TextChanged += LabelCompute;
            paceLabel.Slow += GreenBack;
            paceLabel.Fast += RedBack;
            paceLabel.Average += YellowBack;
        }

        /// <summary>
        /// tapahtuu jos event Slow kuullaan asettaa taustan vihreäksi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GreenBack(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
        }

        /// <summary>
        /// tapahtuu jos eventti Fast tapahtuu. Asettaa taustan punaiseksi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RedBack(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }

        /// <summary>
        /// Tapahtuu jos eventti Average aiheutuu. laittaa taustan keltaiseksi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YellowBack(object sender, EventArgs e)
        {
            this.BackColor = Color.Yellow;
        }

        /// <summary>
        /// Laittaa PaceLabelille oikean sisällön.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelCompute(object sender, EventArgs e)
        {
            bool validated = this.ValidateChildren();
            button1.Enabled = validated;
            if (validated)
            {
                paceLabel.Distance = matkaBox.value;
                paceLabel.Time = aikaBox.aika;
            }
        }

        /// <summary>
        /// Laske nappula painallus eventti. Laskee kilometrinopeuden sille tarkoitettuun labeliin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            matkaLabel.Text = Math.Round((matkaBox.value / aikaBox.aika.TotalHours),2).ToString() + "km/h";
        }
    }
}
