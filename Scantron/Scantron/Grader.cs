// Grader.cs
//
// Property of the Kansas State University IT Help Desk
// Written by: William McCreight, Caleb Schweer, and Joseph Webster
// 
// An extensive explanation of the reasoning behind the architecture of this program can be found on the github 
// repository: https://github.com/prometheus1994/scantron-dev/wiki
//
// This class handles button click events on the GUI.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scantron
{
    class Grader
    {
        // Holds the raw data split up by card.
        private List<string> raw_cards = new List<string>();
        // Holds the cards used to create the students.
        private List<Card> cards = new List<Card>();
        // Hold the list of students to be graded
        private List<Student> students = new List<Student>();
        // Holds the answer key to compare to student responses.
        private List<Question> answer_key = new List<Question>(); // may need to be converted to a Dictionary<int, List<questions>> as well

        // Default constructor; does nothing
        public Grader()
        {

        }

        // getter for cards
        public List<Card> Cards
        {
            get
            {
                return cards;
            }
        }

        // getter/setter for answer_key
        public List<Question> AnswerKey
        {
            get
            {
                return answer_key;
            }
            set
            {
                answer_key = value;
            }
        }

        // Creates card objects from the created cards and adds them to the list
        public void CreateCards(string raw_scantron_output)
        {
            // Sets each reference value in cards equal to exactly one scantron card.
            raw_cards = raw_scantron_output.Split('$').ToList<string>();

            // For each index/value in cards, create a *card* object and add to the list cards.
            for (int i = 0; i < raw_cards.Count - 1; i++)
            {
                cards.Add(new Card(raw_cards[i]));
            }
        }

        // Creates the students based off of the list of Card(s); However, it does not sort them.
        public void CreateStudents()
        {
            foreach (Card card in cards)
            {
                // instantiate a NEW dictionary every time to create the "cards" field for Student(s)
                SortedDictionary<int, List<Question>> sheets = new SortedDictionary<int, List<Question>>
                {
                    {card.SheetNumber, card.Response }
                };

                students.Add(new Student(card.WID, sheets));
            }
        }

        // I THINK this is right...
        // Sorts & Merges sheets 1,2,3,...,n of the students cards
        private void MergeSheets()
        {
            foreach (Student student in students)
            {
                List<Question> student_answers = new List<Question>();
                // 'i' is the index of the KeyValuePair of the Dictionary
                for (int i = 1; i <= student.Cards.Count; i++)
                {
                    student_answers = student.Cards[i];
                }
                student.Answers = student_answers;
            }
        }

        // REWRITE ONCE THE LIST OF STUDENTS HAS BEEN CREATED
        // Check student answers against the answer key. Canvas grading
        public void GradeStudents()
        {
            foreach (Card card in cards)
            {
                for (int i = 0; i < answer_key.Count; i++)
                {
                    card.Response[i].Grade(answer_key[i]);
                }
            }
        }

        // Convert the students' grades into a CSV file to be uploaded to the Canvas gradebook.
        public override string ToString()
        {
            float points_possible = 0;
            foreach (Question question in answer_key)
            {
                points_possible += question.Points;
            }

            string info = "Student,ID,SIS User ID,SIS Login ID,Section," + answer_key.Count + Environment.NewLine +
                            "Points Possible,,,,," + points_possible + Environment.NewLine;
            int count = 0;

            foreach (Card student in cards)
            {
                count++;
                info += "Scantron Card(s): " + count + ",," + student.WID + ",,," + student.Score();
            }

            return info;
        }
    }
}