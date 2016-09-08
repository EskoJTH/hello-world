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
            if (teksti.Equals("")) return;
            teksti.Trim();
            TextBox uusiLaatikko = new TextBox();
            uusiLaatikko.Text = teksti;
            uusiLaatikko.BackColor = Color.FromArgb(20, 250, 5);
            uusiLaatikko.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            flowLayoutPanel1.Controls.Add(uusiLaatikko);


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ohjelma_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
