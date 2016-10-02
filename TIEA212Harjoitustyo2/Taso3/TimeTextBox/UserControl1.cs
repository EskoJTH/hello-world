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
/// @Version 3.10.2016
/// </summary>
namespace TimeTextBox
{

    /// <summary>
    /// textBox joka tallentaa tietoa aikana.
    /// </summary>
    public partial class TimeTextBox : TextBox
    {
        private ErrorProvider errorProvider1 = new ErrorProvider();
        public TimeSpan aika { get; private set; } = TimeSpan.Zero;
        private TimeSpan aikaMax = new TimeSpan(23,59,59);

        /// <summary>
        /// Initialisoi komponentin ja luo eventhandlereita
        /// </summary>
        public TimeTextBox()
        {
            InitializeComponent();
            this.Validating += new CancelEventHandler(TimeValidating);
            this.Validated += new EventHandler(Validi);
            this.Text = aika.ToString();
        }

        /// <summary>
        /// Tarkistaa onko syötetty tieto validi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeValidating(object sender, CancelEventArgs e)
        {

            try
            {

                String syote = this.Text;
                if (syote.Trim().Equals(""))
                {
                    this.aika = TimeSpan.FromSeconds(0);
                    e.Cancel = false;
                    this.Text = aika.ToString();

                }
                else
                {
                    Regex regex = new Regex(@"^(([10]?[0-9])|(2[0-3])):([012345]?[0-9]):([012345]?[0-9])$");
                    syote = syote.Trim();
                    Match match = regex.Match(syote);
                    if (match.Success)
                    {
                        TimeSpan x = TimeSpan.Parse(syote);
                        this.aika = x;
                        e.Cancel = false;

                    }
                    else
                    {
                        throw new System.ArgumentException("aika ei oikean muotoinen");
                    }
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(this, "Syötä oikean muotoinen aika.");
                e.Cancel = true;
                this.BackColor=Color.Red;
            }
        }

        /// <summary>
        /// asettaa arvot oikeiksi validia tilannetta varten.
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

