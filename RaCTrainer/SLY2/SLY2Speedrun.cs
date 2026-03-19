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

            if (func.api is Ratchetron r)
            {
                r.setDisconnectCallback(() =>
                {
                    if (game.api is Ratchetron ratchetron)
                    {
                        ratchetron.ReleaseAllSubs();
                    }
                });

                r.setReconnectCallback(() =>
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
                    game.SetupInputDisplayMemorySubs();

                    // Restart input timer if needed
                    if (InputDisplay != null && !InputDisplay.IsDisposed)
                    {
                        game.InputsTimer.Start();
                    }

                    // Restart autosplitter if it was running
                    if (autosplitterCheckbox.Checked)
                    {
                        Console.WriteLine("Sly 2: Restarting autosplitter...");
                        autosplitter.Stop();
                        autosplitter = new AutosplitterHelper();
                        autosplitter.StartAutosplitterForGame(this.game);
                    }

                    game.api.Notify($"SluMAN v{Assembly.GetEntryAssembly().GetName().Version.ToString(3)} (Speedrun Mode)");
                    Console.WriteLine("Sly 2: Reconnection complete");
                });
            }
        }

        private void SLY2Speedrun_Load(object sender, EventArgs e)
        {

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

        private void alwaysOnTopCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!alwaysOnTopCheckBox.Checked)
            {
                this.TopMost = false;

            }
            else
            {
                this.TopMost = true;
            }
        }

        private void autosplitterCheckbox_CheckedChanged(object sender, EventArgs e)
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

        private void gadgetsButton_Click(object sender, EventArgs e)
        {
            if (GadgetsWindow == null || GadgetsWindow.IsDisposed)
            {
                GadgetsWindow = new Sly2Gadgets(game);
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
