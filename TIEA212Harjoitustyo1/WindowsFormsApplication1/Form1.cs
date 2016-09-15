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
    /// Ohjelma classin osa jossa suurin osa itse tehdystä koodista on
    /// </summary>
    public partial class Ohjelma : Form
    {
        private List<Historia> historia = new List<Historia>();
        private List<Historia> redo = new List<Historia>();
        private List<String> jarjestys = new List<String>();

        /// <summary>
        /// Luo ohjelman pääikkunan ja siihen kuuluvat komponentit.
        /// </summary>
        public Ohjelma()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lisää painikkeen painalluskuuntelia.
        /// </summary>
        /// <param name="sender">Olio josta painallus kuultiin.</param>
        /// <param name="e">Tapahtuma.</param>
        private void button1_Click(object sender, EventArgs e)
        {         
            LisaaTietoLaatikko();
        }

        /// <summary>
        /// Lisää tekstiä sisältävän laatikon, jolle ei ole erikseen määritetty tekstiä.
        /// </summary>
        private void LisaaTietoLaatikko()
        {
            LisaaTietoLaatikko(textBox1.Text);
        }

        /// <summary>
        /// Lisää tekstiä sisältävän laatikon, jolle on erikseen määritetty teksti.
        /// </summary>
        /// <param name="teksti">Mikä teksti laatikkoon tallennetaan.</param>
        /// <returns>Viite luotuun laatikkoon.</returns>
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

        /// <summary>
        /// Poistaa viimeksi lisätyn olin ja tallentaa sen listaan, josta se voitaisiin tulevaisuudessa tarvittaessa hakea Redo toiminnolla.
        /// Tätä ohjelmaa varten toimii sekä undo että poista toimintona, koska ei ollut erikseen määritelty miten toiminnot kuuluisi tehdä.
        /// </summary>
        private void Undo()
        {
            if (historia.Count > 0)
            {
                redo.Add(historia.Last());
                historia.Last().Undo();
                historia.Remove(historia.Last());
            }
        }

        /// <summary>
        /// Hakee viimeksi poistetun tai undo:tun laatikon tekstin ja lisää sen takaisin ohjelmaan.
        /// </summary>
        private void Redo()
        {
            if (redo.Count > 0) {
                Historia muutettava = redo.Last();
                TextBox uusiLaatikko = LisaaTietoLaatikko(muutettava.ToString());
                muutettava.Redo(uusiLaatikko);
                redo.Remove(muutettava);
                }
        }

        /// <summary>
        /// Muokkaa laatikossa olevan tekstin koon siihen sopivaksi tekstin muuttuessa
        /// </summary>
        /// <param name="sender">olio joka aiheutti Kutsun</param>
        /// <param name="e">tapahtuma</param>
        private void textBox_TextChanged(Object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            Size size = TextRenderer.MeasureText(textBox.Text, textBox.Font);
            ScaalaaBoxiTeksti(textBox);
        }

        /// <summary>
        ///  Suorittaa annetussa laatikossa olevan tekstin koon muuttamisen fonttiin sopivaksi.
        /// </summary>
        /// <param name="kuka"></param>
        private void ScaalaaBoxiTeksti(TextBox kuka)
        {
            Size size = TextRenderer.MeasureText(kuka.Text, kuka.Font);
            kuka.Width = size.Width;
            kuka.Height = size.Height+5;// +5 antaa sopivan tekstin jostain syystä.
        }

        /// <summary>
        /// Kuulee kun "jarjesta" painiketta painetaan ja sorttii näkyvät laatikot 1.pituus ja 2.aakkos järjestykseen.
        /// Jos kaikki valmiiksi järjestyksesä kääntää järjestyksen.
        /// </summary>
        /// <param name="sender">olilo joka aiheutti kutsun</param>
        /// <param name="e">tapahtuma</param>
        private void JarjestaButton_Click(object sender, EventArgs e)
        {
            List<String> lista = new List<String>();

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                lista.Add(ctrl.Text);
            }
            lista.Sort(); //aakkoseten mukaan
            lista.Sort((x,y) => x.Length.CompareTo(y.Length)); //pituuden mukaan
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

        /// <summary>
        /// kKuntelee painettiinko menussa exit nappulaa ja sulkee ohjelman.
        /// </summary>
        /// <param name="sender">Olio josta kutsuttiin.</param>
        /// <param name="e">Tapahtuma</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Kuulee undo napin painalluksen.
        /// Suorittaa Undo toiminnon.
        /// </summary>
        /// <param name="sender">Olio joka aiheutti kutsun.</param>
        /// <param name="e">Tapahtuma</param>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        /// <summary>
        /// Kuulee redo napin painalluksen.
        /// Suorittaa redo toiminnon.
        /// </summary>
        /// <param name="sender">Olio joka aiheutti kutsun.</param>
        /// <param name="e">Tapahtuma</param>
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }

        /// <summary>
        /// Kuulee jos flowPanel:ia tuplaklikataan ja poistaa(Undo()) viimeksi lisätyn teksti laatikon.
        /// </summary>
        /// <param name="sender">olio josta kutsu aiheutui.</param>
        /// <param name="e">tTapahtuma</param>
        private void FlowPanelDoubleClickListener(object sender, EventArgs e)
        {
            Undo();
        }

        /// <summary>
        /// Suorittaa about menu nappulan toiminnan. Eli avaa AboutBox:in
        /// </summary>
        /// <param name="sender">Mistä tapahtuma tuli.</param>
        /// <param name="e">Tapahtuma.</param>
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 poksi = new AboutBox1();
                poksi.ShowDialog();
        }
    }
}
