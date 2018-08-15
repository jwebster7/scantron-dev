// GUI.cs
//
// Property of the Kansas State University IT Help Desk
// Written by: William McCreight, Caleb Schweer, and Joseph Webster
// 
// An extensive explanation of the reasoning behind the architecture of this program can be found on the github 
// repository: https://github.com/prometheus1994/scantron-dev/wiki
//
// This class handles GUI changing methods.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Scantron
{
    public class GUI
    {
        private Grader grader;

        // GUI objects that we need data from.
        private Form scantron_form;
        private Label uxScanInstructionLabel;
        private Label uxGradeInstructionLabel;
        private Panel uxStudentResponsePanel;
        private ComboBox uxStudentSelector;
        private TabControl uxAnswerKeyTabControl;
        private TextBox uxExamName;
        private NumericUpDown uxNumberOfQuestions;
        private NumericUpDown uxNumberOfVersions;
        private NumericUpDown uxAllQuestionPoints;
        private CheckBox uxAllPartialCredit;
        private Button uxPreviousStudent;
        private Button uxNextStudent;
        private Label uxVersionLabel;
        private Label uxScoreLabel;
        private Label uxCouldNotBeGradedLabel;
        private Panel uxStudentList;
        // Holds the raw card data from the Scantron.
        private List<string> raw_cards;
        private bool toAbort = true;

        Task<List<string>> cr;

        private ScannerCom scannerCom;

        public GUI(Form scantron_form)
        {
            raw_cards = new List<string>();
            //// Test Data. Has two students for a 150 question exam. One has blank answers.
            raw_cards.Add("b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0E#R0#\\Fb#T0#\\Fa000D#P0#\\Fb#T0#\\Fa00C#Q0#\\Fb#T0#\\Fa#D0D#O0#\\Fb#T0#\\Fa#F0E#M0#\\Fb#T0#\\Fa#I0D#J0#\\Fb#T0#\\FaD#S0#\\Fb#T0#\\Fa#I0C#J0#\\Fa#I0C#J0#\\Fb#T0#\\Fb#T0#\\Fa#D0E#E0E#I0#\\Fb#T0#\\Fa000F000F#L0#\\Fb#T0#\\Fa00F#J0E#F0#\\Fb#T0#\\Fa0D#R0#\\FaD#S0#\\Fb#T0#\\Fb#T0#\\Fa#D0D#D0F#D0C#E0#\\Fb#T0#\\Fa000F#D0F#D0E#F0#\\Fb#T0#\\Fa00E#D0F#D0E#G0#\\Fb#T0#\\Fa0E#D0F#D0C#H0#\\FaE#D0D#D0F#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0E#D0F#D0B#E0#\\Fb#T0#\\Fa000D#D0E#D0D#F0#\\Fb#T0#\\Fa00D#D0F#D0E#G0#\\Fb#T0#\\Fa0D#D0F#D0F#H0#\\FaD#D0F#D0F#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0E#D0E#D0E#E0#\\Fb#T0#\\Fa000F#D0F#D0E#F0#\\Fb#T0#\\Fa00E#D0F#D0E0005000#\\Fb#T0#\\Fa0E#D0E#D0D#D06000#\\FaE#D0E#D0D#I0#\\F$");
            raw_cards.Add("b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0F#R0#\\Fb#T0#\\Fa000F#P0#\\Fb#T0#\\Fa00E#Q0#\\Fb#T0#\\Fa#D0E#O0#\\Fb#T0#\\Fa#F0F#M0#\\Fb#T0#\\Fa#I0E#J0#\\Fb#T0#\\FaE#S0#\\Fb#T0#\\Fa#I0E#J0#\\Fa#I0E#J0#\\Fb#T0#\\FaD0F0F#E0F#I0#\\Fb#T0#\\Fa000E#P0#\\Fb#T0#\\Fa0F#E0F#E0E#F0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa00D#G0F00D#F0#\\Fb#T0#\\FaD#D0C0F0E0D#H0#\\Fb#T0#\\Fa0D0D#D0E#K0#\\Fb#T0#\\Fb#T0#\\Fb#T0#\\Fa#F0F#G0D#E0#\\Fa#D0D#G0E#G0#\\Fb#T0#\\Fb#T0#\\Fa0F#G0D#J0#\\Fb#T0#\\Fa#G0E#L0#\\Fb#T0#\\Fa#E0F#F0C0C#E0#\\Fb#T0#\\Fa#D0F0C0D0D00C#F0#\\FaF0EF#G0C#H0#\\Fb#T0#\\Fb#T0#\\FaE#F0E#H07000#\\Fb#T0#\\Fa0C#D0D0D#E0C#E0#\\Fb#T0#\\Fa00D00C000D00F#G0#\\Fb#T0#\\Fa#D0C#E0E#I0#\\Fa000C#G0E0E004000#\\F$");
            raw_cards.Add("b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0F#R0#\\Fb#T0#\\Fa000E#P0#\\Fb#T0#\\Fa00E#Q0#\\Fb#T0#\\Fa#D0E#O0#\\Fb#T0#\\Fa#F0D#M0#\\Fb#T0#\\Fa#I0D#J0#\\Fb#T0#\\FaD#S0#\\Fb#T0#\\Fa#I0E#J0#\\Fa#I0D#J0#\\Fb#T0#\\Fb#T0#\\FaFBFFF00F00E#I0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#M0F#F0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#J0EEEFE#E0#\\Fb#T0#\\Fa#E0DFFFD#J0#\\Fb#T0#\\FaEEDEE#O0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#E0FFFEF#J0#\\Fb#T0#\\FaFFFDE#O0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#J0FEEFF#E0#\\Fb#T0#\\Fb#T0#\\Fa#P07000#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#J0DDFFC03000#\\Fb#T0#\\Fa#E0FFDFD#J0#\\FaF#DE#O0#\\F$");
            raw_cards.Add("b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0E#R0#\\Fb#T0#\\Fa00E#Q0#\\Fb#T0#\\Fa#F0E#M0#\\Fb#T0#\\Fa000D#P0#\\Fb#T0#\\Fa#E0F#N0#\\Fb#T0#\\FaB#S0#\\Fb#T0#\\Fa#G0F#L0#\\Fb#T0#\\Fa#I0D#J0#\\Fa#H0D#K0#\\Fb#T0#\\Fb#T0#\\Fa#G0E#L0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#J0F00F#F0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#Q0300#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#S03#\\F$");
            raw_cards.Add("b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0E#R0#\\Fb#T0#\\Fa00D#Q0#\\Fb#T0#\\Fa#F0E#M0#\\Fb#T0#\\Fa000D#P0#\\Fb#T0#\\Fa#E0D#N0#\\Fb#T0#\\FaB#S0#\\Fb#T0#\\Fa#G0F#L0#\\Fb#T0#\\Fa#I0E#J0#\\Fa#H0E#K0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#G0F00F00F#F0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\F$");
            raw_cards.Add("b0F00F0FF#F0#DF00#\\Fb#T0#\\Fa0F00F0FF#F0#DF00#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa0D#R0#\\Fb#T0#\\Fa00C#Q0#\\Fb#T0#\\Fa#F0F#M0#\\Fb#T0#\\Fa000D#P0#\\Fb#T0#\\Fa#E0F#N0#\\Fb#T0#\\FaD#S0#\\Fb#T0#\\Fa#G0E#L0#\\Fb#T0#\\Fa#I0D#J0#\\Fa#H0D#K0#\\Fb#T0#\\Fb#T0#\\Fa#G05#L0#\\Fb#T0#\\Fa#G0F#L0#\\Fb#T0#\\Fa#J0F00F#F0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\Fb#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#T0#\\Fb#T0#\\Fa#Q0300#\\Fb#T0#\\Fa#T0#\\Fa#T0#\\F$");

            this.scantron_form = scantron_form;
            scannerCom = new ScannerCom();
           
            uxScanInstructionLabel = (Label) scantron_form.Controls.Find("uxScanInstructionLabel", true)[0];
            uxGradeInstructionLabel = (Label) scantron_form.Controls.Find("uxGradeInstructionLabel", true)[0];
            uxStudentResponsePanel = (Panel) scantron_form.Controls.Find("uxStudentResponsePanel", true)[0];
            uxStudentSelector = (ComboBox) scantron_form.Controls.Find("uxStudentSelector",true)[0];
            uxAnswerKeyTabControl = (TabControl) scantron_form.Controls.Find("uxAnswerKeyTabControl", true)[0];
            uxExamName = (TextBox) scantron_form.Controls.Find("uxExamName", true)[0];
            uxNumberOfQuestions = (NumericUpDown)scantron_form.Controls.Find("uxNumberOfQuestions", true)[0];
            uxNumberOfVersions = (NumericUpDown) scantron_form.Controls.Find("uxNumberOfVersions", true)[0];
            uxAllQuestionPoints = (NumericUpDown) scantron_form.Controls.Find("uxAllQuestionPoints", true)[0];
            uxAllPartialCredit = (CheckBox) scantron_form.Controls.Find("uxAllPartialCredit", true)[0];
            uxPreviousStudent = (Button) scantron_form.Controls.Find("uxPreviousStudent", true)[0];
            uxNextStudent = (Button) scantron_form.Controls.Find("uxNextStudent", true)[0];
            uxVersionLabel = (Label) scantron_form.Controls.Find("uxVersionLabel", true)[0];
            uxScoreLabel = (Label) scantron_form.Controls.Find("uxScoreLabel", true)[0];
            uxCouldNotBeGradedLabel = (Label) scantron_form.Controls.Find("uxCouldNotBeGradedLabel", true)[0];
            uxStudentList = (Panel) scantron_form.Controls.Find("uxStudentList", true)[0];

            uxScanInstructionLabel.Text =   "You may click Restart at any time to start at the beginning of these instructions." + Environment.NewLine + Environment.NewLine +
                                            "Scan tab instructions: " +  Environment.NewLine + Environment.NewLine +
                                            "1. Load the Scantron hopper and use the guider to make sure they are straight." + Environment.NewLine +
                                            "2. Click Start within this Window." + Environment.NewLine +
                                            "3. After your cards have finished scanning, click the Grade tab.";

            uxGradeInstructionLabel.Text =  "Grade tab instructions: " + Environment.NewLine + Environment.NewLine +
                                            "1. Specify the number of questions and versions the exam has and give it a name." + Environment.NewLine +
                                            "2. Fill in the answer key for each version with the check boxes and specify their points and if they are worth partial credit for multiple answer questions." + Environment.NewLine +
                                            "3. Click Grade Students and name the .csv file you will upload to your course's gradebook. You may review each student's response in the window on the right.";

            grader = new Grader(this);
        }

        /// <summary>
        /// Displays messages via Message Box.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }

        /// <summary>
        /// Opens the serial port; begins scanning the cards. The most common exceptions with serial ports are handled. 
        /// Ref: https://msdn.microsoft.com/en-us/library/system.io.ports.serialport.open(v=vs.110).aspx
        /// </summary>
        public void Start()
        {

            ScannerCom.ToAbort.Set();
            scannerCom.Start();

            cr = new Task<List<string>>(() => scannerCom.Run(raw_cards));
            cr.Start();
            //grader.CreateStudents(cr.Result);
        }

        /// <summary>
        /// Close the serial port and create list of students from scanned in data.
        /// </summary>
        public void Stop()
        {

            //The following code should be moved to a place where it 
            //should be executed automaticly
            //***************************************

            raw_cards.AddRange(cr.Result);
            grader.CreateStudents(raw_cards);

            // May need to check if it's null
            if (grader.PartialWids.Count > 0)
            {
                DisplayMessage(grader.GetBrokenWids());
            }

            UpdateStudentList();
        }

        /// <summary>
        /// Pauses the scanning
        /// </summary>
        public void Pause()
        {
            // The logic to Abort is below
            // toAbort is a bool to make the Stop button toggle
            if (toAbort)
            {
                ScannerCom.ToAbort.Reset(); //Aborts & Stops
                toAbort = false;
            }
            else
            {
                ScannerCom.ToAbort.Set(); // Does NOT Abort & Stop
                toAbort = true;
            }

            //ScannerCom.ToAbort.Reset();
        }

        /// <summary>
        /// Reset all fields to initial states.
        /// </summary>
        public void Restart()
        {
            raw_cards.Clear();
            grader.Cards.Clear();
            grader.Students.Clear();
            grader.PartialWids.Clear();
        }

        private static void ThreadAbort()
        {
            //This is an empty method for the dummy thread
        }


        private void UpdateStudentList()
        {
            for (int i = 0; i < grader.Students.Count; i++)
            {
                Panel student_panel = new Panel
                {
                    BackColor = Color.LightGray,
                    Location = new Point(3, 3 + 29 * i),
                    Size = new Size(270, 25)
                };

                Label wid_label = new Label
                {
                    Font = new Font("Microsoft Sans Serif", 8),
                    Location = new Point(3, 6),
                    Text = "WID:",
                    Width = 32
                };

                TextBox wid_textbox = new TextBox
                {
                    Font = new Font("Microsoft Sans Serif", 8),
                    Location = new Point(35, 3),
                    MaxLength = 9,
                    Text = grader.Students[i].WID,
                    Width = 65
                };

                Label version_label = new Label
                {
                    Font = new Font("Microsoft Sans Serif", 8),
                    Location = new Point(105, 6),
                    Text = "Version:",
                    Width = 45
                };

                NumericUpDown version_updown = new NumericUpDown
                {
                    Font = new Font("Microsoft Sans Serif", 8),
                    Location = new Point(150, 3),
                    Maximum = 3,
                    Minimum = 1,
                    Value = grader.Students[i].TestVersion,
                    Width = 30
                };

                Label card_label = new Label
                {
                    Font = new Font("MicrosoftSans Serif", 8),
                    Location = new Point(185, 6),
                    Text = "Cards: " + grader.Students[i].Cards.Count,
                    Width = 50
                };

                CheckBox checkbox = new CheckBox
                {
                    Location = new Point(250, 1)
                };
                
                student_panel.Controls.Add(wid_label); // index 0
                student_panel.Controls.Add(wid_textbox); // index 1
                student_panel.Controls.Add(version_label); // index 2
                student_panel.Controls.Add(version_updown); // index 3
                student_panel.Controls.Add(card_label); // index 4
                student_panel.Controls.Add(checkbox); // index 5
                uxStudentList.Controls.Add(student_panel);
            }
        }

        public void SaveChanges()
        {
            TextBox wid_textbox;
            NumericUpDown version_updown;

            for (int i = 0; i < uxStudentList.Controls.Count; i++)
            {
                wid_textbox = (TextBox) uxStudentList.Controls[i].Controls[1];
                // previously had
                // grader.Students[i].WID = wid_textbox.Text;
                // I think it should be: 
                wid_textbox.Text = grader.Students[i].WID;

                version_updown = (NumericUpDown)uxStudentList.Controls[i].Controls[3];
                // previously had
                // grader.Students[i].TestVersion = (int) version_updown.Value;
                // I think it should be:
                version_updown.Value = grader.Students[i].TestVersion;
            }

            UpdateStudentList();
        }

        /// <summary>
        /// Create the answer key form with the specified number of questions and versions.
        /// </summary>
        public void UpdateAnswerForm()
        {
            CheckBox checkbox;

            foreach (TabPage tabpage in uxAnswerKeyTabControl.TabPages)
            {
                foreach (Panel panel in tabpage.Controls)
                {
                    panel.Visible = false;
                    
                    for (int i = 0; i < 5; i++)
                    {
                        checkbox = (CheckBox) panel.Controls[i];
                        checkbox.Checked = false;
                    }
                }
            }

            uxAllQuestionPoints.Value = 1;
            uxAllPartialCredit.Checked = false;

            int number_of_versions = (int) uxNumberOfVersions.Value;
            int number_of_questions = (int) uxNumberOfQuestions.Value;

            TabPage answer_key_tabpage;

            for (int i = 0; i < number_of_versions; i++)
            {
                answer_key_tabpage = uxAnswerKeyTabControl.TabPages[i];

                for (int j = 0; j < number_of_questions; j++)
                {
                    answer_key_tabpage.Controls[j].Visible = true;
                }
            }
        }

        /// <summary>
        /// Updates points for all questions in the exam.
        /// </summary>
        public void UpdateAllQuestionPoints()
        {
            foreach (TabPage tabpage in uxAnswerKeyTabControl.TabPages)
            {
                foreach (Control control in tabpage.Controls)
                {
                    NumericUpDown updown = (NumericUpDown)control.Controls[5];
                    updown.Value = uxAllQuestionPoints.Value;
                }
            }
        }

        /// <summary>
        /// Updates partial credit for all questions in the exam.
        /// </summary>
        public void UpdateAllPartialCredit()
        {
            foreach (TabPage tabpage in uxAnswerKeyTabControl.TabPages)
            {
                foreach (Control control in tabpage.Controls)
                {
                    CheckBox checkbox = (CheckBox)control.Controls[6];
                    checkbox.Checked = uxAllPartialCredit.Checked;
                }
            }
        }

        /// <summary>
        /// Create the answer key form to be filled out by the instructor.
        /// </summary>
        /// <param name="tabpage">Current version being created.</param>
        public void InstantiateAnswerKeyForm(TabPage tabpage)
        {
            for (int j = 0; j < 250; j++)
            {
                Panel question_panel = new Panel
                {
                    BackColor = Color.MediumPurple,
                    Location = new Point(3, 3 + 26 * j),
                    Size = new Size(420, 22),
                    Visible = false
                };

                for (int k = 0; k < 5; k++)
                {
                    CheckBox checkbox = new CheckBox
                    {
                        Location = new Point(73 + 39 * k, 3),
                        Size = new Size(33, 17),
                        Text = ((char)(k + 65)).ToString()
                    };
                    question_panel.Controls.Add(checkbox); // Checkboxes are added first so they are indices 0-4.
                }

                NumericUpDown points_updown = new NumericUpDown
                {
                    Location = new Point(268, 1),
                    DecimalPlaces = 2,
                    Size = new Size(58, 20),
                    Value = 1
                };

                CheckBox partial_credit_checkbox = new CheckBox
                {
                    Location = new Point(330, 3),
                    Size = new Size(100, 17),
                    Text = "Partial Credit"
                };

                Label question_label = new Label
                {
                    Location = new Point(3, 3),
                    Size = new Size(70, 13),
                    Text = "Question " + (j + 1)
                };

                question_panel.Controls.Add(points_updown); // Index 5
                question_panel.Controls.Add(partial_credit_checkbox); // Index 6
                question_panel.Controls.Add(question_label); // Index 7

                tabpage.Controls.Add(question_panel);
            }
        }

        /// <summary>
        /// Create the answer key from the filled out form.
        /// </summary>
        /// <returns>True if successful.</returns>
        public bool CreateAnswerKey()
        {
            int number_of_versions = (int)uxNumberOfVersions.Value;
            int number_of_questions = (int)uxNumberOfQuestions.Value;

            if (number_of_versions == 0 || number_of_questions == 0)
            {
                DisplayMessage("You have not created an answer key. Select the number of questions and versions" +
                                ", then fill out the answer key form.");
                return false;
            }

            grader.AnswerKey = new Dictionary<int, List<Question>>();

            Panel question_panel;
            CheckBox checkbox;
            NumericUpDown points_updown;

            char[] answer = new char[5];
            float points = 0;
            bool partial_credit = false;

            for (int i = 0; i < number_of_versions; i++)
            {
                grader.AnswerKey.Add(i, new List<Question>());
                
                for (int j = 0; j < number_of_questions; j++)
                {
                    answer = new char[5];

                    question_panel = (Panel) uxAnswerKeyTabControl.TabPages[i].Controls[j];

                    // This loop cycles through the first 5 controls in the current question panel, which are the checkboes for A-E.
                    for (int k = 0; k < 5; k++)
                    {
                        checkbox = (CheckBox) question_panel.Controls[k];
                        if (checkbox.Checked)
                        {
                            answer[k] = (char)(65 + k);
                        }
                        else
                        {
                            answer[k] = ' ';
                        }
                    }
                    
                    points_updown = (NumericUpDown) question_panel.Controls[5];
                    points = (float) points_updown.Value;
                    
                    // Checks the current question panel's partial credit checkbox.
                    checkbox = (CheckBox) question_panel.Controls[6];
                    if (checkbox.Checked)
                    {
                        partial_credit = true;
                    }
                    else
                    {
                        partial_credit = false;
                    }
                    
                    grader.AnswerKey[i].Add(new Question(answer, points, partial_credit));
                }
            }

            return true;
        }

        /// <summary>
        /// Grade the students.
        /// </summary>
        public void GradeStudents()
        {
            if (grader.Students.Count == 0)
            {
                DisplayMessage("You have not scanned in the student responses. Go back to the Scan tab"
                                + " and follow the instructions.");
                return;
            }

            if (uxExamName.Text == "")
            {
                DisplayMessage("Enter a name for the exam.");
                return;
            }

            if (!CreateAnswerKey())
            {
                return;
            }

            if (grader.GradeStudents(uxExamName.Text))
            {
                WriteFile();

                uxStudentSelector.Items.Clear();
                foreach (Student student in grader.Students)
                {
                    uxStudentSelector.Items.Add(student.WID);
                }

                // Displays the first student in the index
                NextStudent();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Write the file to be uploaded to the Canvas gradebook.
        /// </summary>
        private void WriteFile()
        {
            string file = grader.ToString();

            // Then we have to start a file dialog to save the string to a file.
            SaveFileDialog uxSaveFileDialog = new SaveFileDialog
            {
                // Could be used to select the default directory ex. "C:\Users\Public\Desktop".
                InitialDirectory = "c:\\desktop",
                // Filter is the default file extensions seen by the user.
                Filter = "csv files (*.csv)|*.csv",
                // FilterIndex sets what the user initially sees ex: 2nd index of the filter is ".txt".
                FilterIndex = 1
            };

            if (uxSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = uxSaveFileDialog.FileName;
                // Stores the location of the file we want to save; use filenames for multiple.
                if (path.Equals(""))
                {
                    MessageBox.Show("You must enter a filename and select" + Environment.NewLine +
                                    "a file path for the exam record!");
                    throw new IOException();
                }
                else
                {
                    // "using" opens and close the StreamWriter.
                    using (StreamWriter file_generator = new StreamWriter(path))
                    {
                        // Adds everything in the 'file' given to the streamwriter.
                        file_generator.Write(file);
                    }
                    MessageBox.Show("Student responses have been successfully recorded!\n" +
                                    "You may now upload the student responses to Canvas\n" +
                                    "using the file generated.");
                }
            }
            else
            {
                MessageBox.Show("An error occured while trying to save,\n" +
                                "The format for filenames should not include\n" +
                                "slashes, parentheticals, or symbols\n" +
                                "Please reload the hopper and ensure the\n" +
                                "cards are not stuck together, backwards,\n" +
                                "or reversed. ");
                throw new IOException();
            }
        }

        /// <summary>
        /// Populates the student answer panel with question panels that show the selected student's response.
        /// </summary>
        public void SelectStudent()
        {
            DisplayStudent(grader.Students.Find(item => item.WID == uxStudentSelector.Text));
        }

        /// <summary>
        /// Displays the next student's responses in the uxStudentResponsePanel.
        /// </summary>
        public void NextStudent()
        {
            string wid = (string)uxStudentSelector.Items[uxStudentSelector.SelectedIndex + 1];
            uxStudentSelector.SelectedItem = wid;
        }

        /// <summary>
        /// Displays the previous student's responses in the uxStudentResponsePanel.
        /// </summary>
        public void PreviousStudent()
        {
            string wid = (string)uxStudentSelector.Items[uxStudentSelector.SelectedIndex - 1];
            uxStudentSelector.SelectedItem = wid;
        }

        /// <summary>
        /// 
        /// </summary>
        public void InstantiateStudentDisplay()
        {
            for (int i = 0; i < 250; i++)
            {
                Panel question_panel = new Panel
                {
                    Location = new Point(3, 3 + 26 * i),
                    Size = new Size(350, 22),
                    Visible = false
                };

                for (int j = 0; j < 5; j++)
                {
                    CheckBox checkbox = new CheckBox
                    {
                        Enabled = false,
                        Location = new Point(73 + 39 * j, 3),
                        Size = new Size(33, 17),
                        Text = ((char)(j + 65)).ToString()
                    };

                    question_panel.Controls.Add(checkbox); // Checkboxes are added first so their indices are 0-4.
                }

                Label points_label = new Label
                {
                    Location = new Point(268, 3),
                    Size = new Size(80, 13),
                    Text = "Points: 0"
                };

                Label question_label = new Label
                {
                    Location = new Point(3, 3),
                    Size = new Size(70, 13),
                    Text = "Question " + (i + 1)
                };

                question_panel.Controls.Add(points_label); // Index 5
                question_panel.Controls.Add(question_label); // Index 6

                uxStudentResponsePanel.Controls.Add(question_panel);
            }
        }

        /// <summary>
        /// Display the selected student's response in uxStudentResponsePanel.
        /// </summary>
        /// <param name="student">Selected student.</param>
        private void DisplayStudent(Student student)
        {
            if (uxStudentSelector.SelectedIndex == 0)
            {
                uxPreviousStudent.Enabled = false;
            }
            else
            {
                uxPreviousStudent.Enabled = true;
            }

            if (uxStudentSelector.SelectedIndex == uxStudentSelector.Items.Count -1)
            {
                uxNextStudent.Enabled = false;
            }
            else
            {
                uxNextStudent.Enabled = true;
            }

            int test_version = student.TestVersion;
            uxVersionLabel.Text = "Version: " + test_version;
            uxScoreLabel.Text = "Score: " + student.Score();
            uxCouldNotBeGradedLabel.Visible = false;
            Panel question_panel;
            CheckBox response_checkbox;
            CheckBox answer_key_checkbox;

            foreach (Control control in uxStudentResponsePanel.Controls)
            {
                control.Visible = false;
            }

            if (test_version > grader.AnswerKey.Keys.Count)
            {
                uxCouldNotBeGradedLabel.Visible = true;

                return;
            }

            if(grader.AnswerKey[0].Count > student.Response.Count)
            {
                uxCouldNotBeGradedLabel.Visible = true;
            }

            for (int i = 0; i < Math.Min(grader.AnswerKey[test_version - 1].Count, student.Response.Count); i++)
            {
                question_panel = (Panel)uxStudentResponsePanel.Controls[i];
                question_panel.Visible = true;

                if (student.Response[i].Points == grader.AnswerKey[test_version - 1][i].Points)
                {
                    question_panel.BackColor = Color.DarkGreen;
                }
                else if(student.Response[i].Points == 0)
                {
                    question_panel.BackColor = Color.Red;
                }
                else
                {
                    question_panel.BackColor = Color.Cyan;
                }

                for (int j = 0; j < 5; j++)
                {
                    response_checkbox = (CheckBox)question_panel.Controls[j];
                    answer_key_checkbox = (CheckBox)uxAnswerKeyTabControl.TabPages[test_version - 1].Controls[i].Controls[j];

                    if (student.Response[i].Answer[j] == ' ')
                    {
                        response_checkbox.Checked = false;
                    }
                    else
                    {
                        response_checkbox.Checked = true;
                    }
                }

                question_panel.Controls[5].Text = "Points: " + student.Response[i].Points.ToString("0.00");
            }
        }
    }
}
