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
        private List<string> cards = new List<string>();
        private List<Student> students = new List<Student>();
        private SerialPort serial_port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        //private string raw_scantron_output;
        private string raw_scantron_output = "b3F33F0FF#F0#DF00#\\Fb033#Q0#\\Fa3F00F0FF#F0#DF00#\\Fb0033#P0#\\Fa3#S0#\\Fb0003#P0#\\Fa4F#H05#I0#[FEb3#S0#\\Fa4#G0F08#I0#\\Fb#T0#\\Fa33000F00034#I0#\\Fb#T0#\\Fa3303F#E05#I0#\\Fb#T0#\\Fa333000E003#J0#\\Fb#T0#\\Fa30F#F037#I0#\\Fb#T0#\\Fa300F#F07#I0#\\Fb#T0#\\Fa3#H0F4#I0#\\FaF#H047#I0#\\Fb#T0#\\Fa4334F00F#L0#\\Fb#T0#\\Fa433F#P0#\\Fb#T0#\\Fa33F#G0F00F#F0#\\Fb#T0#\\Fb#T0#\\Fa3D00F#O0#\\FaF3003#O0#\\Fb#T0#\\Fb#T0#\\Fa3000F#D0E#D0E#E0#\\Fb#T0#\\Fa300F#D0F#D0E#F0#\\Fb#T0#\\Fa30F#D0F#D0F#G0#\\Fb#T0#\\Fa0E#D0F#D0F#H0#\\FaF#D0F#D0F#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0F#D0E#D0E#E0#\\Fb#T0#\\Fa000F#D0F#D0F#F0#\\Fb#T0#\\Fa00C#D0F#D0F#G0#\\Fb#T0#\\Fa0E#D0F#D0F#H0#\\FaF#D0F#D0F#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0D#D0F#D0F#E0#\\Fb#T0#\\Fa000F#D0F#D0F#F0#\\Fb#T0#\\Fa30F#D0F#D0F#G0#\\Fb#S05#\\Fa0D#D0F#D0F#H0#\\FaE#D0D#D0E#H06#\\F$";

        public Scantron()
        {
            InitializeComponent();
            uxInstructionBox.Text = "Please load the hopper of the Scantron" + Environment.NewLine +
                                    "Then click on the 'Start Button'" + Environment.NewLine +
                                    "Now press Start on the Machine to begin scanning";
            uxStart.Enabled = true;
            uxStop.Enabled = false;
            uxDebug.Enabled = false;
            uxCreateFile.Enabled = false;
        }

        private void CreateStudents()
        {
            cards = raw_scantron_output.Split('$').ToList<string>();

            for(int i = 0; i < cards.Count - 1; i++)
            {
                students.Add(new Student(cards[i]));
            }
        }

        private void uxStart_Click(object sender, EventArgs e)
        {
            students = new List<Student>();
            raw_scantron_output = "";
            serial_port.Open();
            serial_port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
            uxStart.Enabled = false;
            uxInstructionBox.Text = "Once all the cards have successfully scanned, " + Environment.NewLine +
                                    "Press the 'Stop Button'";
            uxStop.Enabled = true;
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            serial_port = (SerialPort)sender;
            raw_scantron_output += serial_port.ReadExisting();
        }

        private void uxStop_Click(object sender, EventArgs e)
        {
            serial_port.Close();
            uxStop.Enabled = false;
            uxStart.Enabled = false;
            uxInstructionBox.Text = "Please insert a USB drive into the computer" + Environment.NewLine +
                                    "Then press 'Create File' to create and save" + Environment.NewLine +
                                    "a file onto the USB drive";
            uxCreateFile.Enabled = true;
        }

        private void uxCreateFile_Click(object sender, EventArgs e)
        {
            uxInstructionBox.Text = "Please check your file to ensure all" + Environment.NewLine + 
                                    "Scantron cards have been scanned and stored correctly" + Environment.NewLine +
                                    "If not, please start over";
            CreateStudents();

            for(int i = 0; i < students.Count; i++)
            {
                uxInstructionBox.Text += "Student " + (i + 1) + ": " + Environment.NewLine 
                    + students[i].ToString() + Environment.NewLine;
            }

            #region Code for writing the students list to a file
            
            string file = WriteFile();  //Method "WriteFile" creates a string that is correctly formatted for output
            
            SaveFileDialog uxSaveFileDialog = new SaveFileDialog(); //Then we have to start a file dialog to save the string to a file
            uxSaveFileDialog.InitialDirectory = "c:\\desktop";  //could be used to select the default directory ex. "C:\Users\Public\Desktop"
            uxSaveFileDialog.Filter = "doc files (*.doc)|*.doc|All files (*.*)|*.*";  //Filter is the default file extensions seen by the user
            uxSaveFileDialog.FilterIndex = 2;  //FilterIndex sets what the user initially sees ex: 2nd index of the filter is ".doc"

            //Opens save dialog box
            if (uxSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = uxSaveFileDialog.FileName;  //This stores the location of the file we want to save; use filenames for multiple
                
                if (path.Equals(""))  //checks if the path and name are an empty string
                {
                    MessageBox.Show("You must enter a filename!");
                    throw new FileNotFoundException();
                }
                else
                {
                    //"using" opens and close the StreamWriter
                    using (StreamWriter file_generator = new StreamWriter(path))
                    {
                        file_generator.Write(file);  //writes everything in file to the file found at "path"
                    }
                }
            }
            else
            {
                throw new Exception();
            }

            #endregion Code for writing the students list to a file
            uxStart.Enabled = true;
            uxStop.Enabled = false;
            uxCreateFile.Enabled = false;
            uxDebug.Enabled = false;
        }

        private void uxDebug_Click(object sender, EventArgs e)
        {
            string debug_output = raw_scantron_output;
            uxInstructionBox.Text = "Here is the output of the cards: " + Environment.NewLine +
                                     debug_output.ToString();
            uxStart.Enabled = true;
            uxStop.Enabled = false;
            uxCreateFile.Enabled = false;
            uxDebug.Enabled = false;
        }

        //Function for writing the student info to a string for us in the streamwriter
        private string WriteFile()
        {
            string file = "";
            //we want to write to a file and use what StudentExamInfo returns to print to a file
            foreach (Student student in students)
            {
                file += student.ToString();
            }
            return file;
        }
    }
}
