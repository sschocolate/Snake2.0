using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake2._0
{
    public partial class MenuScreenControl : UserControl
    {
        private List<string> high_scores_m;
        private int score_m;
        private bool GameOver_m = false;

        public MenuScreenControl()
        {
            InitializeComponent();
        }

        [Description("On exit click"),
         CategoryAttribute("Custom")]
        public event EventHandler exitClickEvent
        {
            add { exit_button.Click += value; }
            remove { exit_button.Click -= value; }
        }

        [Description("On map1 click"),
         CategoryAttribute("Custom")]
        public event EventHandler map1ClickEvent
        {
            add { map1.Click += value; }
            remove { map1.Click -= value; }
        }

        [Description("On map2 click"),
         CategoryAttribute("Custom")]
        public event EventHandler map2ClickEvent
        {
            add { map2.Click += value; }
            remove { map2.Click -= value; }
        }

        [Description("On map3 click"),
         CategoryAttribute("Custom")]
        public event EventHandler map3ClickEvent
        {
            add { map3.Click += value; }
            remove { map3.Click -= value; }
        }

        [Description("On play again click"),
         CategoryAttribute("Custom")]
        public event EventHandler playAgainClickEvent
        {
            add { playAgain_button.Click += value; }
            remove { playAgain_button.Click -= value; }
        }

        [Description("Paint event for the play screen"),
         CategoryAttribute("Custom")]
        public event PaintEventHandler playScreenPaint
        {
            add { PlayScreen.Paint += value; }
            remove { PlayScreen.Paint -= value; }
        }

        [Description("Image for map 1"),
         BindableAttribute(true)]
        public Image map1_Image 
        {
            get { return map1.Image; }
            set { map1.Image = value; } 
        }

        [Description("Image for map 2"),
         BindableAttribute(true)]
        public Image map2_Image
        {
            get { return map2.Image; }
            set { map2.Image = value; }
        }

        [Description("Image for map 3"),
         BindableAttribute(true)]
        public Image map3_Image
        {
            get { return map3.Image; }
            set { map3.Image = value; }
        }

        [Description("Array used to populate high scores"),
         Category("Custom")]
        public List<string> highScores
        {
            get { return high_scores_m; }
            set { high_scores_m = value; }
        }

        [Description("Determines if the player has died"),
         Category("Custom")]
        public bool GameOver
        {
            get { return GameOver_m; }
            set { GameOver_m = value; }
        }

        [Description("Determines the player's score"),
         Category("Custom")]
        public int playerScore
        {
            get { return score_m; }
            set 
            { 
                score_m = value;
                endGame_score.Text = value.ToString();
            }
        }

        //Method called by buttons to switch between screens.
        private void switchScreen(Panel currPanel,Panel nextPanel)
        {
            currPanel.Visible = false;
            nextPanel.Visible = true;
        }

        //Method used to populate high scores page
        private void populateHighScores(List<string> scores)
        {
            for (int i = 0; i < scores.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        firstLabel.Text = scores[i];
                        break;
                    case 1:
                        secondLabel.Text = scores[i];
                        break;
                    case 2:
                        thirdLabel.Text = scores[i];
                        break;
                    case 3:
                        fourthLabel.Text = scores[i];
                        break;
                    case 4:
                        fifthLabel.Text = scores[i];
                        break;
                    default:
                        break;
                }
            }
        }

        private void startGame_button_Click(object sender, EventArgs e)
        {
            switchScreen(MenuScreen, chooseMapPanel);
        }

        private void highScores_button_Click(object sender, EventArgs e)
        {
            populateHighScores(high_scores_m);
            switchScreen(MenuScreen, highScoresPanel);
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            switchScreen(chooseMapPanel, MenuScreen);
        }

        private void home_button_Click(object sender, EventArgs e)
        {
            switchScreen(highScoresPanel, MenuScreen);
        }

        private void map1_Click(object sender, EventArgs e)
        {
            switchScreen(chooseMapPanel, playScreenPanel);
        }

        private void map2_Click(object sender, EventArgs e)
        {
            switchScreen(chooseMapPanel, playScreenPanel);
        }

        private void map3_Click(object sender, EventArgs e)
        {
            switchScreen(chooseMapPanel, playScreenPanel);
        }

        private void endGame_homeButton_Click(object sender, EventArgs e)
        {
            gameOver_panel.Visible = false;
            switchScreen(playScreenPanel, MenuScreen);
        }

        private void PlayScreen_Paint(object sender, PaintEventArgs e)
        {
            if (GameOver_m)
                switchScreen(playScreenPanel, gameOver_panel);
        }

        private void playAgain_button_Click(object sender, EventArgs e)
        {
            switchScreen(gameOver_panel, playScreenPanel);
        }

    }
}
