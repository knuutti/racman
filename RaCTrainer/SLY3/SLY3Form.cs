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
        public Form GadgetsWindow;
        public sly3 game;

        public SLY3Form(sly3 game)
        {
            this.game = game;
            InitializeComponent();

            positionsComboBox.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            positionsComboBox.Text = "1";

            mapComboBox.Items.AddRange(game.GetMapNames());
            mapComboBox.SelectedIndex = 0;

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
                    game.SetCoinCount(int.Parse(coinsTextBox.Text));
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

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void switchGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.AttachPS3Form.Show();
        }

        private void configureButtonCombosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigureCombos configureCombos = new ConfigureCombos();
            configureCombos.ShowDialog();
        }

        private void inputDisplayToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void memoryUtilitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemoryForm memoryForm = Application.OpenForms["MemoryForm"] as MemoryForm;

            if (memoryForm != null)
            {
                memoryForm.Activate();
            }
            else
            {
                memoryForm = new MemoryForm();
                memoryForm.Show();
            }
        }

        private void loadMapButton_Click(object sender, EventArgs e)
        {
            game.LoadMap(mapComboBox.SelectedIndex);
        }

        private void gadgetsButton_Click(object sender, EventArgs e)
        {
            if (GadgetsWindow == null || GadgetsWindow.IsDisposed)
            {
                GadgetsWindow = new SLY3GadgetsForm(game);
                GadgetsWindow.FormClosed += GadgetsWindow_FormClosed;
                GadgetsWindow.Show();
            }
            else
            {
                GadgetsWindow.Focus();
            }
        }

        private void GadgetsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            GadgetsWindow = null;
        }
    }
}
