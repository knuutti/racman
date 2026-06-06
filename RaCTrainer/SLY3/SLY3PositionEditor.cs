using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace racman
{
    public partial class SLY3PositionEditor : Form
    {
        private sly3 game;
        private System.Windows.Forms.Timer pollTimer;

        private float? frozenPosX;
        private float? frozenPosY;
        private float? frozenPosZ;
        private float flyFrozenZ;
        private float prevFlyPosX;
        private float prevFlyPosY;

        private const float FlyHeightStep = 20.0f;
        private const float FlyBoostMultiplier = 8.0f;

        public SLY3PositionEditor(sly3 game)
        {
            this.game = game;
            InitializeComponent();

            pollTimer = new System.Windows.Forms.Timer();
            pollTimer.Interval = 10;
            pollTimer.Tick += PollTimer_Tick;
            pollTimer.Start();
        }

        private bool TryResolvePointers(out uint entityPtr, out uint transformPtr)
        {
            entityPtr = 0;
            transformPtr = 0;
            try
            {
                byte[] epBytes = game.api.ReadMemory(game.pid, 0x5EC654, 4);
                entityPtr = BitConverter.ToUInt32(epBytes.Reverse().ToArray(), 0);
                if (entityPtr == 0) return false;

                byte[] tpBytes = game.api.ReadMemory(game.pid, entityPtr + 0x44, 4);
                transformPtr = BitConverter.ToUInt32(tpBytes.Reverse().ToArray(), 0);
                return transformPtr != 0;
            }
            catch
            {
                return false;
            }
        }

        private float ReadFloat(uint address)
        {
            byte[] b = game.api.ReadMemory(game.pid, address, 4);
            return BitConverter.ToSingle(b.Reverse().ToArray(), 0);
        }

        private int ReadInt(uint address)
        {
            byte[] b = game.api.ReadMemory(game.pid, address, 4);
            return BitConverter.ToInt32(b.Reverse().ToArray(), 0);
        }

        private void WriteFloat(uint address, float value)
        {
            byte[] b = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(b);
            game.api.WriteMemory(game.pid, address, b);
        }

        private void PollTimer_Tick(object sender, EventArgs e)
        {
            if (!TryResolvePointers(out uint entityPtr, out uint transformPtr))
            {
                SetLabelsUnavailable();
                return;
            }

            try
            {
                // Position freezes — also zero corresponding velocity axis
                if (frozenPosX.HasValue)
                {
                    WriteFloat(transformPtr + 0x130, frozenPosX.Value);
                    WriteFloat(transformPtr + 0x1B0, 0f);
                }
                if (frozenPosY.HasValue)
                {
                    WriteFloat(transformPtr + 0x134, frozenPosY.Value);
                    WriteFloat(transformPtr + 0x1B4, 0f);
                }
                if (!flyModeCheckBox.Checked && frozenPosZ.HasValue)
                {
                    WriteFloat(transformPtr + 0x138, frozenPosZ.Value);
                    WriteFloat(transformPtr + 0x1B8, 0f);
                }

                // Fly mode: freeze Z pos + Z vel, adjust height with L2/R2, amplify horizontal movement
                if (flyModeCheckBox.Checked)
                {
                    if ((Inputs.RawInputs & 0x1) != 0) flyFrozenZ += FlyHeightStep;   // L2 = up
                    if ((Inputs.RawInputs & 0x2) != 0) flyFrozenZ -= FlyHeightStep;   // R2 = down

                    WriteFloat(transformPtr + 0x138, flyFrozenZ);
                    WriteFloat(transformPtr + 0x1B8, 0f);
                    zPosTextBox.Text = flyFrozenZ.ToString("F3", CultureInfo.InvariantCulture);

                    float curX = ReadFloat(transformPtr + 0x130);
                    float curY = ReadFloat(transformPtr + 0x134);
                    if ((Inputs.RawInputs & 0x8) != 0)  // R1 = horizontal boost
                    {
                        float deltaX = curX - prevFlyPosX;
                        float deltaY = curY - prevFlyPosY;
                        if (Math.Abs(deltaX) > 0.001f || Math.Abs(deltaY) > 0.001f)
                        {
                            float newX = prevFlyPosX + deltaX * FlyBoostMultiplier;
                            float newY = prevFlyPosY + deltaY * FlyBoostMultiplier;
                            WriteFloat(transformPtr + 0x130, newX);
                            WriteFloat(transformPtr + 0x134, newY);
                            curX = newX;
                            curY = newY;
                        }
                    }
                    prevFlyPosX = curX;
                    prevFlyPosY = curY;
                }

                // Infinite jump — write full 4 bytes; LSB is what the game checks
                if (infiniteJumpCheckBox.Checked) game.api.WriteMemory(game.pid, entityPtr + 0x338, (uint)0);

                // Read current state for display labels
                int entityId = ReadInt(entityPtr + 0x18);
                int health = ReadInt(entityPtr + 0x168);
                int gadgetPower = ReadInt(entityPtr + 0x170);
                float opacity = ReadFloat(entityPtr + 0x104);
                float rotation = ReadFloat(entityPtr + 0x1AC);

                float posX = ReadFloat(transformPtr + 0x130);
                float posY = ReadFloat(transformPtr + 0x134);
                float posZ = ReadFloat(transformPtr + 0x138);
                float velX = ReadFloat(transformPtr + 0x1B0);
                float velY = ReadFloat(transformPtr + 0x1B4);
                float velZ = ReadFloat(transformPtr + 0x1B8);
                float hSpeed = (float)Math.Sqrt(velX * velX + velY * velY);

                entityIdValueLabel.Text = entityId.ToString();
                healthValueLabel.Text = health.ToString();
                gadgetPowerValueLabel.Text = gadgetPower.ToString();
                opacityValueLabel.Text = opacity.ToString("F3", CultureInfo.InvariantCulture);
                rotationValueLabel.Text = rotation.ToString("F3", CultureInfo.InvariantCulture);
                xPosLiveLabel.Text = posX.ToString("F3", CultureInfo.InvariantCulture);
                yPosLiveLabel.Text = posY.ToString("F3", CultureInfo.InvariantCulture);
                zPosLiveLabel.Text = posZ.ToString("F3", CultureInfo.InvariantCulture);
                hSpeedLabel.Text = hSpeed.ToString("F3", CultureInfo.InvariantCulture);
                zVelLiveLabel.Text = velZ.ToString("F3", CultureInfo.InvariantCulture);
            }
            catch
            {
                SetLabelsUnavailable();
            }
        }

        private void SetLabelsUnavailable()
        {
            entityIdValueLabel.Text = "N/A";
            healthValueLabel.Text = "N/A";
            gadgetPowerValueLabel.Text = "N/A";
            opacityValueLabel.Text = "N/A";
            rotationValueLabel.Text = "N/A";
            xPosLiveLabel.Text = "N/A";
            yPosLiveLabel.Text = "N/A";
            zPosLiveLabel.Text = "N/A";
            hSpeedLabel.Text = "N/A";
            zVelLiveLabel.Text = "N/A";
        }

        private void setXPosButton_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(xPosTextBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float val)) return;
            try
            {
                if (!TryResolvePointers(out _, out uint transformPtr)) return;
                WriteFloat(transformPtr + 0x130, val);
                WriteFloat(transformPtr + 0x1B0, 0f);
                if (freezePosXCheckBox.Checked) frozenPosX = val;
            }
            catch { }
        }

        private void setYPosButton_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(yPosTextBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float val)) return;
            try
            {
                if (!TryResolvePointers(out _, out uint transformPtr)) return;
                WriteFloat(transformPtr + 0x134, val);
                WriteFloat(transformPtr + 0x1B4, 0f);
                if (freezePosYCheckBox.Checked) frozenPosY = val;
            }
            catch { }
        }

        private void setZPosButton_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(zPosTextBox.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float val)) return;
            try
            {
                if (!TryResolvePointers(out _, out uint transformPtr)) return;
                WriteFloat(transformPtr + 0x138, val);
                WriteFloat(transformPtr + 0x1B8, 0f);
                if (freezePosZCheckBox.Checked) frozenPosZ = val;
                if (flyModeCheckBox.Checked) flyFrozenZ = val;
            }
            catch { }
        }

        private void freezePosXCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (freezePosXCheckBox.Checked)
            {
                try
                {
                    if (TryResolvePointers(out _, out uint tp))
                    {
                        float live = ReadFloat(tp + 0x130);
                        frozenPosX = live;
                        xPosTextBox.Text = live.ToString("F3", CultureInfo.InvariantCulture);
                    }
                }
                catch { }
            }
            else
            {
                frozenPosX = null;
            }
        }

        private void freezePosYCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (freezePosYCheckBox.Checked)
            {
                try
                {
                    if (TryResolvePointers(out _, out uint tp))
                    {
                        float live = ReadFloat(tp + 0x134);
                        frozenPosY = live;
                        yPosTextBox.Text = live.ToString("F3", CultureInfo.InvariantCulture);
                    }
                }
                catch { }
            }
            else
            {
                frozenPosY = null;
            }
        }

        private void freezePosZCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (freezePosZCheckBox.Checked)
            {
                try
                {
                    if (TryResolvePointers(out _, out uint tp))
                    {
                        float live = ReadFloat(tp + 0x138);
                        frozenPosZ = live;
                        zPosTextBox.Text = live.ToString("F3", CultureInfo.InvariantCulture);
                    }
                }
                catch { }
            }
            else
            {
                frozenPosZ = null;
            }
        }

        private void flyModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (flyModeCheckBox.Checked)
            {
                try
                {
                    if (TryResolvePointers(out _, out uint tp))
                    {
                        flyFrozenZ = ReadFloat(tp + 0x138);
                        zPosTextBox.Text = flyFrozenZ.ToString("F3", CultureInfo.InvariantCulture);
                        prevFlyPosX = ReadFloat(tp + 0x130);
                        prevFlyPosY = ReadFloat(tp + 0x134);
                    }
                }
                catch { }
            }
        }

        private void SLY3PositionEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            pollTimer.Stop();
            pollTimer.Dispose();
        }
    }
}
