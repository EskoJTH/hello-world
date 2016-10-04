using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OmaWindowsFormsComponenttiTaiJotainSemmosta
{
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

        public NumeberTextBox()
        {
            InitializeComponent();
            this.Validated += new EventHandler(Validi);
            this.Text = ""+min;
        }

        private void DecimalValidating(object sender, CancelEventArgs e)
        {
            
            try
            {

                String syote = this.Text;
                if (syote.Trim().Equals(""))
                {
                    this.value = 0;
                    errorProvider1.SetError(this, string.Empty);
                    e.Cancel = false;
                    this.Text = "0";

                }
                else
                {

                    double x = Double.Parse(syote); //TODO TESTAAAAAAA!!!!!!!!!!!!!!!
                    this.value = x;
                    if (!(Min <= x && Max >= x))
                    {
                        errorProvider1.SetError(this, "Anneun arvon pitää olla väliltä: " + min + " < X < " + max);
                        e.Cancel = true;
                    }
                    else
                    {
                        errorProvider1.SetError(this, string.Empty);
                        e.Cancel = false;
                    }
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(this, "Not a decimal value.");
                e.Cancel = true;
            }
        }

        private void Validi(object sender, EventArgs e)
        {
            errorProvider1.SetError(this, string.Empty);
        }
    }
}
