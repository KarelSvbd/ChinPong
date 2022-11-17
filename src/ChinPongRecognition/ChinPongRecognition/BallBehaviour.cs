using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Windows.Forms;

namespace ChinPongRecognition
{
    public class BallBehaviour : PictureBox
    {
        Color DEFAULT_COLOR = Color.Beige;
        Brush BALL_COLOR = new SolidBrush(Color.Red);
        Brush BAR_COLOR = new SolidBrush(Color.Blue);



        const int BALL_SPAWN_POSITION_X = 20;
        const int BALL_SPAWN_POSITION_Y = 40;
        const int BALL_SIZE = 30;
        const int SPEED = 5;
        const int VALUE_INVERSOR = -1;
        const int BAR_WIDTH = 200;
        const int BAR_HEIGHT = 10;

        private int _curentPositionX = BALL_SPAWN_POSITION_X;
        public int CurentPositionX { get => _curentPositionX; private set => _curentPositionX = value; }

        private int _curentPositionY = BALL_SPAWN_POSITION_Y;
        public int CurentPositionY { get => _curentPositionY; set => _curentPositionY = value; }

        private int _barPositionX = 0;
        public int BarPositionX { get => _barPositionX; set => _barPositionX = value; }

        private int _barPositionY = 0;
        public int BarPositionY { get => _barPositionY; set => _barPositionY = value; }

        private int nextDirectionX = 1;

        private int nextDirectionY = 1;

        public BallBehaviour()
        {

        }

        public void NextDirection()
        {
            CurentPositionX += SPEED * nextDirectionX;
            CurentPositionY += SPEED * nextDirectionY;

            // si ça touche le mur de droite
            if (CurentPositionX + BALL_SIZE >= this.Width)
            {
                nextDirectionX *= VALUE_INVERSOR;
            }
            // si ça touche le mur du bas
            if (CurentPositionY + BALL_SIZE >= this.Height)
            {
                nextDirectionY *= VALUE_INVERSOR;
            }
            // si ça touche le mur de gauche
            if (CurentPositionX <= 0)
            {
                nextDirectionX *= VALUE_INVERSOR;
            }
            // si ça touche le mur du haut
            if (CurentPositionY <= 0)
            {
                nextDirectionY *= VALUE_INVERSOR;
            }
            // si ça touche la barre
            if (CurentPositionX + BALL_SIZE >= BarPositionX - (BAR_WIDTH / 2) && CurentPositionX + BALL_SIZE <= BarPositionX + (BAR_WIDTH / 2) && CurentPositionY + BALL_SIZE >= BarPositionY && CurentPositionY + BALL_SIZE <= BarPositionY + BAR_HEIGHT)
            {
                //nextDirectionX *= VALUE_INVERSOR;
                nextDirectionY *= VALUE_INVERSOR;
            }

            Invalidate();

            Parent.Invalidate();
        }

        /*protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            BarPositionX = e.X;
            BarPositionY = e.Y;


        }*/

        protected override void OnPaint(PaintEventArgs p)
        {
            base.OnPaint(p);

            p.Graphics.Clear(DEFAULT_COLOR);

            p.Graphics.FillEllipse(BALL_COLOR, new Rectangle(CurentPositionX, CurentPositionY, BALL_SIZE, BALL_SIZE));

            p.Graphics.FillRectangle(BAR_COLOR, new Rectangle(BarPositionX - (BAR_WIDTH / 2), BarPositionY, BAR_WIDTH, BAR_HEIGHT));
        }
    }
}
