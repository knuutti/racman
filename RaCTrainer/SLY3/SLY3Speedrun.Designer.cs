namespace racman
{
    partial class SLY3Speedrun
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
            this.inputDisplayButton = new System.Windows.Forms.Button();
            this.autosplitterCheckbox = new System.Windows.Forms.CheckBox();
            this.gadgetsButton = new System.Windows.Forms.Button();
            this.alwaysTopButton = new System.Windows.Forms.CheckBox();
            this.runFileComboBox = new System.Windows.Forms.ComboBox();
            this.loadRunFileButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputDisplayButton
            // 
            this.inputDisplayButton.Location = new System.Drawing.Point(12, 12);
            this.inputDisplayButton.Name = "inputDisplayButton";
            this.inputDisplayButton.Size = new System.Drawing.Size(121, 39);
            this.inputDisplayButton.TabIndex = 0;
            this.inputDisplayButton.Text = "Input Display";
            this.inputDisplayButton.UseVisualStyleBackColor = true;
            this.inputDisplayButton.Click += new System.EventHandler(this.inputDisplayButton_Click);
            // 
            // autosplitterCheckbox
            // 
            this.autosplitterCheckbox.AutoSize = true;
            this.autosplitterCheckbox.Location = new System.Drawing.Point(12, 57);
            this.autosplitterCheckbox.Name = "autosplitterCheckbox";
            this.autosplitterCheckbox.Size = new System.Drawing.Size(92, 20);
            this.autosplitterCheckbox.TabIndex = 1;
            this.autosplitterCheckbox.Text = "Autosplitter";
            this.autosplitterCheckbox.UseVisualStyleBackColor = true;
            this.autosplitterCheckbox.CheckedChanged += new System.EventHandler(this.AutosplitterCheckbox_CheckedChanged);
            // 
            // gadgetsButton
            // 
            this.gadgetsButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gadgetsButton.Location = new System.Drawing.Point(161, 12);
            this.gadgetsButton.Name = "gadgetsButton";
            this.gadgetsButton.Size = new System.Drawing.Size(112, 39);
            this.gadgetsButton.TabIndex = 3;
            this.gadgetsButton.Text = "Gadgets";
            this.gadgetsButton.UseVisualStyleBackColor = false;
            this.gadgetsButton.Click += new System.EventHandler(this.gadgetsButton_Click);
            // 
            // alwaysTopButton
            // 
            this.alwaysTopButton.AutoSize = true;
            this.alwaysTopButton.Location = new System.Drawing.Point(12, 83);
            this.alwaysTopButton.Name = "alwaysTopButton";
            this.alwaysTopButton.Size = new System.Drawing.Size(117, 20);
            this.alwaysTopButton.TabIndex = 4;
            this.alwaysTopButton.Text = "Always On Top";
            this.alwaysTopButton.UseVisualStyleBackColor = true;
            this.alwaysTopButton.CheckedChanged += new System.EventHandler(this.alwaysTopButton_CheckedChanged);
            // 
            // runFileComboBox
            // 
            this.runFileComboBox.FormattingEnabled = true;
            this.runFileComboBox.Items.AddRange(new object[] {
            "Episode 1",
            "Episode 2",
            "Episode 3",
            "Episode 4",
            "Episode 5",
            "Episode 6 (No CE)",
            "Episode 6 (CE)"});
            this.runFileComboBox.Location = new System.Drawing.Point(6, 31);
            this.runFileComboBox.Name = "runFileComboBox";
            this.runFileComboBox.Size = new System.Drawing.Size(145, 24);
            this.runFileComboBox.TabIndex = 5;
            this.runFileComboBox.Text = "Select category...";
            // 
            // loadRunFileButton
            // 
            this.loadRunFileButton.Location = new System.Drawing.Point(157, 31);
            this.loadRunFileButton.Name = "loadRunFileButton";
            this.loadRunFileButton.Size = new System.Drawing.Size(97, 24);
            this.loadRunFileButton.TabIndex = 6;
            this.loadRunFileButton.Text = "Load";
            this.loadRunFileButton.UseVisualStyleBackColor = true;
            this.loadRunFileButton.Click += new System.EventHandler(this.loadRunFileButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.runFileComboBox);
            this.groupBox1.Controls.Add(this.loadRunFileButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 76);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load run file";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // SLY3Speedrun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 211);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.alwaysTopButton);
            this.Controls.Add(this.gadgetsButton);
            this.Controls.Add(this.autosplitterCheckbox);
            this.Controls.Add(this.inputDisplayButton);
            this.Name = "SLY3Speedrun";
            this.Text = "SluMAN :: Sly 3: Honor Among Thieves - NPEA00343 (Speedrun Mode)";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button inputDisplayButton;
        private System.Windows.Forms.CheckBox autosplitterCheckbox;
        private System.Windows.Forms.Button gadgetsButton;
        private System.Windows.Forms.CheckBox alwaysTopButton;
        private System.Windows.Forms.ComboBox runFileComboBox;
        private System.Windows.Forms.Button loadRunFileButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}