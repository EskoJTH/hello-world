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
        List<String> historia = new List<String>();
        List<String> redo = new List<String>();
        List<String> jarjestys = new List<String>();
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
            uusiLaatikko.BackColor = Color.Cyan;
            uusiLaatikko.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            uusiLaatikko.AutoSize = false;

            ScaalaaBoxiTeksti(uusiLaatikko);

            flowLayoutPanel1.Controls.Add(uusiLaatikko);
            jarjestys.Add(teksti);
            uusiLaatikko.ReadOnly = false;
            uusiLaatikko.TextChanged += new System.EventHandler(textBox_TextChanged);
            
                
        }
                private void textBox_TextChanged(Object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Size size = TextRenderer.MeasureText(textBox.Text, textBox.Font);
            ScaalaaBoxiTeksti(textBox);
        }//

        private void ScaalaaBoxiTeksti(TextBox kuka)
        {
            Size size = TextRenderer.MeasureText(kuka.Text, kuka.Font);
            kuka.Width = size.Width;
            kuka.Height = size.Height;
        }

        private void Undo()
        {
            //TODO
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    

        private void JarjestaButton_Click(object sender, EventArgs e)
        {
            List<String> lista = new List<String>();
            //List<String> listaVertaus = new List<String>();

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                lista.Add(ctrl.Text);
            }
            //listaVertaus = lista;
            lista.Sort(); //aakkoseten mukaan
            lista.Sort((x,y) => x.Length.CompareTo(y.Length)); //pituuden mukaan

            /*
                        List<String> yhtapitkat = new List<String>();
                        for (int i = 0; i<lista.Count; i++)
                        {
                            if (yhtapitkat.Count == 0)
                            {
                                yhtapitkat.Add(lista[i]);
                            }
                            else if (lista[i].Length == yhtapitkat[yhtapitkat.Count - 1].Length)
                            {
                                yhtapitkat.Add(lista[i]);
                            }
                            else
                            {

                            }

                 */
            bool samat = true;
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Equals(jarjestys[i]))
                {
                    continue;
                }
                samat = false;
                break;
            }
            if (samat) lista.Reverse();

            for (int i=0; i<lista.Count;i++)
            {
                flowLayoutPanel1.Controls[i].Text = lista[i];
                jarjestys = lista;
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }
    }
    //textrenderer.mesureText();
}
