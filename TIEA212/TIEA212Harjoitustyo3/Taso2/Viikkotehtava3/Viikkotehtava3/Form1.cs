using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pollo
{
    public partial class Form1 : Form
    {
        private SoundPlayer Player = new SoundPlayer();

        public Form1()
        {
            InitializeComponent();
            try
            {
                this.Player.Stream = Pollo.Properties.Resources.Viikkoteht_v_3_taso_1_m;
                this.Player.PlayLooping();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error playing sound");
            }

        }
    }
}
