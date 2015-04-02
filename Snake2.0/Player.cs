using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Snake2._0
{
    class Player
    {
        private List<Circle> Snake = new List<Circle>();
        private Direction direction { get; set; }
        private int startX = 18;
        private int startY = 18;
        private int maxXpos;
        private int maxYPos;

        /// <summary>
        /// Constructor to initialize a player object's properties.
        /// </summary>
        public Player(int maxX, int maxY, Collectible eat)
        {
            eat.CollectibleEaten += PowerUp;

            //Instantiate max positions
            maxXpos = maxX;
            maxYPos = maxY;
            //Create player head and body
            Snake.Clear();
            Circle head = new Circle(startX, startY);
            Circle body1 = new Circle(head.X, head.Y);
            Circle body2 = new Circle(body1.X, body1.Y);
            Circle body3 = new Circle(body2.X, body2.Y);

            Snake.Add(head);
            Snake.Add(body1);
            Snake.Add(body2);
            Snake.Add(body3);

            direction = Direction.Up;
        }

        private void PowerUp()
        {
            
        }

        public void Shrink()
        {
            Snake.RemoveAt(Snake.Count - 1);
        }

        /// <summary>
        /// Draws the snake onto the pictureBox
        /// </summary>
        /// <param name="e"></param>
        public void Draw(System.Windows.Forms.PaintEventArgs e)
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

                //Draw the snake
                e.Graphics.FillEllipse(snakeColour,
                    new Rectangle(Snake[i].X * Settings.Width,
                                  Snake[i].Y * Settings.Height,
                                  Settings.Width, Settings.Height));
            }
        }

        /// <summary>
        /// Moves all pieces of the snake object.
        /// </summary>
        public void Move()
        {
            try
            {

                if (KeyPressedEvents.KeyPressed(Keys.Right) && direction != Direction.Left)
                    direction = Direction.Right;
                else if (KeyPressedEvents.KeyPressed(Keys.Left) && direction != Direction.Right)
                    direction = Direction.Left;
                else if (KeyPressedEvents.KeyPressed(Keys.Up) && direction != Direction.Down)
                    direction = Direction.Up;
                else if (KeyPressedEvents.KeyPressed(Keys.Down) && direction != Direction.Up)
                    direction = Direction.Down;

                for (int i = Snake.Count - 1; i >= 0; i--)
                {
                    //Move head
                    if (i == 0)
                    {
                        switch (direction)
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
                    }
                    else
                    {
                        //Move body
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

        /// <summary>
        /// Called when snake collides with food.
        /// Author: Michiel Wouters
        /// </summary>
        public void EatFood()
        {
            //Add another body piece
            Circle body = new Circle();
            body.X = Snake[Snake.Count - 1].X;
            body.Y = Snake[Snake.Count - 1].Y;

            Snake.Add(body);
        }

        //Return the snake's body
        public List<Circle> getSnake()
        {
            return Snake;
        }
    }
}
