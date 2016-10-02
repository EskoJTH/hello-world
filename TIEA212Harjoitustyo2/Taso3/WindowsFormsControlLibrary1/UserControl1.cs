using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Juuri sitä mitä nimi sanoo.
/// @author Esko Hanell
/// @version 2.10.2016
/// </summary>
namespace OmaWindowsFormsComponenttiTaiJotainSemmosta
{
    /// <summary>
    /// Omatekoinen numeroboksi joka osaa tarkastaa onko laatikossa desimaalinumero ja on vain tällöin validi.
    /// </summary>
    public partial class NumeberTextBox : TextBox
    {

        private ErrorProvider errorProvider1 = new ErrorProvider();
        private double min;
        private double max = Double.MaxValue;
        public double value { get; private set; }
        public double Min
        {
            get { return min; }
            set { min = value; }
        }

        public double Max
        {
            get { return max; }
            set { max = value; }
        }

        /// <summary>
        /// Initialisoi komponentin.
        /// </summary>
        public NumeberTextBox()
        {
            InitializeComponent();
            this.Validated += new EventHandler(Validi);
            this.Text = ""+min;
        }

        /// <summary>
        /// Eventhandleri joka tarkastaa onko laatikossa olevat kirjaimet desimaaliluku.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecimalValidating(object sender, CancelEventArgs e)
        {
            
            try
            {

                String syote = this.Text;
                if (syote.Trim().Equals(""))
                {
                    this.value = 0;
                    e.Cancel = false;
                    this.Text = "0";
                }
                else
                {

                    double x = Double.Parse(syote); 
                    this.value = x;
                    if (!(Min <= x && Max >= x))
                    {
                        errorProvider1.SetError(this, "Anneun arvon pitää olla väliltä: " + min + " < X < " + max);
                        e.Cancel = true;
                        this.BackColor = Color.Red;
                    }
                    else
                    {
                        e.Cancel = false;         
                    }
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(this, "Not a decimal value.");
                e.Cancel = true;
                this.BackColor = Color.Red;
            }
        }

        /// <summary>
        /// kutsutaan kun edellinen tarkastelu on mennyt kunniakkaasti läpi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Validi(object sender, EventArgs e)
        {
            errorProvider1.SetError(this, string.Empty);
            this.BackColor = Color.White;
        }
    }
}
