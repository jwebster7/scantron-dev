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
            Uncompress();
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

        private void Uncompress()
        {
            int hashtag_location;
            char amount_character;
            char character;
            int amount;
            string uncompressed_string;

            while (raw_student_data.Contains("#"))
            {
                uncompressed_string = "";
                hashtag_location = raw_student_data.IndexOf("#");
                amount_character = raw_student_data[hashtag_location + 1];
                character = raw_student_data[hashtag_location + 2];
                amount = (int)amount_character - 64;

                uncompressed_string = uncompressed_string.PadRight(amount, character);

                raw_student_data = raw_student_data.Replace("#" + amount_character + character, uncompressed_string);
            }
        }

        public override string ToString()
        {
            return raw_student_data;
        }
    }
}
