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

namespace TimeTextBox
{
    public partial class TimeTextBox : TextBox
    {
        private ErrorProvider errorProvider1 = new ErrorProvider();
        private TimeSpan aika = TimeSpan.Zero;
        private TimeSpan aikaMax = new TimeSpan(23,59,59);


        public TimeTextBox()
        {
            InitializeComponent();
            this.Validating += new CancelEventHandler(TimeValidating);
            this.Validated += new EventHandler(Validi);
            this.Text = aika.ToString();
        }

        private void TimeValidating(object sender, CancelEventArgs e)
        {

            try
            {

                String syote = this.Text;
                if (syote.Trim().Equals(""))
                {
                    this.aika = TimeSpan.FromSeconds(0);
                    errorProvider1.SetError(this, string.Empty);
                    e.Cancel = false;
                    this.Text = aika.ToString();

                }
                else
                {
                    Regex regex = new Regex(@"^(([10][0-9])|(2[0-3])):([012345][0-9]):([012345][0-9])$");
                    syote = syote.Trim();
                    Match match = regex.Match(syote);
                    if (match.Success)
                    {
                        TimeSpan x = TimeSpan.Parse(syote);
                        this.aika = x;
                        errorProvider1.SetError(this, string.Empty);
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
            }
        }

        private void Validi(object sender, EventArgs e)
        {
            errorProvider1.SetError(this, string.Empty);
        }
    }
}

