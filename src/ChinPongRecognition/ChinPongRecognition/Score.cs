using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinPongRecognition
{
    public class Score
    {
        private const int DEFAULT_VALUE = 0;
        private const string DEFAULT_NAME = "inconnu";

        private int _value;
        private string _name;
        public int Value { get => _value; set => _value = value; }
        public string Name { get => _name; set => _name = value; }

        //designeted constructor
        public Score(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public Score(int value) : this(value, DEFAULT_NAME)
        {
            // empty
        }

        public Score(string name) : this(DEFAULT_VALUE, name)
        {
            //empty
        }

        public Score() : this(DEFAULT_VALUE, DEFAULT_NAME)
        {
            //empty
        }

        public string Display()
        {
            return $"Name : {Name} Score : {Value}";
        }

    }
}
