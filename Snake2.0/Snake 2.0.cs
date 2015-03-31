﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake2._0
{
    /// <summary>
    /// This is our main class for the game. It contains all basic functionalities
    /// that make our game work.
    /// This class contains methods for: starting, initializing, generating food pieces,
    ///                                  processing keyboard events, drawing onto the screen,
    ///                                  the paint method for the picturebox, player movement,
    ///                                  interaction between snake and game board, and the
    ///                                  pause functionality.
    /// For our prototype, all these methods are in one class; however, as we progress we
    /// will separate them into different classes if applicable.
    /// Some of this code was taken from an online author's tutorial on youtube (Michiel Wouters)
    /// </summary>
    public partial class SnakeGame : Form
    {
        private int runningTime;
        private int maxXPos;
        private int maxYPos;
        Player player;
        
        /// <summary>
        /// Constructor: Sets game to default state and initializes game timers. 
        /// Author: Michiel Wouters
        /// </summary>
        public SnakeGame()
        {
            InitializeComponent();

            mainScreen.highScores = Settings.high_scores;
            //Set everything to default state
            new Settings();
            //Set player control keys
            KeyPressedEvents.initializeKeys();

            //Set game field boundary
            maxXPos = mainScreen.Size.Width / Settings.Width;
            maxYPos = mainScreen.Size.Height / Settings.Height;
            //Set game speed
            try
            {
                ActionTimer.Interval = 1000 / Settings.Speed;
            }
            catch (DivideByZeroException e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        /// <summary>
        /// Initializes a snake and some food for it to eat. Initializes the score and timers.
        /// </summary>
        public void StartGame()
        {
            //Set variables to default state
            new Settings();
            runningTime = 0;
            this.Time.Text = "00:00";
            mainScreen.GameOver = false;

            //Set default direction to Up
            KeyPressedEvents.ChangeState(Keys.Left, false);
            KeyPressedEvents.ChangeState(Keys.Right, false);
            KeyPressedEvents.ChangeState(Keys.Up, true);
            KeyPressedEvents.ChangeState(Keys.Down, false);

            //Start timers
            ActionTimer.Start();
            GameTime.Start();

            //Create new player
            player = new Player();

            //set score to 0
            Score.Text = Settings.Score.ToString();

            //Generate food object
            new Food(maxXPos, maxYPos);
            //Generate enemy object
            new Enemy(maxXPos, maxYPos);
            //Generate collectable object
            new Collectable(maxXPos, maxYPos);
        }

        /// <summary>
        /// Key down press events. This is one of the ways i found to detect arrow key presses.
        /// Using KeyEvents, it will not allow me to detect awwor keys.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyPressedEvents.ChangeState(Keys.Left, false);
            KeyPressedEvents.ChangeState(Keys.Right, false);
            KeyPressedEvents.ChangeState(Keys.Up, false);
            KeyPressedEvents.ChangeState(Keys.Down, false);
            switch (keyData)
            {
                case Keys.Left:
                    KeyPressedEvents.ChangeState(Keys.Left, true);
                    break;
                case Keys.Right:
                    KeyPressedEvents.ChangeState(Keys.Right, true);
                    break;
                case Keys.Up:
                    KeyPressedEvents.ChangeState(Keys.Up, true);
                    break;
                case Keys.Down:
                    KeyPressedEvents.ChangeState(Keys.Down, true);
                    break;
                case Keys.P:
                    KeyPressedEvents.ChangeState(Keys.P, true);
                    pauseGame();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Updates the screen and checks if game over.
        /// Author: Michiel Wouters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateScreen(object sender, EventArgs e)
        {
            Player.Move();
            CheckCollision();
            Enemy.Move(Direction.Left);
            mainScreen.Refresh();
        }

        /// <summary>
        /// Sets default parameters for snake and food.
        /// Author: Michiel Wouters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayScreen_Paint(object sender, PaintEventArgs e)
        {
            if(mainScreen.GameOver != true)
            {
                //Drawy player
                Player.Draw(e);
                //Draw food
                Food.Draw(e);
                //Draw enemy
                Enemy.Draw(e);
                //Draw collectable
                Collectable.Draw(e);
            }
        }

        /// <summary>
        /// Moves the snake depending on which key is pressed.
        /// Author: Michiel Wouters
        /// </summary>
        private void CheckCollision()
        {
            try
            {
                //Detect collision with border
                if (Player.Snake[0].X < 0 || Player.Snake[0].Y < 0
                    || Player.Snake[0].X >= maxXPos || Player.Snake[0].Y >= maxYPos)
                {
                    Die();
                }

                //Detect collision with body
                for (int j = 1; j < Player.Snake.Count; j++)
                {
                    if (Player.Snake[0].X == Player.Snake[j].X && Player.Snake[0].Y == Player.Snake[j].Y)
                    {
                        Die();
                    }
                }

                //Detect collision with Enemy
                for (int i = 0; i < Enemy.enemy.Count; i++)
                {
                    if (Player.Snake[0].X == Enemy.enemy[i].X && Player.Snake[0].Y == Enemy.enemy[i].Y)
                    {
                        Die();
                    }
                }

                //Detect collision with food piece
                if (Player.Snake[0].X == Food.X && Player.Snake[0].Y == Food.Y)
                {
                    EatFood();
                }

                //Detect collision with a Collectable
                if (Player.Snake[0].X == Collectable.X && Player.Snake[0].Y == Collectable.Y)
                {
                    new Collectable(maxXPos, maxYPos);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Array out of bounds Exception occured.");
            }

        }

        /// <summary>
        /// Called when the player collides with objects.
        /// Author: Michiel Wouters
        /// </summary>
        private void Die()
        {
            mainScreen.GameOver = true;

            //Add a highs scores to the list
            Settings.high_scores.Add(Settings.Score.ToString() + " Points");
            Settings.high_scores.Sort();
            Settings.high_scores.Reverse();

            //Stop all timers
            ActionTimer.Stop();
            GameTime.Stop();
        }

        /// <summary>
        /// Called when snake collides with food.
        /// Author: Michiel Wouters
        /// </summary>
        private void EatFood()
        {
            //Add another body piece
            Circle body = new Circle();
            body.X = Player.Snake[Player.Snake.Count - 1].X;
            body.Y = Player.Snake[Player.Snake.Count - 1].Y;

            Player.Snake.Add(body);

            //Update Score
            Settings.Score += Settings.Points;
            Score.Text = Settings.Score.ToString();

            new Food(maxXPos, maxYPos);
        }

        /// <summary>
        /// Called when the pause button is pressed.
        /// </summary>
        private void pauseGame()
        {
            if (Settings.Paused == false)
            {
                Settings.Paused = true;
                ActionTimer.Stop();
                GameTime.Stop();
            }
            else
            {
                Settings.Paused = false;
                ActionTimer.Start();
                GameTime.Start();
            }
        }

        /// <summary>
        /// The game pauses.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pause_Click(object sender, EventArgs e)
        {
            pauseGame();
        }

        /// <summary>
        /// Tracks the timer on every tick.
        /// Updates the timer label "Time" in format mm:ss.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameTime_Tick(object sender, EventArgs e)
        {
            runningTime += 1;
            TimeSpan time = TimeSpan.FromSeconds(runningTime);
            if (runningTime < 3600)
            {
                this.Time.Text = time.ToString(@"mm\:ss");
            }
            else
            {
                this.Time.Text = time.ToString(@"hh\:mm\:ss");
            }
        }

        private void mainScreen_map1ClickEvent(object sender, EventArgs e)
        {
            StartGame();
        }

        private void mainScreen_playAgainClickEvent(object sender, EventArgs e)
        {
            StartGame();
        }

        private void mainScreen_exitClickEvent(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
