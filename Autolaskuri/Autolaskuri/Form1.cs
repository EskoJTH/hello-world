using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autolaskuri
{

    public partial class Autolaskuri : Form
    {
        private Bitmap bike = new Bitmap(Properties.Resources.bike);
        private Bitmap car = new Bitmap(Properties.Resources.car);

        int henkiloAutoLkm;
        int polkupyoratLkm;

        private int henkiloautot
        {
            get { return henkiloAutoLkm; }
            set { henkiloAutoLkm = value;
                Kuva auto = new Kuva(car);
                auto.BringToFront();
                this.Controls.Add(auto);
            }
        }
        private int polkupyorat
        {
            get { return polkupyoratLkm; }
            set { polkupyoratLkm = value;
                Kuva pyora = new Kuva(bike);
                pyora.BringToFront();
                this.Controls.Add(pyora);
            }
        }

        public Autolaskuri()
        {
            InitializeComponent();
        }

        private void henkiloautoClick(object sender, EventArgs e)
        {
            henkiloautot++;
            HenkiloautoLabel.Text=henkiloautot.ToString();
            

        }

        private void PolkupyoraClick(object sender, EventArgs e)
        {
            polkupyorat++;
            polkupyoraLabel.Text = polkupyorat.ToString();
        }

        private void AutoBoxClick(object sender, EventArgs e)
        {
            AboutBox1 aboutbox = new AboutBox1();
            aboutbox.ShowDialog();
        }

        private void Vari(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Color color = colorDialog1.Color;
            this.BackColor = color;

        }

        private void UusiIkkunaClick(object sender, EventArgs e)
        {
            Autolaskuri autolaskuri = new Autolaskuri();
            autolaskuri.ShowDialog();
        }

    }
}
