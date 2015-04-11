using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake2._0
{
    class Maps
    {
        private List<Circle> walls = new List<Circle>();
        
        public Maps(int selection)
        {
            //declare all wall pieces
            Circle w1, w2, w3, w4, w5, w6, w7, w8, w9, w10,
                   w11, w12, w13, w14, w15, w16, w17, w18, w19, w20,
                   w21, w22, w23, w24, w25, w26, w27, w28, w29, w30,
                   w31, w32, w33, w34, w35, w36, w37, w38, w39, w40,
                   w41, w42, w43, w44, w45, w46, w47, w48, w49, w50,
                   w51, w52, w53, w54, w55, w56, w57, w58, w59, w60,
                   w61, w62;

            switch (selection)
            {
                case 1:
                    //Left side
                    w1 = new Circle(5, 4);
                    w2 = new Circle(5, 5);
                    w3 = new Circle(5, 6);
                    w4 = new Circle(5, 7);
                    w5 = new Circle(5, 8);
                    w6 = new Circle(5, 9);
                    w7 = new Circle(5, 10);
                    w8 = new Circle(5, 11);
                    w9 = new Circle(5, 12);
                    w10 = new Circle(5, 13);
                    w11 = new Circle(5, 14);
                    w12 = new Circle(5, 15);
                    w13 = new Circle(5, 16);
                    w14 = new Circle(5, 17);
                    w15 = new Circle(5, 18);
                    w16 = new Circle(6, 4);
                    w17 = new Circle(7, 4);
                    w18 = new Circle(8, 4);
                    w19 = new Circle(9, 4);
                    w20 = new Circle(10, 4);
                    w21 = new Circle(11, 4);
                    w22 = new Circle(12, 4);
                    w23 = new Circle(13, 4);
                    w24 = new Circle(6, 18);
                    w25 = new Circle(7, 18);
                    w26 = new Circle(8, 18);
                    w27 = new Circle(9, 18);
                    w28 = new Circle(10, 18);
                    w29 = new Circle(11, 18);
                    w30 = new Circle(12, 18);
                    w31 = new Circle(13, 18);
                    //Right side
                    w32 = new Circle(31, 4);
                    w33 = new Circle(31, 5);
                    w34 = new Circle(31, 6);
                    w35 = new Circle(31, 7);
                    w36 = new Circle(31, 8);
                    w37 = new Circle(31, 9);
                    w38 = new Circle(31, 10);
                    w39 = new Circle(31, 11);
                    w40 = new Circle(31, 12);
                    w41 = new Circle(31, 13);
                    w42 = new Circle(31, 14);
                    w43 = new Circle(31, 15);
                    w44 = new Circle(31, 16);
                    w45 = new Circle(31, 17);
                    w46 = new Circle(31, 18);
                    w47 = new Circle(30, 4);
                    w48 = new Circle(29, 4);
                    w49 = new Circle(28, 4);
                    w50 = new Circle(27, 4);
                    w51 = new Circle(26, 4);
                    w52 = new Circle(25, 4);
                    w53 = new Circle(24, 4);
                    w54 = new Circle(23, 4);
                    w55 = new Circle(30, 18);
                    w56 = new Circle(29, 18);
                    w57 = new Circle(28, 18);
                    w58 = new Circle(27, 18);
                    w59 = new Circle(26, 18);
                    w60 = new Circle(25, 18);
                    w61 = new Circle(24, 18);
                    w62 = new Circle(23, 18);
                    break;
                case 2:
                    //Left side
                    w1 = new Circle(12, 6);
                    w2 = new Circle(12, 7);
                    w3 = new Circle(12, 8);
                    w4 = new Circle(12, 9);
                    w5 = new Circle(12, 10);
                    w6 = new Circle(12, 11);
                    w7 = new Circle(12, 12);
                    w8 = new Circle(12, 13);
                    w9 = new Circle(12, 14);
                    w10 = new Circle(12, 15);
                    w11 = new Circle(12, 16);
                    //Left-top
                    w12 = new Circle(5, 6);
                    w13 = new Circle(6, 6);
                    w14 = new Circle(7, 6);
                    w15 = new Circle(8, 6);
                    w16 = new Circle(9, 6);
                    w17 = new Circle(10, 6);
                    w18 = new Circle(11, 6);
                    //Left-bottom
                    w19 = new Circle(5, 16);
                    w20 = new Circle(6, 16);
                    w21 = new Circle(7, 16);
                    w22 = new Circle(8, 16);
                    w23 = new Circle(9, 16);
                    w24 = new Circle(10, 16);
                    w25 = new Circle(11, 16);

                    //Right side
                    w26 = new Circle(24, 6);
                    w27 = new Circle(24, 7);
                    w28 = new Circle(24, 8);
                    w29 = new Circle(24, 9);
                    w30 = new Circle(24, 10);
                    w31 = new Circle(24, 11);
                    w32 = new Circle(24, 12);
                    w33 = new Circle(24, 13);
                    w34 = new Circle(24, 14);
                    w35 = new Circle(24, 15);
                    w36 = new Circle(24, 16);
                    //Right-top
                    w37 = new Circle(25, 6);
                    w38 = new Circle(26, 6);
                    w39 = new Circle(27, 6);
                    w40 = new Circle(28, 6);
                    w41 = new Circle(29, 6);
                    w42 = new Circle(30, 6);
                    w43 = new Circle(31, 6);
                    //Right-bottom
                    w44 = new Circle(25, 16);
                    w45 = new Circle(26, 16);
                    w46 = new Circle(27, 16);
                    w47 = new Circle(28, 16);
                    w48 = new Circle(29, 16);
                    w49 = new Circle(30, 16);
                    w50 = new Circle(31, 16);

                    //Center
                    w51 = new Circle(23, 11);
                    w52 = new Circle(22, 11);
                    w53 = new Circle(21, 11);
                    w54 = new Circle(20, 11);
                    w55 = new Circle(19, 11);
                    w56 = new Circle(17, 11);
                    w57 = new Circle(16, 11);
                    w58 = new Circle(15, 11);
                    w59 = new Circle(14, 11);
                    w60 = new Circle(13, 11);

                    //Extra
                    w61 = new Circle(99, 99);
                    w62 = new Circle(99, 99);
                    break;
                default:
                    return;
            }

            walls.Add(w1);
            walls.Add(w2);
            walls.Add(w3);
            walls.Add(w4);
            walls.Add(w5);
            walls.Add(w6);
            walls.Add(w7);
            walls.Add(w8);
            walls.Add(w9);
            walls.Add(w10);
            walls.Add(w11);
            walls.Add(w12);
            walls.Add(w13);
            walls.Add(w14);
            walls.Add(w15);
            walls.Add(w16);
            walls.Add(w17);
            walls.Add(w18);
            walls.Add(w19);
            walls.Add(w20);
            walls.Add(w21);
            walls.Add(w22);
            walls.Add(w23);
            walls.Add(w24);
            walls.Add(w25);
            walls.Add(w26);
            walls.Add(w27);
            walls.Add(w28);
            walls.Add(w29);
            walls.Add(w30);
            walls.Add(w31);
            walls.Add(w32);
            walls.Add(w33);
            walls.Add(w34);
            walls.Add(w35);
            walls.Add(w36);
            walls.Add(w37);
            walls.Add(w38);
            walls.Add(w39);
            walls.Add(w40);
            walls.Add(w41);
            walls.Add(w42);
            walls.Add(w43);
            walls.Add(w44);
            walls.Add(w45);
            walls.Add(w46);
            walls.Add(w47);
            walls.Add(w48);
            walls.Add(w49);
            walls.Add(w50);
            walls.Add(w51);
            walls.Add(w52);
            walls.Add(w53);
            walls.Add(w54);
            walls.Add(w55);
            walls.Add(w56);
            walls.Add(w57);
            walls.Add(w58);
            walls.Add(w59);
            walls.Add(w60);
            walls.Add(w61);
            walls.Add(w62);
        }
        /// <summary>
        /// Draws the map onto the pictureBox
        /// </summary>
        /// <param name="e"></param>
        public void drawMap(System.Windows.Forms.PaintEventArgs e)
        {
            for (int i = 0; i <= walls.Count - 1; i++)
            {
                //Draw the map
                e.Graphics.FillEllipse(Brushes.Black,
                    new Rectangle(walls[i].X * Settings.Width,
                                  walls[i].Y * Settings.Height,
                                  Settings.Width, Settings.Height));
            }
        }

        //Return the enemy's body
        public List<Circle> getMap()
        {
            return walls;
        }
    }
}
