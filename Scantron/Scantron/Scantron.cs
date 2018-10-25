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

        // Event handler for when Reset button is clicked.
        private void uxResetButton_click(object sender, EventArgs e)
        {
            gui.Reset();
        }

        // Event handler for when Start button is clicked.
        private void uxStartButton_Click(object sender, EventArgs e)
        {
            gui.Start();
        }

        // Event handler for when Save Changes button is clicked.
        private void uxSaveChangesButton_Click(object sender, EventArgs e)
        {
            gui.SaveChanges();
        }

        // Event handler for when Create Students button is clicked.
        private void uxCreateStudentsButton_Click(object sender, EventArgs e)
        {
            //gui.CreateStudents();
        }

        // Event handler for hen Test Data button is clicked.
        private void uxTestDataButton_Click(object sender, EventArgs e)
        {
            gui.TestData();
        }

        // Event handler for when Pause button is clicked.
        private void uxPauseButton_Click(object sender, EventArgs e)
        {
            //gui.Pause();
        }

        // Event handler for when Resume button is clicked.
        private void uxResumeButton_Click(object sender, EventArgs e)
        {
            //gui.Resume();
        }

        // Event handler for when Stop button is clicked.
        private void uxStopButton_Click(object sender, EventArgs e)
        {
            gui.Stop();
        }

        // Event handler for when Grade Students button is clicked.
        private void uxGradeStudentsButton_Click(object sender, EventArgs e)
        {
            gui.GradeStudents();
        }

        // Event handler for when Next button is clicked.
        private void uxNextButton_Click(object sender, EventArgs e)
        {
            gui.NextStudent();
        }

        // Event handler for when Previous button is clicked.
        private void uxPreviousButton_Click(object sender, EventArgs e)
        {
            gui.PreviousStudent();
        }

        // Event handler for when Finish button is clicked.
        private void uxFinishButton_Click(object sender, EventArgs e)
        {
            gui.Finish();
        }

        // Event handler for when Scantron Tool Single Answer button is clicked.
        private void uxScantronToolSingleAnswerButton_Click(object sender, EventArgs e)
        {
            gui.WriteFile("single");
        }

        // Event handler for when Scantron Tool Multiple Answer button is clicked.
        private void uxScantronToolMultipleAnswerButton_Click(object sender, EventArgs e)
        {
            gui.WriteFile("multiple");
        }

        private void uxNumberOfVersionsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            gui.UpdateNumberOfVersions();
        }

        private void uxNumberOfQuestionsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            gui.UpdateNumberOfQuestions();
        }

        private void uxStartContinueButton_Click(object sender, EventArgs e)
        {
            gui.StartContinue();
        }

        private void uxAnswerKeyContinueButton_Click(object sender, EventArgs e)
        {
            gui.AnswerKeyContinue();
        }

        private void uxScanContinueButton_Click(object sender, EventArgs e)
        {
            gui.ScanContinue();
        }

        private void uxGradeContinueButton_Click(object sender, EventArgs e)
        {
            gui.GradeContinue();
        }

        private void uxUseScantronCardButton_Click(object sender, EventArgs e)
        {
            gui.UseScantronCard();
        }
    }
}