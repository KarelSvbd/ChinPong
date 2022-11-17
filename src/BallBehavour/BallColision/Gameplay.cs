using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallColision
{
    internal class Gameplay
    {
        private int _life;

        public int Life { get => _life; private set => _life = value; }

        private int _score;
        public int Score { get => _score; private set => _score = value; }
        private int _highScore;
        public int HighScore { get => _highScore; private set => _highScore = value; }

        const int LIFE_BEGIN = 3;
        const int POINT_BEGIN = 0;
        const int POINT_INCREMENT = 1;

        public Gameplay()
        {
            Life = LIFE_BEGIN;
            Score = POINT_BEGIN;
            HighScore = POINT_BEGIN;
        }

        public bool GameOver()
        {
            if(Life <= 0)
            {              
                return true;
            }
            return false;
        }

        

        public void LoseLife()
        {
            Life--;
            if (Life <= 0)
            {
                if(Score > HighScore)
                    HighScore = Score;
                GameOver();
            }
        }

        public void Respawn()
        {
            Life = LIFE_BEGIN;
            Score = POINT_BEGIN;
            this.GameOver();
        }

        public int GainPoint()
        {
            Score += POINT_INCREMENT;
            return Score;
        }

    }
}
