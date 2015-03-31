using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake2._0
{
    class Collectable
    {
        public static BonusType type;
        public static int X { get; set; }
        public static int Y { get; set; }
        public static int colour;
        public Collectable(int maxXPos, int maxYPos)
        {
            //Generate a random collectable type
            Array values = Enum.GetValues(typeof(BonusType));
            Random random = new Random();
            type = (BonusType)values.GetValue(random.Next(values.Length));

            //Set location to somwhere within the playing field
            X = Settings.rand.Next(0, maxXPos);
            Y = Settings.rand.Next(0, maxYPos);
        }

        public static void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            Brush collectableColour = Brushes.Black;
            colour = Settings.BLACK;
            switch (type)
            {
                case BonusType.PointsBig:
                    collectableColour = Brushes.GreenYellow;
                    colour = Settings.GREEN_YELLOW;
                    break;
                case BonusType.PointsMed:
                    collectableColour = Brushes.Yellow;
                    colour = Settings.YELLOW;
                    break;
                case BonusType.PointsSm:
                    collectableColour = Brushes.LightYellow;
                    colour = Settings.LIGHT_YELLOW;
                    break;
                case BonusType.Retaliate:
                    collectableColour = Brushes.Blue;
                    colour = Settings.BLUE;
                    break;
                case BonusType.ScoreMultiplier:
                    collectableColour = Brushes.Magenta;
                    colour = Settings.MAGENTA;
                    break;
                case BonusType.Shrink:
                    collectableColour = Brushes.LightGreen;
                    colour = Settings.LIGHT_GREEN;
                    break;
                case BonusType.Slow:
                    collectableColour = Brushes.LightSkyBlue;
                    colour = Settings.LIGHT_SKY_BLUE;
                    break;
            }
            e.Graphics.FillEllipse(collectableColour,
                    new Rectangle(X * Settings.Width,
                                  Y * Settings.Height,
                                  Settings.Width, Settings.Height));
        }

        public void isEaten(int colour)
        {

        }
    }
}
