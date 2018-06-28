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
        private List<Student> students = new List<Student>();
        private string[] answer_key = new string[5];

        public Grader(List<Student> students, string[] answer_key)
        {
            this.students = students;
            this.answer_key = answer_key;
        }
    }
}
