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
    public partial class SLY3Form : Form
    {
        public Form InputDisplay;
        public sly3 game;

        public SLY3Form(sly3 game)
        {
            this.game = game;
            InitializeComponent();

            positionsComboBox.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            positionsComboBox.Text = "1";

            game.SetupInputDisplayMemorySubs();
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

        private void loadPosButton_Click(object sender, EventArgs e)
        {
            game.selectedPositionIndex = int.Parse(positionsComboBox.Text);
            game.LoadPosition();
        }

        private void savePosButton_Click(object sender, EventArgs e)
        {
            game.selectedPositionIndex = int.Parse(positionsComboBox.Text);
            game.SavePosition();
        }

        private void coinsTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    game.SetBoltCount(uint.Parse(coinsTextBox.Text));
                }
                catch
                {
                    MessageBox.Show("Please enter a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void positionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SLY3Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cleanup when form closes
            if (game.InputsTimer != null)
            {
                game.InputsTimer.Stop();
            }
            if (game.DiscordTimer != null)
            {
                game.DiscordTimer.Stop();
            }
        }
    }
}
