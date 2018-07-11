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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks; //Requires .Net 4
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace Scantron
{
    class GUI
    {
        private SerialPort serial_port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        //private string raw_scantron_output;
        private string raw_scantron_output = "b3F33F0FF#F0#DF00#\\Fb033#Q0#\\Fa3F00F0FF#F0#DF00#\\Fb0033#P0#\\Fa3#S0#\\Fb0003#P0#\\Fa4F#H05#I0#[FEb3#S0#\\Fa4#G0F08#I0#\\Fb#T0#\\Fa33000F00034#I0#\\Fb#T0#\\Fa3303F#E05#I0#\\Fb#T0#\\Fa333000E003#J0#\\Fb#T0#\\Fa30F#F037#I0#\\Fb#T0#\\Fa300F#F07#I0#\\Fb#T0#\\Fa3#H0F4#I0#\\FaF#H047#I0#\\Fb#T0#\\Fa4334F00F#L0#\\Fb#T0#\\Fa433F#P0#\\Fb#T0#\\Fa33F#G0F00F#F0#\\Fb#T0#\\Fb#T0#\\Fa3D00F#O0#\\FaF3003#O0#\\Fb#T0#\\Fb#T0#\\Fa3000F#D0E#D0E#E0#\\Fb#T0#\\Fa300F#D0F#D0E#F0#\\Fb#T0#\\Fa30F#D0F#D0F#G0#\\Fb#T0#\\Fa0E#D0F#D0F#H0#\\FaF#D0F#D0F#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0F#D0E#D0E#E0#\\Fb#T0#\\Fa000F#D0F#D0F#F0#\\Fb#T0#\\Fa00C#D0F#D0F#G0#\\Fb#T0#\\Fa0E#D0F#D0F#H0#\\FaF#D0F#D0F#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0D#D0F#D0F#E0#\\Fb#T0#\\Fa000F#D0F#D0F#F0#\\Fb#T0#\\Fa30F#D0F#D0F#G0#\\Fb#S05#\\Fa0D#D0F#D0F#H0#\\FaE#D0D#D0E#H06#\\F$";
        private Form scantron_form;
        private Panel uxMainPanel;
        private TextBox uxInstructionBox;
        private ComboBox uxStudentSelector;
        private Panel uxAnswerKeyPanel;
        private List<Control> question_panels = new List<Control>();

        private Grader grader = new Grader();

        public GUI(Form scantron_form)
        {
            this.scantron_form = scantron_form;

            uxMainPanel = (Panel) scantron_form.Controls["uxMainPanel"];
            uxInstructionBox = (TextBox) uxMainPanel.Controls["uxInstructionBox"];
            uxStudentSelector = (ComboBox) scantron_form.Controls["uxStudentSelector"];
            uxAnswerKeyPanel = (Panel) scantron_form.Controls["uxAnswerKeyPanel"];

            foreach (Control control in uxAnswerKeyPanel.Controls)
            {
                question_panels.Add(control);
            }

            uxInstructionBox.Text = "Please load the hopper of the Scantron," + Environment.NewLine +
                                    "then click on 'Start' within this window.";
        }

        public void Start()
        {
            try
            {
                uxInstructionBox.Text = "Now press Start on the Machine to begin scanning." + Environment.NewLine +
                                        "Once all the cards have successfully scanned, " + Environment.NewLine +
                                        "press the 'Stop' within this window.";
                raw_scantron_output = "";
                serial_port.Open();
                serial_port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
            }
            // SystemException is the superclass containing IOException and InvalidOperationException
            catch (SystemException)
            {
                // Do nothing. This is to prevent an error message about the port already being open if a user has to rescan cards.
            }
        }

        // This method is an event handler for the serialport.
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Sets serial_port to the event object value.
            serial_port = (SerialPort)sender;
            // Appends the values from the scantron machine into the raw_scantron_ouput.
            raw_scantron_output += serial_port.ReadExisting();
        }

        public void Stop()
        {
            serial_port.Close();
            grader.CreateStudents(raw_scantron_output);

            // If no students were created, (this should already be taken care of in the Stop event handler), 
            // we want to set the state back to the start button and start over.
            if (grader.Students.Count == 0)
            {
                uxInstructionBox.Text = "Please load the hopper of the Scantron," + Environment.NewLine +
                                        "then click on 'Start' within this window.";

                MessageBox.Show("Something went wrong when scanning the cards." + Environment.NewLine +
                                Environment.NewLine +
                                "Please ensure the cards are not stuck together," + Environment.NewLine +
                                "backwards, or reversed and reload the hopper.");
            }

            // We cannot create students if raw_scantron_output is empty.
            // Sets the program to initial state of the program.
            if (raw_scantron_output.Equals(""))
            {
                uxInstructionBox.Text = "Please load the hopper of the Scantron," + Environment.NewLine +
                                        "then click on 'Start' within this window.";

                MessageBox.Show("Something went wrong when scanning the cards." + Environment.NewLine +
                                Environment.NewLine +
                                "Please ensure the cards are not stuck together," + Environment.NewLine +
                                "backwards, or reversed and reload the hopper.");
            }
            else
            {
                uxInstructionBox.Text = "Please insert a USB drive into the computer" + Environment.NewLine +
                                        "Then press 'Create File' to create and save" + Environment.NewLine +
                                        "a file onto the USB drive";
            }
        }

        public void Restart()
        {
            uxInstructionBox.Text = "Please load the hopper of the Scantron," + Environment.NewLine +
                                    "then click on 'Start' within this window.";
        }

        public void Enter()
        {
            TextBox uxNumberOfQuestions = (TextBox)scantron_form.Controls["uxNumberOfQuestions"];

            int number_of_questions = Convert.ToInt32(uxNumberOfQuestions.Text);

            if (number_of_questions <= 150 && number_of_questions > 0)
            {
                uxAnswerKeyPanel.Controls.Clear();

                for (int i = 0; i < number_of_questions; i++)
                {
                    Panel panel = new Panel
                    {
                        BackColor = Color.MediumPurple,
                        Location = new Point(3, 3 + 26 * i),
                        Size = new Size(420, 22)
                    };

                    for (int j = 0; j < 5; j++)
                    {
                        CheckBox checkbox = new CheckBox
                        {
                            Location = new Point(73 + 39 * j, 3),
                            Size = new Size(33, 17),
                            Text = ((char)(j + 65)).ToString()
                        };
                        panel.Controls.Add(checkbox); // Checkboxes are added first so they are indices 0-4.
                    }

                    NumericUpDown updown = new NumericUpDown
                    {
                        Location = new Point(268, 1),
                        Minimum = 1,
                        DecimalPlaces = 2,
                        Size = new Size(58, 20)
                    };

                    CheckBox partial_credit = new CheckBox
                    {
                        Location = new Point(330, 3),
                        Size = new Size(100, 17),
                        Text = "Partial Credit"
                    };

                    Label label = new Label
                    {
                        Location = new Point(3, 3),
                        Size = new Size(70, 13),
                        Text = "Question" + (i + 1)
                    };

                    panel.Controls.Add(updown); // Index 5
                    panel.Controls.Add(partial_credit); // Index 6
                    panel.Controls.Add(label); // Index 7

                    uxAnswerKeyPanel.Controls.Add(panel);
                }
            }
            else
            {
                MessageBox.Show("Enter a number from 1-150.");
            }
        }

        public void CreateAnswerKey()
        {
            grader.AnswerKey = new List<Question>();

            CheckBox checkbox;
            NumericUpDown updown;

            int number_of_questions = uxAnswerKeyPanel.Controls.Count;
            char[] answer = new char[5];
            float points = 0;
            bool partial_credit = false;

            for (int i = 0; i < number_of_questions; i++)
            {
                answer = new char[5];

                // This loop cycles through the first 5 controls in the current question panel, which are the checkboes for A-E.
                for (int j = 0; j < 5; j++)
                {
                    checkbox = (CheckBox)uxAnswerKeyPanel.Controls[i].Controls[j];
                    if (checkbox.Checked)
                    {
                        answer[j] = (char)(65 + j);
                    }
                    else
                    {
                        answer[j] = ' ';
                    }
                }

                updown = (NumericUpDown)uxAnswerKeyPanel.Controls[i].Controls[5];
                points = (float)updown.Value;

                // Checks the current question panel's partial credit checkbox.
                checkbox = (CheckBox)uxAnswerKeyPanel.Controls[i].Controls[6];
                if (checkbox.Checked)
                {
                    partial_credit = true;
                }
                else
                {
                    partial_credit = false;
                }

                grader.AnswerKey.Add(new Question(answer, points, partial_credit));
            }

            MessageBox.Show("Answer key created!");
        }

        public void Grade()
        {
            grader.GradeStudents();
            WriteFile();

            uxStudentSelector.Items.Clear();
            foreach (Student student in grader.Students)
            {
                uxStudentSelector.Items.Add(student.WID);
            }
        }

        // Write the file to be uploaded to the Canvas gradebook.
        private void WriteFile()
        {
            string file = "";

            // We want to write to a file and use what StudentExamInfo returns to print to a file.
            foreach (Student student in grader.Students)
            {
                file += grader.ToString();
            }

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
                    MessageBox.Show("Student responses have been successfully recorded!" + Environment.NewLine +
                                    "You may now upload the student responses to Canvas" + Environment.NewLine +
                                    "using the file generated.");
                }
            }
            else
            {
                MessageBox.Show("An error occured while trying to save," + Environment.NewLine +
                                "The format for filenames should not include" + Environment.NewLine +
                                "slashes, parentheticals, or symbols" +
                                Environment.NewLine +
                                "Please reload the hopper and ensure the" + Environment.NewLine +
                                "cards are not stuck together, backwards," + Environment.NewLine +
                                "or reversed. ");
                throw new IOException();
            }
        }

        // Populates the student answer panel with question panels that show the selected student's response.
        public void SelectStudent()
        {
            Panel uxStudentAnswerPanel = (Panel) scantron_form.Controls["uxStudentAnswerPanel"];

            foreach (Student student in grader.Students)
            {
                if (uxStudentSelector.Text.Equals(student.WID))
                {
                    uxStudentAnswerPanel.Controls.Clear();

                    for (int i = 0; i < grader.AnswerKey.Count; i++)
                    {
                        Panel panel = new Panel
                        {
                            BackColor = Color.Green,
                            Location = new Point(3, 3 + 26 * i),
                            Size = new Size(268, 22)
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

                            if (student.Response[i].Answer[j] != ' ')
                            {
                                checkbox.Checked = true;
                            }

                            panel.Controls.Add(checkbox); // Checkboxes are added first so their indices are 0-4.
                        }

                        Label label = new Label
                        {
                            Location = new Point(3, 3),
                            Size = new Size(70, 13),
                            Text = "Question" + (i + 1)
                        };

                        for (int k = 0; k < 5; k++)
                        {
                            CheckBox response_checkbox = (CheckBox)panel.Controls[k];
                            CheckBox answer_key_checkbox = (CheckBox)uxAnswerKeyPanel.Controls[i].Controls[k];

                            if (response_checkbox.Checked != answer_key_checkbox.Checked)
                            {
                                panel.BackColor = Color.Red;
                                break;
                            }
                        }

                        panel.Controls.Add(label);

                        uxStudentAnswerPanel.Controls.Add(panel);
                    }
                }
            }
        }
    }
}
