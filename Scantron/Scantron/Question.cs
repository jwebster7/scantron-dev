// Question.cs
//
// Property of the Kansas State University IT Help Desk
// Written by: William McCreight, Caleb Schweer, and Joseph Webster
// 
// An extensive explanation of the reasoning behind the architecture of this program can be found on the github 
// repository: https://github.com/prometheus1994/scantron-dev/wiki
//
// This class is used to create Question objects for the student responses & exam key.

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scantron
{
    class Question
    {
        // char[] to hold the student response to the question
        private char[] answer = new char[5];

        // float for holding the total points for the question
        private float points;

        // will decide if the question gives partial points for multiple choice or multiple answer
        private bool partial_credit;

        // constructor for Question
        public Question(char[] answer, float points, bool partial_credit)
        {
            this.answer = answer;
            this.points = points;
            this.partial_credit = partial_credit;
        }

        // getter for char[] answer
        public char[] Answer
        {
            get
            {
                return answer;
            }
        }

        public float Points
        {
            get
            {
                return points;
            }
        }

        public bool PartialCredit
        {
            get
            {
                return partial_credit;
            }
        }

        // Method for grading this question.
        public void Grade(Question answer_key)
        {
            if (answer_key.PartialCredit)
            {
                float total_answers = 0;
                float correct_answers = 0;

                for (int i = 0; i < 5; i++)
                {
                    if (answer[i] != ' ' || answer_key.answer[i] != ' ')
                    {
                        total_answers++;

                        if (answer[i] == answer_key.answer[i])
                        {
                            correct_answers++;
                        }
                    }
                }
                
                points = (correct_answers / total_answers) * answer_key.points;
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    if (answer[i] != answer_key.Answer[i])
                    {
                        points = 0;
                        return;
                    }
                }

                points = answer_key.Points;
                return;
            }
        }
    }
}