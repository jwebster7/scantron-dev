using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Scantron
{
    class Student
    {
        private string raw_student_data;
        private string wid;
        private char grant_permission;
        private char test_version;
        private char sheet_number;
        private string answers;
        
        public Student(string raw_student_data)
        {
            this.raw_student_data = raw_student_data;
            RemoveBackSide();
        }

        private void RemoveBackSide()
        {
            int start;
            int length;

            while (raw_student_data.Contains("b"))
            {
                start = raw_student_data.IndexOf("b");

                if (raw_student_data.IndexOf("a", start) != -1)
                {
                    length = raw_student_data.IndexOf("a", start) - start;
                }
                else
                {
                    length = raw_student_data.Length - start;
                }

                raw_student_data = raw_student_data.Remove(start, length);
            }
        }

        public override string ToString()
        {
            return raw_student_data;
        }
    }
}
