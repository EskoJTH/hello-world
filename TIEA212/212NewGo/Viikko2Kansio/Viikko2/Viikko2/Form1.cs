using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viikko2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AutoValidate = AutoValidate.EnablePreventFocusChange;
            NumBoxKm.min = 0;
            NumBoxKm.max = 1000;
            NumBoxT.min = 0;
            NumBoxT.max = 24;
            NumBoxKm.TextChanged += buttonVisibility;
            NumBoxT.TextChanged += buttonVisibility;

        }

        private void buttonVisibility(object o, EventArgs e)
        {
            button1.Enabled = this.ValidateChildren();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Arvo.Text = Laske();
        }

        private string Laske()
        {
            double kissa = Math.Round(NumBoxKm.value / NumBoxT.value, 2);
            return Arvo.Text = kissa + " km/h";
        }
    }
}
