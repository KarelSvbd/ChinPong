/// \file ChinPongRecognition
/// \class OpenCVProject
/// \bief Open cv part, captures the face and makes the logic
/// \author Karel.SVBD, CFPTI
/// \date 17.11.2022
/// \version 0.2

using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChinPongRecognition
{
    public class OpenCvProject
    {
        //constants
        private const string XML_DATA = @"C:\Users\karel.svbd\Documents\GitHub\ChinPong\src\ChinPongRecognition\ChinPongRecognition\haarcascade_frontalface_alt.xml";
        public const int DEFAULT_LINE_MARGIN = 100;
        public const int DEFAULT_CHANNEL = 0;

        //instance variables
        private Capture _videoCapture = null;
        private Image<Bgr, byte> _currentFrame = null;
        private CascadeClassifier _faceCasacdeClassifier = new CascadeClassifier(XML_DATA);
        private Mat _frame = new Mat();
        private PictureBox _pbxOutput;
        private BallBehaviour _ballBehaviour;

        //proprieties
        public Capture VideoCapture
        {
            get { return _videoCapture; }
            private set { _videoCapture = value; }
        }
        public Image<Bgr, byte> CurrentFrame
        {
            get { return _currentFrame; }
            private set { _currentFrame = value; }
        }
        public CascadeClassifier FaceCasacdeClassifier
        {
            get { return _faceCasacdeClassifier; }
            private set { _faceCasacdeClassifier = value; }
        }
        public Mat Frame
        {
            get { return _frame; }
            private set { _frame = value; }
        }
        public PictureBox PbxOutput
        {
            get { return _pbxOutput; }
            private set { _pbxOutput = value; }
        }
        public BallBehaviour BallBehaviour
        {
            get { return _ballBehaviour; }
            set { _ballBehaviour = value; }
        }


        //contructors
        public OpenCvProject(PictureBox pbxOutput, BallBehaviour ballBehaviour)
        {
            PbxOutput = pbxOutput;
            BallBehaviour = ballBehaviour;
        }

        //functions

        /// <summary>
        /// Executes at each frame
        /// Sends the data to a picture box
        /// Creates a bar in the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ActualFrame(object sender, EventArgs e)
        {
            if (VideoCapture != null && VideoCapture.Ptr != IntPtr.Zero)
            {
                VideoCapture.Retrieve(Frame, DEFAULT_CHANNEL);
                CurrentFrame = Frame.ToImage<Bgr, byte>().Resize(PbxOutput.Width, PbxOutput.Height, Inter.Cubic);
                PbxOutput.Image = CurrentFrame.Bitmap;

                Rectangle[] faces = FaceCasacdeClassifier.DetectMultiScale(Frame, 1.1, 1, Size.Empty, Size.Empty);
                foreach (var face in faces)
                {
                    CvInvoke.Line(CurrentFrame, new Point(face.Left + DEFAULT_LINE_MARGIN, face.Bottom + face.Height / 2), new Point(face.Right + DEFAULT_LINE_MARGIN, face.Bottom + face.Height / 2), new Bgr(Color.Green).MCvScalar, 20, new LineType(), 0);
                    _ballBehaviour.BarPositionX = BallBehaviour.Width - (face.Left + DEFAULT_LINE_MARGIN);
                    _ballBehaviour.BarPositionY = face.Bottom + DEFAULT_LINE_MARGIN;
                }
            }
        }

        /// <summary>
        /// Begins the video capture
        /// </summary>
        public void StartCapture()
        {
            VideoCapture = new Capture();
        }
    }
}
