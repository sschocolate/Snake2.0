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
        public static Color clr;
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

        public Collectable(Color collected)
        {
            
        }

        public static void Draw(System.Windows.Forms.PaintEventArgs e)
        {
            Brush collectableColour = Brushes.Black;
            clr = Color.Black;
            switch (type)
            {
                case BonusType.PointsBig:
                    collectableColour = Brushes.GreenYellow;
                    clr = Color.GreenYellow;
                    break;
                case BonusType.PointsMed:
                    collectableColour = Brushes.Yellow;
                    clr = Color.Yellow;
                    break;
                case BonusType.PointsSm:
                    collectableColour = Brushes.LightYellow;
                    clr = Color.LightYellow;
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

        public BonusType isEaten(Color clr)
        {
            return BonusType.PointsBig;
        }
    }
}
