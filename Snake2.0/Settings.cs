using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2._0
{
    /// <summary>
    /// Enumerated type for the direction our player snake is facing.
    /// </summary>
    public enum Direction
    {
        Up,Down,Left,Right
    };

    /// <summary>
    /// Enumerated type for the types of collectable objects
    /// </summary>
    public enum BonusType
    {
        Retaliate, Shrink, Slow, ScoreMultiplier, PointsBig, PointsMed, PointsSm
    }

    /// <summary>
    /// The default settings of the snake game.
    /// Author: Michiel Wouters
    /// </summary>
    class Settings
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int Speed { get; set; }
        public static int Score { get; set; }
        public static int Points { get; set; }
        public static bool GameOver { get; set; }
        public static bool Paused { get; set; }
        public static Random rand = new Random();

        /// <summary>
        /// Constructor: Initializes default parameters of the game.
        /// </summary>
        public Settings()
        {
            Width = 16;
            Height = 16;
            Speed = 10;
            Score = 0;
            Points = 100;
            GameOver = false;
            Paused = false;
        }
    }
}
