using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2._0
{
    /// <summary>
    /// This class is the basic unit used for our game.
    /// For now it is just properties of a circle.
    /// We intend to alter this to use a user control instead.
    /// </summary>
    class Circle
    {
        public int X { get; set;}
        public int Y { get; set;}

        public Circle()
        {
            X = 0;
            Y = 0;
        }
        public Circle(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
