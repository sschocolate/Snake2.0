﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Some of this code was taken from an online author's tutorial on youtube (Michiel Wouters)
    /// </summary>
    public partial class SnakeGame : Form
    {
        private int runningTime;
        private int maxXPos;
        private int maxYPos;
        Player player;
        Enemy enemy;
        Collectible collect;
        Maps mapFactory;
        
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

            //Create a new maps object to use when selecting a map
            mapFactory = new Maps(0);

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
            Settings.retaliate = false;

            //Set default direction to Up
            KeyPressedEvents.ChangeState(Keys.Left, false);
            KeyPressedEvents.ChangeState(Keys.Right, false);
            KeyPressedEvents.ChangeState(Keys.Up, true);
            KeyPressedEvents.ChangeState(Keys.Down, false);

            //Set game speed
            try
            {
                ActionTimer.Interval = 1000 / Settings.Speed;
            }
            catch (DivideByZeroException e)
            {
                MessageBox.Show(e.ToString());
            }
            //Start timers
            ActionTimer.Start();
            GameTime.Start();


            //Create new player
            player = new Player(maxXPos, maxYPos, collect);

            //set score to 0
            Score.Text = Settings.Score.ToString();

            //Generate food object
            new Food(maxXPos, maxYPos);
            //Generate enemy object
            enemy = new Enemy(maxXPos, maxYPos);
            //Generate collectable object
            collect = new Collectible(maxXPos, maxYPos);
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
            player.Move();
            enemy.Move(); 
            CheckCollision();
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
                mapFactory.drawMap(e);
                //Draw player
                player.Draw(e);
                //Draw food
                Food.Draw(e);
                //Draw enemy
                enemy.Draw(e);
                //Draw collectable
                Collectible.Draw(e);
            }
        }


        /// <summary>
        /// Checks to see if the snake has collided with another object.
        /// Author: Michiel Wouters
        /// </summary>
        public void CheckCollision()
        {
            try
            {
                //Get the bodies of player and enemy to check for collision
                List<Circle> snake = player.getSnake();
                List<Circle> enemyBody = enemy.getEnemy();
                List<Circle> mapWalls = mapFactory.getMap();

                //Detect collision with border
                if (snake[0].X < 0 || snake[0].Y < 0
                    || snake[0].X >= maxXPos || snake[0].Y >= maxYPos)
                {
                    Die();
                }

                //Detect collision with map
                for (int k = 0; k < mapWalls.Count; k++)
                {
                    if (snake[0].X == mapWalls[k].X && snake[0].Y == mapWalls[k].Y)
                    {
                        Die();
                    }
                }

                //Dectect enemy collision with walls
                for (int kk = 0; kk < mapWalls.Count; kk++)
                {
                    for (int jj = 0; jj < enemyBody.Count; jj++) { 
                        //Check if enemy collides with a wall piece
                        if (enemyBody[jj].X == mapWalls[kk].X && enemyBody[jj].Y == mapWalls[kk].Y)
                        {
                            enemy.newDestination();
                            enemy.Move();
                            CheckCollision();
                            break;
                        }
                    }
                }

                //Detect collision with body
                for (int j = 1; j < snake.Count; j++)
                {
                    if (snake[0].X == snake[j].X && snake[0].Y == snake[j].Y)
                    {
                        Die();
                    }
                }

                //Detect collision with Enemy
                for (int i = 0; i < enemyBody.Count; i++)
                {
                    if (snake[0].X == enemyBody[i].X && snake[0].Y == enemyBody[i].Y)
                    {
                        if (Settings.retaliate == true)
                        {
                            enemy.die();
                            //Increase score by 100 points
                            int numScore = Int32.Parse(Score.Text);
                            Settings.Score = numScore + 200;
                            Score.Text = Settings.Score.ToString();
                            //start timer
                            AI_respawn.Start();
                        }
                        else
                        {
                            Die();
                        }
                    }
                }

                //Detect collision with food piece
                if (snake[0].X == Food.X && snake[0].Y == Food.Y)
                {
                    player.EatFood();

                    //Generate new food
                    new Food(maxXPos, maxYPos);

                    //Update Score
                    Settings.Score += Settings.Points;
                    Score.Text = Settings.Score.ToString();
                }

                //Detect food collision with wall
                for (int i = 0; i < mapWalls.Count; i++)
                {
                    if (Food.X == mapWalls[i].X && Food.Y == mapWalls[i].Y)
                        new Food(maxXPos, maxYPos);
                }

                //Detect collectable collision with wall
                for (int i = 0; i < mapWalls.Count; i++)
                {
                    if (Collectible.X == mapWalls[i].X && Collectible.Y == mapWalls[i].Y)
                        new Collectible(maxXPos, maxYPos);
                }

                //Detect collision with a Collectable, give corresponding attribute
                if (snake[0].X == Collectible.X && snake[0].Y == Collectible.Y)
                {
                    BonusType bonus;
                    // notifies the collectible that it has been eaten by the snake
                    bonus = collect.EatingCollectible();

                    if(bonus == BonusType.PointsBig)
                    {
                        //Increase score by 100 points
                        int numScore = Int32.Parse(Score.Text);
                        Settings.Score = numScore + 100;
                        Score.Text = Settings.Score.ToString();
                    }

                    if(bonus == BonusType.PointsMed)
                    {
                        //Increase score by 50 points
                        int numScore = Int32.Parse(Score.Text);
                        Settings.Score = numScore + 50;
                        Score.Text = Settings.Score.ToString();
                    }

                    if (bonus == BonusType.PointsSm)
                    {
                        //Increase score by 20 points
                        int numScore = Int32.Parse(Score.Text);
                        Settings.Score = numScore + 20;
                        Score.Text = Settings.Score.ToString();
                    }

                    if (bonus == BonusType.Retaliate)
                    {
                        //Allows snake to destoy enemy
                        Settings.retaliate = true;
                    }

                    if (bonus == BonusType.ScoreMultiplier)
                    {
                        //Multiplies current score by 2
                        int numScore = Int32.Parse(Score.Text);
                        Settings.Score = numScore * 2;
                        Score.Text = Settings.Score.ToString();
                    }

                    if (bonus == BonusType.Shrink)
                    {
                        //Removes a link of the snake's body
                        if(player.getSnake().Count() > 4)
                        {
                            player.Shrink();
                        }
                    }

                    if (bonus == BonusType.Slow)
                    {
                        //Marginally slow down the game speed
                        try
                        {
                            ActionTimer.Interval = 1500 / Settings.Speed;
                        }
                        catch (DivideByZeroException e)
                        {
                            MessageBox.Show(e.ToString());
                        }
                    }
                    //Make collectable disapear
                    new Collectible(99, 99);
                    //start timer
                    collectable_timer.Start();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        /// <summary>
        /// Called when the player collides with objects.
        /// Author: Michiel Wouters
        /// </summary>
        private void Die()
        {
            mainScreen.GameOver = true;
            mainScreen.playerScore = Settings.Score;

            //Add a highs scores to the list
            Settings.high_scores.Add(Settings.Score);
            Settings.high_scores.Sort();
            Settings.high_scores.Reverse();

            //Stop all timers
            ActionTimer.Stop();
            GameTime.Stop();

            try
            {
                ActionTimer.Interval = 1500 / Settings.Speed;
            }
            catch (DivideByZeroException e)
            {
                MessageBox.Show(e.ToString());
            }
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
        /// <summary>
        /// Select map 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainScreen_map1ClickEvent(object sender, EventArgs e)
        {
            mapFactory = new Maps(1);
            StartGame();
        }
        /// <summary>
        /// Select map 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainScreen_map2ClickEvent(object sender, EventArgs e)
        {
            mapFactory = new Maps(0);
            StartGame();
        }
        /// <summary>
        /// Select map 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainScreen_map3ClickEvent(object sender, EventArgs e)
        {
            mapFactory = new Maps(2);
            StartGame();
        }
        /// <summary>
        /// End game's replay button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainScreen_playAgainClickEvent(object sender, EventArgs e)
        {
            StartGame();
        }
        /// <summary>
        /// Menu screen "Exit" button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainScreen_exitClickEvent(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Timer tick event responsible for spawning a new collectable
        private void respawn_timer_Tick(object sender, EventArgs e)
        {
            //Makes sure the power-ups lose their effect when the next one spawns
            new Collectible(maxXPos, maxYPos);
            ActionTimer.Interval = 1000 / Settings.Speed;
            Settings.retaliate = false;
            collectable_timer.Stop();
        }

        /// <summary>
        /// Respawn enemy AI timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AI_respawn_Tick(object sender, EventArgs e)
        {
            enemy = new Enemy(maxXPos, maxYPos);
            AI_respawn.Stop();
        }
    }
}
