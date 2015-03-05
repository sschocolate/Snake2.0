using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake2._0
{
    class KeyPressedEvents
    {
        //Load list of available Keyboard buttons
        private static Hashtable keyTable = new Hashtable();

        public static void initializeKeys()
        {
            keyTable.Add(Keys.Right, false);
            keyTable.Add(Keys.Left, false);
            keyTable.Add(Keys.Up, false);
            keyTable.Add(Keys.Down, false);
            keyTable.Add(Keys.Enter, false);
            keyTable.Add(Keys.P, false);
        }

        //Perform a check to see if a particular button is pressed.
        public static bool KeyPressed(Keys key)
        {
            if (keyTable[key] == null)
            {
                return false;
            }
            return (bool)keyTable[key];
        }

        //Sets true if a keyboard button is pressed
        public static void ChangeState(Keys key, bool state)
        {
            keyTable[key] = state;
        }
    }
}
