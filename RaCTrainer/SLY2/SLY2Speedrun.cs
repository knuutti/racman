using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static racman.SLY3Speedrun;
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
            game.CheckRunFileConfig();

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

                var loadType = (uint)Sly2Addresses.LoadTypes.RunFile;

                game.api.Notify($"SluMAN v{Assembly.GetEntryAssembly().GetName().Version.ToString(3)}: Loading {runFileComboBox.SelectedItem} run file.");

                game.TriggerGameLoad(loadType);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading complete run file: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private RunFileData LoadRunFileDataFromConfig(string episodeKey)
        {
            string mapName = func.GetConfigData("data/s2_run_file_config.txt", episodeKey + "_MapName");
            string spawnLocationStr = func.GetConfigData("data/s2_run_file_config.txt", episodeKey + "_SpawnLocation");
            string memoryDataHex = func.GetConfigData("data/s2_run_file_config.txt", episodeKey + "_MemoryData");
            string memoryAddressStr = func.GetConfigData("data/s2_run_file_config.txt", episodeKey + "_MemoryAddress");

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

        private void LoadRunFileGadgets()
        {
            string episodeKey = GetEpisodeKey(runFileComboBox.SelectedItem.ToString());

            string gadgetHex = func.GetConfigData("config.txt", episodeKey + "_Sly2GadgetUnlocks");
            string bindingHex = func.GetConfigData("config.txt", episodeKey + "_Sly2GadgetBindings");

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
                case "Episode 6": return "Episode6";
                case "Episode 7": return "Episode7";
                case "Episode 8": return "Episode8";
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
    }
}
