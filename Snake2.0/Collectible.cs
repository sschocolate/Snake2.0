﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake2._0
{
    public class Collectible
    {
        //public Action CollectibleEaten;
        public static BonusType type;
        public static int X { get; set; }
        public static int Y { get; set; }
        public static Color clr = Color.Black;
        public Collectible(int maxXPos, int maxYPos)
        {
            //Generate a random collectable type
            Array values = Enum.GetValues(typeof(BonusType));
            Random random = new Random();
            type = (BonusType)values.GetValue(random.Next(values.Length));

            //Set location to somwhere within the playing field
            X = Settings.rand.Next(0, maxXPos);
            Y = Settings.rand.Next(0, maxYPos);
        }

        /// <summary>
        /// Based on the color of the collectible, it sends the bonus type to the player
        /// </summary>
        /// <returns></returns>
        public BonusType EatingCollectible()
        {
            //CollectibleEaten();
            if(clr == Color.Goldenrod)
            {
                return BonusType.PointsBig;
            }

            if(clr == Color.Gold)
            {
                return BonusType.PointsMed;
            }

            if(clr == Color.Yellow)
            {
                return BonusType.PointsSm;
            }

            if(clr == Color.Blue)
            {
                return BonusType.Retaliate;
            }

            if(clr == Color.Magenta)
            {
                return BonusType.ScoreMultiplier;
            }

            if(clr == Color.LightGreen)
            {
                return BonusType.Shrink;
            }

            return BonusType.Slow;
        }

        /// <summary>
        /// Draws a random collectible on the map
        /// </summary>
        /// <param name="e"></param>
        public static void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            Brush collectableColour = Brushes.Black;
            switch (type)
            {
                case BonusType.PointsBig:
                    collectableColour = Brushes.Goldenrod;
                    clr = Color.Goldenrod;
                    break;
                case BonusType.PointsMed:
                    collectableColour = Brushes.Gold;
                    clr = Color.Gold;
                    break;
                case BonusType.PointsSm:
                    collectableColour = Brushes.Yellow;
                    clr = Color.Yellow;
                    break;
                case BonusType.Retaliate:
                    collectableColour = Brushes.Blue;
                    clr = Color.Blue;
                    break;
                case BonusType.ScoreMultiplier:
                    collectableColour = Brushes.Magenta;
                    clr = Color.Magenta;
                    break;
                case BonusType.Shrink:
                    collectableColour = Brushes.LightGreen;
                    clr = Color.LightGreen;
                    break;
                case BonusType.Slow:
                    collectableColour = Brushes.LightSkyBlue;
                    clr = Color.LightSkyBlue;
                    break;
            }
            e.Graphics.FillEllipse(collectableColour,
                    new Rectangle(X * Settings.Width,
                                  Y * Settings.Height,
                                  Settings.Width, Settings.Height));
        }
    }
}
