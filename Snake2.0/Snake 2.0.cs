using System;
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
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();
        public Form1()
        {
            InitializeComponent();

            //Set everything to default state
            new Settings();
            //Set player control keys
            KeyPressedEvents.initializeKeys();

            //Set game speed and start timer
            GameTimer.Interval = 1000 / Settings.Speed;
            GameTimer.Tick += UpdateScreen;
            GameTimer.Tick += UpdateTime;
            GameTimer.Start();

            //Start new game
            StartGame();
        }

        private void StartGame()
        {
            labelGameOver.Visible = false;
            //Set settings to default
            new Settings();

            //Create new player
            Snake.Clear();
            Circle head = new Circle();
            head.X = 19;
            head.Y = 19;
            Circle body1 = new Circle();
            body1.X = head.X;
            body1.Y = head.Y;
            Circle body2 = new Circle();
            body2.X = body1.X;
            body2.Y = body1.Y;
            Circle body3 = new Circle();
            body3.X = body2.X;
            body3.Y = body2.Y;

            Snake.Add(head);
            Snake.Add(body1);
            Snake.Add(body2);
            Snake.Add(body3);

            Score.Text = Settings.Score.ToString();
            GenerateFood();
        }

        // place food at random location
        private void GenerateFood()
        {
            int maxXPos = PlayScreen.Size.Width / Settings.Width;
            int maxYPos = PlayScreen.Size.Height / Settings.Height;

            Random rand = new Random();
            food.X = rand.Next(0, maxXPos);
            food.Y = rand.Next(0, maxYPos);
        }

        //Key press down event
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyPressedEvents.ChangeState(Keys.Left, false);
            KeyPressedEvents.ChangeState(Keys.Right, false);
            KeyPressedEvents.ChangeState(Keys.Up, false);
            KeyPressedEvents.ChangeState(Keys.Down, false);
            KeyPressedEvents.ChangeState(Keys.Enter, false);
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
                case Keys.Enter:
                    KeyPressedEvents.ChangeState(Keys.Enter, true);
                    break;
                case Keys.P:
                    KeyPressedEvents.ChangeState(Keys.P, true);
                    pauseGame();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            Time.Text += 1;
        }
        //Updates the screen and checks if game over
        private void UpdateScreen(object sender, EventArgs e)
        {
            //Check for game over
            if(Settings.GameOver)
            {
                //Check if Enter is pressed
                if(KeyPressedEvents.KeyPressed(Keys.Enter))
                {
                    KeyPressedEvents.ChangeState(Keys.Enter, false);
                    StartGame();
                }
            }
            else
            {
                if (KeyPressedEvents.KeyPressed(Keys.Right) && Settings.direction != Direction.Left)
                    Settings.direction = Direction.Right;
                else if (KeyPressedEvents.KeyPressed(Keys.Left) && Settings.direction != Direction.Right)
                    Settings.direction = Direction.Left;
                else if (KeyPressedEvents.KeyPressed(Keys.Up) && Settings.direction != Direction.Down)
                    Settings.direction = Direction.Up;
                else if (KeyPressedEvents.KeyPressed(Keys.Down) && Settings.direction != Direction.Up)
                    Settings.direction = Direction.Down;

                MovePlayer();
            }
            PlayScreen.Invalidate();
        }

        private void PlayScreen_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if(Settings.GameOver != true)
            {
                // Set colour of snake
                Brush snakeColour;
                //Draw snake
                for (int i = 0; i <= Snake.Count - 1; i++)
                {
                    if (i == 0)
                        snakeColour = Brushes.Black; //Head
                    else
                        snakeColour = Brushes.Green; //Body

                    //Draw
                    canvas.FillEllipse(snakeColour,
                        new Rectangle(Snake[i].X * Settings.Width,
                                      Snake[i].Y * Settings.Height,
                                      Settings.Width, Settings.Height));

                }
                //Draw food
                canvas.FillEllipse(Brushes.Red,
                    new Rectangle(food.X * Settings.Width,
                                  food.Y * Settings.Height,
                                  Settings.Width, Settings.Height));
            }
            else
            {
                string gameOver = "Game Over \nYour final score is: " + Settings.Score + "\nPress Enter to play again.";
                labelGameOver.Text = gameOver;
                labelGameOver.Visible = true;
            }
        }

        private void MovePlayer()
        {
            try
            {
                for (int i = Snake.Count - 1; i >= 0; i--)
                {
                    //Move head
                    if (i == 0)
                    {
                        switch (Settings.direction)
                        {
                            case Direction.Right:
                                Snake[0].X++;
                                break;
                            case Direction.Left:
                                Snake[0].X--;
                                break;
                            case Direction.Up:
                                Snake[0].Y--;
                                break;
                            case Direction.Down:
                                Snake[0].Y++;
                                break;
                        }

                        //Get game field sizes
                        int maxXPos = PlayScreen.Size.Width / Settings.Width;
                        int maxYPos = PlayScreen.Size.Height / Settings.Height;

                        //Detect collision with border
                        if(Snake[i].X < 0 || Snake[i].Y < 0 
                            || Snake[i].X >= maxXPos || Snake[i].Y >= maxYPos)
                        {
                            Die();
                        }

                        //Detect collision with body
                        for(int j = 1; j < Snake.Count; j++)
                        {
                            if(Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                            {
                                Die();
                            }
                        }

                        //Detect collision with food piece
                        if(Snake[0].X == food.X && Snake[0].Y == food.Y)
                        {
                            Eat();
                        }
                    }
                    else
                    {
                        Snake[i].X = Snake[i - 1].X;
                        Snake[i].Y = Snake[i - 1].Y;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Array out of bounds Exception occured.");
            }

        }

        //Called when the player collides with objects
        private void Die()
        {
            Settings.GameOver = true;
        }

        //Called when snake collides with food
        private void Eat()
        {
            //Add another body piece
            Circle body = new Circle();
            body.X = Snake[Snake.Count - 1].X;
            body.Y = Snake[Snake.Count - 1].Y;
                    
            Snake.Add(body);

            //Update Score
            Settings.Score += Settings.Points;
            Score.Text = Settings.Score.ToString();

            GenerateFood();
        }
        private void pauseGame()
        {
            if (Settings.Paused == false)
            {
                Settings.Paused = true;
                GameTimer.Stop();
            }
            else
            {
                Settings.Paused = false;
                GameTimer.Start();
            }
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            pauseGame();
        }
    }
}
