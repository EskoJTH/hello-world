using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmaTextBox
{
    public partial class NumberTextBox : TextBox
    {
        private ErrorProvider error = new ErrorProvider();
        public double min { get; set; } = Double.MinValue;
        public double max { get; set; } = Double.MaxValue;
        public double value { get; private set; } = 0;

        public NumberTextBox()
        {
            InitializeComponent();
            this.Validated += new EventHandler(Valid);
            this.Text = "" + 0;
        }

        public void Valid(object sender, EventArgs e)
        {
            error.SetError(this, "");
        }

        private void validatingRuleSet(object sender, CancelEventArgs e)
        {
            e.Cancel = true;

            if (Text.Trim().Equals(""))
            {
                error.SetError(this, "Kenttä jätetty tyhjäksi");
                this.BackColor = Color.Red;
                return;
            }

            double luku = 0;

            if (double.TryParse(this.Text.Trim(), out luku))
            {
                this.value = luku;
                if (min < luku && luku < max)
                {
                    error.SetError(this, "");
                    e.Cancel = false;
                    this.BackColor = Color.White;
                }
                else
                {
                    error.SetError(this, "Annettu arvo ei välilä: " + min + " <-> " + max);
                    this.BackColor = Color.Red;
                }
                return;
            }
            else
            {
                error.SetError(this, "Arvo ei ollut kelpaava desimaaliluku");
                this.BackColor = Color.Red;
            }
        }
    }
}
