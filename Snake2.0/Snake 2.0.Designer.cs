namespace Snake2._0
{
    partial class SnakeGame
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
            this.components = new System.ComponentModel.Container();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.Score = new System.Windows.Forms.Label();
            this.Pause = new System.Windows.Forms.Button();
            this.ActionTimer = new System.Windows.Forms.Timer(this.components);
            this.GameTime = new System.Windows.Forms.Timer(this.components);
            this.mainScreen = new Snake2._0.MenuScreenControl();
            this.SuspendLayout();
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.Location = new System.Drawing.Point(254, 9);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(80, 25);
            this.ScoreLabel.TabIndex = 1;
            this.ScoreLabel.Text = "Score: ";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeLabel.Location = new System.Drawing.Point(13, 9);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(71, 25);
            this.TimeLabel.TabIndex = 2;
            this.TimeLabel.Text = "Time: ";
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time.Location = new System.Drawing.Point(71, 9);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(0, 25);
            this.Time.TabIndex = 3;
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.Location = new System.Drawing.Point(322, 9);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(24, 25);
            this.Score.TabIndex = 4;
            this.Score.Text = "0";
            // 
            // Pause
            // 
            this.Pause.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pause.Location = new System.Drawing.Point(563, 9);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(40, 28);
            this.Pause.TabIndex = 5;
            this.Pause.Text = "| |";
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // ActionTimer
            // 
            this.ActionTimer.Interval = 1000;
            this.ActionTimer.Tick += new System.EventHandler(this.UpdateScreen);
            // 
            // GameTime
            // 
            this.GameTime.Interval = 1000;
            this.GameTime.Tick += new System.EventHandler(this.GameTime_Tick);
            // 
            // mainScreen
            // 
            this.mainScreen.GameOver = false;
            this.mainScreen.highScores = null;
            this.mainScreen.Location = new System.Drawing.Point(12, 43);
            this.mainScreen.map1_Image = null;
            this.mainScreen.map2_Image = null;
            this.mainScreen.map3_Image = null;
            this.mainScreen.Name = "mainScreen";
            this.mainScreen.playerScore = 0;
            this.mainScreen.Size = new System.Drawing.Size(604, 385);
            this.mainScreen.TabIndex = 6;
            this.mainScreen.exitClickEvent += new System.EventHandler(this.mainScreen_exitClickEvent);
            this.mainScreen.map1ClickEvent += new System.EventHandler(this.mainScreen_map1ClickEvent);
            this.mainScreen.map2ClickEvent += new System.EventHandler(this.mainScreen_map1ClickEvent);
            this.mainScreen.map3ClickEvent += new System.EventHandler(this.mainScreen_map1ClickEvent);
            this.mainScreen.playAgainClickEvent += new System.EventHandler(this.mainScreen_playAgainClickEvent);
            this.mainScreen.playScreenPaint += new System.Windows.Forms.PaintEventHandler(this.PlayScreen_Paint);
            // 
            // SnakeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 440);
            this.Controls.Add(this.mainScreen);
            this.Controls.Add(this.Pause);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.ScoreLabel);
            this.Name = "SnakeGame";
            this.Text = "Snake 2.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Button Pause;
        internal System.Windows.Forms.Timer ActionTimer;
        internal System.Windows.Forms.Timer GameTime;
        private MenuScreenControl mainScreen;
    }
}

