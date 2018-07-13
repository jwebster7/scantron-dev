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
        private Dictionary<int, Card> cards = new Dictionary<int, Card>();

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
        public Dictionary<int, Card> Cards
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
