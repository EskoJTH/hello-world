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
    public partial class NumeberTextBox : TextBox , IComponent
    {
        public NumeberTextBox()
        {
            InitializeComponent();
            this.TextChanged += new EventHandler(IsNumber_OnTextChanged);
        }

        private void IsNumber_OnTextChanged(object sender, EventArgs obj)
        {

        }

        private void DecimalValidating(object sender, CancelEventArgs e)
        {
            ErrorProvider errorProvider1 = new ErrorProvider();
            try
            {

                String syote = this.Text;
                double x = Double.Parse(syote); //TODO TESTAAAAAAA!!!!!!!!!!!!!!!
                errorProvider1.Clear();
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(this, "Not a decimal value.");
            }
        }
    }
}
