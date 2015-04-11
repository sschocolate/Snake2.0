using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Snake2._0
{
    class Enemy
    {
        private List<Circle> enemy = new List<Circle>();
        private int maxXPos;
        private int maxYPos;
        private Point destination;
        Size s = new Size(16,16);

        public Enemy(int maxX, int maxY)
        {
            //Initialization
            maxXPos = maxX;
            maxYPos = maxY;
            destination = new Point(Settings.rand.Next(maxXPos), Settings.rand.Next(maxYPos));

            //Create enemy body
            enemy.Clear();
            Circle body1 = new Circle(Settings.rand.Next(0, maxXPos), Settings.rand.Next(0, maxYPos));
            Circle body2 = new Circle(body1.X + 1, body1.Y);
            Circle body3 = new Circle(body1.X, body1.Y + 1);
            Circle body4 = new Circle(body1.X + 1, body1.Y + 1);
            //Add body to the list
            enemy.Add(body1);
            enemy.Add(body2);
            enemy.Add(body3);
            enemy.Add(body4);

        }

        /// <summary>
        /// Draws the enemy onto the pictureBox
        /// </summary>
        /// <param name="e"></param>
        public void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            for (int i = 0; i <= enemy.Count - 1; i++)
            {
                //Draw the enemy
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
        public void Move()
        {
            try
            {
                //Enemy will head towards destination
                if (enemy.Any())
                {
                    if (enemy[0].X < destination.X)
                        for (int i = 0; i < enemy.Count; i++)
                            enemy[i].X++;

                    if (enemy[0].Y < destination.Y)
                        for (int i = 0; i < enemy.Count; i++)
                            enemy[i].Y++;

                    if (enemy[0].X > destination.X)
                        for (int i = 0; i < enemy.Count; i++)
                            enemy[i].X--;

                    if (enemy[0].Y > destination.Y)
                        for (int i = 0; i < enemy.Count; i++)
                            enemy[i].Y--;

                    //Once destination is reached, generate a new destination
                    for (int i = 0; i < enemy.Count; i++)
                        if (enemy[i].X == destination.X && enemy[i].Y == destination.Y)
                            newDestination();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        //Return the enemy's body
        public List<Circle> getEnemy()
        {
            return enemy;
        }
        
        //Find a new point for the enemy to head towards
        public void newDestination()
        {
            Point dest = new Point(Settings.rand.Next(maxXPos), Settings.rand.Next(maxYPos));
            destination = dest;
        }

        //Removes all body pieces of the enemy
        public void die()
        {
            enemy.Clear();
        }
    }
}
