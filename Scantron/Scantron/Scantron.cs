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

        // Event handler for selecting students in ComboBox.
        private void uxStudentSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            gui.SelectStudent();
        }

        // Event handler for the All Partial Credit CheckBox.
        private void uxAllPartialCredit_CheckedChanged(object sender, EventArgs e)
        {
            gui.UpdateAllPartialCredit();
        }

        // Event handler for All Question Points NumericUpDown.
        private void uxAllQuestionPoints_ValueChanged(object sender, EventArgs e)
        {
            gui.UpdateAllQuestionPoints();
        }

        // Event handler for Number of Questions NumericUpDown.
        private void uxNumberOfQuestions_ValueChanged(object sender, EventArgs e)
        {
            gui.UpdateAnswerForm();
        }

        // Event handler for Number of Versions NumericUpDown.
        private void uxNumberOfVersions_ValueChanged(object sender, EventArgs e)
        {
            gui.UpdateAnswerForm();
        }

        // Event handler for when Gradebook button is clicked.
        private void uxGradebookButton_Click(object sender, EventArgs e)
        {
            gui.WriteFile("gradebook");
        }

        // Event handler for when Create Answer Key button is clicked.
        private void uxCreateAnswerKeyButton_Click(object sender, EventArgs e)
        {
            gui.CreateAnswerKey();
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

        private void uxFinishButton_Click(object sender, EventArgs e)
        {
            gui.Finish();
        }

        private void uxScantronToolSingleAnswerButton_Click(object sender, EventArgs e)
        {
            gui.WriteFile("single");
        }

        private void uxScantronToolMultipleAnswerButton_Click(object sender, EventArgs e)
        {
            gui.WriteFile("multiple");
        }
    }
}