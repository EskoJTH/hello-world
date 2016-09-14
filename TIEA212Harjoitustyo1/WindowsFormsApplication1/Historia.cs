using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    
    class Historia
    {
        private string text;
        private bool poistettu = false;
        private TextBox lahde;
        public Historia(TextBox lahde)
        {
            this.text = lahde.Text;
            this.lahde = lahde;
        }

        public void Poista()
        {
            if (!poistettu)
            {
                if (lahde != null)
                {
                    this.poistettu = false;
                    lahde.Dispose();
                }
             }
        }

        public void Undo()
        {
            if (lahde != null)
            {
                lahde.Dispose();
            }
        }

        public void Redo(TextBox tama)
        {
            lahde=tama;
        }

        public string ToString()
        {
            return text;
        }
    }
}
