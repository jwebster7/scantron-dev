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

        /// <summary>
        /// Public constructor builds Student objects from the properties of the sheets read in from the Scanner class
        /// </summary>
        /// <param name="wid">The students unique, 9-digit id number</param>
        /// <param name="grant_permission">The student granting permission to post the grades</param>
        /// <param name="test_version">The version of the exam the student took</param>
        /// <param name="sheet_number">The sheet_number; May be insignificant for our needs</param>
        /// <param name="answers">The answers of the exam; Typically, a maximum of 50 answers are on each sheet</param>
        public Student(string wid, char grant_permission, char test_version, char sheet_number, string answers)
        {
            this.wid = wid;
            this.grant_permission = grant_permission;
            this.test_version = test_version;
            this.sheet_number = sheet_number;
            this.answers = answers;
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
