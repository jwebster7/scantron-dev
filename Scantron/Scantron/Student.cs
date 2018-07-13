using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scantron
{
    class Student
    {
        // The student's WID.
        private string wid;

        // The student's Scantron card(s).
        private List<Card> cards = new List<Card>();

        // The student's responses compiled from the cards.
        private List<Question> response = new List<Question>();

        // Creates Student() objects using the WID & Dictionary of cards and their sheet number
        public Student(string wid, Card card)
        {
            this.wid = wid;
            cards.Add(card);
        }

        // getter for wid
        public string WID
        {
            get
            {
                return wid;
            }
        }

        // getter for cards
        public List<Card> Cards
        {
            get
            {
                return cards;
            }
        }

        public List<Question> Response
        {
            get
            {
                return response;
            }
        }


        // Convert the student's list of cards to a list of answers.
        public void CreateResponse()
        {
            cards.Sort((a, b) => a.SheetNumber.CompareTo(b.SheetNumber));

            foreach (Card card in cards)
            {
                response.AddRange(card.Response);
            }
        }

        // Get the student's score.
        public float Score()
        {
            float score = 0;

            foreach (Question question in response)
            {
                score += question.Points;
            }

            return score;
        }
    }
}
