// Scantron.cs
//
// Property of the Kansas State University IT Help Desk
// Written by: William McCreight, Caleb Schweer, and Joseph Webster
// 
// An extensive explanation of the reasoning behind the architecture of this program can be found on the github 
// repository: https://github.com/prometheus1994/scantron-dev/wiki
//
// This file is for the Scantron GUI 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace Scantron
{
    public partial class Scantron : Form
    {
        // Holds the raw data split up by card
        private List<string> cards = new List<string>();
        // Holds students; data derived from 'cards'
        private List<Student> students = new List<Student>();
        // Serial port object used to read in the data stream
        private SerialPort serial_port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        // Holds the read in Scantron data
        // private string raw_scantron_output;
        // Uncomment below assignment for example card data.
        private string raw_scantron_output = "b3F33F0FF#F0#DF00#\\Fb033#Q0#\\Fa3F00F0FF#F0#DF00#\\Fb0033#P0#\\Fa3#S0#\\Fb0003#P0#\\Fa4F#H05#I0#[FEb3#S0#\\Fa4#G0F08#I0#\\Fb#T0#\\Fa33000F00034#I0#\\Fb#T0#\\Fa3303F#E05#I0#\\Fb#T0#\\Fa333000E003#J0#\\Fb#T0#\\Fa30F#F037#I0#\\Fb#T0#\\Fa300F#F07#I0#\\Fb#T0#\\Fa3#H0F4#I0#\\FaF#H047#I0#\\Fb#T0#\\Fa4334F00F#L0#\\Fb#T0#\\Fa433F#P0#\\Fb#T0#\\Fa33F#G0F00F#F0#\\Fb#T0#\\Fb#T0#\\Fa3D00F#O0#\\FaF3003#O0#\\Fb#T0#\\Fb#T0#\\Fa3000F#D0E#D0E#E0#\\Fb#T0#\\Fa300F#D0F#D0E#F0#\\Fb#T0#\\Fa30F#D0F#D0F#G0#\\Fb#T0#\\Fa0E#D0F#D0F#H0#\\FaF#D0F#D0F#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0F#D0E#D0E#E0#\\Fb#T0#\\Fa000F#D0F#D0F#F0#\\Fb#T0#\\Fa00C#D0F#D0F#G0#\\Fb#T0#\\Fa0E#D0F#D0F#H0#\\FaF#D0F#D0F#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0D#D0F#D0F#E0#\\Fb#T0#\\Fa000F#D0F#D0F#F0#\\Fb#T0#\\Fa30F#D0F#D0F#G0#\\Fb#S05#\\Fa0D#D0F#D0F#H0#\\FaE#D0D#D0E#H06#\\F$";
        // Header text for the Debug Mode
        private string debug_header = "Debug Mode On" +
                                       Environment.NewLine +
                                       "Click Debug again to exit" +
                                       Environment.NewLine;
        // Flag for toggling Debug Mode
        private bool debug = false;

        // The default constructor for the scantron GUI
        public Scantron()
        {
            // Initializes the form
            InitializeComponent();
            // Displays initial instructions into the instruction box
            uxInstructionBox.Text = "Please load the hopper of the Scantron" + Environment.NewLine +
                                    "Then click on the 'Start Button'" + Environment.NewLine +
                                    "Now press Start on the Machine to begin scanning";
            uxStart.Enabled = true;
            uxStop.Enabled = false;
            // Debug button will always need to be enabled
            uxDebug.Enabled = true;
            uxCreateFile.Enabled = false;
        }

        // The event handler opens the serial port and begins reading data from the scantron machine
        private void uxStart_Click(object sender, EventArgs e)
        {
            students = new List<Student>();
            raw_scantron_output = "";
            serial_port.Open();
            serial_port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);

            if (debug)
            {
                uxInstructionBox.Text = debug_header + "Click 'Stop' once all cards are scanned to view the raw output";
            }
            else
            {
                uxInstructionBox.Text = "Once all the cards have successfully scanned, " + Environment.NewLine +
                                        "Press the 'Stop Button'";
                uxStart.Enabled = false;
                uxStop.Enabled = true;
                uxCreateFile.Enabled = false;
            }
        }

        // This method is an event handler for the serialport
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Sets serial_port to the event object value
            serial_port = (SerialPort)sender;
            // Appends the values from the scantron machine into the 'raw_scantron_ouput'
            raw_scantron_output += serial_port.ReadExisting();
        }

        // Event handler for the 'Stop' button; closes the serial port; enables the 'Create File' button
        private void uxStop_Click(object sender, EventArgs e)
        {
            serial_port.Close();

            if (debug)
            {
                uxInstructionBox.Text = debug_header +
                                        "Raw card output: " +
                                        Environment.NewLine +
                                        Environment.NewLine +
                                        raw_scantron_output.ToString();
            }
            else
            {
                uxInstructionBox.Text = "Please insert a USB drive into the computer" + Environment.NewLine +
                                        "Then press 'Create File' to create and save" + Environment.NewLine +
                                        "a file onto the USB drive";
                uxStart.Enabled = false;
                uxStop.Enabled = false;
                uxCreateFile.Enabled = true;
            }
        }

        // Event handler for 'Create File' button
        private void uxCreateFile_Click(object sender, EventArgs e)
        {
            CreateStudents();
            WriteFile();

            if (debug)
            {
                uxInstructionBox.Text = debug_header;
                for (int i = 0; i < students.Count; i++)
                {
                    uxInstructionBox.Text += "Student " + (i + 1) + ": " + Environment.NewLine
                        + students[i].ToString() + Environment.NewLine;
                }
            }
            else
            {
                uxInstructionBox.Text = "Please check your file to ensure all" + Environment.NewLine +
                                        "Scantron cards have been scanned and stored correctly" + Environment.NewLine +
                                        "If not, please start over";
                uxStart.Enabled = true;
                uxStop.Enabled = false;
                uxCreateFile.Enabled = false;
            }
        }

        // This method creates student objects and adds them to the list, 'students'
        private void CreateStudents()
        {
            // Sets each reference value in 'cards' equal to exactly one scantron card
            cards = raw_scantron_output.Split('$').ToList<string>();

            // For each index/value in 'cards', create a student object and add to the list 'students'
            for (int i = 0; i < cards.Count - 1; i++)
            {
                students.Add(new Student(cards[i]));
            }
        }

        // Event handler for the 'Debug' button
        private void uxDebug_Click(object sender, EventArgs e)
        {
            if (!debug)
            {
                uxInstructionBox.Font = new Font("Courier New", 9, FontStyle.Regular);
                uxInstructionBox.Text = debug_header;
                uxInstructionBox.ScrollBars = ScrollBars.Vertical;
                uxStart.Enabled = true;
                uxStop.Enabled = true;
                uxCreateFile.Enabled = true;
                debug = true;
            }
            else
            {
                uxInstructionBox.Font = new Font("Microsoft Sans Serif", (float)17.5, FontStyle.Regular);
                uxInstructionBox.Text = "Please load the hopper of the Scantron" + Environment.NewLine +
                                        "Then click on the 'Start Button'" + Environment.NewLine +
                                        "Now press Start on the Machine to begin scanning";
                uxInstructionBox.ScrollBars = ScrollBars.None;
                uxStart.Enabled = true;
                uxStop.Enabled = false;
                uxCreateFile.Enabled = false;
                debug = false;
            }
        }

        // Function for writing the student info to a string for us in the streamwriter
        private void WriteFile()
        {
            string file = "";

            // We want to write to a file and use what StudentExamInfo returns to print to a file
            foreach (Student student in students)
            {
                file += student.ToString();
            }

            // Then we have to start a file dialog to save the string to a file
            SaveFileDialog uxSaveFileDialog = new SaveFileDialog();
            // Could be used to select the default directory ex. "C:\Users\Public\Desktop"
            uxSaveFileDialog.InitialDirectory = "c:\\desktop";
            // Filter is the default file extensions seen by the user
            uxSaveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            // FilterIndex sets what the user initially sees ex: 2nd index of the filter is ".txt"
            uxSaveFileDialog.FilterIndex = 2;

            // Opens save dialog box
            if (uxSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Stores the location of the file we want to save; use filenames for multiple
                string path = uxSaveFileDialog.FileName;

                // Checks if the path and name are an empty string
                if (path.Equals(""))
                {
                    // displays an error; no file name given
                    MessageBox.Show("You must enter a filename!");
                    throw new FileNotFoundException();
                }
                else
                {
                    // "using" opens and close the StreamWriter
                    using (StreamWriter file_generator = new StreamWriter(path))
                    {
                        // Adds everything in the 'file' given to the streamwriter
                        file_generator.Write(file);
                    }
                }
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
