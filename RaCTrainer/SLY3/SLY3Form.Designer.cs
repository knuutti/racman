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
            this.coinsTextBox = new System.Windows.Forms.TextBox();
            this.inputDisplayButton = new System.Windows.Forms.Button();
            this.coinsLabel = new System.Windows.Forms.Label();
            this.savePosButton = new System.Windows.Forms.Button();
            this.loadPosButton = new System.Windows.Forms.Button();
            this.positionsComboBox = new System.Windows.Forms.ComboBox();
            this.positionSlotLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.switchGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureButtonCombosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.inputDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memoryUtilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // coinsTextBox
            // 
            this.coinsTextBox.Location = new System.Drawing.Point(175, 67);
            this.coinsTextBox.Name = "coinsTextBox";
            this.coinsTextBox.Size = new System.Drawing.Size(100, 20);
            this.coinsTextBox.TabIndex = 0;
            this.coinsTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.coinsTextBox_KeyDown);
            // 
            // inputDisplayButton
            // 
            this.inputDisplayButton.Location = new System.Drawing.Point(139, 112);
            this.inputDisplayButton.Name = "inputDisplayButton";
            this.inputDisplayButton.Size = new System.Drawing.Size(96, 23);
            this.inputDisplayButton.TabIndex = 1;
            this.inputDisplayButton.Text = "Input Display";
            this.inputDisplayButton.UseVisualStyleBackColor = true;
            this.inputDisplayButton.Click += new System.EventHandler(this.inputDisplayButton_Click);
            // 
            // coinsLabel
            // 
            this.coinsLabel.AutoSize = true;
            this.coinsLabel.Location = new System.Drawing.Point(136, 70);
            this.coinsLabel.Name = "coinsLabel";
            this.coinsLabel.Size = new System.Drawing.Size(33, 13);
            this.coinsLabel.TabIndex = 2;
            this.coinsLabel.Text = "Coins";
            // 
            // savePosButton
            // 
            this.savePosButton.Location = new System.Drawing.Point(12, 61);
            this.savePosButton.Name = "savePosButton";
            this.savePosButton.Size = new System.Drawing.Size(93, 23);
            this.savePosButton.TabIndex = 3;
            this.savePosButton.Text = "Save Position";
            this.savePosButton.UseVisualStyleBackColor = true;
            this.savePosButton.Click += new System.EventHandler(this.savePosButton_Click);
            // 
            // loadPosButton
            // 
            this.loadPosButton.Location = new System.Drawing.Point(12, 90);
            this.loadPosButton.Name = "loadPosButton";
            this.loadPosButton.Size = new System.Drawing.Size(93, 23);
            this.loadPosButton.TabIndex = 4;
            this.loadPosButton.Text = "Load Position";
            this.loadPosButton.UseVisualStyleBackColor = true;
            this.loadPosButton.Click += new System.EventHandler(this.loadPosButton_Click);
            // 
            // positionsComboBox
            // 
            this.positionsComboBox.FormattingEnabled = true;
            this.positionsComboBox.Location = new System.Drawing.Point(12, 152);
            this.positionsComboBox.Name = "positionsComboBox";
            this.positionsComboBox.Size = new System.Drawing.Size(121, 21);
            this.positionsComboBox.TabIndex = 5;
            this.positionsComboBox.SelectedIndexChanged += new System.EventHandler(this.positionsComboBox_SelectedIndexChanged);
            // 
            // positionSlotLabel
            // 
            this.positionSlotLabel.AutoSize = true;
            this.positionSlotLabel.Location = new System.Drawing.Point(12, 133);
            this.positionSlotLabel.Name = "positionSlotLabel";
            this.positionSlotLabel.Size = new System.Drawing.Size(65, 13);
            this.positionSlotLabel.TabIndex = 6;
            this.positionSlotLabel.Text = "Position Slot";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.toolsToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(385, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchGameToolStripMenuItem,
            this.configureButtonCombosToolStripMenuItem,
            this.toolStripSeparator1,
            this.inputDisplayToolStripMenuItem,
            this.memoryUtilitiesToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.toolsToolStripMenuItem.Text = "Autosplitter";
            this.toolsToolStripMenuItem.Click += new System.EventHandler(this.toolsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem1
            // 
            this.toolsToolStripMenuItem1.Name = "toolsToolStripMenuItem1";
            this.toolsToolStripMenuItem1.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem1.Text = "Tools";
            // 
            // switchGameToolStripMenuItem
            // 
            this.switchGameToolStripMenuItem.Name = "switchGameToolStripMenuItem";
            this.switchGameToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.switchGameToolStripMenuItem.Text = "Switch Game";
            this.switchGameToolStripMenuItem.Click += new System.EventHandler(this.switchGameToolStripMenuItem_Click);
            // 
            // configureButtonCombosToolStripMenuItem
            // 
            this.configureButtonCombosToolStripMenuItem.Name = "configureButtonCombosToolStripMenuItem";
            this.configureButtonCombosToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.configureButtonCombosToolStripMenuItem.Text = "Configure Button Combos";
            this.configureButtonCombosToolStripMenuItem.Click += new System.EventHandler(this.configureButtonCombosToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
            // 
            // inputDisplayToolStripMenuItem
            // 
            this.inputDisplayToolStripMenuItem.Name = "inputDisplayToolStripMenuItem";
            this.inputDisplayToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.inputDisplayToolStripMenuItem.Text = "Input Display";
            this.inputDisplayToolStripMenuItem.Click += new System.EventHandler(this.inputDisplayToolStripMenuItem_Click);
            // 
            // memoryUtilitiesToolStripMenuItem
            // 
            this.memoryUtilitiesToolStripMenuItem.Name = "memoryUtilitiesToolStripMenuItem";
            this.memoryUtilitiesToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.memoryUtilitiesToolStripMenuItem.Text = "Memory Utilities";
            this.memoryUtilitiesToolStripMenuItem.Click += new System.EventHandler(this.memoryUtilitiesToolStripMenuItem_Click);
            // 
            // SLY3Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 472);
            this.Controls.Add(this.positionSlotLabel);
            this.Controls.Add(this.positionsComboBox);
            this.Controls.Add(this.loadPosButton);
            this.Controls.Add(this.savePosButton);
            this.Controls.Add(this.coinsLabel);
            this.Controls.Add(this.inputDisplayButton);
            this.Controls.Add(this.coinsTextBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SLY3Form";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox coinsTextBox;
        private System.Windows.Forms.Button inputDisplayButton;
        private System.Windows.Forms.Label coinsLabel;
        private System.Windows.Forms.Button savePosButton;
        private System.Windows.Forms.Button loadPosButton;
        private System.Windows.Forms.ComboBox positionsComboBox;
        private System.Windows.Forms.Label positionSlotLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureButtonCombosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem inputDisplayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem memoryUtilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem1;
    }
}