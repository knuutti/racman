using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace racman
{
    public partial class InputDisplay : Form
    {
        public struct InputPlot
        {
            public int drawX { get; set; }
            public int drawY { get; set; }
            public int spriteX { get; set; }
            public int spriteY { get; set; }
            public int spriteWidth { get; set; }
            public int spriteHeight { get; set; }
        }

        class ControllerSkin
        {

            public Image image;
            public Dictionary<string, InputPlot> buttons;
            public int analogPitch = 32;


            public static ControllerSkin Load(string skinPath)
            {
                var skin = new ControllerSkin();
                skin.buttons = new Dictionary<string, InputPlot>();

                var config = File.ReadAllText(skinPath + "\\skin.txt");

                foreach (var line in config.Split('\n'))
                {
                    if (line.Length < 2 || line[0] == '#')
                    {
                        continue;
                    }

                    var components = line.Split(':');
                    if (components.Length < 2) 
                    {
                        continue;
                    }

                    string buttonName = components[0];

                    if (buttonName == "imageName")
                    {
                        skin.image = Image.FromFile(skinPath + "\\" + components[1].Trim());
                        continue;
                    }

                    if (buttonName == "analogPitch")
                    {
                        skin.analogPitch = int.Parse(components[1].Trim());
                        continue;
                    }

                    var plot = components[1].Split(',').Select(thing => int.Parse(thing.Trim())).ToArray();
                    
                    if (plot.Length < 6)
                    {
                        continue;
                    }


                    var inputPlot = new InputPlot();
                    inputPlot.drawX         = plot[0];
                    inputPlot.drawY         = plot[1];
                    inputPlot.spriteX       = plot[2];
                    inputPlot.spriteY       = plot[3];
                    inputPlot.spriteWidth   = plot[4];
                    inputPlot.spriteHeight  = plot[5];

                    skin.buttons[buttonName] = inputPlot;
                }

                return skin;
            }
        }

        public System.Windows.Forms.Timer timer;
        ControllerSkin controllerSkin;
        private readonly List<ToolStripMenuItem> skinMenuItems = new List<ToolStripMenuItem>();

        public InputDisplay()
        {
            InitializeComponent();
        }
        private void InputDisplay_Load(object sender, EventArgs e)
        {
            if (Directory.Exists("controllerskins"))
            {
                foreach(var skinName in Directory.EnumerateDirectories("controllerskins"))
                {
                    skinComboBox.Items.Add(skinName.Replace("controllerskins\\", ""));
                }
            }

            BuildSkinContextMenu();

            // controllerSkin = ControllerSkin.Load(Directory.EnumerateDirectories("controllerskins").First());
            try
            {
                skinComboBox.SelectedIndex = Convert.ToInt32(func.GetConfigData("config.txt", "InputDisplaySkin"));
            }
            catch
            {
                skinComboBox.SelectedIndex = 0;
            }

            var savedBackColor = func.GetConfigData("config.txt", "InputDisplayBackColor");
            if (savedBackColor != "")
            {
                try
                {
                    this.BackColor = Color.FromArgb(Convert.ToInt32(savedBackColor));
                }
                catch
                {
                    // Ignore invalid color values in config.
                }
            }

            timer = new System.Windows.Forms.Timer();
            timer.Interval = (int)16.66667;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private static void DrawSprite(Graphics graphics, Image sprite, InputPlot plot, int drawXOffset = 0, int drawYOffset = 0)
        {
            var destination = new Rectangle(
                plot.drawX + drawXOffset,
                plot.drawY + drawYOffset,
                plot.spriteWidth,
                plot.spriteHeight);

            var source = new Rectangle(plot.spriteX, plot.spriteY, plot.spriteWidth, plot.spriteHeight);
            graphics.DrawImage(sprite, destination, source, GraphicsUnit.Pixel);
        }

        private void InputDisplay_Paint(object sender, PaintEventArgs e)
        {
            Image sprite = controllerSkin.image;

            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;

            InputPlot basePlot = controllerSkin.buttons["base"];
            InputPlot r3 = controllerSkin.buttons["r3"];
            InputPlot r3Press = controllerSkin.buttons["r3Press"];
            InputPlot l3 = controllerSkin.buttons["l3"];
            InputPlot l3Press = controllerSkin.buttons["l3Press"];

            InputPlot dpadLeft = controllerSkin.buttons["dpadLeft"];
            InputPlot dpadRight = controllerSkin.buttons["dpadRight"];
            InputPlot dpadDown = controllerSkin.buttons["dpadDown"];
            InputPlot dpadUp = controllerSkin.buttons["dpadUp"];

            InputPlot cross = controllerSkin.buttons["cross"];
            InputPlot circle = controllerSkin.buttons["circle"];
            InputPlot triangle = controllerSkin.buttons["triangle"];
            InputPlot square = controllerSkin.buttons["square"];

            InputPlot select = controllerSkin.buttons["select"];
            InputPlot start = controllerSkin.buttons["start"];

            InputPlot r1 = controllerSkin.buttons["r1"];
            InputPlot l1 = controllerSkin.buttons["l1"];
            InputPlot l2 = controllerSkin.buttons["l2"];
            InputPlot r2 = controllerSkin.buttons["r2"];

            DrawSprite(e.Graphics, sprite, basePlot);

            if (Inputs.Mask.Contains(Inputs.Buttons.r3)) DrawSprite(e.Graphics, sprite, r3, Inputs.rx * controllerSkin.analogPitch, Inputs.ry * controllerSkin.analogPitch);
            else DrawSprite(e.Graphics, sprite, r3Press, Inputs.rx * controllerSkin.analogPitch, Inputs.ry * controllerSkin.analogPitch);

            if (Inputs.Mask.Contains(Inputs.Buttons.l3)) DrawSprite(e.Graphics, sprite, l3, Inputs.lx * controllerSkin.analogPitch, Inputs.ly * controllerSkin.analogPitch);
            else DrawSprite(e.Graphics, sprite, l3Press, Inputs.lx * controllerSkin.analogPitch, Inputs.ly * controllerSkin.analogPitch);

            if (Inputs.Mask.Contains(Inputs.Buttons.left)) DrawSprite(e.Graphics, sprite, dpadLeft);
            if (Inputs.Mask.Contains(Inputs.Buttons.right)) DrawSprite(e.Graphics, sprite, dpadRight);
            if (Inputs.Mask.Contains(Inputs.Buttons.down)) DrawSprite(e.Graphics, sprite, dpadDown);
            if (Inputs.Mask.Contains(Inputs.Buttons.up)) DrawSprite(e.Graphics, sprite, dpadUp);

            if (Inputs.Mask.Contains(Inputs.Buttons.cross)) DrawSprite(e.Graphics, sprite, cross);
            if (Inputs.Mask.Contains(Inputs.Buttons.circle)) DrawSprite(e.Graphics, sprite, circle);
            if (Inputs.Mask.Contains(Inputs.Buttons.triangle)) DrawSprite(e.Graphics, sprite, triangle);
            if (Inputs.Mask.Contains(Inputs.Buttons.square)) DrawSprite(e.Graphics, sprite, square);

            if (Inputs.Mask.Contains(Inputs.Buttons.select)) DrawSprite(e.Graphics, sprite, select);
            if (Inputs.Mask.Contains(Inputs.Buttons.start)) DrawSprite(e.Graphics, sprite, start);

            if (Inputs.Mask.Contains(Inputs.Buttons.r1)) DrawSprite(e.Graphics, sprite, r1);
            if (Inputs.Mask.Contains(Inputs.Buttons.l1)) DrawSprite(e.Graphics, sprite, l1);
            if (Inputs.Mask.Contains(Inputs.Buttons.l2)) DrawSprite(e.Graphics, sprite, l2);
            if (Inputs.Mask.Contains(Inputs.Buttons.r2)) DrawSprite(e.Graphics, sprite, r2);
        }

        private void skinComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySkinByIndex(skinComboBox.SelectedIndex);
        }

        private void InputDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Enabled = false;
        }

        private void BuildSkinContextMenu()
        {
            skinToolStripMenuItem.DropDownItems.Clear();
            skinMenuItems.Clear();

            for (int i = 0; i < skinComboBox.Items.Count; i++)
            {
                var skinName = skinComboBox.Items[i].ToString();
                var menuItem = new ToolStripMenuItem(skinName)
                {
                    Tag = i,
                    CheckOnClick = true
                };

                menuItem.Click += SkinMenuItem_Click;
                skinToolStripMenuItem.DropDownItems.Add(menuItem);
                skinMenuItems.Add(menuItem);
            }
        }

        private void ApplySkinByIndex(int skinIndex)
        {
            if (skinIndex < 0 || skinIndex >= skinComboBox.Items.Count)
            {
                return;
            }

            var skinName = skinComboBox.Items[skinIndex].ToString();

            controllerSkin = ControllerSkin.Load($"controllerskins\\{skinName}");

            func.ChangeFileLines("config.txt", skinIndex.ToString(), "InputDisplaySkin");

            this.Width = Math.Max(controllerSkin.buttons["base"].spriteWidth + 50, this.Width);
            this.Height = Math.Max(controllerSkin.buttons["base"].spriteHeight + 50, this.Height);

            for (int i = 0; i < skinMenuItems.Count; i++)
            {
                skinMenuItems[i].Checked = i == skinIndex;
            }
        }

        private void SkinMenuItem_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem clickedItem) || clickedItem.Tag == null)
            {
                return;
            }

            int skinIndex = (int)clickedItem.Tag;
            skinComboBox.SelectedIndex = skinIndex;
        }

        private void InputDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this, e.Location);
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = this.BackColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDialog1.Color;
                func.ChangeFileLines("config.txt", this.BackColor.ToArgb().ToString(), "InputDisplayBackColor");
            }
        }
    }
}
