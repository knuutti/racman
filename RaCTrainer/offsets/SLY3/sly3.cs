using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRPC;
using Timer = System.Windows.Forms.Timer;

namespace racman
{
    public class Sly3Addresses : IAddresses
    {
        // Unused RaC addresses
        public uint boltCount => 0x0;
        public uint currentPlanet => 0x0; 
        public uint loadPlanet => 0x0;  
        public uint mobyInstances => 0x0;
        public uint analogOffset => 0x0;
        public uint playerCoords => 0x0;

        public uint inputOffset => 0x5EC5AA;
        public uint analogOffsetLeft => 0x5EC5F0;
        public uint analogOffsetRight => 0x5EC61C;
        public uint coinCount => 0x6CC808;

        public uint playerEntityPointer => 0x5EC654;
        public uint transformOffset => 0x44; 
        public uint coordsOffsetX => 0x130; 
        public uint coordsOffsetY => 0x134; 
        public uint coordsOffsetZ => 0x138;

        public uint mapAOB => 0x78D2C8;
        public uint spawnLocation => 0x78D308;

        public uint loadType => 0x78D2C4;
        public uint loadTrigger => 0x78D2C0; // Set to 1 to trigger load

        public uint gadgetUnlocks => 0x6CC7F8;
        public uint gadgetBinds => 0x6CC7B0;

        public enum LoadTypes : uint
        {
            Fast = 0,
            Normal = 6,
            Reset = 15,
        }
    }

    public class sly3 : IGame
    {
        public static Sly3Addresses addr = new Sly3Addresses();

        public string[] mapList;
        public uint mapIndex;

        public struct MapData
        {
            public string naturalName;
            public string indicator;
            public uint defaultWarp;
            
            public MapData(string naturalName, string indicator, uint defaultWarp)
            {
                this.naturalName = naturalName;
                this.indicator = indicator;
                this.defaultWarp = defaultWarp;
            }
        }

        public MapData[] maps;

        public sly3(IPS3API api) : base(api)
        {
            this.maps = new MapData[]
            {
                new MapData("Main Menu", "Y$KFdvd_menu", 0),
                new MapData("Hazard Room", "Y$KFi_trainer", 424),
                new MapData("Venice Hub", "Y$KFv_ext", 44438),
                new MapData("Canal Chase", "Y$KFv_canal", 0),
                new MapData("Coffee House", "Y$KFv_apt", 0),
                new MapData("Opera House", "Y$KFv_gauntlet", 0),
                new MapData("Police Station", "Y$KFv_interpol", 0),
                new MapData("Outback Hub", "Y$KFo_ext", 44438),
                new MapData("Ayer's Rock", "Y$KFo_quarry", 0),
                new MapData("Oil Field", "Y$KFo_arena", 0),
                new MapData("Cave 1", "Y$KFo_cave_a", 0),
                new MapData("Cave 2", "Y$KFo_cave_b", 0),
                new MapData("Cave 3", "Y$KFo_cave_murray", 0),
                new MapData("Lemonade Bar", "Y$KFo_bar", 0),
                new MapData("Holland Hub", "Y$KFh_ext", 44438),
                new MapData("Hotel", "Y$KFh_hotel", 0),
                new MapData("Black Baron's Hangar", "Y$KFh_hangar_b", 0),
                new MapData("Cooper Gang Hangar", "Y$KFh_hangar_c", 0),
                new MapData("Team Belgium's Hangar", "Y$KFh_hangar_a", 0),
                new MapData("Sewer", "Y$KFh_sewer", 0),
                new MapData("Dogfight Arena", "Y$KFh_dogfight", 0),
                new MapData("China Hub", "Y$KFc_ext", 44438),
                new MapData("Intro", "Y$KFc_intro", 0),
                new MapData("Flashback", "Y$KFc_flashback", 0),
                new MapData("Tsao's Battleground", "Y$KFc_forest", 0),
                new MapData("Panda King's House", "Y$KFc_apt", 0),
                new MapData("Tsao's Business Center", "Y$KFc_hall_a", 0),
                new MapData("Palace", "Y$KFc_hall_b", 0),
                new MapData("Treasure Temple", "Y$KFc_tilt_hall", 0),
                new MapData("Pirate Hub", "Y$KFp_ext", 44438),
                new MapData("Sailing Map", "Y$KFp_at_sea", 0),
                new MapData("Underwater Shipwreck", "Y$KFp_dive", 0),
                new MapData("Dagger Island", "Y$KFp_island_map", 0),
                new MapData("Kaine Island", "Y$KFm_ext", 15022),
                new MapData("Underwater", "Y$KFm_underwater", 0),
                new MapData("Cooper Vault", "Y$KFm_vault", 0),
                new MapData("Gauntlet", "Y$KFm_gauntlet", 0),
                new MapData("Inner Sanctum", "Y$KFm_boss", 0)
            };
            
            // For compatibility with base class
            this.planetsList = new string[] { };
        }

