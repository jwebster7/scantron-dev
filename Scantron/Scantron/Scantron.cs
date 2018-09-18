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

        // Event handler for selecting student answers to view.
        private void uxStudentSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            gui.SelectStudent();
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

        private void uxGradebookButton_Click(object sender, EventArgs e)
        {
            gui.WriteFile(true);
        }

        private void uxCreateAnswerKeyButton_Click(object sender, EventArgs e)
        {
            gui.CreateAnswerKey();
        }

        private void uxNoAnswerKeyButton_Click(object sender, EventArgs e)
        {
            gui.NoAnswerKey();
        }

        private void uxResetButton_click(object sender, EventArgs e)
        {
            gui.Reset();
        }

        private void uxStartButton_Click(object sender, EventArgs e)
        {
            gui.Start();
        }

        private void uxSaveChangesButton_Click(object sender, EventArgs e)
        {
            gui.SaveChanges();
        }

        private void uxCreateStudentsButton_Click(object sender, EventArgs e)
        {
            gui.CreateStudents();
        }

        private void uxTestDataButton_Click(object sender, EventArgs e)
        {
            gui.TestData();
        }

        private void uxPauseButton_Click(object sender, EventArgs e)
        {
            gui.Pause();
        }

        private void uxResumeButton_Click(object sender, EventArgs e)
        {
            gui.Resume();
        }

        private void uxStopButton_Click(object sender, EventArgs e)
        {
            gui.Stop();
        }

        private void uxGradeStudentsButton_Click(object sender, EventArgs e)
        {
            gui.GradeStudents();
        }

        private void uxNextButton_Click(object sender, EventArgs e)
        {
            gui.NextStudent();
        }

        private void uxPreviousButton_Click(object sender, EventArgs e)
        {
            gui.PreviousStudent();
        }

        private void uxScantronToolButton_Click(object sender, EventArgs e)
        {
            gui.WriteFile(false);
        }

        private void uxFinishButton_Click(object sender, EventArgs e)
        {
            gui.Finish();
        }
    }
}