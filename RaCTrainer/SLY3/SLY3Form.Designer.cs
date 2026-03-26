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
            this.mapComboBox = new System.Windows.Forms.ComboBox();
            this.loadMapButton = new System.Windows.Forms.Button();
            this.gadgetButton = new System.Windows.Forms.Button();
            this.toggleGroupBox = new System.Windows.Forms.GroupBox();
            this.alwaysOnTopCheckBox = new System.Windows.Forms.CheckBox();
            this.jobComboBox = new System.Windows.Forms.ComboBox();
            this.loadJobButton = new System.Windows.Forms.Button();
            this.skipCinematicsButton = new System.Windows.Forms.Button();
            this.fullReloadButton = new System.Windows.Forms.Button();
            this.reloadGroupBox = new System.Windows.Forms.GroupBox();
            this.fastReloadButton = new System.Windows.Forms.Button();
            this.healthTextBox = new System.Windows.Forms.TextBox();
            this.setCoinsButton = new System.Windows.Forms.Button();
            this.setHealthButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.jobGroupBox = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.toggleGroupBox.SuspendLayout();
            this.reloadGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.jobGroupBox.SuspendLayout();
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
            this.inputDisplayButton.Location = new System.Drawing.Point(226, 255);
            this.inputDisplayButton.Name = "inputDisplayButton";
            this.inputDisplayButton.Size = new System.Drawing.Size(234, 40);
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
            this.inputDisplayToolStripMenuItem});
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
            this.gadgetButton.Location = new System.Drawing.Point(119, 99);
            this.gadgetButton.Name = "gadgetButton";
            this.gadgetButton.Size = new System.Drawing.Size(101, 40);
            this.gadgetButton.TabIndex = 11;
            this.gadgetButton.Text = "Gadgets";
            this.gadgetButton.UseVisualStyleBackColor = true;
            this.gadgetButton.Click += new System.EventHandler(this.gadgetsButton_Click);
            // 
            // toggleGroupBox
            // 
            this.toggleGroupBox.Controls.Add(this.alwaysOnTopCheckBox);
            this.toggleGroupBox.Location = new System.Drawing.Point(226, 196);
            this.toggleGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.toggleGroupBox.Name = "toggleGroupBox";
            this.toggleGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.toggleGroupBox.Size = new System.Drawing.Size(234, 50);
            this.toggleGroupBox.TabIndex = 15;
            this.toggleGroupBox.TabStop = false;
            this.toggleGroupBox.Text = "Toggles";
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
            "A Deadly Bite",
            " [ADB] Sharks #2",
            " [ADB] Sharks #3",
            " [ADB] Sharks #4",
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
            this.skipCinematicsButton.Location = new System.Drawing.Point(15, 99);
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
            this.fullReloadButton.Size = new System.Drawing.Size(82, 40);
            this.fullReloadButton.TabIndex = 19;
            this.fullReloadButton.Text = "Reload (Full)";
            this.fullReloadButton.UseVisualStyleBackColor = true;
            this.fullReloadButton.Click += new System.EventHandler(this.fullReloadButton_Click);
            // 
            // reloadGroupBox
            // 
            this.reloadGroupBox.Controls.Add(this.fastReloadButton);
            this.reloadGroupBox.Controls.Add(this.fullReloadButton);
            this.reloadGroupBox.Location = new System.Drawing.Point(10, 218);
            this.reloadGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.reloadGroupBox.Name = "reloadGroupBox";
            this.reloadGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.reloadGroupBox.Size = new System.Drawing.Size(201, 77);
            this.reloadGroupBox.TabIndex = 20;
            this.reloadGroupBox.TabStop = false;
            this.reloadGroupBox.Text = "Reload";
            // 
            // fastReloadButton
            // 
            this.fastReloadButton.Location = new System.Drawing.Point(13, 25);
            this.fastReloadButton.Name = "fastReloadButton";
            this.fastReloadButton.Size = new System.Drawing.Size(87, 40);
            this.fastReloadButton.TabIndex = 21;
            this.fastReloadButton.Text = "Reload (Fast)";
            this.fastReloadButton.UseVisualStyleBackColor = true;
            this.fastReloadButton.Click += new System.EventHandler(this.fastReloadButton_Click);
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
            this.groupBox1.Size = new System.Drawing.Size(234, 155);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Utility";
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
            // SLY3Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 309);
            this.Controls.Add(this.jobGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reloadGroupBox);
            this.Controls.Add(this.toggleGroupBox);
            this.Controls.Add(this.inputDisplayButton);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SLY3Form";
            this.Text = "SluMAN :: Sly 3: Honor Among Thieves - NPEA00343 (Practice Mode)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SLY3Form_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toggleGroupBox.ResumeLayout(false);
            this.toggleGroupBox.PerformLayout();
            this.reloadGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.jobGroupBox.ResumeLayout(false);
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
    }
}