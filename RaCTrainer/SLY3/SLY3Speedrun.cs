using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using System.Net.Http;
using System.Threading;

namespace racman
{
    public partial class SLY3Speedrun : Form
    {
        public Form InputDisplay;
        public Form GadgetsWindow;
        public sly3 game;

        public SLY3Speedrun(sly3 game)
        {
            this.game = game;
            InitializeComponent();
        }

        private void inputDisplayButton_Click(object sender, EventArgs e)
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
