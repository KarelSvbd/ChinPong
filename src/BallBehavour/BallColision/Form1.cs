namespace BallColision
{
    public partial class Form1 : Form
    {
        BallBehaviour ground;

        public Form1()
        {
            InitializeComponent();

            ground = new BallBehaviour();
            ground.Width = 500;
            ground.Height = 650;
            Controls.Add(ground);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ground.NextDirection();
        }
    }
}