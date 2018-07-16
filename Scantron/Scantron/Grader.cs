// Grader.cs
//
// Property of the Kansas State University IT Help Desk
// Written by: William McCreight, Caleb Schweer, and Joseph Webster
// 
// An extensive explanation of the reasoning behind the architecture of this program can be found on the github 
// repository: https://github.com/prometheus1994/scantron-dev/wiki
//
// This class handles creation and grading of students.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scantron
{
    class Grader
    {
        GUI gui;
        // Holds the raw data split up by card.
        private List<string> raw_cards = new List<string>();
        // Holds the cards used to create the students.
        private List<Card> cards = new List<Card>();
        // Hold the list of students to be graded
        private List<Student> students = new List<Student>();
        // Holds the answer key to compare to student responses.
        private List<Question> answer_key = new List<Question>(); // may need to be converted to a Dictionary<int, List<questions>> as well

        // Default constructor; does nothing
        public Grader(GUI gui)
        {
            this.gui = gui;
        }

        // getter for cards
        public List<Student> Students
        {
            get
            {
                return students;
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
                Student student = new Student(card);

                if (students.Exists(item => item.WID == card.WID))
                {
                    student = students.Find(item => item.WID == card.WID);
                    student.Cards.Add(card);
                }
                else
                {
                    students.Add(student);
                }
            }

            foreach (Student student in students)
            {
                student.CreateResponse();
            }
        }
        
        // Check student answers against the answer key. Canvas grading. Returns true if no errors occurred.
        public bool GradeStudents()
        {
            foreach (Student student in students)
            {
                try
                {
                    for (int i = 0; i < answer_key.Count; i++)
                    {
                        student.Response[i].Grade(answer_key[i]);
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    gui.DisplayMessage("Student " + student.WID + " has " + student.Response.Count + " questions associated with them."
                                        + " If this is too few, the student filled out the WID on one or more of their cards incorrectly."
                                        + " If this is the correct number, you may have entered too many questions on the answer key.");
                    return false;
                }
            }

            return true;
        }

        // Convert the students' grades into a CSV file to be uploaded to the Canvas gradebook.
        public override string ToString()
        {
            float points_possible = answer_key.Sum(question => question.Points);

            string info = "Student,ID,SIS User ID,SIS Login ID,Section," + answer_key.Count + Environment.NewLine +
                            "Points Possible,,,,," + points_possible + Environment.NewLine;
            int count = 0;

            foreach (Student student in students)
            {
                count++;
                info += "Scantron Card(s): " + count + ",," + student.WID + ",,," + student.Score() + Environment.NewLine;
            }

            return info;
        }
    }
}