using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIEA212Harjoitustyo2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Kilometrit.Min = 0;
            Kilometrit.Max = double.MaxValue;
            Tunnit.Min = 0;
            Tunnit.Max = double.MaxValue;
            
            
        }


        private void Nappula1(object sender, EventArgs e)
        {
            Laske();
        }

        private void Laske()
        {
            double vastaus = Kilometrit.value / Tunnit.value;
            textBox1.Text = "" + Math.Round(vastaus,2);
        }
    }
}
