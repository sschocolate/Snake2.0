using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake2._0
{
    class Enemy
    {
        public static List<Circle> enemy = new List<Circle>();
        public static Direction direction { get; set; }

        public Enemy(int maxXPos, int maxYPos)
        {
            enemy.Clear();
            Circle body1 = new Circle(Settings.rand.Next(0, maxXPos), Settings.rand.Next(0, maxYPos));
            Circle body2 = new Circle(body1.X + 1, body1.Y);
            Circle body3 = new Circle(body1.X, body1.Y + 1);
            Circle body4 = new Circle(body1.X + 1, body1.Y + 1);

            enemy.Add(body1);
            enemy.Add(body2);
            enemy.Add(body3);
            enemy.Add(body4);
        }

        /// <summary>
        /// Draws the enemy onto the pictureBox
        /// </summary>
        /// <param name="e"></param>
        public static void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            for (int i = 0; i <= enemy.Count - 1; i++)
            {
                //Draw the snake
                e.Graphics.FillEllipse(Brushes.Purple,
                    new Rectangle(enemy[i].X * Settings.Width,
                                  enemy[i].Y * Settings.Height,
                                  Settings.Width, Settings.Height));
            }
        }

        /// <summary>
        /// Automated enemy movement.
        /// </summary>
        public static void Move()
        {
            // Random number generator for determining direction of enemy movement.
            var random = new Random();
            int num = random.Next(100);
            string dir = "up";
            if(num >= 0 && num <= 24)
            {
                dir = "up";
            }
            else if(num >= 25 && num <= 49)
            {
                dir = "down";
            }
            else if(num >= 50 && num <= 74)
            {
                dir = "left";
            }
            else if(num >= 75 && num < 99)
            {
                dir = "right";
            }
            
            switch(dir)
            {
                case "down":
                    if(Enemy.enemy[0].Y < 0 || Enemy.enemy[3].Y < 0)
                    {
                        Enemy.enemy[0].Y++;
                        Enemy.enemy[1].Y++;
                        Enemy.enemy[2].Y++;
                        Enemy.enemy[3].Y++;
                    }
                    else
                    {
                        Enemy.enemy[0].Y--;
                        Enemy.enemy[1].Y--;
                        Enemy.enemy[2].Y--;
                        Enemy.enemy[3].Y--;
                    }

                    break;

                case "up":
                    if(Enemy.enemy[0].Y > Settings.Height || Enemy.enemy[3].Y > Settings.Height)
                    {
                        Enemy.enemy[0].Y--;
                        Enemy.enemy[1].Y--;
                        Enemy.enemy[2].Y--;
                        Enemy.enemy[3].Y--;
                    }
                    else
                    {
                        Enemy.enemy[0].Y++;
                        Enemy.enemy[1].Y++;
                        Enemy.enemy[2].Y++;
                        Enemy.enemy[3].Y++;
                    }

                    break;

                case "right":
                    if (Enemy.enemy[0].X < 0 || Enemy.enemy[2].X < 0)
                    {
                        Enemy.enemy[0].X++;
                        Enemy.enemy[1].X++;
                        Enemy.enemy[2].X++;
                        Enemy.enemy[3].X++;
                    }
                    else
                    {
                        Enemy.enemy[0].X--;
                        Enemy.enemy[1].X--;
                        Enemy.enemy[2].X--;
                        Enemy.enemy[3].X--;
                    }

                    break;

                case "left":
                    if (Enemy.enemy[0].X > Settings.Width || Enemy.enemy[3].X > Settings.Width)
                    {
                        Enemy.enemy[0].X--;
                        Enemy.enemy[1].X--;
                        Enemy.enemy[2].X--;
                        Enemy.enemy[3].X--;
                    }
                    else
                    {
                        Enemy.enemy[0].X++;
                        Enemy.enemy[1].X++;
                        Enemy.enemy[2].X++;
                        Enemy.enemy[3].X++;
                    }

                    break;

                default:
                    break;
            }
        }
    }
}
