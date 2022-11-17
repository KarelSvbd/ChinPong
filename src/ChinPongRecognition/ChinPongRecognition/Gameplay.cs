/* Gameplay.cs
 * Lachenal Ruben
 * Classe qui gère le comportement du jeu, particulièrement l'UI
 * 17/11/2022
 */
namespace ChinPongRecognition
{
    public class Gameplay
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

        /// <summary>
        /// Booléen qui indique si le jeu est en cours ou pas
        /// </summary>
        /// <returns>False si le jeu est en cours True si le joueur à perdu </returns>
        public bool GameOver()
        {
            if(Life <= 0)
            {              
                return true;
            }
            return false;
        }

        
        /// <summary>
        /// méthode qui enlève une vie au joueur, si en pérdant le joueur à battu le record il le stoque dans le highscore  
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        public void Respawn()
        {
            Life = LIFE_BEGIN;
            Score = POINT_BEGIN;
            this.GameOver();
        }

        /// <summary>
        /// Ajoute les points du joueur
        /// </summary>
        /// <returns>le score incrémenté</returns>
        public int GainPoint()
        {
            Score += POINT_INCREMENT;
            return Score;
        }

    }
}
