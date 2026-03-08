
namespace racman
{
    partial class AttachPS3Form
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
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.attachButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.currentVerLabel = new System.Windows.Forms.Label();
            this.AttachRPCS3Button = new System.Windows.Forms.Button();
            this.attachRestrictedButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IPTextBox
            // 
            this.IPTextBox.Location = new System.Drawing.Point(52, 48);
            this.IPTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(132, 22);
            this.IPTextBox.TabIndex = 0;
            this.IPTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IPTextBox_KeyDown);
            // 
            // attachButton
            // 
            this.attachButton.Location = new System.Drawing.Point(192, 45);
            this.attachButton.Margin = new System.Windows.Forms.Padding(4);
            this.attachButton.Name = "attachButton";
            this.attachButton.Size = new System.Drawing.Size(100, 28);
            this.attachButton.TabIndex = 1;
            this.attachButton.Text = "Attach";
            this.attachButton.UseVisualStyleBackColor = true;
            this.attachButton.Click += new System.EventHandler(this.attachButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Address:";
            // 
            // currentVerLabel
            // 
            this.currentVerLabel.AutoSize = true;
            this.currentVerLabel.Location = new System.Drawing.Point(49, 147);
            this.currentVerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentVerLabel.Name = "currentVerLabel";
            this.currentVerLabel.Size = new System.Drawing.Size(93, 16);
            this.currentVerLabel.TabIndex = 3;
            this.currentVerLabel.Text = "SluMAN v0.0.0";
            this.currentVerLabel.Click += new System.EventHandler(this.currentVerLabel_Click);
            // 
            // AttachRPCS3Button
            // 
            this.AttachRPCS3Button.Location = new System.Drawing.Point(192, 141);
            this.AttachRPCS3Button.Margin = new System.Windows.Forms.Padding(4);
            this.AttachRPCS3Button.Name = "AttachRPCS3Button";
            this.AttachRPCS3Button.Size = new System.Drawing.Size(100, 28);
            this.AttachRPCS3Button.TabIndex = 4;
            this.AttachRPCS3Button.Text = "RPCS3";
            this.AttachRPCS3Button.UseVisualStyleBackColor = true;
            this.AttachRPCS3Button.Click += new System.EventHandler(this.AttachRPCS3Button_Click);
            // 
            // attachRestrictedButton
            // 
            this.attachRestrictedButton.Location = new System.Drawing.Point(52, 78);
            this.attachRestrictedButton.Margin = new System.Windows.Forms.Padding(4);
            this.attachRestrictedButton.Name = "attachRestrictedButton";
            this.attachRestrictedButton.Size = new System.Drawing.Size(240, 28);
            this.attachRestrictedButton.TabIndex = 5;
            this.attachRestrictedButton.Text = "Attach (Speedrun Mode)";
            this.attachRestrictedButton.UseVisualStyleBackColor = true;
            this.attachRestrictedButton.Click += new System.EventHandler(this.attachPS3SpeedrunModeButton_Click);
            // 
            // AttachPS3Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 203);
            this.Controls.Add(this.attachRestrictedButton);
            this.Controls.Add(this.AttachRPCS3Button);
            this.Controls.Add(this.currentVerLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.attachButton);
            this.Controls.Add(this.IPTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "AttachPS3Form";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SluMAN :: Attach to game";
            this.Load += new System.EventHandler(this.AttachPS3Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.Button attachButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentVerLabel;
        private System.Windows.Forms.Button AttachRPCS3Button;
        private System.Windows.Forms.Button attachRestrictedButton;
    }
}