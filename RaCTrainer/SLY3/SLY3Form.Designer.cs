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
            this.savePosButton = new System.Windows.Forms.Button();
            this.loadPosButton = new System.Windows.Forms.Button();
            this.positionsComboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureButtonCombosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.inputDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapComboBox = new System.Windows.Forms.ComboBox();
            this.loadMapButton = new System.Windows.Forms.Button();
            this.gadgetButton = new System.Windows.Forms.Button();
            this.setLanguageButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.toggleGroupBox = new System.Windows.Forms.GroupBox();
            this.infiniteHealthCheckBox = new System.Windows.Forms.CheckBox();
            this.infiniteJuiceCheckBox = new System.Windows.Forms.CheckBox();
            this.disableGuardAiCheckBox = new System.Windows.Forms.CheckBox();
            this.invulnerabilityCheckBox = new System.Windows.Forms.CheckBox();
            this.infiniteJumpsCheckBox = new System.Windows.Forms.CheckBox();
            this.alwaysOnTopCheckBox = new System.Windows.Forms.CheckBox();
            this.jobComboBox = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.skipCinematicsButton = new System.Windows.Forms.Button();
            this.fullReloadButton = new System.Windows.Forms.Button();
            this.reloadGroupBox = new System.Windows.Forms.GroupBox();
            this.fastReloadButton = new System.Windows.Forms.Button();
            this.healthTextBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.jobGroupBox = new System.Windows.Forms.GroupBox();
            this.abandonJobButton = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.webMANShortcutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turnOffPS3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitTheGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.coinsTextBox.Location = new System.Drawing.Point(21, 37);
            this.coinsTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.coinsTextBox.Name = "coinsTextBox";
            this.coinsTextBox.Size = new System.Drawing.Size(148, 22);
            this.coinsTextBox.TabIndex = 0;
            this.coinsTextBox.Text = "Set coins...";
            this.coinsTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.coinsTextBox_KeyDown);
            // 
            // inputDisplayButton
            // 
            this.inputDisplayButton.Location = new System.Drawing.Point(632, 216);
            this.inputDisplayButton.Margin = new System.Windows.Forms.Padding(4);
            this.inputDisplayButton.Name = "inputDisplayButton";
            this.inputDisplayButton.Size = new System.Drawing.Size(154, 49);
            this.inputDisplayButton.TabIndex = 1;
            this.inputDisplayButton.Text = "Input Display";
            this.inputDisplayButton.UseVisualStyleBackColor = true;
            this.inputDisplayButton.Click += new System.EventHandler(this.inputDisplayButton_Click);
            // 
            // savePosButton
            // 
            this.savePosButton.Location = new System.Drawing.Point(20, 154);
            this.savePosButton.Margin = new System.Windows.Forms.Padding(4);
            this.savePosButton.Name = "savePosButton";
            this.savePosButton.Size = new System.Drawing.Size(113, 30);
            this.savePosButton.TabIndex = 3;
            this.savePosButton.Text = "Save Position";
            this.savePosButton.UseVisualStyleBackColor = true;
            this.savePosButton.Click += new System.EventHandler(this.savePosButton_Click);
            // 
            // loadPosButton
            // 
            this.loadPosButton.Location = new System.Drawing.Point(141, 155);
            this.loadPosButton.Margin = new System.Windows.Forms.Padding(4);
            this.loadPosButton.Name = "loadPosButton";
            this.loadPosButton.Size = new System.Drawing.Size(116, 30);
            this.loadPosButton.TabIndex = 4;
            this.loadPosButton.Text = "Load Position";
            this.loadPosButton.UseVisualStyleBackColor = true;
            this.loadPosButton.Click += new System.EventHandler(this.loadPosButton_Click);
            // 
            // positionsComboBox
            // 
            this.positionsComboBox.FormattingEnabled = true;
            this.positionsComboBox.Location = new System.Drawing.Point(20, 122);
            this.positionsComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.positionsComboBox.Name = "positionsComboBox";
            this.positionsComboBox.Size = new System.Drawing.Size(237, 24);
            this.positionsComboBox.TabIndex = 5;
            this.positionsComboBox.Text = "Select position slot...";
            this.positionsComboBox.SelectedIndexChanged += new System.EventHandler(this.positionsComboBox_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.webMANShortcutsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(801, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchGameToolStripMenuItem,
            this.configureButtonCombosToolStripMenuItem,
            this.toolStripSeparator1,
            this.inputDisplayToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // switchGameToolStripMenuItem
            // 
            this.switchGameToolStripMenuItem.Name = "switchGameToolStripMenuItem";
            this.switchGameToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.switchGameToolStripMenuItem.Text = "Switch Game";
            this.switchGameToolStripMenuItem.Click += new System.EventHandler(this.switchGameToolStripMenuItem_Click);
            // 
            // configureButtonCombosToolStripMenuItem
            // 
            this.configureButtonCombosToolStripMenuItem.Name = "configureButtonCombosToolStripMenuItem";
            this.configureButtonCombosToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.configureButtonCombosToolStripMenuItem.Text = "Configure Button Combos";
            this.configureButtonCombosToolStripMenuItem.Click += new System.EventHandler(this.configureButtonCombosToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(261, 6);
            // 
            // inputDisplayToolStripMenuItem
            // 
            this.inputDisplayToolStripMenuItem.Name = "inputDisplayToolStripMenuItem";
            this.inputDisplayToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.inputDisplayToolStripMenuItem.Text = "Input Display";
            this.inputDisplayToolStripMenuItem.Click += new System.EventHandler(this.inputDisplayToolStripMenuItem_Click);
            // 
            // mapComboBox
            // 
            this.mapComboBox.FormattingEnabled = true;
            this.mapComboBox.Location = new System.Drawing.Point(20, 31);
            this.mapComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.mapComboBox.Name = "mapComboBox";
            this.mapComboBox.Size = new System.Drawing.Size(237, 24);
            this.mapComboBox.TabIndex = 8;
            this.mapComboBox.Text = "Select a map...";
            // 
            // loadMapButton
            // 
            this.loadMapButton.Location = new System.Drawing.Point(20, 63);
            this.loadMapButton.Margin = new System.Windows.Forms.Padding(4);
            this.loadMapButton.Name = "loadMapButton";
            this.loadMapButton.Size = new System.Drawing.Size(113, 30);
            this.loadMapButton.TabIndex = 9;
            this.loadMapButton.Text = "Load Map";
            this.loadMapButton.UseVisualStyleBackColor = true;
            this.loadMapButton.Click += new System.EventHandler(this.loadMapButton_Click);
            // 
            // gadgetButton
            // 
            this.gadgetButton.Location = new System.Drawing.Point(160, 109);
            this.gadgetButton.Margin = new System.Windows.Forms.Padding(4);
            this.gadgetButton.Name = "gadgetButton";
            this.gadgetButton.Size = new System.Drawing.Size(135, 49);
            this.gadgetButton.TabIndex = 11;
            this.gadgetButton.Text = "Gadgets";
            this.gadgetButton.UseVisualStyleBackColor = true;
            this.gadgetButton.Click += new System.EventHandler(this.gadgetsButton_Click);
            // 
            // setLanguageButton
            // 
            this.setLanguageButton.Location = new System.Drawing.Point(178, 177);
            this.setLanguageButton.Margin = new System.Windows.Forms.Padding(4);
            this.setLanguageButton.Name = "setLanguageButton";
            this.setLanguageButton.Size = new System.Drawing.Size(115, 28);
            this.setLanguageButton.TabIndex = 13;
            this.setLanguageButton.Text = "Set Language";
            this.setLanguageButton.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(21, 179);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(148, 24);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.Text = "Set language...";
            // 
            // toggleGroupBox
            // 
            this.toggleGroupBox.Controls.Add(this.alwaysOnTopCheckBox);
            this.toggleGroupBox.Controls.Add(this.infiniteJumpsCheckBox);
            this.toggleGroupBox.Controls.Add(this.invulnerabilityCheckBox);
            this.toggleGroupBox.Controls.Add(this.disableGuardAiCheckBox);
            this.toggleGroupBox.Controls.Add(this.infiniteJuiceCheckBox);
            this.toggleGroupBox.Controls.Add(this.infiniteHealthCheckBox);
            this.toggleGroupBox.Location = new System.Drawing.Point(14, 254);
            this.toggleGroupBox.Name = "toggleGroupBox";
            this.toggleGroupBox.Size = new System.Drawing.Size(273, 180);
            this.toggleGroupBox.TabIndex = 15;
            this.toggleGroupBox.TabStop = false;
            this.toggleGroupBox.Text = "Toggles";
            this.toggleGroupBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // infiniteHealthCheckBox
            // 
            this.infiniteHealthCheckBox.AutoSize = true;
            this.infiniteHealthCheckBox.Location = new System.Drawing.Point(7, 22);
            this.infiniteHealthCheckBox.Name = "infiniteHealthCheckBox";
            this.infiniteHealthCheckBox.Size = new System.Drawing.Size(108, 20);
            this.infiniteHealthCheckBox.TabIndex = 0;
            this.infiniteHealthCheckBox.Text = "Infinite Health";
            this.infiniteHealthCheckBox.UseVisualStyleBackColor = true;
            // 
            // infiniteJuiceCheckBox
            // 
            this.infiniteJuiceCheckBox.AutoSize = true;
            this.infiniteJuiceCheckBox.Location = new System.Drawing.Point(7, 48);
            this.infiniteJuiceCheckBox.Name = "infiniteJuiceCheckBox";
            this.infiniteJuiceCheckBox.Size = new System.Drawing.Size(155, 20);
            this.infiniteJuiceCheckBox.TabIndex = 1;
            this.infiniteJuiceCheckBox.Text = "Infinite Gadget Power";
            this.infiniteJuiceCheckBox.UseVisualStyleBackColor = true;
            // 
            // disableGuardAiCheckBox
            // 
            this.disableGuardAiCheckBox.AutoSize = true;
            this.disableGuardAiCheckBox.Location = new System.Drawing.Point(7, 74);
            this.disableGuardAiCheckBox.Name = "disableGuardAiCheckBox";
            this.disableGuardAiCheckBox.Size = new System.Drawing.Size(131, 20);
            this.disableGuardAiCheckBox.TabIndex = 2;
            this.disableGuardAiCheckBox.Text = "Disable Guard AI";
            this.disableGuardAiCheckBox.UseVisualStyleBackColor = true;
            // 
            // invulnerabilityCheckBox
            // 
            this.invulnerabilityCheckBox.AutoSize = true;
            this.invulnerabilityCheckBox.Location = new System.Drawing.Point(7, 100);
            this.invulnerabilityCheckBox.Name = "invulnerabilityCheckBox";
            this.invulnerabilityCheckBox.Size = new System.Drawing.Size(110, 20);
            this.invulnerabilityCheckBox.TabIndex = 3;
            this.invulnerabilityCheckBox.Text = "Invulnerability";
            this.invulnerabilityCheckBox.UseVisualStyleBackColor = true;
            // 
            // infiniteJumpsCheckBox
            // 
            this.infiniteJumpsCheckBox.AutoSize = true;
            this.infiniteJumpsCheckBox.Location = new System.Drawing.Point(7, 126);
            this.infiniteJumpsCheckBox.Name = "infiniteJumpsCheckBox";
            this.infiniteJumpsCheckBox.Size = new System.Drawing.Size(109, 20);
            this.infiniteJumpsCheckBox.TabIndex = 4;
            this.infiniteJumpsCheckBox.Text = "Infinite Jumps";
            this.infiniteJumpsCheckBox.UseVisualStyleBackColor = true;
            // 
            // alwaysOnTopCheckBox
            // 
            this.alwaysOnTopCheckBox.AutoSize = true;
            this.alwaysOnTopCheckBox.Location = new System.Drawing.Point(7, 152);
            this.alwaysOnTopCheckBox.Name = "alwaysOnTopCheckBox";
            this.alwaysOnTopCheckBox.Size = new System.Drawing.Size(120, 20);
            this.alwaysOnTopCheckBox.TabIndex = 5;
            this.alwaysOnTopCheckBox.Text = "Always On Top";
            this.alwaysOnTopCheckBox.UseVisualStyleBackColor = true;
            // 
            // jobComboBox
            // 
            this.jobComboBox.FormattingEnabled = true;
            this.jobComboBox.Location = new System.Drawing.Point(21, 31);
            this.jobComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.jobComboBox.Name = "jobComboBox";
            this.jobComboBox.Size = new System.Drawing.Size(272, 24);
            this.jobComboBox.TabIndex = 16;
            this.jobComboBox.Text = "Select a job...";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(21, 63);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 30);
            this.button2.TabIndex = 17;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // skipCinematicsButton
            // 
            this.skipCinematicsButton.Location = new System.Drawing.Point(21, 109);
            this.skipCinematicsButton.Margin = new System.Windows.Forms.Padding(4);
            this.skipCinematicsButton.Name = "skipCinematicsButton";
            this.skipCinematicsButton.Size = new System.Drawing.Size(131, 49);
            this.skipCinematicsButton.TabIndex = 18;
            this.skipCinematicsButton.Text = "Skip Cinematic";
            this.skipCinematicsButton.UseVisualStyleBackColor = true;
            // 
            // fullReloadButton
            // 
            this.fullReloadButton.Location = new System.Drawing.Point(17, 85);
            this.fullReloadButton.Margin = new System.Windows.Forms.Padding(4);
            this.fullReloadButton.Name = "fullReloadButton";
            this.fullReloadButton.Size = new System.Drawing.Size(123, 49);
            this.fullReloadButton.TabIndex = 19;
            this.fullReloadButton.Text = "Reload (Full)";
            this.fullReloadButton.UseVisualStyleBackColor = true;
            this.fullReloadButton.Click += new System.EventHandler(this.fullReloadButton_Click);
            // 
            // reloadGroupBox
            // 
            this.reloadGroupBox.Controls.Add(this.fastReloadButton);
            this.reloadGroupBox.Controls.Add(this.fullReloadButton);
            this.reloadGroupBox.Location = new System.Drawing.Point(630, 50);
            this.reloadGroupBox.Name = "reloadGroupBox";
            this.reloadGroupBox.Size = new System.Drawing.Size(156, 152);
            this.reloadGroupBox.TabIndex = 20;
            this.reloadGroupBox.TabStop = false;
            this.reloadGroupBox.Text = "Reload";
            // 
            // fastReloadButton
            // 
            this.fastReloadButton.Location = new System.Drawing.Point(17, 31);
            this.fastReloadButton.Margin = new System.Windows.Forms.Padding(4);
            this.fastReloadButton.Name = "fastReloadButton";
            this.fastReloadButton.Size = new System.Drawing.Size(123, 49);
            this.fastReloadButton.TabIndex = 21;
            this.fastReloadButton.Text = "Reload (Fast)";
            this.fastReloadButton.UseVisualStyleBackColor = true;
            this.fastReloadButton.Click += new System.EventHandler(this.fastReloadButton_Click);
            // 
            // healthTextBox
            // 
            this.healthTextBox.Location = new System.Drawing.Point(21, 69);
            this.healthTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.healthTextBox.Name = "healthTextBox";
            this.healthTextBox.Size = new System.Drawing.Size(148, 22);
            this.healthTextBox.TabIndex = 21;
            this.healthTextBox.Text = "Set health...";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(178, 37);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 22);
            this.button3.TabIndex = 22;
            this.button3.Text = "Set Coins";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(178, 71);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(115, 22);
            this.button4.TabIndex = 23;
            this.button4.Text = "Set Health";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.coinsTextBox);
            this.groupBox1.Controls.Add(this.skipCinematicsButton);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.healthTextBox);
            this.groupBox1.Controls.Add(this.setLanguageButton);
            this.groupBox1.Controls.Add(this.gadgetButton);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(301, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 222);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Utility";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mapComboBox);
            this.groupBox2.Controls.Add(this.loadMapButton);
            this.groupBox2.Controls.Add(this.loadPosButton);
            this.groupBox2.Controls.Add(this.positionsComboBox);
            this.groupBox2.Controls.Add(this.savePosButton);
            this.groupBox2.Location = new System.Drawing.Point(14, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 203);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Locations";
            // 
            // jobGroupBox
            // 
            this.jobGroupBox.Controls.Add(this.abandonJobButton);
            this.jobGroupBox.Controls.Add(this.jobComboBox);
            this.jobGroupBox.Controls.Add(this.button2);
            this.jobGroupBox.Location = new System.Drawing.Point(301, 278);
            this.jobGroupBox.Name = "jobGroupBox";
            this.jobGroupBox.Size = new System.Drawing.Size(312, 110);
            this.jobGroupBox.TabIndex = 26;
            this.jobGroupBox.TabStop = false;
            this.jobGroupBox.Text = "Jobs";
            // 
            // abandonJobButton
            // 
            this.abandonJobButton.Location = new System.Drawing.Point(178, 62);
            this.abandonJobButton.Margin = new System.Windows.Forms.Padding(4);
            this.abandonJobButton.Name = "abandonJobButton";
            this.abandonJobButton.Size = new System.Drawing.Size(117, 30);
            this.abandonJobButton.TabIndex = 18;
            this.abandonJobButton.Text = "Abandon Job";
            this.abandonJobButton.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(301, 402);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(152, 24);
            this.comboBox2.TabIndex = 19;
            this.comboBox2.Text = "Select character...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(461, 400);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 26);
            this.button1.TabIndex = 19;
            this.button1.Text = "Select and Reload";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // webMANShortcutsToolStripMenuItem
            // 
            this.webMANShortcutsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.turnOffPS3ToolStripMenuItem,
            this.rebootToolStripMenuItem,
            this.exitTheGameToolStripMenuItem});
            this.webMANShortcutsToolStripMenuItem.Name = "webMANShortcutsToolStripMenuItem";
            this.webMANShortcutsToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.webMANShortcutsToolStripMenuItem.Text = "PS3 Tools";
            this.webMANShortcutsToolStripMenuItem.Click += new System.EventHandler(this.webMANShortcutsToolStripMenuItem_Click);
            // 
            // turnOffPS3ToolStripMenuItem
            // 
            this.turnOffPS3ToolStripMenuItem.Name = "turnOffPS3ToolStripMenuItem";
            this.turnOffPS3ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.turnOffPS3ToolStripMenuItem.Text = "Turn off the console";
            // 
            // rebootToolStripMenuItem
            // 
            this.rebootToolStripMenuItem.Name = "rebootToolStripMenuItem";
            this.rebootToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.rebootToolStripMenuItem.Text = "Reboot the game";
            // 
            // exitTheGameToolStripMenuItem
            // 
            this.exitTheGameToolStripMenuItem.Name = "exitTheGameToolStripMenuItem";
            this.exitTheGameToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitTheGameToolStripMenuItem.Text = "Exit the game";
            // 
            // SLY3Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 581);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.jobGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reloadGroupBox);
            this.Controls.Add(this.toggleGroupBox);
            this.Controls.Add(this.inputDisplayButton);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SLY3Form";
            this.Text = "SluMAN :: Sly 3: Honor Among Thieves - NPEA00343 (Practice Mode)";
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
        private System.Windows.Forms.Button savePosButton;
        private System.Windows.Forms.Button loadPosButton;
        private System.Windows.Forms.ComboBox positionsComboBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureButtonCombosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem inputDisplayToolStripMenuItem;
        private System.Windows.Forms.ComboBox mapComboBox;
        private System.Windows.Forms.Button loadMapButton;
        private System.Windows.Forms.Button gadgetButton;
        private System.Windows.Forms.Button setLanguageButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox toggleGroupBox;
        private System.Windows.Forms.CheckBox alwaysOnTopCheckBox;
        private System.Windows.Forms.CheckBox infiniteJumpsCheckBox;
        private System.Windows.Forms.CheckBox invulnerabilityCheckBox;
        private System.Windows.Forms.CheckBox disableGuardAiCheckBox;
        private System.Windows.Forms.CheckBox infiniteJuiceCheckBox;
        private System.Windows.Forms.CheckBox infiniteHealthCheckBox;
        private System.Windows.Forms.ComboBox jobComboBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button skipCinematicsButton;
        private System.Windows.Forms.Button fullReloadButton;
        private System.Windows.Forms.GroupBox reloadGroupBox;
        private System.Windows.Forms.Button fastReloadButton;
        private System.Windows.Forms.TextBox healthTextBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox jobGroupBox;
        private System.Windows.Forms.Button abandonJobButton;
        private System.Windows.Forms.ToolStripMenuItem webMANShortcutsToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem turnOffPS3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rebootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitTheGameToolStripMenuItem;
    }
}