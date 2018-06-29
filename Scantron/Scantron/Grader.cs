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

        // Check each student answer to each answer key answer.
        private int[] CheckAnswers(string[] answers, string[] answer_key)
        {
            int[] score = new int[answer_key.Length];

            for (int i = 0; i < answer_key.Length; i++)
            {
                if (answers[i] == answer_key[i])
                {
                    score[i] = 1;
                }
                else
                {
                    score[i] = 0;
                }
            }

            return score;
        }

        // Convert the students' grades into a CSV file to be uploaded to the Canvas gradebook.
        public override string ToString()
        {
            string info = "Student,ID,SIS User ID,SIS Login ID,Section," + answer_key.Length + Environment.NewLine +
                            "Points Possible,,,,," + answer_key.Length + Environment.NewLine;
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
