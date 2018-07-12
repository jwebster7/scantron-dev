using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scantron
{
    class Student
    {
        // the students wid
        private string wid;

        // the students Scantron card(s); Holds 1 KVP if only question count is <= 50
        private Dictionary<int, List<Question>> cards = new Dictionary<int, List<Question>>();

        // default Student constructor
        public Student()
        {
            // do nothing for now
        }

        // Creates Student() objects using the WID & Dictionary of cards and their sheet number
        public Student(string wid, Dictionary<int, List<Question>> cards)
        {
            this.wid = wid;
            this.cards = cards;
        }

        // getter/setter for wid
        public string WID
        {
            get
            {
                return wid;
            }
            set
            {
                this.wid = value;
            }
        }

        // getter/setter for cards
        public Dictionary<int, List<Question>> Cards
        {
            get
            {
                return cards;
            }
            set
            {
                this.cards = value;
            }
        }
    }
}
