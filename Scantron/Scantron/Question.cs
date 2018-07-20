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
        // A char array that holds the answer a student gives or the answer on the answer key.
        private char[] answer = new char[5];

        // How many points this question is worth.
        private float points;

        // Holds if this questions can be graded for partial credit on multiple answer questions.
        private bool partial_credit;
        
        public Question(char[] answer, float points, bool partial_credit)
        {
            this.answer = answer;
            this.points = points;
            this.partial_credit = partial_credit;
        }
        
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

        /// <summary>
        /// Method for grading this question.
        /// </summary>
        /// <param name="answer_key">Answer key to grade this questions against.</param>
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