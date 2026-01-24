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
            this.SuspendLayout();
            // 
            // coinsTextBox
            // 
            this.coinsTextBox.Location = new System.Drawing.Point(175, 25);
            this.coinsTextBox.Name = "coinsTextBox";
            this.coinsTextBox.Size = new System.Drawing.Size(100, 20);
            this.coinsTextBox.TabIndex = 0;
            this.coinsTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.coinsTextBox_KeyDown);
            // 
            // inputDisplayButton
            // 
            this.inputDisplayButton.Location = new System.Drawing.Point(139, 70);
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
            this.coinsLabel.Location = new System.Drawing.Point(136, 28);
            this.coinsLabel.Name = "coinsLabel";
            this.coinsLabel.Size = new System.Drawing.Size(33, 13);
            this.coinsLabel.TabIndex = 2;
            this.coinsLabel.Text = "Coins";
            // 
            // savePosButton
            // 
            this.savePosButton.Location = new System.Drawing.Point(12, 19);
            this.savePosButton.Name = "savePosButton";
            this.savePosButton.Size = new System.Drawing.Size(93, 23);
            this.savePosButton.TabIndex = 3;
            this.savePosButton.Text = "Save Position";
            this.savePosButton.UseVisualStyleBackColor = true;
            this.savePosButton.Click += new System.EventHandler(this.savePosButton_Click);
            // 
            // loadPosButton
            // 
            this.loadPosButton.Location = new System.Drawing.Point(12, 48);
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
            this.positionsComboBox.Location = new System.Drawing.Point(12, 110);
            this.positionsComboBox.Name = "positionsComboBox";
            this.positionsComboBox.Size = new System.Drawing.Size(121, 21);
            this.positionsComboBox.TabIndex = 5;
            this.positionsComboBox.SelectedIndexChanged += new System.EventHandler(this.positionsComboBox_SelectedIndexChanged);
            // 
            // positionSlotLabel
            // 
            this.positionSlotLabel.AutoSize = true;
            this.positionSlotLabel.Location = new System.Drawing.Point(12, 91);
            this.positionSlotLabel.Name = "positionSlotLabel";
            this.positionSlotLabel.Size = new System.Drawing.Size(65, 13);
            this.positionSlotLabel.TabIndex = 6;
            this.positionSlotLabel.Text = "Position Slot";
            // 
            // SLY3Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.positionSlotLabel);
            this.Controls.Add(this.positionsComboBox);
            this.Controls.Add(this.loadPosButton);
            this.Controls.Add(this.savePosButton);
            this.Controls.Add(this.coinsLabel);
            this.Controls.Add(this.inputDisplayButton);
            this.Controls.Add(this.coinsTextBox);
            this.Name = "SLY3Form";
            this.Text = "Form1";
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
    }
}