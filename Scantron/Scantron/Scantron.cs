// Scantron.cs
//
// Property of the Kansas State University IT Help Desk
// Written by: William McCreight, Caleb Schweer, and Joseph Webster
// 
// An extensive explanation of the reasoning behind the architecture of this program can be found on the github 
// repository: https://github.com/prometheus1994/scantron-dev/wiki
//
// This class handles button click events on the GUI.

using System;
using System.Windows.Forms;

namespace Scantron
{
    public partial class Scantron : Form
    {
        private GUI gui;

        // The default constructor for the scantron GUI.
        public Scantron()
        {
            InitializeComponent();
            gui = new GUI(this);

            for (int i = 0; i < 3; i++)
            {
                TabPage tabpage = uxAnswerKeyTabControl.TabPages[i];
                gui.InstantiateAnswerKeyForm(tabpage);
            }

            gui.InstantiateStudentDisplay();
        }

        // The event handler opens the serial port and begins reading data from the scantron machine.
        private void uxStart_Click(object sender, EventArgs e)
        {
            gui.Start();
        }

        // Event handler for the stop button; closes the serial port; enables the create file button.
        private void uxStop_Click(object sender, EventArgs e)
        {
            gui.Stop();
        }

        // Click event for the 'Restart' button.
        private void uxRestart_Click(object sender, EventArgs e)
        {
            gui.Restart();
        }

        // Event handler for the 'Grade Students' button.
        private void uxGradeStudents_Click(object sender, EventArgs e)
        {
            gui.GradeStudents();
        }

        // Event handler for selecting student answers to view.
        private void uxStudentSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            gui.SelectStudent();
        }

        private void uxNextStudent_Click(object sender, EventArgs e)
        {
            gui.NextStudent();
        }

        private void uxPreviousStudent_Click(object sender, EventArgs e)
        {
            gui.PreviousStudent();
        }

        private void uxAllPartialCredit_CheckedChanged(object sender, EventArgs e)
        {
            gui.UpdateAllPartialCredit();
        }

        private void uxAllQuestionPoints_ValueChanged(object sender, EventArgs e)
        {
            gui.UpdateAllQuestionPoints();
        }

        private void uxNumberOfQuestions_ValueChanged(object sender, EventArgs e)
        {
            gui.UpdateAnswerForm();
        }

        private void uxNumberOfVersions_ValueChanged(object sender, EventArgs e)
        {
            gui.UpdateAnswerForm();
        }

        private void uxSaveChanges_Click(object sender, EventArgs e)
        {
            gui.SaveChanges();
        }

        private void uxTestData_Click(object sender, EventArgs e)
        {
            gui.TestData();
        }

        private void uxCreateAnswerKey_Click(object sender, EventArgs e)
        {
            gui.CreateAnswerKey();
        }

        private void uxCreateStudents_Click(object sender, EventArgs e)
        {
            gui.CreateStudents();
        }

        private void uxPause_Click(object sender, EventArgs e)
        {

        }

        private void uxResume_Click(object sender, EventArgs e)
        {

        }
    }
}