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
            this.SuspendLayout();
            // 
            // inputDisplayButton
            // 
            this.inputDisplayButton.Location = new System.Drawing.Point(74, 47);
            this.inputDisplayButton.Name = "inputDisplayButton";
            this.inputDisplayButton.Size = new System.Drawing.Size(112, 39);
            this.inputDisplayButton.TabIndex = 0;
            this.inputDisplayButton.Text = "Input Display";
            this.inputDisplayButton.UseVisualStyleBackColor = true;
            this.inputDisplayButton.Click += new System.EventHandler(this.inputDisplayButton_Click);
            // 
            // SLY3Speedrun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 158);
            this.Controls.Add(this.inputDisplayButton);
            this.Name = "SLY3Speedrun";
            this.Text = "SluMAN :: Sly 3: Honor Among Thieves - NPEA00343 (Speedrun Mode)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button inputDisplayButton;
    }
}