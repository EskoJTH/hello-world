using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viikkotehtava3
{
    public partial class Form1 : Form
    {
        private SoundPlayer Player = new SoundPlayer();

        public Form1()
        {
            InitializeComponent();
            try
            {
                this.Player.Stream = Viikkotehtava3.Properties.Resources.Viikkoteht_v_3_taso_1_m;
                this.Player.PlayLooping();
                userControl11.BringToFront();
                userControl12.SendToBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error playing sound");
            }
        }
    }
}
