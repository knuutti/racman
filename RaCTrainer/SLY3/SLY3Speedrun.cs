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
            game.speedrunMode = true;

            game.CheckRunFileConfig();

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

                    game.api.Notify($"SluMAN v{Assembly.GetEntryAssembly().GetName().Version.ToString(3)} (Speedrun Mode)");
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

            }
            else
            {
                this.TopMost = true;
            }
        }

        private void loadRunFileButton_Click(object sender, EventArgs e)
        {
            if (runFileComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a run file to load.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            LoadCompleteRunFile();
        }

        private void LoadCompleteRunFile()
        {
            string episodeKey = GetEpisodeKey(runFileComboBox.SelectedItem.ToString());
            
            try
            {
                var runFileData = LoadRunFileDataFromConfig(episodeKey);
                
                if (runFileData == null)
                {
                    game.api.Notify("Error loading a run file: Config file not found.");
                    return;
                }
                
                game.SetSuckValue(runFileData.SuckValue);
                
                if (runFileData.MemoryData != null && runFileData.MemoryData.Length > 0)
                {
                    game.WriteMemoryRegion(runFileData.MemoryStartAddress, runFileData.MemoryData);
                }
                
                if (!string.IsNullOrEmpty(runFileData.MapName))
                {
                    game.SetMapName(runFileData.MapName);
                }
                
                game.SetSpawnLocation(runFileData.SpawnLocation);
                
                LoadRunFileGadgets();

                var loadType = (uint)Sly3Addresses.LoadTypes.RunFile;

                if (episodeKey == "Episode6_CE" || episodeKey == "Episode6_NoCE")
                {
                    game.SetJobState(4342, 1842, (int)-1);
                    loadType = (uint)Sly3Addresses.LoadTypes.Job;
                    if (episodeKey == "Episode6_CE")
                    {
                        game.SetEpisode6NoobMode();
                    }   
                } else
                {
                    SetTutorialComplete();
                }

                game.api.Notify($"SluMAN v{Assembly.GetEntryAssembly().GetName().Version.ToString(3)}: Loading {runFileComboBox.SelectedItem} run file.");

                game.TriggerGameLoad(loadType);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading complete run file: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Function for loading saved run file data from config
        private RunFileData LoadRunFileDataFromConfig(string episodeKey)
        {
            string mapName = func.GetConfigData("run_file_config.txt", episodeKey + "_MapName");
            string spawnLocationStr = func.GetConfigData("run_file_config.txt", episodeKey + "_SpawnLocation");
            string memoryDataHex = func.GetConfigData("run_file_config.txt", episodeKey + "_MemoryData");
            string memoryAddressStr = func.GetConfigData("run_file_config.txt", episodeKey + "_MemoryAddress");

            if (string.IsNullOrEmpty(mapName) && string.IsNullOrEmpty(memoryDataHex))
            {
                return null;
            }
            
            var runFileData = new RunFileData();
            
            runFileData.MapName = mapName;
            
            if (uint.TryParse(spawnLocationStr, out uint spawnLocation))
            {
                runFileData.SpawnLocation = spawnLocation;
            }
            
            if (!string.IsNullOrEmpty(memoryDataHex))
            {
                try
                {
                    runFileData.MemoryData = ConvertMemoryDataString(memoryDataHex);
                }
                catch
                {
                    runFileData.MemoryData = null;
                }
            }
            
            if (!string.IsNullOrEmpty(memoryAddressStr))
            {
                try
                {
                    runFileData.MemoryStartAddress = Convert.ToUInt32(memoryAddressStr, 16);
                }
                catch
                {
                    var (startAddress, size) = game.GetMemoryRegionForEpisode(episodeKey);
                    runFileData.MemoryStartAddress = startAddress;
                }
            }
            else
            {
                var (startAddress, size) = game.GetMemoryRegionForEpisode(episodeKey);
                runFileData.MemoryStartAddress = startAddress;
            }
            
            return runFileData;
        }

        private void SetTutorialComplete()
        {
            string memoryDataHex = func.GetConfigData("config.txt", "Episode0_MemoryData");
            string memoryAddressStr = func.GetConfigData("config.txt", "Episode0_MemoryAddress");   

            if (!string.IsNullOrEmpty(memoryDataHex) && !string.IsNullOrEmpty(memoryAddressStr))
            {
                try
                {
                    byte[] memoryData = ConvertMemoryDataString(memoryDataHex);
                    uint memoryAddress = Convert.ToUInt32(memoryAddressStr, 16);
                    game.WriteMemoryRegion(memoryAddress, memoryData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error setting tutorial complete: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadRunFileGadgets()
        {
            string episodeKey = GetEpisodeKey(runFileComboBox.SelectedItem.ToString());
            
            string gadgetHex = func.GetConfigData("config.txt", episodeKey + "_GadgetUnlocks");
            string bindingHex = func.GetConfigData("config.txt", episodeKey + "_GadgetBindings");
            
            if (!string.IsNullOrEmpty(gadgetHex))
            {
                try
                {
                    byte[] gadgetBytes = StringToByteArray(gadgetHex);
                    byte[] bindingBytes = StringToByteArray(bindingHex);
                    
                    game.SetGadgetUnlocks(gadgetBytes);
                    
                    if (!string.IsNullOrEmpty(bindingHex))
                    {
                        game.SetGadgetBindings(bindingBytes);
                    }
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

        public class RunFileData
        {
            public string MapName { get; set; }
            public uint SpawnLocation { get; set; }
            public byte[] MemoryData { get; set; }
            public uint MemoryStartAddress { get; set; }
            public float SuckValue { get; set; } = 0.0f;
        }

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
                default: return "Episode1";
            }
        }

        // Helper function for converting strings like "FFFF" to [0xFF, 0xFF] byte array
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

        // Helper function for converting (comma-separated) memory data to byte array
        private static byte[] ConvertMemoryDataString(string data)
        {
            var parts = data.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    
            byte[] bytes = new byte[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                bytes[i] = (byte)int.Parse(parts[i].ToString());
            }
            return bytes;
        }

        private void switchGameModeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (game.api is Ratchetron r)
            {
                r.ReleaseAllSubs();
            }
            this.Close();
            Program.AttachPS3Form.Show();
        }
    }
}
