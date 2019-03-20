// Scantron.cs
//
// Property of the Kansas State University IT Help Desk
// Written by: William McCreight, Caleb Schweer, and Joseph Webster
// 
// An extensive explanation of the reasoning behind the architecture of this program can be found on the github 
// repository: https://github.com/prometheus1994/scantron-dev/wiki
//
// This class handles control events on the GUI.
// https://github.com/prometheus1994/scantron-dev/wiki/Scantron.cs

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

        /// <summary>
        /// Event handler for selecting students in ComboBox.
        /// </summary>
        private void uxStudentSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            gui.SelectStudent();
        }

        /// <summary>
        /// Event handler for the All Partial Credit CheckBox.
        /// </summary>
        private void uxAllPartialCredit_CheckedChanged(object sender, EventArgs e)
        {
            gui.UpdateAllPartialCredit();
        }

        /// <summary>
        /// Event handler for All Question Points NumericUpDown.
        /// </summary>
        private void uxAllQuestionPoints_ValueChanged(object sender, EventArgs e)
        {
            gui.UpdateAllQuestionPoints();
        }

        /// <summary>
        /// Event handler for Number of Questions NumericUpDown.
        /// </summary>
        private void uxNumberOfQuestions_ValueChanged(object sender, EventArgs e)
        {
            gui.UpdateAnswerForm();
        }

        /// <summary>
        /// Event handler for Number of Versions NumericUpDown.
        /// </summary>
        private void uxNumberOfVersions_ValueChanged(object sender, EventArgs e)
        {
            gui.UpdateAnswerForm();
        }

        /// <summary>
        /// Event handler for when Gradebook button is clicked.
        /// </summary>
        private void uxGradebookButton_Click(object sender, EventArgs e)
        {
            gui.WriteFile("gradebook");
        }

        /// <summary>
        /// Event handler for when Create Answer Key button is clicked.
        /// </summary>
        private void uxCreateAnswerKeyButton_Click(object sender, EventArgs e)
        {
            gui.CreateAnswerKey();
        }

        /// <summary>
        /// Event handler for when Reset button is clicked.
        /// </summary>
        private void uxResetButton_Click(object sender, EventArgs e)
        {
            gui.Reset();
        }

        /// <summary>
        /// Event handler for when Ready button is clicked.
        /// </summary>
        private void uxReadyButton_Click(object sender, EventArgs e)
        {
            gui.Ready();
        }

        /// <summary>
        /// Event handler for when Save Changes button is clicked.
        /// </summary>
        private void uxSaveChangesButton_Click(object sender, EventArgs e)
        {
            gui.SaveChanges();
        }

        /// <summary>
        /// Event handler for hen Test Data button is clicked.
        /// </summary>
        private void uxTestDataButton_Click(object sender, EventArgs e)
        {
            gui.TestData();
        }

        /// <summary>
        /// Event handler for when Done button is clicked.
        /// </summary>
        private void uxDoneButton_Click(object sender, EventArgs e)
        {
            gui.Done();
        }

        /// <summary>
        /// Event handler for when Grade Students button is clicked.
        /// </summary>
        private void uxGradeStudentsButton_Click(object sender, EventArgs e)
        {
            gui.GradeStudents();
        }

        /// <summary>
        /// Event handler for when Next button is clicked.
        /// </summary>
        private void uxNextButton_Click(object sender, EventArgs e)
        {
            gui.NextStudent();
        }

        /// <summary>
        /// Event handler for when Previous button is clicked.
        /// </summary>
        private void uxPreviousButton_Click(object sender, EventArgs e)
        {
            gui.PreviousStudent();
        }

        /// <summary>
        /// Event handler for when Finish button is clicked.
        /// </summary>
        private void uxFinishButton_Click(object sender, EventArgs e)
        {
            gui.Finish();
        }

        /// <summary>
        /// Event handler for when Scantron Tool Single Answer button is clicked.
        /// </summary>
        private void uxScantronToolSingleAnswerButton_Click(object sender, EventArgs e)
        {
            gui.WriteFile("single");
        }

        /// <summary>
        /// Event handler for when Scantron Tool Multiple Answer button is clicked.
        /// </summary>
        private void uxScantronToolMultipleAnswerButton_Click(object sender, EventArgs e)
        {
            gui.WriteFile("multiple");
        }

        /// <summary>
        /// Event handler for when number of test versions is changed.
        /// </summary>
        private void uxNumberOfVersionsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            gui.UpdateNumberOfVersions();
        }

        /// <summary>
        /// Event handler for when numberof questionsis changed.
        /// </summary>
        private void uxNumberOfQuestionsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            gui.UpdateNumberOfQuestions();
        }

        /// <summary>
        /// Event handler for when continue button on Start tab is clicked.
        /// </summary>
        private void uxStartContinueButton_Click(object sender, EventArgs e)
        {
            gui.StartContinue();
        }

        /// <summary>
        /// Event handler for when continue button on Answer Key tab is clicked.
        /// </summary>
        private void uxAnswerKeyContinueButton_Click(object sender, EventArgs e)
        {
            gui.AnswerKeyContinue();
        }

        /// <summary>
        /// Event handler for when continue button on Scan tab is clicked.
        /// </summary>
        private void uxScanContinueButton_Click(object sender, EventArgs e)
        {
            gui.ScanContinue();
        }

        /// <summary>
        /// Event handler for when continue button on Grade tab is clicked.
        /// </summary>
        private void uxGradeContinueButton_Click(object sender, EventArgs e)
        {
            gui.GradeContinue();
        }

        /// <summary>
        /// Event handler for when Use Scantron Card button is clicked.
        /// </summary>
        private void uxScanAnswerKeyButton_Click(object sender, EventArgs e)
        {
            gui.UseScantronCard();
        }

        /// <summary>
        /// Event handler for when Done Scanning button is clicked.
        /// </summary>
        private void uxDoneScanningButton_Click(object sender, EventArgs e)
        {
            gui.DoneScanning();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}