using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using System.Net.Http;
using System.Threading;
using System.Reflection;

namespace racman
{
    public partial class SLY3Form : Form
    {
        private const string PrefersAlwaysOnTopKey = "prefersAlwaysOnTop";

        public Form InputDisplay;
        public Form GadgetsWindow;
        public sly3 game;
        public string gameNameId;

        public SLY3Form(sly3 game, string gameNameId = "NPEA00343")
        {
            this.game = game;
            InitializeComponent();

            mapComboBox.Items.AddRange(game.GetMapNames());
            mapComboBox.SelectedIndex = 0;

            game.SetupInputDisplayMemorySubs();
            game.SetupWebManPopUp();

            game.CheckRunFileConfig();

            if (func.api is Ratchetron r)
            {
                r.setDisconnectCallback(() => { DisconnectGame(false); });

                r.setReconnectCallback(() => { ReconnectGame(); });
            }

            this.gameNameId = gameNameId;
        }

        private void ApplySavedPreferences()
        {
            var prefersAlwaysOnTop = bool.TryParse(func.GetConfigData("config.txt", PrefersAlwaysOnTopKey), out bool alwaysOnTopEnabled) && alwaysOnTopEnabled;
            alwaysOnTopCheckBox.Checked = prefersAlwaysOnTop;
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
        }

        private void savePosButton_Click(object sender, EventArgs e)
        {
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
            // Make sure all child forms are closed
            if (InputDisplay != null && !InputDisplay.IsDisposed)
            {
                InputDisplay.Close();
            }
            if (GadgetsWindow != null && !GadgetsWindow.IsDisposed)
            {
                GadgetsWindow.Close();
            }
            
            // Stop timers
            if (game.InputsTimer != null)
            {
                game.InputsTimer.Stop();
            }
            if (game.DiscordTimer != null)
            {
                game.DiscordTimer.Stop();
            }

            try
            {
                if (game.api is Ratchetron r)
                {
                    r.ReleaseAllSubs();
                }
                game.api.Disconnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during disconnect: {ex.Message}");
            }
            
            Application.Exit();
            
            Environment.Exit(0);
        }

        private void HandleDisconnect()
        {
            if (game.api is Ratchetron r)
            {
                r.ReleaseAllSubs();
            }
            game.api.Disconnect();
            Console.WriteLine("Sly 3: Full cleanup on form close");
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void switchGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisconnectGame();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void fastReloadButton_Click(object sender, EventArgs e)
        {
            game.TriggerGameLoad((uint)0);
        }

        private void fullReloadButton_Click(object sender, EventArgs e)
        {
            game.TriggerGameLoad();
        }

        private void loadRunFileButton_Click(object sender, EventArgs e)
        {

        }

        private void webMANShortcutsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void skipCinematicsButton_Click(object sender, EventArgs e)
        {
            game.SkipCinematic();
        }

        private void alwaysOnTopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            func.ChangeFileLines("config.txt", alwaysOnTopCheckBox.Checked ? "true" : "false", PrefersAlwaysOnTopKey);
            if (!alwaysOnTopCheckBox.Checked)
            {
                this.TopMost = false;

            }
            else
            {
                this.TopMost = true;
            }
        }

        private void loadJobButton_Click(object sender, EventArgs e)
        {
            game.LoadJob(jobComboBox.Text);
        }

        private void abandonJobButton_Click(object sender, EventArgs e)
        {
            game.AbandonJob(jobComboBox.Text);
        }

        private void setCoinsButton_Click(object sender, EventArgs e)
        {
            SetCoinsFromTextBox();

        }

        private void coinsTextBox_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void DisconnectGame(bool closeInputDisplay = true)
        {
            if (game.api is Ratchetron ratchetron)
            {
                ratchetron.ReleaseAllSubs();
            }
            CloseAdditionalWindows(closeInputDisplay);
        }

        private void CloseAdditionalWindows(bool closeInputDisplay = true)
        {
            if (closeInputDisplay && InputDisplay != null && !InputDisplay.IsDisposed)
            {
                InputDisplay.Close();
            }
            if (GadgetsWindow != null && !GadgetsWindow.IsDisposed)
            {
                GadgetsWindow.Close();
            }
        }

        private void ReconnectGame()
        {
            int pid = 0;
            int attempts = 0;
            int maxAttempts = 30;

            while (pid == 0 && attempts < maxAttempts)
            {
                Thread.Sleep(3000);
                attempts++;

                try
                {
                    if (game.api.getGameTitleID() != gameNameId)
                    {
                        Console.WriteLine("Different game detected.");
                        return;
                    }

                    pid = game.api.getCurrentPID();
                    if (pid != 0)
                    {
                        Console.WriteLine($"Sly 3: Game detected after {attempts * 3} seconds (PID: {pid})");
                    }
                    else
                    {
                        Console.WriteLine($"Sly 3: Still waiting for game... ({attempts * 3}s elapsed)");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Sly 3: Error checking game status: {ex.Message}");
                }
            }

            if (pid == 0)
            {
                Console.WriteLine("Sly 3: Game did not start within 90 seconds");
                game.api.Notify("Sly 3: Reconnection timeout");
                return;
            }

            // Update PID for new game session
            AttachPS3Form.pid = pid;
            game.pid = pid;

            // Give game extra time to fully initialize
            Thread.Sleep(2000);

            // Re-establish memory subscriptions
            game.SetupInputDisplayMemorySubs();

            // Restart input timer if needed
            if (InputDisplay != null && !InputDisplay.IsDisposed)
            {
                game.InputsTimer.Start();
            }

            game.api.Notify($"SluMAN v{Assembly.GetEntryAssembly().GetName().Version.ToString(3)} (Practice Mode)");
            Console.WriteLine("Sly 3: Reconnection complete");
        }

        private void SetCoinsFromTextBox()
        {
            var coinsText = coinsTextBox.Text;
            // try to parse the input as an integer
            if (int.TryParse(coinsText, out int coins))
            {
                game.SetCoinCount(coins);
            }
            else
            {
                MessageBox.Show("Please enter a valid number for coins.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetHealthFromTextBox()
        {
            var healthText = healthTextBox.Text;
            // try to parse the input as an integer
            if (int.TryParse(healthText, out int health))
            {
                game.SetHealth(health);
            }
            else
            {
                MessageBox.Show("Please enter a valid number for health.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void healthTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void setHealthButton_Click(object sender, EventArgs e)
        {
            SetHealthFromTextBox();
        }



        private void SLY3Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.AttachPS3Form.Visible == false)
            {
                Program.AttachPS3Form.Close();
                Environment.Exit(0);
            }
        }

        private void powerOffPS3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (game.api is Ratchetron r)
            {
                var dialogResult = MessageBox.Show("Do you want to turn off your PS3?", "Power Off PS3", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DisconnectGame();
                    WebMAN.TurnOffPS3(func.api.GetIP());
                    this.Close();
                    Program.AttachPS3Form.Show();
                }

            }
        }

        private void rebootPS3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (game.api is Ratchetron r)
            {
                var dialogResult = MessageBox.Show("Do you want to reboot your PS3?", "Reboot PS3", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DisconnectGame();
                    WebMAN.RebootPS3(func.api.GetIP());
                    this.Close();
                    Program.AttachPS3Form.Show();
                }
            }
        }
    }
}
