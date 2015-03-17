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
        public static List<Circle> Snake = new List<Circle>();
        public static Direction direction { get; set; }

        /// <summary>
        /// Constructor to initialize a player object's properties.
        /// </summary>
        public Player()
        {
            //Create player head and body
            Snake.Clear();
            Circle head = new Circle(19, 19);
            Circle body1 = new Circle(head.X, head.Y);
            Circle body2 = new Circle(body1.X, body1.Y);
            Circle body3 = new Circle(body2.X, body2.Y);

            Snake.Add(head);
            Snake.Add(body1);
            Snake.Add(body2);
            Snake.Add(body3);

            direction = Direction.Up;
        }
        /// <summary>
        /// Draws the snake onto the pictureBox
        /// </summary>
        /// <param name="e"></param>
        public static void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            // Set colour of snake
            Brush snakeColour;
            //Draw snake
            for (int i = 0; i <= Player.Snake.Count - 1; i++)
            {
                if (i == 0)
                    snakeColour = Brushes.Black; //Head
                else
                    snakeColour = Brushes.Green; //Body

                //Draw the snake
                e.Graphics.FillEllipse(snakeColour,
                    new Rectangle(Player.Snake[i].X * Settings.Width,
                                  Player.Snake[i].Y * Settings.Height,
                                  Settings.Width, Settings.Height));
            }
        }

        /// <summary>
        /// Moves all pieces of the snake object.
        /// </summary>
        public static void Move()
        {
            try
            {

                if (KeyPressedEvents.KeyPressed(Keys.Right) && Player.direction != Direction.Left)
                    Player.direction = Direction.Right;
                else if (KeyPressedEvents.KeyPressed(Keys.Left) && Player.direction != Direction.Right)
                    Player.direction = Direction.Left;
                else if (KeyPressedEvents.KeyPressed(Keys.Up) && Player.direction != Direction.Down)
                    Player.direction = Direction.Up;
                else if (KeyPressedEvents.KeyPressed(Keys.Down) && Player.direction != Direction.Up)
                    Player.direction = Direction.Down;

                for (int i = Player.Snake.Count - 1; i >= 0; i--)
                {
                    //Move head
                    if (i == 0)
                    {
                        switch (Player.direction)
                        {
                            case Direction.Right:
                                Player.Snake[0].X++;
                                break;
                            case Direction.Left:
                                Player.Snake[0].X--;
                                break;
                            case Direction.Up:
                                Player.Snake[0].Y--;
                                break;
                            case Direction.Down:
                                Player.Snake[0].Y++;
                                break;
                        }
                    }
                    else
                    {
                        //Move body
                        Player.Snake[i].X = Player.Snake[i - 1].X;
                        Player.Snake[i].Y = Player.Snake[i - 1].Y;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Array out of bounds Exception occured.");
            }
        }
    }
}
