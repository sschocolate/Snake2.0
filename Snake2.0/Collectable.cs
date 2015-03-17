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
        private static BonusType type;
        public static int X { get; set; }
        public static int Y { get; set; }

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
            switch (type)
            {
                case BonusType.PointsBig:
                    collectableColour = Brushes.Gold;
                    break;
                case BonusType.PointsMed:
                    collectableColour = Brushes.Yellow;
                    break;
                case BonusType.PointsSm:
                    collectableColour = Brushes.LightYellow;
                    break;
                case BonusType.Retaliate:
                    collectableColour = Brushes.Blue;
                    break;
                case BonusType.ScoreMultiplier:
                    collectableColour = Brushes.Magenta;
                    break;
                case BonusType.Shrink:
                    collectableColour = Brushes.LightGreen;
                    break;
                case BonusType.Grow:
                    collectableColour = Brushes.DarkRed;
                    break;
                case BonusType.SpeedUp:
                    collectableColour = Brushes.GreenYellow;
                    break;
                case BonusType.Slow:
                    collectableColour = Brushes.LightSkyBlue;
                    break;
            }
            e.Graphics.FillEllipse(collectableColour,
                    new Rectangle(X * Settings.Width,
                                  Y * Settings.Height,
                                  Settings.Width, Settings.Height));
        }
    }
}
