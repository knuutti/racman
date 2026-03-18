using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace racman
{
    public partial class SLY2Speedrun : Form
    {
        public Form InputDisplay;
        public Form GadgetsWindow;
        public sly2 game;
        public AutosplitterHelper autosplitter;

        public SLY2Speedrun(sly2 game)
        {
            this.game = game;
            InitializeComponent();
            game.SetupInputDisplayMemorySubs();

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
