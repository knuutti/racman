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
    }

    public class sly3 : IGame
    {
        public static Sly3Addresses addr = new Sly3Addresses();

        public sly3(IPS3API api) : base(api)
        {
            this.planetsList = new string[] { 
                "Venice", 
                "Outback", 
                "Holland", 
                "China", 
                "Blood-Bath Bay",
                "Kaine Island" 
            };
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
                func.ChangeFileLines("config.txt", position, planetsList[planetIndex] + "SavedPos" + selectedPositionIndex);
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
                string position = func.GetConfigData("config.txt", planetsList[planetIndex] + "SavedPos" + selectedPositionIndex);
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
    }
}