using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scantron
{
    class Student
    {
        private string wid;

        Dictionary<int, Card> response = new Dictionary<int, Card>();

        public string WID
        {
            get
            {
                return wid;
            }
        }

        public Dictionary<int, Card> Response
        {
            get
            {
                return response;
            }
        }


    }
}
