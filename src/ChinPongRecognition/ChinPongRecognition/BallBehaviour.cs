using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Windows.Forms;
using OpenTK.Graphics.ES30;

namespace ChinPongRecognition
{
    public class BallBehaviour : PictureBox
    {
        Color DEFAULT_COLOR = Color.Beige;
        Brush BALL_COLOR = new SolidBrush(Color.Red);
        Brush BAR_COLOR = new SolidBrush(Color.Blue);

        Gameplay _ui;
        
        internal Gameplay UI { get => _ui; set => _ui = value; }

        const int BALL_SPAWN_POSITION_X = 20;
        const int BALL_SPAWN_POSITION_Y = 40;
        const int BALL_SIZE = 30;
        const int SPEED = 5;
        const int VALUE_INVERSOR = -1;
        const int BAR_WIDTH = 200;
        const int BAR_HEIGHT = 10;
        const bool BALL_EXIST = true;

        private bool ballExist;
        public bool BallExist { get => ballExist; private set => ballExist = value; }

        private int _curentPositionX = BALL_SPAWN_POSITION_X;
        public int CurentPositionX { get => _curentPositionX; private set => _curentPositionX = value; }

        private int _curentPositionY = BALL_SPAWN_POSITION_Y;
        public int CurentPositionY { get => _curentPositionY; set => _curentPositionY = value; }

        private int _barPositionX = 0;
        public int BarPositionX { get => _barPositionX; set => _barPositionX = value; }

        private int _barPositionY = 0;
        public int BarPositionY { get => _barPositionY; set => _barPositionY = value; }

        private bool _gameOver;

        public bool GameOver { get => _gameOver; set => _gameOver = value; }

        private int nextDirectionX = 1;

        private int nextDirectionY = 1;

        public BallBehaviour(Gameplay pUI)
        {
            UI = pUI;
            ballExist = BALL_EXIST;
            GameOver = false;
        }

        public void NextDirection()
        {
            // tant que le jeu continue
            if (!UI.GameOver())
            {

                CurentPositionX += SPEED * nextDirectionX;
                CurentPositionY += SPEED * nextDirectionY;

                // si ça touche le mur de droite
                if (CurentPositionX + BALL_SIZE >= this.Width)
                {
                    nextDirectionX *= VALUE_INVERSOR;
                    UI.GainPoint();
                }
                // si ça touche le mur du bas perdre une vie
                if (CurentPositionY + BALL_SIZE >= this.Height)
                {
                    nextDirectionY *= VALUE_INVERSOR;
                    UI.LoseLife();
                }
                // si ça touche le mur de gauche
                if (CurentPositionX <= 0)
                {
                    nextDirectionX *= VALUE_INVERSOR;
                    UI.GainPoint();
                }
                // si ça touche le mur du haut
                if (CurentPositionY <= 0)
                {
                    nextDirectionY *= VALUE_INVERSOR;
                    UI.GainPoint();
                }
                // si ça touche la barre
                if (CurentPositionX + BALL_SIZE >= BarPositionX - (BAR_WIDTH / 2) && CurentPositionX + BALL_SIZE <= BarPositionX + (BAR_WIDTH / 2) && CurentPositionY + BALL_SIZE >= BarPositionY && CurentPositionY + BALL_SIZE <= BarPositionY + BAR_HEIGHT)
                {
                    nextDirectionY *= VALUE_INVERSOR;
                }
            }


            Invalidate();

            Parent.Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            BarPositionX = e.X;
            BarPositionY = e.Y;


        }

        public void DestroyBall()
        {
            ballExist = false;
        }

        public void RespawnBall()
        {
            CurentPositionX = BALL_SPAWN_POSITION_X;
            CurentPositionY = BALL_SPAWN_POSITION_Y;
            BallExist = true;
        }

        protected override void OnPaint(PaintEventArgs p)
        {

            base.OnPaint(p);

            p.Graphics.Clear(DEFAULT_COLOR);

            if (!UI.GameOver())
            {
                p.Graphics.FillEllipse(BALL_COLOR, new Rectangle(CurentPositionX, CurentPositionY, BALL_SIZE, BALL_SIZE));
                GameOver = false;
            } 
            else
            {
                if (!GameOver)
                {
                    frmGameOver frm = new frmGameOver(UI.Score, UI.HighScore, UI);
                    frm.Show();
                    GameOver = true;
                }
            }
            p.Graphics.FillRectangle(BAR_COLOR, new Rectangle(BarPositionX - (BAR_WIDTH / 2), BarPositionY, BAR_WIDTH, BAR_HEIGHT));
        }
    }
}
