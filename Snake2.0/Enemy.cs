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
        /// Determines number of spaces to move enemy and moves enemy.
        /// </summary>
        /// <returns></returns>
        public static int Move(int direction, int amount)
        {
            return 1;
        }
    }
}
