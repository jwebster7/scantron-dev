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
            Format();
            TranslateData();
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

        private void Format()
        {
            int i;
            List<string> card_lines = new List<string>();
            char[] splitter = new char[] {'a'};
            card_lines = raw_student_data.Split(splitter, StringSplitOptions.RemoveEmptyEntries).ToList<string>();

            // remove space above bubbles
            card_lines.RemoveAt(0);
            card_lines.RemoveAt(0);

            // trim WID section
            for (i = 0; i < 9; i++)
            {
                card_lines[i] = card_lines[i].Substring(0, 10);
            }

            // trim quetions 1-5 and extra options section
            card_lines[9] = card_lines[9].Substring(0, 11);
            card_lines[10] = card_lines[10].Substring(0, 8);
            card_lines[11] = card_lines[11].Substring(0, 14);
            card_lines[12] = card_lines[12].Substring(0, 8);
            card_lines[13] = card_lines[13].Substring(0, 11);

            //trim questions 6-50
            for (i = 14; i < card_lines.Count; i++)
            {
                card_lines[i] = card_lines[i].Substring(0, 15);
            }

            raw_student_data = string.Join(",", card_lines);
        }

        private void TranslateData()
        {
            wid = "";

            int i;
            List<string> card_lines = new List<string>();
            char[] splitter = new char[] {','};
            card_lines = raw_student_data.Split(splitter, StringSplitOptions.RemoveEmptyEntries).ToList<string>();

            for (i = 0; i < 9; i++)
            {
                char[] line = card_lines[i].Reverse().ToArray();
                wid += Array.IndexOf(line, line.Max());
            }


        }

        public override string ToString()
        {
            return raw_student_data + Environment.NewLine + wid;
        }
    }
}
