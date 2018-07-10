// Question.cs
//
// Property of the Kansas State University IT Help Desk
// Written by: William McCreight, Caleb Schweer, and Joseph Webster
// 
// An extensive explanation of the reasoning behind the architecture of this program can be found on the github 
// repository: https://github.com/prometheus1994/scantron-dev/wiki
//
// This class is used to create Question objects for the student responses & exam key

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scantron
{
    class Question
    {
        // char[] to hold the student response to the question
        public char[] answer = new char[5];

        // float for holding the total points for the question
        public float points;

        // will decide if the question gives partial points for multiple choice or multiple answer
        public bool partial;

        // constructor for Question
        public Question(char[] answer, float points, bool partial)
        {
            this.answer = answer;
            this.points = points;
            this.partial = partial;
        }

        // getter for char[] answer
        public char[] Answer
        {
            get
            {
                return answer;
            }
        }

        // method for grading a question
        public void Grade(Question key)
        {
            // partial points
            if (key.partial)
            {
                // Grade the question & give partial points 
                float total_answers = 0;
                float correct_answers = 0;
                float incorrect_answers = 0;

                for (int i = 0; i < 5; i++)
                {
                    if (key.answer[i] != ' ')
                    {
                        total_answers++;

                        if (this.answer[i] == key.answer[i])
                        {
                            correct_answers++;
                        }
                    }
                    else
                    {
                        if (this.answer[i] != key.answer[i])
                        {
                            incorrect_answers++;
                        }
                    }

                    // algorithm for grading based on the total points value of each question given by the instructor in the key
                    this.points = (correct_answers / total_answers) * key.points - (incorrect_answers / total_answers) * key.points;
                }
            } // end if

            // non-partial points
            if (this.answer.Equals(key.answer))
            {
                this.points = key.points;
            } // end if

        } // end Grade()
    }
}
