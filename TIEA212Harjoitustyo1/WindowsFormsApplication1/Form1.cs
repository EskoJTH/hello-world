using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Ohjelma : Form
    {
        public Ohjelma()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string teksti = textBox1.Text;
            TextBox uusiLaatikko = new TextBox();
            uusiLaatikko.Text = teksti;
            flowLayoutPanel1.Controls.Add(uusiLaatikko);

        }
    }
}