        public override void ResetLevelFlags() { }
        public override void SetFastLoads(bool enabled = false) { }
        public override void ToggleInfiniteAmmo(bool toggle = false) { }
        public override void SetupFile() { }

        public override void CheckInputs(object sender, EventArgs e)
        {
            if (Inputs.RawInputs == ConfigureCombos.saveCombo && inputCheck)
            {
                SavePosition();
                inputCheck = false;
            }
            if (Inputs.RawInputs == ConfigureCombos.loadCombo && inputCheck)
            {
                LoadPosition();
                inputCheck = false;
            }
            if (Inputs.RawInputs == ConfigureCombos.dieCombo && inputCheck)
            {
                KillYourself();
                inputCheck = false;
            }
            if (Inputs.RawInputs == ConfigureCombos.runScriptCombo && inputCheck)
            {
                AttachPS3Form.scripting?.RunCurrentCode();
                inputCheck = false;
            }
            if (Inputs.RawInputs == 0x00 && !inputCheck)
            {
                inputCheck = true;
            }
        }

        public override void CheckPlanetForDiscordRPC(object sender = null, EventArgs e = null) { }

        protected override void SetupInputDisplayMemorySubsButtons()
        {
            int buttonMaskSubID = api.SubMemory(pid, sly3.addr.inputOffset, 4, (value) =>
            {
                int slyButtonMask = BitConverter.ToInt32(value.Reverse().ToArray(), 0);
                
                int convertedMask = ConvertSlyButtonsToStandardFormat(slyButtonMask);
                
                Inputs.RawInputs = convertedMask;
                Inputs.Mask = Inputs.DecodeMask(convertedMask);
            });
        }

        private int ConvertSlyButtonsToStandardFormat(int slyMask)
        {
            int standardMask = 0;
            
            if ((slyMask & 0x0001) != 0) standardMask |= 0x100;   // Select
            if ((slyMask & 0x0008) != 0) standardMask |= 0x800;   // Start
            if ((slyMask & 0x0010) != 0) standardMask |= 0x1000;  // Up
            if ((slyMask & 0x0020) != 0) standardMask |= 0x2000;  // Right
            if ((slyMask & 0x0040) != 0) standardMask |= 0x4000;  // Down
            if ((slyMask & 0x0080) != 0) standardMask |= 0x8000;  // Left
            if ((slyMask & 0x0400) != 0) standardMask |= 0x4;     // L1
            if ((slyMask & 0x0100) != 0) standardMask |= 0x1;     // L2
            if ((slyMask & 0x0800) != 0) standardMask |= 0x8;     // R1
            if ((slyMask & 0x0200) != 0) standardMask |= 0x2;     // R2
            if ((slyMask & 0x1000) != 0) standardMask |= 0x10;    // Triangle
            if ((slyMask & 0x2000) != 0) standardMask |= 0x20;    // Circle
            if ((slyMask & 0x4000) != 0) standardMask |= 0x40;    // Cross
            if ((slyMask & 0x8000) != 0) standardMask |= 0x80;    // Square
            if ((slyMask & 0x0002) != 0) standardMask |= 0x200;  // L3
            if ((slyMask & 0x0004) != 0) standardMask |= 0x400;  // R3
            
            return standardMask;
        }

