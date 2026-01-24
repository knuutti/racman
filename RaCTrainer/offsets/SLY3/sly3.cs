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
        public uint boltCount => 0x0;
        public uint playerCoords => 0x5EC654;
        public uint inputOffset => 0x5EC5AA;
        public uint analogOffset => 0x5EC5F0;
        public uint currentPlanet => 0x0; 
        public uint loadPlanet => 0x0;  
        public uint mobyInstances => 0x0;
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

        
        public override void ResetLevelFlags()
        {

        }

        public override void SetFastLoads(bool enabled = false)
        {

        }

        public override void ToggleInfiniteAmmo(bool toggle = false)
        {

        }

        public override void SetupFile()
        {

        }

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

        public override void CheckPlanetForDiscordRPC(object sender = null, EventArgs e = null)
        {

        }

        // Override button input processing for Sly 3
        protected override void SetupInputDisplayMemorySubsButtons()
        {
            int buttonMaskSubID = api.SubMemory(pid, sly3.addr.inputOffset, 4, (value) =>
            {
                // PS3 is big-endian, need to reverse bytes for C#
                int slyButtonMask = BitConverter.ToInt32(value.Reverse().ToArray(), 0);
                
                // Convert Sly 3's button layout to Ratchet's OgBtns format
                int convertedMask = ConvertSlyButtonsToStandardFormat(slyButtonMask);
                
                Inputs.RawInputs = convertedMask;
                Inputs.Mask = Inputs.DecodeMask(convertedMask);
            });
        }

        // Converts Sly 3's button bit positions to the trainer's expected format (OgBtns)
        private int ConvertSlyButtonsToStandardFormat(int slyMask)
        {
            int standardMask = 0;
            
            // TODO: Test each button and fill in the correct Sly bit positions
            // Standard format (OgBtns):
            // l2=0x1, r2=0x2, l1=0x4, r1=0x8
            // triangle=0x10, circle=0x20, cross=0x40, square=0x80
            // select=0x100, l3=0x200, r3=0x400, start=0x800
            // up=0x1000, right=0x2000, down=0x4000, left=0x8000
            
            // Example mappings (replace 0x???? with actual Sly bit values):
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

        // Override analog input processing for Sly 3
        protected override void SetupInputDisplayMemorySubsAnalogs()
        {
            // Left analog stick (LX at 0x5EC5F0, LY at next byte)
            int analogLSubID = api.SubMemory(pid, sly3.addr.analogOffset, 2, (value) =>
            {
                // Convert byte (0-255, center=127) to float (-1.0 to 1.0, center=0)
                Inputs.ly = (value[0] - 127) / 127.0f;
                Inputs.lx = (value[1] - 127) / 127.0f;
            });

            // Right analog stick (RX at 0x5EC61C, RY at next byte)
            int analogRSubID = api.SubMemory(pid, 0x5EC61C, 2, (value) =>
            {
                // Convert byte (0-255, center=127) to float (-1.0 to 1.0, center=0)
                Inputs.ry = (value[0] - 127) / 127.0f;
                Inputs.rx = (value[1] - 127) / 127.0f;
            });
        }
        
        // public void SetBottleCount(int bottles)
        // {
        //     api.WriteMemory(pid, sly3.addr.bottleCount, bottles);
        // }
    }
}