using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ChinPongRecognition
{
    public class XmlManipulation
    {
        private XmlDocument _doc;

        public List<Score> ScoreList = new List<Score>();

        public XmlDocument Doc
        {
            get { return _doc; }
            private set { _doc = value; }
        }


        public XmlManipulation(XmlDocument xmlDoc)
        {
            Doc = xmlDoc;
        }
        /*public List<Score> GetAllScoreDESC()
        {

        }*/

    }
}
