namespace racman
{
    partial class SLY3Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SLY3Form));
            this.coinsTextBox = new System.Windows.Forms.TextBox();
            this.inputDisplayButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.powerOffPS3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebootPS3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapComboBox = new System.Windows.Forms.ComboBox();
            this.loadMapButton = new System.Windows.Forms.Button();
            this.gadgetButton = new System.Windows.Forms.Button();
            this.toggleGroupBox = new System.Windows.Forms.GroupBox();
            this.gameClockCheckBox = new System.Windows.Forms.CheckBox();
            this.deathBarriersCheckBox = new System.Windows.Forms.CheckBox();
            this.undetectableCheckBox = new System.Windows.Forms.CheckBox();
            this.guardAICheckBox = new System.Windows.Forms.CheckBox();
            this.infiniteJumpsCheckBox = new System.Windows.Forms.CheckBox();
            this.invulnerabilityCheckBox = new System.Windows.Forms.CheckBox();
            this.alwaysOnTopCheckBox = new System.Windows.Forms.CheckBox();
            this.jobComboBox = new System.Windows.Forms.ComboBox();
            this.loadJobButton = new System.Windows.Forms.Button();
            this.skipCinematicsButton = new System.Windows.Forms.Button();
            this.fullReloadButton = new System.Windows.Forms.Button();
            this.reloadGroupBox = new System.Windows.Forms.GroupBox();
            this.loadPosButton = new System.Windows.Forms.Button();
            this.savePosButton = new System.Windows.Forms.Button();
            this.fastReloadButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.reloadAsCharacterComboBox = new System.Windows.Forms.ComboBox();
            this.healthTextBox = new System.Windows.Forms.TextBox();
            this.setCoinsButton = new System.Windows.Forms.Button();
            this.setHealthButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelJuice = new System.Windows.Forms.Label();
            this.juiceTextBox = new System.Windows.Forms.TextBox();
            this.setJuiceButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.jobGroupBox = new System.Windows.Forms.GroupBox();
            this.miscGroupBox = new System.Windows.Forms.GroupBox();
            this.labelDD = new System.Windows.Forms.Label();
            this.drawDistTextBox = new System.Windows.Forms.TextBox();
            this.setDrawDistButton = new System.Windows.Forms.Button();
            this.labelFOV = new System.Windows.Forms.Label();
            this.fovTextBox = new System.Windows.Forms.TextBox();
            this.setFOVButton = new System.Windows.Forms.Button();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.speedTextBox = new System.Windows.Forms.TextBox();
            this.setSpeedButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.toggleGroupBox.SuspendLayout();
            this.reloadGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.jobGroupBox.SuspendLayout();
            this.miscGroupBox.SuspendLayout();
            this.SuspendLayout();
            //
            // coinsTextBox
            //
            this.coinsTextBox.Location = new System.Drawing.Point(16, 33);
            this.coinsTextBox.Name = "coinsTextBox";
            this.coinsTextBox.Size = new System.Drawing.Size(112, 20);
            this.coinsTextBox.TabIndex = 0;
            this.coinsTextBox.TextChanged += new System.EventHandler(this.coinsTextBox_TextChanged);
            this.coinsTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.coinsTextBox_KeyDown);
            //
            // inputDisplayButton
            //
            this.inputDisplayButton.Location = new System.Drawing.Point(226, 418);
            this.inputDisplayButton.Name = "inputDisplayButton";
            this.inputDisplayButton.Size = new System.Drawing.Size(234, 62);
            this.inputDisplayButton.TabIndex = 1;
            this.inputDisplayButton.Text = "Input Display";
            this.inputDisplayButton.UseVisualStyleBackColor = true;
            this.inputDisplayButton.Click += new System.EventHandler(this.inputDisplayButton_Click);
            //
            // menuStrip1
            //
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(473, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            //
            // menuToolStripMenuItem
            //
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchGameToolStripMenuItem,
            this.inputDisplayToolStripMenuItem,
            this.toolStripSeparator1,
            this.powerOffPS3ToolStripMenuItem,
            this.rebootPS3ToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.menuToolStripMenuItem.Text = "Tools";
            //
            // switchGameToolStripMenuItem
            //
            this.switchGameToolStripMenuItem.Name = "switchGameToolStripMenuItem";
            this.switchGameToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.switchGameToolStripMenuItem.Text = "Switch Game/Mode";
            this.switchGameToolStripMenuItem.Click += new System.EventHandler(this.switchGameToolStripMenuItem_Click);
            //
            // inputDisplayToolStripMenuItem
            //
            this.inputDisplayToolStripMenuItem.Name = "inputDisplayToolStripMenuItem";
            this.inputDisplayToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.inputDisplayToolStripMenuItem.Text = "Input Display";
            this.inputDisplayToolStripMenuItem.Click += new System.EventHandler(this.inputDisplayButton_Click);
            //
            // toolStripSeparator1
            //
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(176, 6);
            //
            // powerOffPS3ToolStripMenuItem
            //
            this.powerOffPS3ToolStripMenuItem.Name = "powerOffPS3ToolStripMenuItem";
            this.powerOffPS3ToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.powerOffPS3ToolStripMenuItem.Text = "Power Off (PS3)";
            this.powerOffPS3ToolStripMenuItem.Click += new System.EventHandler(this.powerOffPS3ToolStripMenuItem_Click);
            //
            // rebootPS3ToolStripMenuItem
            //
            this.rebootPS3ToolStripMenuItem.Name = "rebootPS3ToolStripMenuItem";
            this.rebootPS3ToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.rebootPS3ToolStripMenuItem.Text = "Reboot (PS3)";
            this.rebootPS3ToolStripMenuItem.Click += new System.EventHandler(this.rebootPS3ToolStripMenuItem_Click);
            //
            // mapComboBox
            //
            this.mapComboBox.FormattingEnabled = true;
            this.mapComboBox.Location = new System.Drawing.Point(15, 25);
            this.mapComboBox.Name = "mapComboBox";
            this.mapComboBox.Size = new System.Drawing.Size(179, 21);
            this.mapComboBox.TabIndex = 8;
            this.mapComboBox.Text = "Select a map...";
            //
            // loadMapButton
            //
            this.loadMapButton.Location = new System.Drawing.Point(15, 51);
            this.loadMapButton.Name = "loadMapButton";
            this.loadMapButton.Size = new System.Drawing.Size(85, 24);
            this.loadMapButton.TabIndex = 9;
            this.loadMapButton.Text = "Load Map";
            this.loadMapButton.UseVisualStyleBackColor = true;
            this.loadMapButton.Click += new System.EventHandler(this.loadMapButton_Click);
            //
            // gadgetButton
            //
            this.gadgetButton.Location = new System.Drawing.Point(119, 142);
            this.gadgetButton.Name = "gadgetButton";
            this.gadgetButton.Size = new System.Drawing.Size(101, 40);
            this.gadgetButton.TabIndex = 11;
            this.gadgetButton.Text = "Gadgets";
            this.gadgetButton.UseVisualStyleBackColor = true;
            this.gadgetButton.Click += new System.EventHandler(this.gadgetsButton_Click);
            //
            // toggleGroupBox
            //
            this.toggleGroupBox.Controls.Add(this.gameClockCheckBox);
            this.toggleGroupBox.Controls.Add(this.deathBarriersCheckBox);
            this.toggleGroupBox.Controls.Add(this.undetectableCheckBox);
            this.toggleGroupBox.Controls.Add(this.guardAICheckBox);
            this.toggleGroupBox.Controls.Add(this.infiniteJumpsCheckBox);
            this.toggleGroupBox.Controls.Add(this.invulnerabilityCheckBox);
            this.toggleGroupBox.Controls.Add(this.alwaysOnTopCheckBox);
            this.toggleGroupBox.Location = new System.Drawing.Point(226, 240);
            this.toggleGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.toggleGroupBox.Name = "toggleGroupBox";
            this.toggleGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.toggleGroupBox.Size = new System.Drawing.Size(234, 170);
            this.toggleGroupBox.TabIndex = 15;
            this.toggleGroupBox.TabStop = false;
            this.toggleGroupBox.Text = "Toggles";
            //
            // gameClockCheckBox
            //
            this.gameClockCheckBox.AutoSize = true;
            this.gameClockCheckBox.Location = new System.Drawing.Point(16, 142);
            this.gameClockCheckBox.Name = "gameClockCheckBox";
            this.gameClockCheckBox.Size = new System.Drawing.Size(120, 17);
            this.gameClockCheckBox.TabIndex = 11;
            this.gameClockCheckBox.Text = "Freeze Game Clock";
            this.gameClockCheckBox.UseVisualStyleBackColor = true;
            this.gameClockCheckBox.CheckedChanged += new System.EventHandler(this.gameClockCheckBox_CheckedChanged);
            //
            // deathBarriersCheckBox
            //
            this.deathBarriersCheckBox.AutoSize = true;
            this.deathBarriersCheckBox.Location = new System.Drawing.Point(16, 122);
            this.deathBarriersCheckBox.Name = "deathBarriersCheckBox";
            this.deathBarriersCheckBox.Size = new System.Drawing.Size(135, 17);
            this.deathBarriersCheckBox.TabIndex = 10;
            this.deathBarriersCheckBox.Text = "Disable Death Barriers";
            this.deathBarriersCheckBox.UseVisualStyleBackColor = true;
            this.deathBarriersCheckBox.CheckedChanged += new System.EventHandler(this.deathBarriersCheckBox_CheckedChanged);
            //
            // undetectableCheckBox
            //
            this.undetectableCheckBox.AutoSize = true;
            this.undetectableCheckBox.Location = new System.Drawing.Point(16, 102);
            this.undetectableCheckBox.Name = "undetectableCheckBox";
            this.undetectableCheckBox.Size = new System.Drawing.Size(92, 17);
            this.undetectableCheckBox.TabIndex = 9;
            this.undetectableCheckBox.Text = "Undetectable";
            this.undetectableCheckBox.UseVisualStyleBackColor = true;
            this.undetectableCheckBox.CheckedChanged += new System.EventHandler(this.undetectableCheckBox_CheckedChanged);
            //
            // guardAICheckBox
            //
            this.guardAICheckBox.AutoSize = true;
            this.guardAICheckBox.Location = new System.Drawing.Point(16, 82);
            this.guardAICheckBox.Name = "guardAICheckBox";
            this.guardAICheckBox.Size = new System.Drawing.Size(115, 17);
            this.guardAICheckBox.TabIndex = 8;
            this.guardAICheckBox.Text = "Disable Guard AI";
            this.guardAICheckBox.UseVisualStyleBackColor = true;
            this.guardAICheckBox.CheckedChanged += new System.EventHandler(this.guardAICheckBox_CheckedChanged);
            //
            // infiniteJumpsCheckBox
            //
            this.infiniteJumpsCheckBox.AutoSize = true;
            this.infiniteJumpsCheckBox.Location = new System.Drawing.Point(16, 62);
            this.infiniteJumpsCheckBox.Name = "infiniteJumpsCheckBox";
            this.infiniteJumpsCheckBox.Size = new System.Drawing.Size(95, 17);
            this.infiniteJumpsCheckBox.TabIndex = 7;
            this.infiniteJumpsCheckBox.Text = "Infinite Jumps";
            this.infiniteJumpsCheckBox.UseVisualStyleBackColor = true;
            this.infiniteJumpsCheckBox.CheckedChanged += new System.EventHandler(this.infiniteJumpsCheckBox_CheckedChanged);
            //
            // invulnerabilityCheckBox
            //
            this.invulnerabilityCheckBox.AutoSize = true;
            this.invulnerabilityCheckBox.Location = new System.Drawing.Point(16, 42);
            this.invulnerabilityCheckBox.Name = "invulnerabilityCheckBox";
            this.invulnerabilityCheckBox.Size = new System.Drawing.Size(98, 17);
            this.invulnerabilityCheckBox.TabIndex = 6;
            this.invulnerabilityCheckBox.Text = "Invulnerability";
            this.invulnerabilityCheckBox.UseVisualStyleBackColor = true;
            this.invulnerabilityCheckBox.CheckedChanged += new System.EventHandler(this.invulnerabilityCheckBox_CheckedChanged);
            //
            // alwaysOnTopCheckBox
            //
            this.alwaysOnTopCheckBox.AutoSize = true;
            this.alwaysOnTopCheckBox.Location = new System.Drawing.Point(16, 22);
            this.alwaysOnTopCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.alwaysOnTopCheckBox.Name = "alwaysOnTopCheckBox";
            this.alwaysOnTopCheckBox.Size = new System.Drawing.Size(98, 17);
            this.alwaysOnTopCheckBox.TabIndex = 5;
            this.alwaysOnTopCheckBox.Text = "Always On Top";
            this.alwaysOnTopCheckBox.UseVisualStyleBackColor = true;
            this.alwaysOnTopCheckBox.CheckedChanged += new System.EventHandler(this.alwaysOnTopCheckBox_CheckedChanged);
            //
            // jobComboBox
            //
            this.jobComboBox.FormattingEnabled = true;
            this.jobComboBox.Items.AddRange(new object[] {
            "The Cooper Vault",
            " [TCV] Cave",
            " [TCV] Top",
            " [TCV] Chase",
            " [TCV] End",
            "Police HQ",
            " [PHQ] Exit the vent",
            " [PHQ] Crawl to the key",
            " [PHQ] Crawl back to Dimitri",
            " [PHQ] Pick the lock",
            " [PHQ] Carmelita chase",
            "Octavio Snap",
            " [OS] After 1st picture",
            " [OS] Taking 2nd picture",
            " [OS] After 2nd picture",
            " [OS] Taking 3rd picture",
            " [OS] After 3rd picture",
            " [OS] Taking 4th picture",
            " [OS] After 4th picture",
            " [OS] Ferris Wheel",
            "Into the Depths",
            " [ItD] Enter the Opera House",
            " [ItD] Canal",
            " [ItD] First laser door",
            " [ItD] Computer Room",
            "Canal Chase",
            " [CC] Start of the chase",
            "Turf War!",
            " [TW] Wave #1",
            " [TW] Wave #2",
            " [TW] Wave #3",
            " [TW] Wave #4",
            "Tar Ball",
            "Run \'n Bomb",
            " [RnB] After bomb 1",
            " [RnB] Deliever bomb 2",
            " [RnB] Climb the tower",
            " [RnB] Run to the shop",
            " [RnB] Chase Octavio",
            "Guard Duty",
            " [GD] Enter Coffee House #1",
            " [GD] Run to Coffee House #2",
            " [GD] Enter Coffee House #2",
            " [GD] Run to Coffee House #3",
            " [GD] Enter Coffee House #3",
            " [GD] Escape the guards",
            "OP: Tar Be Gone!",
            " [TBG] Enter the Opera House",
            " [TBG] Tar Pump room",
            " [TBG] Opera Minigame",
            " [TBG] Canal Chase",
            " [TBG] Boss fight",
            "Search for the Guru",
            " [SftG] Cave entrance",
            " [SftG] Guru\'s home",
            "Spelunking",
            " [S] Enter the cave",
            " [S] First piston",
            " [S] Second pistons",
            " [S] Drills",
            " [S] Find the Guru",
            "Dark Caves",
            " [DC] Enter cave #1",
            " [DC] Escape cave #1",
            " [DC] Find cave #2 entrance",
            " [DC] Enter cave #2",
            " [DC] Escape cave #2",
            "Big Truck",
            " [BT] Enter Ayer\'s Rock",
            " [BT] Phase 1",
            " [BT] Climb the tower",
            " [BT] Phase 2",
            " [BT] Release the scorpions",
            "Unleash the Guru",
            " [UtG] Find the drills",
            " [UtG] Drills",
            " [UtG] Generator",
            "The Claw",
            " [TC] Phase 1",
            " [TC] Phase 2",
            " [TC] Phase 3",
            "Lemon Rage",
            " [LR] Enter the bar",
            " [LR] Drinking contest",
            " [LR] Bar fight",
            " [LR] Boss fight",
            "Hungry Croc",
            " [HC] Feed the Croc",
            " [HC] Flashlight guard",
            "OP: Moon Crash",
            " [MC] Sleep darts",
            " [MC] Truck",
            " [MC] Climb",
            "Hidden Flight Roster",
            " [HFR] Exit the hotel",
            " [HFR] Find the castle",
            " [HFR] Castle Climb",
            " [HFR] Reach the hangar",
            " [HFR] Hangar",
            "Frame Team Belgium",
            " [FTB] Find the pilot",
            " [FTB] Pickpocket",
            " [FTB] Guru section",
            " [FTB] Sly section",
            "Frame Team Iceland",
            " [FTI] Rowing #1",
            " [FTI] Platforming #1",
            " [FTI] Hotel",
            " [FTI] Platforming #2",
            " [FTI] Rowing #2",
            " [FTI] Find the hangar",
            " [FTI] Hangar",
            "Cooper Hangar Defence",
            " [CHD] Muggshot",
            " [CHD] Sewers #1",
            " [CHD] Sewers #2",
            " [CHD] RC Chopper",
            "ACES Semi-finals",
            " [AS] Dogfight",
            "Giant Wolf Massacre",
            " [GWM] Guru section",
            "Windmill Firewall",
            " [WF] Hack #1",
            " [WF] Find computer #2",
            " [WF] Hack #2",
            " [WF] Find computer #3",
            " [WF] Hack #3",
            " [WF] Find computer #4",
            " [WF] Hack #4",
            "Beauty and the Beast",
            " [BatB] Find Muggshot",
            " [BatB] Find Carmelita",
            " [BatB] Muggshot fight",
            "OP: Turbo Dominant Eagle",
            " [TDE] Murray section",
            " [TDE] Dogfight",
            " [TDE] Boss fight",
            "King of Fire",
            " [KoF] Murray",
            " [KoF] Penelope",
            " [KoF] Sly",
            " [KoF] Bentley",
            " [KoF] Guru",
            " [KoF] Flashback",
            "Get a Job",
            " [GaJ] Talk to Tsao",
            " [GaJ] Picture #1",
            " [GaJ] Picture #2",
            " [GaJ] Picture #3",
            " [GaJ] Pictures of Tsao",
            "Tearful Reunion",
            " [TR] Free the van",
            " [TR] Defend Murray #1",
            " [TR] Defend Murray #2",
            "Grapple-Cam Break-in",
            " [GCB] Steal the keys",
            " [GCB] Exchange the keys",
            " [GCB] Break in the building",
            " [GCB] Lure #1",
            " [GCB] Lure #2",
            " [GCB] Find the computer",
            " [GCB] Hack",
            "Laptop Retrieval",
            " [LR] Find the computer",
            " [LR] Hack",
            " [LR] Guru section",
            " [LR] Tsao #1",
            " [LR] Tsao #2",
            "Vampiric Demise",
            " [VD] Panda King\'s house",
            " [VD] Tutorial",
            " [VD] Go to safe #2",
            " [VD] Defend Sly #1",
            " [VD] Go to safe #3",
            " [VD] Defend Sly #2",
            " [VD] Find the gravestone",
            " [VD] Destroy the gravestone",
            "Down the Line",
            " [DtL] RC section",
            "A Battery of Peril",
            " [ABoP] Carmelita",
            " [ABoP] Stabilize the battery",
            "OP: Wedding Crasher",
            " [WC] Open the door",
            " [WC] Reach the computer",
            " [WC] Destroy alarms",
            " [WC] Open the trapdoor",
            " [WC] Go to the palace",
            " [WC] Protect vases",
            " [WC] Lure Carmelita",
            " [WC] Dragon fight",
            "The Talk of Pirates",
            " [TToP] Stone-Jake",
            " [TToP] Find the loutenant",
            " [TToP] Steal the bootleg",
            " [TToP] Find Ned",
            " [TToP] Chase Ned",
            " [TToP] Return to Pete",
            " [TToP] Vinegar Talk",
            "Dynamic Duo",
            " [DD] Go to Skull Keep",
            " [DD] Floating boxes",
            " [DD] Beat the guards",
            " [DD] Lure Penelope #1",
            " [DD] Lure Penelope #2",
            " [DD] Lure Penelope #3",
            "Jollyboat of Destruction",
            " [JoD] Harbor patrol",
            " [JoD] Cutter",
            "X Marks the Spot",
            " [XMtS] Row to the ship",
            " [XMtS] Beat the guards",
            " [XMtS] Escape the bay",
            " [XMtS] Sail to Dagger Isle",
            " [XMtS] Sink the ship",
            " [XMtS] Dagger Isle",
            " [XMtS] Statue",
            " [XMtS] Dig up the chest",
            "Crusher from the Depths",
            " [CftD] Shoot Crusher #1",
            " [CftD] Shoot the tentacles",
            " [CftD] Shoot Crusher #2",
            " [CftD] Cannons",
            "Deep Sea Danger",
            " [DSD] Underwater",
            " [DSD] Collars",
            " [DSD] Fish",
            " [DSD] Hammersharks",
            "Battle on the High Seas",
            " [BotHS] Sail to fight #2",
            " [BotHS] Fight #2",
            " [BotHS] Sail to fight #3",
            " [BotHS] Fight #3",
            "OP: Reverse Double-Cross",
            " [RDC] Insult LefWee",
            " [RDC] Escape the ship",
            " [RDC] Skull Keep",
            " [RDC] Crusher",
            " [RDC] Boss fight",
            "Carmelita to the Rescue",
            " [CttR] Talk with Dr. M",
            "A Deadly Bite",
            " [ADB] Sharks #2",
            " [ADB] Sharks #3",
            " [ADB] Sharks #4",
            " [ADB] Return to the boat",
            "The Dark Current",
            " [TDC] Pinchers",
            " [TDC] Mutant fish",
            "Bump-Charge-Jump",
            " [BCJ] Track #1",
            " [BCJ] Track #2",
            " [BCJ] Track #3",
            "Danger in the Skies",
            " [DitS] Turrets",
            " [DitS] Bats",
            " [DitS] Dogfight",
            " [DitS] Paraglide",
            "The Ancestors\' Gauntlet",
            " [TAG] Enter the gauntlet",
            " [TAG] Slytunkhamen Cooper II",
            " [TAG] Sir Galleth Cooper",
            " [TAG] Salim al-Kupar",
            " [TAG] Slaigh MacCooper",
            " [TAG] Rioichi Cooper",
            " [TAG] Henriette Cooper",
            " [TAG] Tennessee Cooper",
            " [TAG] Thaddeus W. Cooper III",
            " [TAG] Otto van Cooper",
            " [TAG] Connor Cooper",
            "Stand Your Ground",
            " [SYG] Checkpoint #1",
            " [SYG] Checkpoint #2",
            " [SYG] Place the treasures",
            "Final Legacy",
            " [FL] Carmelita section",
            "Sly Tutorial #1",
            "Sly Tutorial #2",
            "Sly Tutorial #3",
            "Sly Tutorial #4",
            "Bentley Tutorial",
            "Murray Tutorial"});
            this.jobComboBox.Location = new System.Drawing.Point(16, 25);
            this.jobComboBox.Name = "jobComboBox";
            this.jobComboBox.Size = new System.Drawing.Size(177, 21);
            this.jobComboBox.TabIndex = 16;
            this.jobComboBox.Text = "Select a job...";
            //
            // loadJobButton
            //
            this.loadJobButton.Location = new System.Drawing.Point(16, 51);
            this.loadJobButton.Name = "loadJobButton";
            this.loadJobButton.Size = new System.Drawing.Size(88, 24);
            this.loadJobButton.TabIndex = 17;
            this.loadJobButton.Text = "Load";
            this.loadJobButton.UseVisualStyleBackColor = true;
            this.loadJobButton.Click += new System.EventHandler(this.loadJobButton_Click);
            //
            // skipCinematicsButton
            //
            this.skipCinematicsButton.Location = new System.Drawing.Point(15, 142);
            this.skipCinematicsButton.Name = "skipCinematicsButton";
            this.skipCinematicsButton.Size = new System.Drawing.Size(98, 40);
            this.skipCinematicsButton.TabIndex = 18;
            this.skipCinematicsButton.Text = "Skip Cinematic";
            this.skipCinematicsButton.UseVisualStyleBackColor = true;
            this.skipCinematicsButton.Click += new System.EventHandler(this.skipCinematicsButton_Click);
            //
            // fullReloadButton
            //
            this.fullReloadButton.Location = new System.Drawing.Point(106, 25);
            this.fullReloadButton.Name = "fullReloadButton";
            this.fullReloadButton.Size = new System.Drawing.Size(82, 33);
            this.fullReloadButton.TabIndex = 19;
            this.fullReloadButton.Text = "Reload (Full)";
            this.fullReloadButton.UseVisualStyleBackColor = true;
            this.fullReloadButton.Click += new System.EventHandler(this.fullReloadButton_Click);
            //
            // reloadGroupBox
            //
            this.reloadGroupBox.Controls.Add(this.label3);
            this.reloadGroupBox.Controls.Add(this.reloadAsCharacterComboBox);
            this.reloadGroupBox.Controls.Add(this.fastReloadButton);
            this.reloadGroupBox.Controls.Add(this.fullReloadButton);
            this.reloadGroupBox.Controls.Add(this.savePosButton);
            this.reloadGroupBox.Controls.Add(this.loadPosButton);
            this.reloadGroupBox.Location = new System.Drawing.Point(10, 218);
            this.reloadGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.reloadGroupBox.Name = "reloadGroupBox";
            this.reloadGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.reloadGroupBox.Size = new System.Drawing.Size(201, 135);
            this.reloadGroupBox.TabIndex = 20;
            this.reloadGroupBox.TabStop = false;
            this.reloadGroupBox.Text = "Reload";
            //
            // loadPosButton
            //
            this.loadPosButton.Location = new System.Drawing.Point(106, 98);
            this.loadPosButton.Name = "loadPosButton";
            this.loadPosButton.Size = new System.Drawing.Size(82, 30);
            this.loadPosButton.TabIndex = 27;
            this.loadPosButton.Text = "Load Pos";
            this.loadPosButton.UseVisualStyleBackColor = true;
            this.loadPosButton.Click += new System.EventHandler(this.loadPosButton_Click);
            //
            // savePosButton
            //
            this.savePosButton.Location = new System.Drawing.Point(13, 98);
            this.savePosButton.Name = "savePosButton";
            this.savePosButton.Size = new System.Drawing.Size(87, 30);
            this.savePosButton.TabIndex = 26;
            this.savePosButton.Text = "Save Pos";
            this.savePosButton.UseVisualStyleBackColor = true;
            this.savePosButton.Click += new System.EventHandler(this.savePosButton_Click);
            //
            // fastReloadButton
            //
            this.fastReloadButton.Location = new System.Drawing.Point(13, 25);
            this.fastReloadButton.Name = "fastReloadButton";
            this.fastReloadButton.Size = new System.Drawing.Size(87, 33);
            this.fastReloadButton.TabIndex = 21;
            this.fastReloadButton.Text = "Reload (Fast)";
            this.fastReloadButton.UseVisualStyleBackColor = true;
            this.fastReloadButton.Click += new System.EventHandler(this.fastReloadButton_Click);
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Character:";
            //
            // reloadAsCharacterComboBox
            //
            this.reloadAsCharacterComboBox.FormattingEnabled = true;
            this.reloadAsCharacterComboBox.Items.AddRange(new object[] {
            "Default",
            "Sly",
            "Bentley",
            "Murray",
            "Carmelita",
            "Guru",
            "Panda King",
            "Penelope"});
            this.reloadAsCharacterComboBox.Location = new System.Drawing.Point(75, 64);
            this.reloadAsCharacterComboBox.Name = "reloadAsCharacterComboBox";
            this.reloadAsCharacterComboBox.Size = new System.Drawing.Size(114, 21);
            this.reloadAsCharacterComboBox.TabIndex = 24;
            this.reloadAsCharacterComboBox.Text = "Default";
            //
            // healthTextBox
            //
            this.healthTextBox.Location = new System.Drawing.Point(16, 75);
            this.healthTextBox.Name = "healthTextBox";
            this.healthTextBox.Size = new System.Drawing.Size(112, 20);
            this.healthTextBox.TabIndex = 21;
            this.healthTextBox.TextChanged += new System.EventHandler(this.healthTextBox_TextChanged);
            //
            // setCoinsButton
            //
            this.setCoinsButton.Location = new System.Drawing.Point(134, 30);
            this.setCoinsButton.Name = "setCoinsButton";
            this.setCoinsButton.Size = new System.Drawing.Size(86, 24);
            this.setCoinsButton.TabIndex = 22;
            this.setCoinsButton.Text = "Set Coins";
            this.setCoinsButton.UseVisualStyleBackColor = true;
            this.setCoinsButton.Click += new System.EventHandler(this.setCoinsButton_Click);
            //
            // setHealthButton
            //
            this.setHealthButton.Location = new System.Drawing.Point(134, 72);
            this.setHealthButton.Name = "setHealthButton";
            this.setHealthButton.Size = new System.Drawing.Size(86, 24);
            this.setHealthButton.TabIndex = 23;
            this.setHealthButton.Text = "Set Health";
            this.setHealthButton.UseVisualStyleBackColor = true;
            this.setHealthButton.Click += new System.EventHandler(this.setHealthButton_Click);
            //
            // groupBox1
            //
            this.groupBox1.Controls.Add(this.labelJuice);
            this.groupBox1.Controls.Add(this.juiceTextBox);
            this.groupBox1.Controls.Add(this.setJuiceButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.setHealthButton);
            this.groupBox1.Controls.Add(this.coinsTextBox);
            this.groupBox1.Controls.Add(this.skipCinematicsButton);
            this.groupBox1.Controls.Add(this.setCoinsButton);
            this.groupBox1.Controls.Add(this.healthTextBox);
            this.groupBox1.Controls.Add(this.gadgetButton);
            this.groupBox1.Location = new System.Drawing.Point(226, 37);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(234, 195);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Utility";
            //
            // labelJuice
            //
            this.labelJuice.AutoSize = true;
            this.labelJuice.Location = new System.Drawing.Point(17, 101);
            this.labelJuice.Name = "labelJuice";
            this.labelJuice.Size = new System.Drawing.Size(35, 13);
            this.labelJuice.TabIndex = 30;
            this.labelJuice.Text = "Juice:";
            //
            // juiceTextBox
            //
            this.juiceTextBox.Location = new System.Drawing.Point(16, 117);
            this.juiceTextBox.Name = "juiceTextBox";
            this.juiceTextBox.Size = new System.Drawing.Size(112, 20);
            this.juiceTextBox.TabIndex = 29;
            //
            // setJuiceButton
            //
            this.setJuiceButton.Location = new System.Drawing.Point(134, 114);
            this.setJuiceButton.Name = "setJuiceButton";
            this.setJuiceButton.Size = new System.Drawing.Size(86, 24);
            this.setJuiceButton.TabIndex = 28;
            this.setJuiceButton.Text = "Set Juice";
            this.setJuiceButton.UseVisualStyleBackColor = true;
            this.setJuiceButton.Click += new System.EventHandler(this.setJuiceButton_Click);
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Health:";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Coins:";
            //
            // groupBox2
            //
            this.groupBox2.Controls.Add(this.mapComboBox);
            this.groupBox2.Controls.Add(this.loadMapButton);
            this.groupBox2.Location = new System.Drawing.Point(10, 37);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(205, 84);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Locations";
            //
            // jobGroupBox
            //
            this.jobGroupBox.Controls.Add(this.jobComboBox);
            this.jobGroupBox.Controls.Add(this.loadJobButton);
            this.jobGroupBox.Location = new System.Drawing.Point(6, 125);
            this.jobGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.jobGroupBox.Name = "jobGroupBox";
            this.jobGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.jobGroupBox.Size = new System.Drawing.Size(205, 89);
            this.jobGroupBox.TabIndex = 26;
            this.jobGroupBox.TabStop = false;
            this.jobGroupBox.Text = "Jobs";
            //
            // miscGroupBox
            //
            this.miscGroupBox.Controls.Add(this.labelDD);
            this.miscGroupBox.Controls.Add(this.drawDistTextBox);
            this.miscGroupBox.Controls.Add(this.setDrawDistButton);
            this.miscGroupBox.Controls.Add(this.labelFOV);
            this.miscGroupBox.Controls.Add(this.fovTextBox);
            this.miscGroupBox.Controls.Add(this.setFOVButton);
            this.miscGroupBox.Controls.Add(this.labelSpeed);
            this.miscGroupBox.Controls.Add(this.speedTextBox);
            this.miscGroupBox.Controls.Add(this.setSpeedButton);
            this.miscGroupBox.Location = new System.Drawing.Point(10, 362);
            this.miscGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.miscGroupBox.Name = "miscGroupBox";
            this.miscGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.miscGroupBox.Size = new System.Drawing.Size(201, 130);
            this.miscGroupBox.TabIndex = 31;
            this.miscGroupBox.TabStop = false;
            this.miscGroupBox.Text = "Misc";
            //
            // labelDD
            //
            this.labelDD.AutoSize = true;
            this.labelDD.Location = new System.Drawing.Point(14, 102);
            this.labelDD.Name = "labelDD";
            this.labelDD.Size = new System.Drawing.Size(57, 13);
            this.labelDD.TabIndex = 40;
            this.labelDD.Text = "Draw dist.:";
            //
            // drawDistTextBox
            //
            this.drawDistTextBox.Location = new System.Drawing.Point(13, 117);
            this.drawDistTextBox.Name = "drawDistTextBox";
            this.drawDistTextBox.Size = new System.Drawing.Size(80, 20);
            this.drawDistTextBox.TabIndex = 39;
            //
            // setDrawDistButton
            //
            this.setDrawDistButton.Location = new System.Drawing.Point(100, 114);
            this.setDrawDistButton.Name = "setDrawDistButton";
            this.setDrawDistButton.Size = new System.Drawing.Size(88, 25);
            this.setDrawDistButton.TabIndex = 38;
            this.setDrawDistButton.Text = "Set Dist";
            this.setDrawDistButton.UseVisualStyleBackColor = true;
            this.setDrawDistButton.Click += new System.EventHandler(this.setDrawDistButton_Click);
            //
            // labelFOV
            //
            this.labelFOV.AutoSize = true;
            this.labelFOV.Location = new System.Drawing.Point(14, 60);
            this.labelFOV.Name = "labelFOV";
            this.labelFOV.Size = new System.Drawing.Size(67, 13);
            this.labelFOV.TabIndex = 37;
            this.labelFOV.Text = "Camera FOV:";
            //
            // fovTextBox
            //
            this.fovTextBox.Location = new System.Drawing.Point(13, 75);
            this.fovTextBox.Name = "fovTextBox";
            this.fovTextBox.Size = new System.Drawing.Size(80, 20);
            this.fovTextBox.TabIndex = 36;
            //
            // setFOVButton
            //
            this.setFOVButton.Location = new System.Drawing.Point(100, 72);
            this.setFOVButton.Name = "setFOVButton";
            this.setFOVButton.Size = new System.Drawing.Size(88, 25);
            this.setFOVButton.TabIndex = 35;
            this.setFOVButton.Text = "Set FOV";
            this.setFOVButton.UseVisualStyleBackColor = true;
            this.setFOVButton.Click += new System.EventHandler(this.setFOVButton_Click);
            //
            // labelSpeed
            //
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(14, 18);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(67, 13);
            this.labelSpeed.TabIndex = 34;
            this.labelSpeed.Text = "Speed mult.:";
            //
            // speedTextBox
            //
            this.speedTextBox.Location = new System.Drawing.Point(13, 33);
            this.speedTextBox.Name = "speedTextBox";
            this.speedTextBox.Size = new System.Drawing.Size(80, 20);
            this.speedTextBox.TabIndex = 33;
            //
            // setSpeedButton
            //
            this.setSpeedButton.Location = new System.Drawing.Point(100, 30);
            this.setSpeedButton.Name = "setSpeedButton";
            this.setSpeedButton.Size = new System.Drawing.Size(88, 25);
            this.setSpeedButton.TabIndex = 32;
            this.setSpeedButton.Text = "Set Speed";
            this.setSpeedButton.UseVisualStyleBackColor = true;
            this.setSpeedButton.Click += new System.EventHandler(this.setSpeedButton_Click);
            //
            // SLY3Form
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 505);
            this.Controls.Add(this.jobGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reloadGroupBox);
            this.Controls.Add(this.miscGroupBox);
            this.Controls.Add(this.toggleGroupBox);
            this.Controls.Add(this.inputDisplayButton);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SLY3Form";
            this.Text = "SluMAN :: Sly 3: Honor Among Thieves (Practice Mode)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SLY3Form_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SLY3Form_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toggleGroupBox.ResumeLayout(false);
            this.toggleGroupBox.PerformLayout();
            this.reloadGroupBox.ResumeLayout(false);
            this.reloadGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.jobGroupBox.ResumeLayout(false);
            this.miscGroupBox.ResumeLayout(false);
            this.miscGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox coinsTextBox;
        private System.Windows.Forms.Button inputDisplayButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputDisplayToolStripMenuItem;
        private System.Windows.Forms.ComboBox mapComboBox;
        private System.Windows.Forms.Button loadMapButton;
        private System.Windows.Forms.Button gadgetButton;
        private System.Windows.Forms.GroupBox toggleGroupBox;
        private System.Windows.Forms.CheckBox alwaysOnTopCheckBox;
        private System.Windows.Forms.ComboBox jobComboBox;
        private System.Windows.Forms.Button loadJobButton;
        private System.Windows.Forms.Button skipCinematicsButton;
        private System.Windows.Forms.Button fullReloadButton;
        private System.Windows.Forms.GroupBox reloadGroupBox;
        private System.Windows.Forms.Button fastReloadButton;
        private System.Windows.Forms.TextBox healthTextBox;
        private System.Windows.Forms.Button setCoinsButton;
        private System.Windows.Forms.Button setHealthButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox jobGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem powerOffPS3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rebootPS3ToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox reloadAsCharacterComboBox;
        private System.Windows.Forms.CheckBox invulnerabilityCheckBox;
        private System.Windows.Forms.CheckBox infiniteJumpsCheckBox;
        private System.Windows.Forms.CheckBox guardAICheckBox;
        private System.Windows.Forms.CheckBox undetectableCheckBox;
        private System.Windows.Forms.CheckBox deathBarriersCheckBox;
        private System.Windows.Forms.CheckBox gameClockCheckBox;
        private System.Windows.Forms.TextBox juiceTextBox;
        private System.Windows.Forms.Button setJuiceButton;
        private System.Windows.Forms.Label labelJuice;
        private System.Windows.Forms.Button savePosButton;
        private System.Windows.Forms.Button loadPosButton;
        private System.Windows.Forms.GroupBox miscGroupBox;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.TextBox speedTextBox;
        private System.Windows.Forms.Button setSpeedButton;
        private System.Windows.Forms.Label labelFOV;
        private System.Windows.Forms.TextBox fovTextBox;
        private System.Windows.Forms.Button setFOVButton;
        private System.Windows.Forms.Label labelDD;
        private System.Windows.Forms.TextBox drawDistTextBox;
        private System.Windows.Forms.Button setDrawDistButton;
    }
}
