/* BallBehaviour.cs
 * Lachenal ruben
 * Cette classe gère le comportement et la physique de la balle
 * 17/11/2022
 */ 
using System.Drawing;
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

        /// <summary>
        /// Cette fonction va déplacer la balle lors de la frame suivante
        /// </summary>
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

        /// <summary>
        /// c'étais un test faut songer à l'éffacer
        /// </summary>
        /// <param name="e">OSEF</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            BarPositionX = e.X;
            BarPositionY = e.Y;


        }

        /// <summary>
        /// Détruit la balle mais je suis pas sur que cette méthode sert encore
        /// </summary>
        public void DestroyBall()
        {
            ballExist = false;
        }

        /// <summary>
        /// méthode qui fait réaparaitre la balle à la position initiale
        /// </summary>
        public void RespawnBall()
        {
            CurentPositionX = BALL_SPAWN_POSITION_X;
            CurentPositionY = BALL_SPAWN_POSITION_Y;
            BallExist = true;
        }

        /// <summary>
        /// méthode qui dessine la balle et la barre chaque frame
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            pe.Graphics.Clear(DEFAULT_COLOR);

            if (!UI.GameOver())
                pe.Graphics.FillEllipse(BALL_COLOR, new Rectangle(CurentPositionX, CurentPositionY, BALL_SIZE, BALL_SIZE));

            pe.Graphics.FillRectangle(BAR_COLOR, new Rectangle(BarPositionX - (BAR_WIDTH / 2), BarPositionY, BAR_WIDTH, BAR_HEIGHT));
        }
    }
}
