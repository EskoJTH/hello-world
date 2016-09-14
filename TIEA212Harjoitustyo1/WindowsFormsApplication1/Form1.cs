using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// @author Esko Hanell
/// @version 14.9.2016
/// </summary>
namespace WindowsFormsApplication1
{
    /// <summary>
    /// winForms:in generoima koodi ja omat lisäykset.
    /// </summary>
    public partial class Ohjelma : Form
    {
        List<Historia> historia = new List<Historia>();
        List<Historia> redo = new List<Historia>();
        List<String> jarjestys = new List<String>();

        /// <summary>
        /// 
        /// </summary>
        public Ohjelma()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            LisaaTietoLaatikko();
        }

        private void LisaaTietoLaatikko()
        {
            LisaaTietoLaatikko(textBox1.Text);
        }

        public TextBox LisaaTietoLaatikko(string teksti)
        {
            if (teksti.Equals("")) return null;
            teksti.Trim();
            TextBox uusiLaatikko = new TextBox();
            uusiLaatikko.Text = teksti;
            uusiLaatikko.BackColor = Color.Cyan;
            uusiLaatikko.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            uusiLaatikko.AutoSize = false;

            flowLayoutPanel1.Controls.Add(uusiLaatikko);
            jarjestys.Add(teksti);
            uusiLaatikko.ReadOnly = false;
            uusiLaatikko.TextChanged += new System.EventHandler(textBox_TextChanged);

            ScaalaaBoxiTeksti(uusiLaatikko);

            historia.Add(new Historia(uusiLaatikko));
            return uusiLaatikko;
        }

        private void Undo()
        {
            if (historia.Count > 0)
            {
                redo.Add(historia.Last());
                historia.Last().Undo();
                historia.Remove(historia.Last());
            }
        }

        private void Redo()
        {
            if (redo.Count > 0) {
                Historia muutettava = redo.Last();
                TextBox uusiLaatikko = LisaaTietoLaatikko(muutettava.ToString());
                muutettava.Redo(uusiLaatikko);
                redo.Remove(muutettava);
                }
        }

        private void textBox_TextChanged(Object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Size size = TextRenderer.MeasureText(textBox.Text, textBox.Font);
            ScaalaaBoxiTeksti(textBox);
        }

        private void ScaalaaBoxiTeksti(TextBox kuka)
        {
            Size size = TextRenderer.MeasureText(kuka.Text, kuka.Font);
            kuka.Width = size.Width;
            kuka.Height = size.Height+5;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            return;
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

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void FlowPanelDoubleClickListener(object sender, EventArgs e)
        {
            Undo();
        }
    }
    //textrenderer.mesureText();
}
