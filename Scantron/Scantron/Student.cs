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
        /// <summary>
        /// Student WID, stores the wildcat ID number
        /// </summary>
        public string wid;

        /// <summary>
        /// Grant permission should only be 1 of 2 values
        /// </summary>
        public char grant_permission;

        /// <summary>
        /// Test_version should only be 1 of 3 values for each Student
        /// </summary>
        public char test_version;

        /// <summary>
        /// Sheet number; could be insignificant for our needs, but included anyways
        /// </summary>
        public char sheet_number;

        /// <summary>
        /// Answers is an unsigned integer for storing the 
        /// </summary>
        public string answers;

        public Student(List<string> cards)
        {

        }


        /// <summary>
        /// This function conversts the info of student into a string with the correct format
        /// </summary>
        /// <returns>Formatted as " wid, grant_permission + test_version + sheet_number, 'answers' "</returns>
        public override string ToString()
        {
            return (wid + ", " + grant_permission + 1 + test_version + sheet_number + ", '" + answers + "'");
        }
    }
}
