using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace viikko1
{
    public partial class Form1 : Form
    {
        //yhdenmittainen Historia koska enempää ei vaadittu
        private HistoryAction undo = new HistoryAction();

        /// <summary>
        /// initialisoi käyttöliittymän
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lisää yhden labelin flowlayout paneeliin.
        /// </summary>
        /// <param name="teksti">data jonka labeli sisältää.</param>
        private void lisaaLabel(string teksti)
        {
            if (teksti.Length > 0)
            {
                Label label = new Label();
                label.Text = teksti;
                label.BackColor = Color.Turquoise;
                label.AutoSize = true;
                label.Padding = new System.Windows.Forms.Padding(7);
                label.BorderStyle = BorderStyle.Fixed3D;
                label.Click += OmaLabeclickListener;
                flowLayoutPanel1.Controls.Add(label);
                label.Show();
            }
        }


        /// <summary>
        /// Luo uuden about ikkunan ja tuo sen näkyville
        /// </summary>
        /// <param name="sender">nappula jota painettiin</param>
        /// <param name="e"></param>
        private void AvaaAbout(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.Show();
        }

        /// <summary>
        /// Sulkee ohjelman
        /// </summary>
        /// <param name="sender">exit valinta valikossa</param>
        /// <param name="e"></param>
        private void Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// kutsutaan kun "lisää nappulaa painetaan"
        /// </summary>
        /// <param name="sender">lisää nappula</param>
        /// <param name="e"></param>
        private void lisaaTekstiNappula(object sender, EventArgs e)
        {
            string teksti = textBox1.Text.Trim();
            lisaaLabel(teksti);

            undo.undo = true;
            undo.existor = true;
            undo.data = teksti;
            undo.lisays = true;
        }

        /// <summary>
        /// Sorttii labelit aakkosjärjestykseen. Kutsutaan kun "Järjestä" nappulaa painetaan
        /// </summary>
        /// <param name="sender">Järjestä nappulan controlli</param>
        /// <param name="e"></param>
        private void SortLabels(object sender, EventArgs e)
        {
            List<String> lista = new List<String>();

            foreach (Control ctrl in flowLayoutPanel1.Controls)//Otetaan listaan talteen kaiki Labelien tekstit
            {
                lista.Add(ctrl.Text);
            }
            lista.Sort(); //aakkoseten mukaan järjestetty

            for (int i = 0; i < lista.Count; i++)
            {
                flowLayoutPanel1.Controls[i].Text = lista[i];
            }
        }

        /// <summary>
        /// Pistaa tuplaklikatessa floylayout panelia.
        /// </summary>
        /// <param name="sender">Floylayout paneeli</param>
        /// <param name="e"></param>
        private void FlowlayotyPanel_click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count > 0)
            {
                undo.data = flowLayoutPanel1.Controls[flowLayoutPanel1.Controls.Count - 1].Text;
                undo.undo = true;
                undo.lisays = false;
                undo.existor = true;

                flowLayoutPanel1.Controls[flowLayoutPanel1.Controls.Count - 1].Dispose();
            }
        }

        /// <summary>
        /// Tätämetodia kutsutaan kun kuullaan floulayout paneeliin lisätysta labelista klikki.
        /// poistaa viimeisen labelin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OmaLabeclickListener(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            TextBox textbox = new TextBox();
            string teksti = label.Text;
            label.Dispose();
            textbox.BackColor = Color.Aqua;
            textbox.AutoSize = true;
            textbox.Padding = new System.Windows.Forms.Padding(7);
            textbox.BorderStyle = BorderStyle.Fixed3D;
            textbox.Text = teksti;

            flowLayoutPanel1.Controls.Add(textbox);

            textbox.Select();
            textbox.KeyDown += EditingReady;
            textbox.LostFocus += textBoxLeft;
        }

        /// <summary>
        /// Kutsutaan kun kuullaan fokusin lähteneen textboksista. käyttää left sanasta huolimatta LostFocus kuunteliaa. 
        /// Muutta textboxin labeliksi.
        /// </summary>
        /// <param name="sender">Textbox olio josta karattiin.</param>
        /// <param name="e"></param>
        public void textBoxLeft(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            lisaaLabel(textbox.Text);
            textbox.KeyDown -= EditingReady;
            textbox.LostFocus -= textBoxLeft;
            textbox.Dispose();
        }

        /// <summary>
        /// Kutsutaan kun havaitaan näppäinpainallus ja muuttaa textboxin labeliksi jos painallus oli entter tai esc
        /// </summary>
        /// <param name="sender">Textbox olio josta karattiin.</param>
        /// <param name="e"></param>
        public void EditingReady(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
            {
                TextBox textbox = (TextBox)sender;
                lisaaLabel(textbox.Text);
                textbox.KeyDown -= EditingReady;
                textbox.LostFocus -= textBoxLeft;
                textbox.Dispose();
            }



        }


        /// <summary>
        /// Poistaa viimeksi lisätyn tai poistetun labelin. Omaa vain yhden labelin pituisen muistin joten toimii vain kerran.
        /// </summary>
        /// <param name="sender">Nappula jota painettiin.</param>
        /// <param name="e"></param>
        private void Undo(object sender, EventArgs e)
        {
            if (undo.existor && undo.undo)
            {


                if (undo.lisays)
                {
                    for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
                        if (flowLayoutPanel1.Controls[i].Text == undo.data)
                        {
                            flowLayoutPanel1.Controls[i].Dispose();
                            break;
                        }
                }
                else
                {
                    lisaaLabel(undo.data);
                }
                undo.undo = false;
            }

        }

        /// <summary>
        /// Tekee takaperin edellisen undo käskyn jos se oli edellinen käskky.
        /// </summary>
        /// <param name="sender">Nappula jossa painettiin.</param>
        /// <param name="e"></param>
        private void Redo(object sender, EventArgs e)
        {
            if (undo.existor && !undo.undo)
            {
                if (!undo.lisays)
                {
                    for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
                        if (flowLayoutPanel1.Controls[i].Text == undo.data)
                        {
                            flowLayoutPanel1.Controls[i].Dispose();
                            break;
                        }
                }
                else
                {
                    lisaaLabel(undo.data);
                }
                undo.undo = true;

            }
        }

        /// <summary>
        /// Jarjestaa flowlayout panelin alkiot pituusjärjestykseen ja sen sisällä aakkosjärjestykeen.
        /// </summary>
        /// <param name="sender">Nappula jota painettiin</param>
        /// <param name="e"></param>
        private void JarjestaPituus(object sender, EventArgs e)
        {
            List<String> lista = new List<String>();

            foreach (Control ctrl in flowLayoutPanel1.Controls)//Otetaan listaan talteen kaiki Labelien tekstit
            {
                lista.Add(ctrl.Text);
            }

            lista.Sort(); //aakkoseten mukaan järjestetty
            lista.Sort((x, y) => x.Length.CompareTo(y.Length)); //pituuden mukaan

            for (int i = 0; i < lista.Count; i++)
            {
                flowLayoutPanel1.Controls[i].Text = lista[i];
            }

        }
    }

    /// <summary>
    /// Tallentaa historian tarviteman datan sisälleen yhteen paikkaan kivasti. voisi köyttää gettiä ja settiä, mutta tässä tilanteessa se olisi vain extra kirjoittamista.
    /// </summary>
    class HistoryAction
    {
        public bool undo = true;
        public bool existor;
        public bool lisays;
        public string data;

        public HistoryAction()
        {
            this.lisays = true;
            this.data = "";
            this.existor = false;
        }

        public HistoryAction(string data, bool poisto)
        {
            this.lisays = poisto;
            this.data = data;
            this.existor = true;
        }
    }
}
