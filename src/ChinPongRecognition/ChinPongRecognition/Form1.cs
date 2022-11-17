using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChinPongRecognition
{
    public partial class Form1 : Form
    {
        BallBehaviour _ballBehaviour;
        OpenCvProject _openCvProject;

        public BallBehaviour BallBehaviour
        {
            get { return _ballBehaviour; }
            private set { _ballBehaviour = value; }
        }

        public OpenCvProject OpenCvProject
        {
            get { return _openCvProject; }
            private set { _openCvProject = value; }
        }


        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            BallBehaviour = new BallBehaviour();
            BallBehaviour.Width = 730;
            BallBehaviour.Height = 620;
            BallBehaviour.Location = new Point(750, 10);
            OpenCvProject = new OpenCvProject(pbxCapture, BallBehaviour);
            Controls.Add(BallBehaviour);
            StartGame();
        }

        private void StartGame()
        {
            //Creates a new video capture
            OpenCvProject.StartCapture();
            //Execules continusoly
            Application.Idle += OpenCvProject.ActualFrame;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\karel.svbd\Documents\GitHub\ChinPong\src\ChinPongRecognition\ChinPongRecognition\ressources\mainMusic.wav");
            //player.Play();
        }

        private void pbxCapture_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            BallBehaviour.NextDirection();
        }
    }
}