        public void Load()
        {
            api.WriteMemory(pid, sly3.addr.loadType, (uint)Sly3Addresses.LoadTypes.Normal);
            api.WriteMemory(pid, sly3.addr.loadTrigger, (uint)1);
        }

        public void LoadMap(int mapIndex)
        {
            if (mapIndex < 0 || mapIndex >= maps.Length)
            {
                MessageBox.Show("Invalid map index", "Error");
                return;
            }
            
            MapData selectedMap = maps[mapIndex];
            
            try
            {
                byte[] clearBytes = new byte[64];
                api.WriteMemory(pid, sly3.addr.mapAOB, clearBytes);

                byte[] indicatorBytes = System.Text.Encoding.ASCII.GetBytes(selectedMap.indicator);
                api.WriteMemory(pid, sly3.addr.mapAOB, indicatorBytes);
                
                api.WriteMemory(pid, sly3.addr.spawnLocation, selectedMap.defaultWarp);
                
                api.WriteMemory(pid, sly3.addr.loadTrigger, (uint)1);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load map: {ex.Message}", "Error");
            }
        }

        public string[] GetMapNames()
        {
            return maps.Select(m => m.naturalName).ToArray();
        }

        private uint GetPlayerCoordsAddress()
        {
            byte[] playerEntityPtrBytes = api.ReadMemory(pid, sly3.addr.playerEntityPointer, 4);
            uint playerEntity = BitConverter.ToUInt32(playerEntityPtrBytes.Reverse().ToArray(), 0);

            byte[] transformPtrBytes = api.ReadMemory(pid, playerEntity + sly3.addr.transformOffset, 4);
            uint transformPtr = BitConverter.ToUInt32(transformPtrBytes.Reverse().ToArray(), 0);

            return transformPtr + sly3.addr.coordsOffsetX;
        }

        public override void SavePosition()
        {
            try
            {
                uint coordsAddress = GetPlayerCoordsAddress();
                
                string position = api.ReadMemoryStr(pid, coordsAddress, 12);
                func.ChangeFileLines("config.txt", position, mapList[mapIndex] + "SavedPos" + selectedPositionIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save position: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void LoadPosition()
        {
            try
            {
                string position = func.GetConfigData("config.txt", mapList[mapIndex] + "SavedPos" + selectedPositionIndex);
                if (position != "")
                {
                    uint coordsAddress = GetPlayerCoordsAddress();
                    
                    api.WriteMemory(pid, coordsAddress, 12, position);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load position: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void SetupInputDisplayMemorySubsAnalogs()
        {
            int analogLSubID = api.SubMemory(pid, sly3.addr.analogOffsetLeft, 2, (value) =>
            {
                Inputs.ly = (value[0] - 127) / 127.0f;
                Inputs.lx = (value[1] - 127) / 127.0f;
            });

            int analogRSubID = api.SubMemory(pid, sly3.addr.analogOffsetRight, 2, (value) =>
            {
                Inputs.ry = (value[0] - 127) / 127.0f;
                Inputs.rx = (value[1] - 127) / 127.0f;
            });
        }
        
        public void SetCoinCount(int coins)
        {
            byte[] coinBytes = BitConverter.GetBytes(coins).Reverse().ToArray();
            api.WriteMemory(pid, sly3.addr.coinCount, coinBytes);
        }

        public void SetGadgetUnlocks(byte[] gadgetBytes)
        {
            api.WriteMemory(pid, sly3.addr.gadgetUnlocks, gadgetBytes);
        }

        public byte[] GetGadgetUnlocks()
        {
            return api.ReadMemory(pid, sly3.addr.gadgetUnlocks, 8);
        }
    }
}