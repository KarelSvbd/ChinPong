namespace BallColision
{
    public partial class Form1 : Form
    {
        BallBehaviour ground;
        Gameplay game;

        public Form1()
        {
            InitializeComponent();
            game = new Gameplay();
            ground = new BallBehaviour(game);
            ground.Width = 500;
            ground.Height = 650;
            Controls.Add(ground);
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ground.NextDirection();
            lblLife.Text = game.Life.ToString();
            lblScore.Text = game.Score.ToString();
            lblHighScore.Text = game.HighScore.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            game.Respawn();
            ground.RespawnBall();
        }
    }
}