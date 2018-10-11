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

namespace Scantron
{
    class Grader
    {
        private GUI gui;

        string exam_name = "";
        // Holds the cards used to create the students.
        private List<Card> cards = new List<Card>();
        // Hold the list of students to be graded
        private List<Student> students = new List<Student>();
        // Holds the answer key to compare to student responses.
        private Dictionary<int, List<Question>> answer_key = new Dictionary<int, List<Question>>();
        // Holds the partial misread WID's
        private List<string> partial_wids = new List<string>();

        public Grader(GUI gui)
        {
            this.gui = gui;
        }
        
        public List<Card> Cards
        {
            get
            {
                return cards;
            }
        }
        public List<Student> Students
        {
            get
            {
                return students;
            }
        }
        
        public Dictionary<int, List<Question>> AnswerKey
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

        public List<string> PartialWids
        {
            get
            {
                return partial_wids;
            }
        }

        /// <summary>
        /// Create a list of cards from the raw card data.
        /// </summary>
        /// <param name="raw_cards">Raw card data read in from Scantron.</param>
        public void CreateCards(List<string> raw_cards)
        {
            cards.Clear();

            for (int i = 0; i < raw_cards.Count; i++)
            {
                cards.Add(new Card(raw_cards[i]));
            }
        }

        /// <summary>
        /// Creates the students based off of the list of cards.
        /// </summary>
        public void CreateStudents()
        {
            students.Clear();

            foreach (Card card in cards)
            {
                // Checks for a partial wid on the card; 
                // We want to create a student regardless to retain the scores read in;
                if (card.WID.Contains('-'))
                {
                    partial_wids.Add(card.WID);
                }

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

            gui.DisplayMessage(students.Count + " students successfully created!");
        }

        /// <summary>
        /// Check student answers against the answer key.
        /// </summary>
        /// <returns>True if no errors occurred.</returns>
        public void GradeStudents(string exam_name)
        {
            this.exam_name = exam_name;

            foreach (Student student in students)
            {
                int test_version = student.TestVersion;

                try
                {
                    for (int i = 0; i < answer_key[0].Count; i++)
                    {
                        student.Response[i].Grade(answer_key[test_version - 1][i]);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    gui.DisplayMessage( "Student " + student.WID + " has " + student.Response.Count + " questions associated with them.\n\n" +
                                        "If this is the correct number, you may have entered too many questions on the answer key.\n\n" +
                                        "If this is too few, the student filled out the WID on one or more of their cards incorrectly.\n\n" +
                                        "You can correct this, re-scan the student, and add the student's score, by itself, to the gradebook later.\n\n"+
                                        "The student will still be graded on the questions available.");
                }
                catch (KeyNotFoundException)
                {
                    gui.DisplayMessage( "Student " + student.WID + " wrote down Test Version " + test_version + ".\n\n" +
                                        "You did not create this many versions. Student cannot be graded correctly.\n\n" +
                                        "You can correct this, re-scan the student, and add the student's score to the gradebook by itself later.");
                }
            }
        }

        /// <summary>
        /// Convert the students' grades into a CSV file to be uploaded to the Canvas gradebook.
        /// </summary>
        /// <returns></returns>
        public string GradebookFile()
        {
            float points_possible;

            if (answer_key.Count < 1)
            {
                points_possible = 0;
            }
            else
            {
               points_possible = answer_key[0].Sum(question => question.Points);
            }

            string info = "Student,ID,SIS User ID,SIS Login ID,Section," + exam_name + Environment.NewLine +
                            "Points Possible,,,,," + points_possible + Environment.NewLine;

            foreach (Student student in students)
            {
                info += student.ToString();
            }

            return info;
        }

        public string ScantronToolSingleAnswerFile()
        {
            string info = "";

            foreach (Card card in cards)
            {
                info += card.ToSingleAnswerString();
            }

            return info;
        }

        public string ScantronToolMultipleAnswerFile()
        {
            string info = "";

            foreach (Card card in cards)
            {
                info += card.ToMultipleAnswerString();
            }

            return info;
        }
    }
}