using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// @author Esko Hanell
/// @version 15.9.2016
/// </summary>
namespace WindowsFormsApplication1
{
    
    /// <summary>
    /// Historia luokka joka tallentaa yksittäisen tekstilaatikon sisältämän tiedon.
    /// </summary>
    class Historia
    {
        private string text;
        private TextBox lahde;

        /// <summary>
        /// konstruktoi ilmentymän historia oliosta ja tallenttaa siihen tiedot annetusta text boxista.
        /// </summary>
        /// <param name="lahde">TextBox jonka tiedot tallennetaan olioon</param>
        public Historia(TextBox lahde)
        {
            this.text = lahde.Text;
            this.lahde = lahde;
        }

        /// <summary>
        /// Poistaa laatikon jossa tiedot oli näkyvillä. jättää tiedot talteen.
        /// </summary>
        public void Undo()
        {
            if (lahde != null)
            {
                lahde.Dispose();
            }
        }

        /// <summary>
        /// Sijoittaa tähän olioon laatikon, jossa tiedot on näkyvillä.
        /// </summary>
        /// <param name="tama">uusi textBox joka liitetään tähän olioon</param>
        public void Redo(TextBox tama)
        {
            lahde=tama;
        }

        /// <summary>
        /// Antaa olioon tallennetun tekstin.
        /// </summary>
        /// <returns>Teksti joka oliossa on tallessa .</returns>
        override
        public string ToString()
        {
            return text;
        }
    }
}
