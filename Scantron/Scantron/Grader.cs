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
        private List<string> cards = new List<string>();
        // Holds the students to be graded.
        private List<Student> students = new List<Student>();
        // Holds the answer key to compare to student responses.
        private string[] answer_key = new string[5];
        // Hold a list of which questions are given partial credit.
        private bool[] partial_credit;
        
        public List<Student> Students
        {
            get
            {
                return students;
            }
        }

        public string[] AnswerKey
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

        public bool[] PartialCredit
        {
            get
            {
                return partial_credit;
            }
            set
            {
                partial_credit = value;
            }
        }

        // Real constructor for the grader.
        public Grader()
        {
        }

        // This method creates student objects and adds them to the students list.
        public void CreateStudents(string raw_scantron_output)
        {
            // Sets each reference value in cards equal to exactly one scantron card.
            cards = raw_scantron_output.Split('$').ToList<string>();

            // For each index/value in cards, create a student object and add to the list students.
            for (int i = 0; i < cards.Count - 1; i++)
            {
                students.Add(new Student(cards[i]));
            }
        }

        // Method for grading the student responses.
        public void Grade()
        {
            foreach (Student student in students)
            {
                student.Grade = CheckAnswers(student.Answers, answer_key);
            }
        }

        // Check student answers against the answer key. Canvas grading
        private float[] CheckAnswers(string[] answers, string[] answer_key)
        {
            int number_of_questions = answer_key[0].Length;
            float[] score = new float[number_of_questions];

            for (int i = 0; i < number_of_questions; i++)
            {
                if (partial_credit[i])
                {
                    float total_answers = 0;
                    float correct_answers = 0;
                    float incorrect_answers = 0;

                    for (int j = 0; j < 5; j++)
                    {
                        if (answer_key[j][i] != ' ')
                        {
                            total_answers++;

                            if (answers[j][i] == answer_key[j][i])
                            {
                                correct_answers++;
                            }
                        }
                        else
                        {
                            if (answers[j][i] != answer_key[j][i])
                            {
                                incorrect_answers++;
                            }
                        }
                    }

                    score[i] = (correct_answers / total_answers) - (incorrect_answers / total_answers); // This is the algorithm.
                }
                else
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (answers[j][i] != answer_key[j][i])
                        {
                            score[i] = 0;
                            break;
                        }
                        score[i] = 1;
                    }
                }
            }

            return score;
        }

        // Convert the students' grades into a CSV file to be uploaded to the Canvas gradebook.
        public override string ToString()
        {
            string info = "Student,ID,SIS User ID,SIS Login ID,Section," + answer_key[0].Length + Environment.NewLine +
                            "Points Possible,,,,," + answer_key[0].Length + Environment.NewLine; // Will need to fix with Question.Score
            int count = 1;

            foreach (Student student in students)
            {
                count++;
                info += "Scantron Card(s): " + count + ",," + student.WID + ",,," + student.Grade.Sum();
            }

            return info;
        }
    }
}
