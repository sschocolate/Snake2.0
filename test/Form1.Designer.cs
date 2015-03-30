namespace test
{
    partial class Form1
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
            this.menuScreenControl1 = new Snake2._0.MenuScreenControl();
            this.SuspendLayout();
            // 
            // menuScreenControl1
            // 
            this.menuScreenControl1.GameOver = false;
            this.menuScreenControl1.highScores = null;
            this.menuScreenControl1.Location = new System.Drawing.Point(12, 12);
            this.menuScreenControl1.map1_Image = null;
            this.menuScreenControl1.map2_Image = null;
            this.menuScreenControl1.map3_Image = null;
            this.menuScreenControl1.Name = "menuScreenControl1";
            this.menuScreenControl1.playerScore = 0;
            this.menuScreenControl1.Size = new System.Drawing.Size(604, 385);
            this.menuScreenControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 408);
            this.Controls.Add(this.menuScreenControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Snake2._0.MenuScreenControl menuScreenControl1;

    }
}

