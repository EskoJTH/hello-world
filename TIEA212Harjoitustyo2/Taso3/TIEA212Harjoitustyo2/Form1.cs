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
/// Luo ikkunan jossa voi laskea km/h nopeuden.
/// @author Esko Hanell
/// @version 2.10.2016
/// </summary>
namespace TIEA212Harjoitustyo2
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// Initialisoidaan ikkuna.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Kilometrit.Min = 0;
            Kilometrit.Max = double.MaxValue;
            Tunnit.Min = 0;
            Tunnit.Max = double.MaxValue;
            this.AutoValidate = AutoValidate.EnablePreventFocusChange;
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
            double vastaus = Kilometrit.value / Tunnit.value;
            textBox1.Text = "" + Math.Round(vastaus,2);
        }
    }
}
