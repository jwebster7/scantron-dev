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
        private List<string> card_data = new List<string>();
        // Hold the cards to be turned in to students.
        private List<Card> cards = new List<Card>();
        // Holds the students to be graded.
        private List<Student> students = new List<Student>();
        // Holds the answer key to compare to student responses.
        private List<Question> answer_key = new List<Question>();

        public Grader()
        {

        }

        public List<Student> Students
        {
            get
            {
                return students;
            }
        }

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

        // This method creates student objects and adds them to the students list.
        public void CreateStudents(string raw_scantron_output)
        {
            card_data = raw_scantron_output.Split('$').ToList<string>();
            Card card;
            
            for (int i = 0; i < card_data.Count - 1; i++)
            {
                card = new Card(card_data[i]);
            }
        }

        // Check student answers against the answer key. Canvas grading
        public void GradeStudents()
        {
            foreach (Student student in students)
            {
                for (int i = 0; i < answer_key.Count; i++)
                {
                    student.Response[i].Grade(answer_key[i]);
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

            foreach (Student student in students)
            {
                count++;
                info += "Scantron Card(s): " + count + ",," + student.WID + ",,," + student.Score();
            }

            return info;
        }
    }
}