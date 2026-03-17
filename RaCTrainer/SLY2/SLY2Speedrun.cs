using racman;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SluMAN.SLY2
{
    public partial class SLY2Speedrun : Form
    {
        public Form InputDisplay;
        public Form GadgetsWindow;
        public sly2 game;
        private int webManLoadSubId = -1;
        public SLY2Speedrun()
        {
            InitializeComponent();
        }

        private void SLY2Speedrun_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (InputDisplay == null || InputDisplay.IsDisposed)
            {
                InputDisplay = new InputDisplay();
                InputDisplay.Show();
                game.InputsTimer.Start();
            }
            else
            {
                InputDisplay.Focus();
            }
        }
    }
}
