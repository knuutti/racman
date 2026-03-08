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
    }
}
