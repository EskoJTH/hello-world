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
    public partial class TimeTextBox: TextBox
    {
        private ErrorProvider error = new ErrorProvider();
        public string value { get; set; } = "00:00:00";
        private TimeSpan aika = TimeSpan.Parse("00:00:00");

        public TimeTextBox()
        {
            InitializeComponent();
            this.Validating += new CancelEventHandler(TimeValidating);
            this.Validated += new EventHandler(TimeValid);
            this.value = aika.ToString();
            this.Text = "00:00:00";
        }

        private void TimeValid(object sender, EventArgs e)
        {
            error.SetError(this, "");
        }

        private void TimeValidating(object sender, CancelEventArgs e)
        {

            if (this.Text.Trim().Equals(""))
            {
                error.SetError(this, "tyhjä ei kelpaa ajaksi");
                this.BackColor = Color.Red;
                e.Cancel = true;
                return;
            }
            Regex regex = new Regex(@"^(([10][0-9])|(2[0-3])):([012345][0-9]):([012345][0-9])$");
            Match match = regex.Match(this.Text);
            if (match.Success)
            {
                TimeSpan x = TimeSpan.Parse(this.Text);
                this.aika = x;
                error.SetError(this, "");
                e.Cancel = false;
                this.BackColor = Color.White;
                return;
            }

            error.SetError(this, "Aika ei kelpaavaa muotoa. Yitä uudelleen.");
            this.BackColor = Color.Red;
            e.Cancel = true;
        }
    }
}
