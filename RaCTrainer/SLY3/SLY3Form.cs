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

            // Setup disconnect/reconnect callbacks for XMB transitions
            if (func.api is Ratchetron r)
            {
                r.setDisconnectCallback(() =>
                {
                    // Release memory subs
                    if (game.api is Ratchetron ratchetron)
                    {
                        ratchetron.ReleaseAllSubs();
                    }

                    // TODO: Optimize reset time by disconnecting Ratchetron 
                    // before closing the game
                });

                r.setReconnectCallback(() =>
                {
                    int pid = 0;
                    int attempts = 0;
                    int maxAttempts = 30; // 90 seconds max wait
                    
                    while (pid == 0 && attempts < maxAttempts)
                    {
                        Thread.Sleep(3000);
                        attempts++;
                        
                        try
                        {
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
                    
                    game.api.Notify("Sly 3 reconnected!");
                    Console.WriteLine("Sly 3: Reconnection complete");
                });
            }
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
