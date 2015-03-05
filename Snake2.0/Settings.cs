using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake2._0
{
    public enum Direction
    {
        Up,Down,Left,Right
    };

    /// <summary>
    /// The default settings of the snake game.
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
        public static Direction direction { get; set; }

        /// <summary>
        /// Constructor: Contains the initial default parameters of the game.
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
            direction = Direction.Up;
        }
    }
}
