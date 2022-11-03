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
        private Capture videoCapture = null;
        private Image<Bgr, Byte> currentFrame = null;
        CascadeClassifier faceCasacdeClassifier = new CascadeClassifier(@"C:\Users\karel.svbd\Documents\GitHub\ChinPong\src\ChinPongRecognition\ChinPongRecognition\haarcascade_frontalface_alt.xml");
        Mat frame = new Mat();


        public Form1()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            //Creates a new video capture
            videoCapture = new Capture();
            //Execules continusoly
            Application.Idle += ActualFrame;
        }

        private void ActualFrame(object sender, EventArgs e)
        {
            if (videoCapture != null && videoCapture.Ptr != IntPtr.Zero)
            {
                videoCapture.Retrieve(frame, 0);
                currentFrame = frame.ToImage<Bgr, Byte>().Resize(pbxCapture.Width, pbxCapture.Height, Inter.Cubic);
                pbxCapture.Image = currentFrame.Bitmap;

                Rectangle[] faces = faceCasacdeClassifier.DetectMultiScale(frame, 1.1, 1, Size.Empty, Size.Empty);
                foreach (var face in faces)
                {
                    CvInvoke.Line(currentFrame, new Point(face.Left + 100,  face.Bottom + face.Height / 2), new Point(face.Right + 50, face.Bottom + face.Height / 2), new Bgr(Color.Green).MCvScalar, 20, new LineType(), 0);
                }
            }
        }

        private void pbxCapture_Click(object sender, EventArgs e)
        {

        }
    }
}
