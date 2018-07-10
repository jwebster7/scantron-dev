// Student.cs
//
// Property of the Kansas State University IT Help Desk
// Written by: William McCreight, Caleb Schweer, and Joseph Webster
// 
// An extensive explanation of the reasoning behind the architecture of this program can be found on the github 
// repository: https://github.com/prometheus1994/scantron-dev/wiki
//
// This class is used for creating Student objects with their associated fields, methods, and properties.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Scantron
{
    class Student
    {
        // Stores the raw data stream initially read in from the scantron machine.
        private string raw_student_data;
        // The student's WID.
        private string wid;
        // Stores whether the grant permission bubble is filled.
        private string grant_permission = "-";
        // Stores which of the three test version bubbles is filled.
        private string test_version;
        // Stores which of the five sheet number bubbles is filled.
        private string sheet_number;
        // Stores the answer bubbles formatted to be written to the output file correctly. For more information refer 
        // to the github repository.
        private string[] answers = new string[5];
        // Stores grade on exam
        private float[] grade;

        private char[,] answer = new char[50, 5];

        // WID property.
        public string WID
        {
            get
            {
                return wid;
            }
        }

        // Answers property.
        public string[] Answers
        {
            get
            {
                return answers;
            }
        }

        // Grade property.
        public float[] Grade
        {
            get
            {
                return grade;
            }
            set
            {
                grade = value;
            }
        }

        // Student constructor. Translates the raw data as the student is created and assigns it to the appropriate 
        // fields.
        public Student(string raw_student_data)
        {
            this.raw_student_data = raw_student_data;
            RemoveBackSide();
            Uncompress();
            Format();
            TranslateData();
        }

        // Both sides of a scantron card are scanned. This removes the useless back side data, each line of which is 
        // denoted by a "b" in the raw data. An "a" denotes a front side line.
        private void RemoveBackSide()
        {
            int start;
            int length;

            // As long as any b's are in the raw data, this loop removes any data from and including that b until it 
            // hits an a.
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

        // Looks for the compression character, "#", and uncompresses the characer after it. For more information on 
        // scantron compress, refer to the github repository.
        private void Uncompress()
        {
            int hashtag_location;
            char amount_character;
            char character;
            int amount;
            string uncompressed_string;

            // As long as there is a # in the raw data, this loop replaces the data with its uncompressed form.
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

        // The empty space that a scantron card does not occupy when it goes beneath the scanner is read in as black
        // marks. This method removes that data and trims down the parts of the scantron card that do not contain 
        // bubbles. This turns it into an array of strings that directly correspond to the scantron card itself.
        private void Format()
        {
            int i;
            List<string> card_lines = new List<string>();
            char[] splitter = new char[] {'a'};
            card_lines = raw_student_data.Split(splitter, StringSplitOptions.RemoveEmptyEntries).ToList<string>();

            // The first two lines read are above the bubbles on the scantron card. This removes them.
            card_lines.RemoveAt(0);
            card_lines.RemoveAt(0);

            // Trims useless space to the right of the WID section.
            for (i = 0; i < 9; i++)
            {
                card_lines[i] = card_lines[i].Substring(0, 10);
            }

            // Trims useless space to the right of the miscellaneous options and first five questions. 
            card_lines[9]   = card_lines[9].Substring(0, 11);
            card_lines[10]  = card_lines[10].Substring(0, 8);
            card_lines[11]  = card_lines[11].Substring(0, 14);
            card_lines[12]  = card_lines[12].Substring(0, 8);
            card_lines[13]  = card_lines[13].Substring(0, 11);

            // Trims the space to the right of quetions 6-50.
            for (i = 14; i < card_lines.Count; i++)
            {
                card_lines[i] = card_lines[i].Substring(0, 15);
            }

            raw_student_data = string.Join(",", card_lines);
        }

        // This method take the uncompressed, formatted data and assigns the appropriate data to each student field.
        private void TranslateData()
        {
            // This list splits up each line of bubbles on the scantron card.
            List<string> card_lines = new List<string>();
            char[] splitter = new char[] {','};
            card_lines = raw_student_data.Split(splitter, StringSplitOptions.RemoveEmptyEntries).ToList<string>();

            // Read in the WID bubbles. The relevant lines are reversed because from left to right the bubbles read 
            // from 9 to 0, but their indices are 0 to 9 in their respective strings. Reversing lets Array.IndexOf 
            // do its job correctly.
            for (int i = 0; i < 9; i++)
            {
                char[] line = card_lines[i].Reverse().ToArray();
                wid += Array.IndexOf(line, line.Max());
            }
            
            // Checks the grant permission bubble.
            if ((int)card_lines[11][13] > 6)
            {
                grant_permission = "1";
            }

            // Checks the test version bubbles.
            int test_version_one    = card_lines[9][10];
            int test_version_two    = card_lines[11][10];
            int test_version_three  = card_lines[13][10];

            test_version = GetDarkestBubble(test_version_one, test_version_two, test_version_three);

            // Checks the answer sheet bubbles.
            int sheet_number_one    = card_lines[9][7];
            int sheet_number_two    = card_lines[10][7];
            int sheet_number_three  = card_lines[11][7];
            int sheet_number_four   = card_lines[12][7];
            int sheet_number_five   = card_lines[13][7];

            sheet_number = GetDarkestBubble(sheet_number_one, sheet_number_two, sheet_number_three, 
                sheet_number_four, sheet_number_five);

            // Checks the answer bubbles.
            int count = 0;

            // These for loops are set up so that they read all 50 questions in order, which makes the indexing 
            // difficult. This page details these loops https://github.com/prometheus1994/scantron-dev/wiki/Student.cs.
            for (int i = 9; i < 29; i += 5)
            {
                if (i < 14)
                {
                    for (int j = 4; j >= 0; j--)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            if (card_lines[i + k][j] > 54)
                            {
                                answer[count, k] = (char)(k + 65);
                            }
                            else
                            {
                                answer[count, k] = ' ';
                            }
                        }

                        count++;
                    }
                }
                else
                {
                    for (int j = 14; j >= 0; j--)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            if (card_lines[i + k][j] > 54)
                            {
                                answer[count, k] = (char)(k + 65);
                            }
                            else
                            {
                                answer[count, k] = ' ';
                            }
                        }

                        count++;
                    }
                }
            }
        }

        // Returns which bubble from a group of three is the darkest. Darkness is given by the scantorn machine on a 
        // scale of 0 to F. If no bubble is clearly the darkest, a dash is returned instead.
        private string GetDarkestBubble(int a, int b, int c)
        {
            if (a > b && a > c)
            {
                return "1";
            }
            if (b > a && b > c)
            {
                return "2";
            }
            if (c > a && c > b)
            {
                return "3";
            }

            return "-";
        }

        // Does the same as the above method, but for five bubbles.
        private string GetDarkestBubble(int a, int b, int c, int d, int e)
        {
            if (a > b && a > c && a> d && a >e)
            {
                return "1";
            }
            if (b > a && b > c && b > d && b > e)
            {
                return "2";
            }
            if (c > a && c > b && c > d && c > e)
            {
                return "3";
            }
            if (d > a && d > b && d > c && d > e)
            {
                return "4";
            }
            if (e > a && e > b && e > c && e > d)
            {
                return "5";
            }

            return "-";
        }

        // Translates the student's data to a string.
        public override string ToString()
        {
            string student_info = "";

            // Row 5
            student_info += wid + ", " + test_version + sheet_number + grant_permission + "--,E, '" + answers[4] + "'\r\n";

            // Rows 4, 3, 2, 1
            for (int i = 3; i >= 0; i--)
            {
                student_info += "         ,      " + ',' + (char)(65 + i) + ", '" + answers[i] + "'\r\n";
            }

            return student_info;
        }
    }
}
