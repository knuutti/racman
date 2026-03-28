using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace racman
{
    public partial class Sly1Speedrun : Form
    {
        private const string PrefersAutosplitterKey = "prefersAutosplitter";
        private const string PrefersAlwaysOnTopKey = "prefersAlwaysOnTop";

        public Form InputDisplay;
        public sly1 game;
        public string gameNameId;
        public AutosplitterHelper autosplitter;

        public Sly1Speedrun(sly1 game)
        {
            this.game = game;
            InitializeComponent();

            ApplySavedPreferences();

            game.SetupInputDisplayMemorySubs();

            if (func.api is Ratchetron r)
            {
                r.setDisconnectCallback(() =>
                {
                    DisconnectGame(false);
                });

                r.setReconnectCallback(() =>
                {
                    ReconnectGame();
                });
            }
        }

        private void inputDisplayButton_Click(object sender, EventArgs e)
        {
            OpenInputDisplay();
        }

        private void OpenInputDisplay()
        {
            if (InputDisplay == null || InputDisplay.IsDisposed)
            {
                InputDisplay = new InputDisplay();
                InputDisplay.Show();
            }
            else
            {
                InputDisplay.Focus();
            }
        }

        private void DisconnectGame(bool closeInputDisplay = true)
        {
            if (game.api is Ratchetron ratchetron)
            {
                if (autosplitter != null)
                {
                    autosplitter.Stop();
                    autosplitter = null;
                }
                ratchetron.ReleaseAllSubs();
            }
            CloseAdditionalWindows(closeInputDisplay);
        }

        private void ApplySavedPreferences()
        {
            var prefersAutosplitter = bool.TryParse(func.GetConfigData("config.txt", PrefersAutosplitterKey), out bool autosplitterEnabled) && autosplitterEnabled;
            var prefersAlwaysOnTop = bool.TryParse(func.GetConfigData("config.txt", PrefersAlwaysOnTopKey), out bool alwaysOnTopEnabled) && alwaysOnTopEnabled;

            autosplitterCheckbox.Checked = prefersAutosplitter;
            alwaysOnTopCheckBox.Checked = prefersAlwaysOnTop;
        }

        private void CloseAdditionalWindows(bool closeInputDisplay = true)
        {
            if (closeInputDisplay && InputDisplay != null && !InputDisplay.IsDisposed)
            {
                InputDisplay.Close();
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
                    if (game.api.getGameTitleID() != this.gameNameId)
                    {
                        Console.WriteLine("Different game loaded.");
                        return;
                    }
                    Console.WriteLine(game.api.getGameTitleID());
                    pid = game.api.getCurrentPID();
                    if (pid != 0)
                    {
                        Console.WriteLine($"Sly 2: Game detected after {attempts * 3} seconds (PID: {pid})");
                    }
                    else
                    {
                        Console.WriteLine($"Sly 2: Still waiting for game... ({attempts * 3}s elapsed)");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Sly 2: Error checking game status: {ex.Message}");
                }
            }

            if (pid == 0)
            {
                Console.WriteLine("Sly 2: Game did not start within 90 seconds");
                game.api.Notify("Sly 2: Reconnection timeout");
                return;
            }

            // Update PID for new game session
            AttachPS3Form.pid = pid;
            game.pid = pid;

            // Give game extra time to fully initialize
            Thread.Sleep(2000);

            // Re-establish memory subscriptions

            // Restart input timer if needed
            if (InputDisplay != null && !InputDisplay.IsDisposed)
            {
                game.InputsTimer.Start();
            }

            // Restart autosplitter if it was running
            if (autosplitterCheckbox.Checked)
            {
                Console.WriteLine("Restarting autosplitter...");
                autosplitter = new AutosplitterHelper();
                autosplitter.StartAutosplitterForGame(this.game);
                Console.WriteLine("Autosplitter restarted successfully.");
            }

            game.SetupInputDisplayMemorySubs();

            game.api.Notify($"SluMAN v{Assembly.GetEntryAssembly().GetName().Version.ToString(3)} (Speedrun Mode)");
            Console.WriteLine("Game reconnected.");
        }

        private void alwaysOnTopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void inputDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenInputDisplay();
        }

        private void Sly1Speedrun_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.AttachPS3Form.Visible == false)
            {
                Program.AttachPS3Form.Close();
                Environment.Exit(0);
            }
        }
    }
}
