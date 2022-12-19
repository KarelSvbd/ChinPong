using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChinPongRecognition
{
    public partial class frmGameOver : Form
    {
        private int _score, _highScore;
        private Gameplay gameplay;

        public int Score
        {
            get { return _score; }
            private set { _score = value; }
        }
        public int HighScore
        {
            get { return _highScore; }
            private set { _highScore = value; }
        }

        public Gameplay Gameplay
        {
            get { return gameplay; }
            set { gameplay = value; }
        }
        public frmGameOver(int score, int highScore, Gameplay gameplay)
        {
            InitializeComponent();
            Score = score;
            HighScore = highScore;
            Gameplay = gameplay;
            DisplayResult();
        }

        private void DisplayResult()
        {
            lblHighScore.Text = HighScore.ToString();
            lblScore.Text = Score.ToString();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            Gameplay.Respawn();
            Close();
        }
    }
}
