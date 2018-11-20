// Grader.cs
//
// Property of the Kansas State University IT Help Desk
// Written by: William McCreight, Caleb Schweer, and Joseph Webster
// 
// An extensive explanation of the reasoning behind the architecture of this program can be found on the github 
// repository: https://github.com/prometheus1994/scantron-dev/wiki
//
// This class handles creation and grading of students.
// https://github.com/prometheus1994/scantron-dev/wiki/Grader.cs

using System;
using System.Collections.Generic;
using System.Linq;

namespace Scantron
{
    class Grader
    {
        private GUI gui;
        // Holds the exam name to be used in the output file.
        string exam_name = "";
        // Holds the cards used to create the students.
        private List<Card> cards = new List<Card>();
        // Hold the list of students to be graded
        private List<Student> students = new List<Student>();
        // Holds the answer key to compare to student responses.
        private Dictionary<int, List<Question>> answer_key = new Dictionary<int, List<Question>>();
        // Holds the partial misread WID's
        private List<string> partial_wids = new List<string>();
        
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

        public List<string> PartialWIDs
        {
            get
            {
                return partial_wids;
            }
        }

        public Grader(GUI gui)
        {
            this.gui = gui;
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
        }

        /// <summary>
        /// Check student answers against the answer key.
        /// </summary>
        /// <returns>True if no errors occurred.</returns>
        public void GradeStudents(string exam_name)
        {
            this.exam_name = exam_name;
            string ungraded_students = "";

            foreach (Student student in students)
            {
                int test_version = student.TestVersion;

                for (int i = 0; i < answer_key[0].Count; i++)
                {
                    if (student.TestVersion > 0 && student.TestVersion <= answer_key.Count && student.Response.Count >= answer_key[0].Count)
                    {
                        student.Response[i].Grade(answer_key[test_version - 1][i]);
                    }
                    else
                    {
                        ungraded_students += student.WID + "\n";
                        break;
                    }
                }
            }

            if (ungraded_students != "")
            {
                gui.DisplayMessage( "The following students wrote down an invalid test version " +
                                    "or one of their sheets has their WID written incorrectly:\n" + ungraded_students);
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

        /// <summary>
        /// Create a string to print to a file for only single answer questions.
        /// </summary>
        /// <returns>File string.</returns>
        public string SingleAnswerFile()
        {
            string info = "";

            foreach (Card card in cards)
            {
                info += card.ToSingleAnswerString();
            }

            return info;
        }

        /// <summary>
        /// Create a string to print to a file that can handle multiple answer questions.
        /// </summary>
        /// <returns>File string.</returns>
        public string MultipleAnswerFile()
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