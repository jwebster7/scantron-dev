/* Authors: Joe Webster, Caleb Schweer, & William McCreight
 * Helpdesk Dev: Scantron
 * 12/21/2017
 */
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
        }



        public override string ToString()
        {
            return (wid + ", " + grant_permission + 1 + test_version + sheet_number + ", '" + answers + "'");
        }
    }
}
