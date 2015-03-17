using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake2._0
{
    class Food
    {
        public static int X { get; set; }
        public static int Y { get; set; }

        /// <summary>
        /// Places food at random locations in the game screen.
        /// Author: Michiel Wouters
        /// </summary>
        public Food(int maxXPos, int maxYPos)
        {
            X = Settings.rand.Next(0, maxXPos);
            Y = Settings.rand.Next(0, maxYPos);
        }

        /// <summary>
        /// Draws the food onto the pictureBox
        /// </summary>
        /// <param name="e"></param>
        public static void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red,
                    new Rectangle(X * Settings.Width,
                                  Y * Settings.Height,
                                  Settings.Width, Settings.Height));
        }
    }
}
