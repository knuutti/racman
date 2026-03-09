using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace racman
{
    public partial class SLY3Speedrun : Form
    {
        public Form InputDisplay;
        public Form GadgetsWindow;
        public sly3 game;
        public AutosplitterHelper autosplitter;

        public SLY3Speedrun(sly3 game)
        {
            this.game = game;
            InitializeComponent();

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

                    // Restart autosplitter if it was running
                    if (autosplitterCheckbox.Checked)
                    {
                        Console.WriteLine("Sly 3: Restarting autosplitter...");
                        autosplitter.Stop();
                        autosplitter = new AutosplitterHelper();
                        autosplitter.StartAutosplitterForGame(this.game);
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

        private void AutosplitterCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!autosplitterCheckbox.Checked)
            {
                autosplitter.Stop();
                autosplitter = null;
            }
            else
            {
                autosplitter = new AutosplitterHelper();
                autosplitter.StartAutosplitterForGame(this.game);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void alwaysTopButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!alwaysTopButton.Checked)
            {
                this.TopMost = false;
                if (InputDisplay != null && !InputDisplay.IsDisposed)
                {
                    InputDisplay.TopMost = false;
                }
                if (GadgetsWindow != null && !GadgetsWindow.IsDisposed)
                {
                    GadgetsWindow.TopMost = false;
                }

            }
            else
            {
                this.TopMost = true;
                if (InputDisplay != null && !InputDisplay.IsDisposed)
                {
                    InputDisplay.TopMost = true;
                }
                if (GadgetsWindow != null && !GadgetsWindow.IsDisposed)
                {
                    GadgetsWindow.TopMost = true;
                }
            }
        }

        private void loadRunFileButton_Click(object sender, EventArgs e)
        {
            if (runFileComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a run file to load.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            LoadRunFileGadgets();
        }

        private void LoadRunFileGadgets()
        {
            string episodeKey = GetEpisodeKey(runFileComboBox.SelectedItem.ToString());
            
            // Load gadget data from config
            string gadgetHex = func.GetConfigData("config.txt", episodeKey + "_GadgetUnlocks");
            string bindingHex = func.GetConfigData("config.txt", episodeKey + "_GadgetBindings");
            
            if (!string.IsNullOrEmpty(gadgetHex))
            {
                try
                {
                    byte[] gadgetBytes = StringToByteArray(gadgetHex);
                    byte[] bindingBytes = StringToByteArray(bindingHex);
                    
                    game.SetGadgetUnlocks(gadgetBytes);
                    
                    // Only set bindings if we have binding data
                    if (!string.IsNullOrEmpty(bindingHex))
                    {
                        game.SetGadgetBindings(bindingBytes);
                    }
                    
                    game.api.Notify($"SluMAN v{Assembly.GetEntryAssembly().GetName().Version.ToString(3)}: Loading {runFileComboBox.SelectedItem} run file.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading gadget configuration: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"No saved gadget configuration found for {runFileComboBox.SelectedItem}", "No Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Convert episode display name to a safe config key prefix
        private string GetEpisodeKey(string episodeName)
        {
            switch (episodeName)
            {
                case "Episode 1": return "Episode1";
                case "Episode 2": return "Episode2";
                case "Episode 3": return "Episode3";
                case "Episode 4": return "Episode4";
                case "Episode 5": return "Episode5";
                case "Episode 6 (No CE)": return "Episode6_NoCE";
                case "Episode 6 (CE)": return "Episode6_CE";
                default: return "Episode1"; // fallback
            }
        }

        // Convert hex string to byte array
        private static byte[] StringToByteArray(string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }
    }
}
