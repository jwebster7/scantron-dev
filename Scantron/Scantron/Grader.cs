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
        // Holds the students to be graded.
        private List<Student> students = new List<Student>();
        // Holds the answer key to compare to student responses.
        private string[] answer_key = new string[5];
        // Hold a list of which questions are given partial credit.
        private bool[] partial_credit;

        // Default constructor for the grader.
        public Grader()
        {

        }
        
        // Real constructor for the grader.
        public Grader(List<Student> students, string[] answer_key)
        {
            this.students = students;
            this.answer_key = answer_key;
        }

        // Method for grading the student responses.
        public void Grade()
        {
            foreach (Student student in students)
            {
                student.Grade = CheckAnswers(student.Answers, answer_key);
            }
        }

        // Check student answers against the answer key.
        private int[] CheckAnswers(string[] answers, string[] answer_key)
        {
            int[] score = new int[answer_key[0].Length];

            for (int i = 0; i < answer_key[0].Length; i++)
            {
                if (partial_credit[i])
                {
                    // insert code here
                }
                else
                {
                    for (int j = 0; j < answer_key.Length; j++)
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
                            "Points Possible,,,,," + answer_key[0].Length + Environment.NewLine;
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
