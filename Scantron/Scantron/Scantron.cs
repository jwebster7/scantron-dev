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
    public partial class Scantron : Form
    {
        // Holds the raw data split up by card.
        private List<string> cards = new List<string>();
        // Holds students; data derived from cards.
        private List<Student> students = new List<Student>();
        // Serial port object used to read in the data stream.
        private SerialPort serial_port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        // List of question panels.
        private List<Control> question_panels = new List<Control>();
        
        // Class for grading CanConvert version.
        Grader grader = new Grader();
        private string[] answer_key;
        private bool[] partial_credit;

        // Holds the read in Scantron data.
        //private string raw_scantron_output;
        // Uncomment below assignment for example card data.
        private string raw_scantron_output = "b3F33F0FF#F0#DF00#\\Fb033#Q0#\\Fa3F00F0FF#F0#DF00#\\Fb0033#P0#\\Fa3#S0#\\Fb0003#P0#\\Fa4F#H05#I0#[FEb3#S0#\\Fa4#G0F08#I0#\\Fb#T0#\\Fa33000F00034#I0#\\Fb#T0#\\Fa3303F#E05#I0#\\Fb#T0#\\Fa333000E003#J0#\\Fb#T0#\\Fa30F#F037#I0#\\Fb#T0#\\Fa300F#F07#I0#\\Fb#T0#\\Fa3#H0F4#I0#\\FaF#H047#I0#\\Fb#T0#\\Fa4334F00F#L0#\\Fb#T0#\\Fa433F#P0#\\Fb#T0#\\Fa33F#G0F00F#F0#\\Fb#T0#\\Fb#T0#\\Fa3D00F#O0#\\FaF3003#O0#\\Fb#T0#\\Fb#T0#\\Fa3000F#D0E#D0E#E0#\\Fb#T0#\\Fa300F#D0F#D0E#F0#\\Fb#T0#\\Fa30F#D0F#D0F#G0#\\Fb#T0#\\Fa0E#D0F#D0F#H0#\\FaF#D0F#D0F#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0F#D0E#D0E#E0#\\Fb#T0#\\Fa000F#D0F#D0F#F0#\\Fb#T0#\\Fa00C#D0F#D0F#G0#\\Fb#T0#\\Fa0E#D0F#D0F#H0#\\FaF#D0F#D0F#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0D#D0F#D0F#E0#\\Fb#T0#\\Fa000F#D0F#D0F#F0#\\Fb#T0#\\Fa30F#D0F#D0F#G0#\\Fb#S05#\\Fa0D#D0F#D0F#H0#\\FaE#D0D#D0E#H06#\\F$";


        // The default constructor for the scantron GUI.
        public Scantron()
        {
            // Initializes the form.
            InitializeComponent();
            foreach (Control control in uxAnswerKeyPanel.Controls)
            {
                question_panels.Add(control);
            }
            StartProgram();
        }

        // The event handler opens the serial port and begins reading data from the scantron machine.
        private void uxStart_Click(object sender, EventArgs e)
        {
            try
            {
                uxInstructionBox.Text = "Now press Start on the Machine to begin scanning." + Environment.NewLine +
                                        "Once all the cards have successfully scanned, " + Environment.NewLine +
                                        "press the 'Stop' within this window.";
                raw_scantron_output = "";
                students = new List<Student>();
                serial_port.Open();
                serial_port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
                uxStart.Enabled = false;
                uxStop.Enabled = true;
            }
            // SystemException is the superclass containing IOException and InvalidOperationException
            catch (SystemException)
            {
                // Do nothing. This is to prevent an error message about the port already being open.
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

        // Event handler for the stop button; closes the serial port; enables the create file button.
        private void uxStop_Click(object sender, EventArgs e)
        {
            serial_port.Close();
            CreateStudents();

            // We cannot create students if raw_scantron_output is empty.
            // Sets the program to initial state of the program.
            if (raw_scantron_output.Equals(""))
            {
                uxInstructionBox.Text = "Please load the hopper of the Scantron," + Environment.NewLine +
                                        "then click on 'Start' within this window.";
                uxStart.Enabled = true;
                uxStop.Enabled = false;

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
                uxStart.Enabled = false;
                uxStop.Enabled = false;
            }
        }

        // This method creates student objects and adds them to the students list.
        private void CreateStudents()
        {
            // Sets each reference value in cards equal to exactly one scantron card.
            cards = raw_scantron_output.Split('$').ToList<string>();

            // For each index/value in cards, create a student object and add to the list students.
            for (int i = 0; i < cards.Count - 1; i++)
            {
                students.Add(new Student(cards[i]));
            }

            // If no students were created, (this should already be taken care of in the Stop event handler), 
            // we want to set the state back to the start button and start over.
            if (students.Count == 0)
            {
                uxInstructionBox.Text = "Please load the hopper of the Scantron," + Environment.NewLine +
                                        "then click on 'Start' within this window.";
                uxStart.Enabled = true;
                uxStop.Enabled = false;

                MessageBox.Show("Something went wrong when scanning the cards." + Environment.NewLine +
                                Environment.NewLine +
                                "Please ensure the cards are not stuck together," + Environment.NewLine +
                                "backwards, or reversed and reload the hopper.");
            }
        }

        // Function for writing the student info to a string for us in the streamwriter.
        private void WriteFile()
        {
            string file = "";

            // We want to write to a file and use what StudentExamInfo returns to print to a file.
            foreach (Student student in students)
            {
                file += student.ToString();
            }

            // Then we have to start a file dialog to save the string to a file.
            SaveFileDialog uxSaveFileDialog = new SaveFileDialog
            {
                // Could be used to select the default directory ex. "C:\Users\Public\Desktop".
                InitialDirectory = "c:\\desktop",
                // Filter is the default file extensions seen by the user.
                Filter = "txt files (*.txt)|*.txt",
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

        // Temporary method for people too stubborn to move on from CanConvert. There has to be a way to consolidate all of
        // the write file methods.
        private void WriteCSVFile()
        {
            string file = "";

            // We want to write to a file and use what StudentExamInfo returns to print to a file.
            foreach (Student student in students)
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

        // Event handler for the 'Admin' button.
        private void uxAdmin_Click(object sender, EventArgs e)
        {
            uxInstructionBox.Font = new Font("Microsoft Sans Serif", (float)17.5, FontStyle.Regular);
            uxInstructionBox.Text = "Please load the hopper of the Scantron," + Environment.NewLine +
                                    "then click on 'Start' within this window.";
            uxInstructionBox.ReadOnly = true;
            uxInstructionBox.ScrollBars = ScrollBars.None;
            uxStart.Enabled = true;
            uxStop.Enabled = false;
        }

        // Click event for the 'Restart' button.
        private void uxRestart_Click(object sender, EventArgs e)
        {
            StartProgram();
        }

        // Initial program state
        private void StartProgram()
        {
            uxInstructionBox.Text = "Please load the hopper of the Scantron," + Environment.NewLine +
                                    "then click on 'Start' within this window.";
            uxStart.Enabled = true;
            uxStop.Enabled = false;
        }

        // Event handler for the 'Enter' button.
        private void uxEnter_Click(object sender, EventArgs e)
        {
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

                    NumericUpDown points = new NumericUpDown
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

                    panel.Controls.Add(partial_credit); // Index 5
                    panel.Controls.Add(points); // Index 6
                    panel.Controls.Add(label); // Index 7

                    uxAnswerKeyPanel.Controls.Add(panel);
                }
            }
            else
            {
                MessageBox.Show("Enter a number from 1-150.");
            }
        }

        // Event handler for the 'Create Answer Key' button.
        private void uxCreateAnswerKey_Click(object sender, EventArgs e)
        {
            int number_of_questions = uxAnswerKeyPanel.Controls.Count;
            answer_key = new string[5];
            partial_credit = new bool[number_of_questions];
            CheckBox checkbox;

            for (int i = 0; i < number_of_questions; i++)
            {
                // This loop cycles through the first 5 controls in the current question panel, which are the checkboes for A-E.
                for (int j = 0; j < 5; j++)
                {
                    checkbox = (CheckBox)uxAnswerKeyPanel.Controls[i].Controls[j];
                    if(checkbox.Checked)
                    {
                        answer_key[j] += j + 1;
                    }
                    else
                    {
                        answer_key[j] += " ";
                    }
                }

                // Checks the current question panel's partial credit checkbox.
                checkbox = (CheckBox)uxAnswerKeyPanel.Controls[i].Controls[5];
                if (checkbox.Checked)
                {
                    partial_credit[i] = true;
                }
            }
        }

        // Event handler for the 'Grade' button.
        private void Grade_Click(object sender, EventArgs e)
        {
            grader = new Grader(students, answer_key, partial_credit);
            grader.Grade();
            WriteCSVFile();

            uxStudentSelector.Items.Clear();
            foreach (Student student in students)
            {
                uxStudentSelector.Items.Add(student.WID);
            }
        }

        // Event handler for selecting student answers to view.
        private void uxStudentSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Student student in students)
            {
                if (uxStudentSelector.Text.Equals(student.WID))
                {
                    uxStudentAnswerPanel.Controls.Clear();

                    for (int i = 0; i < answer_key[0].Length; i++)
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

                            if (student.Answers[j][i] != ' ')
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
                            CheckBox checkbox1 = (CheckBox) panel.Controls[k];
                            CheckBox checkbox2 = (CheckBox) uxAnswerKeyPanel.Controls[i].Controls[k];

                            if (checkbox1.Checked != checkbox2.Checked)
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