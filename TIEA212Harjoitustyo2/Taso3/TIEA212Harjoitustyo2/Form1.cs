using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// @author Esko Hanell
/// @version 2.10.2016
/// </summary>
namespace TIEA212Harjoitustyo2
{
    /// <summary>
    /// Luo ikkunan jossa voi laskea km/h nopeuden ja
    /// ajan joka kuluu kilometrin matkustamiseen.
    /// </summary>
    public partial class Form1 : Form
    {

        /// <summary>
        /// Initialisoidaan ikkuna.
        /// Luodaan EventHandlerit.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.EnablePreventFocusChange;
            TomaattiLabeli.Fast += new EventHandler(Punainen);
            TomaattiLabeli.Avarage += new EventHandler(Kelatainen);
            TomaattiLabeli.Slow += new EventHandler(Vihree);
            timeTextBox1.Validated += new EventHandler(Paivita);
            numeberTextBox1.Validated += new EventHandler(Paivita);


        }

        /// <summary>
        /// Päivitetään paceLabel oikeilla tiedoilla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Paivita(object sender, EventArgs e)
        {
            TomaattiLabeli.SetTime(timeTextBox1.aika);
            TomaattiLabeli.SetDistance(numeberTextBox1.value);
        }

        /// <summary>
        /// Pistetään taustaväri punaiseksi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Punainen(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }

        /// <summary>
        /// Taustaväri keltaiseksi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kelatainen(object sender, EventArgs e)
        {
            this.BackColor = Color.Yellow; 
        }

        private void Vihree(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
        }

        /// <summary>
        /// Kutsutaan kun laske nappulaa painetaan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Nappula1(object sender, EventArgs e)
        {
            Laske();
        }

        /// <summary>
        /// Laskee kilometrit ja tunnit yhteen.
        /// </summary>
        private void Laske()
        {
            double vastaus = numeberTextBox1.value / timeTextBox1.aika.TotalHours;
            textBox1.Text = "" + Math.Round(vastaus,2);
        }
    }
}
