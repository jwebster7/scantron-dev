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
        // This holds the data stream from the scantron machine. The commented out version below is an example 
        // scantron output stream. A picture of the card is on the github repository's readme.
        private string raw_scantron_output;
        //raw_scantron_output = "b3F33F0FF#F0#DF00#\\Fb033#Q0#\\Fa3F00F0FF#F0#DF00#\\Fb0033#P0#\\Fa3#S0#\\Fb0003#P0#\\Fa4F#H05#I0#[FEb3#S0#\\Fa4#G0F08#I0#\\Fb#T0#\\Fa33000F00034#I0#\\Fb#T0#\\Fa3303F#E05#I0#\\Fb#T0#\\Fa333000E003#J0#\\Fb#T0#\\Fa30F#F037#I0#\\Fb#T0#\\Fa300F#F07#I0#\\Fb#T0#\\Fa3#H0F4#I0#\\FaF#H047#I0#\\Fb#T0#\\Fa4334F00F#L0#\\Fb#T0#\\Fa433F#P0#\\Fb#T0#\\Fa33F#G0F00F#F0#\\Fb#T0#\\Fb#T0#\\Fa3D00F#O0#\\FaF3003#O0#\\Fb#T0#\\Fb#T0#\\Fa3000F#D0E#D0E#E0#\\Fb#T0#\\Fa300F#D0F#D0E#F0#\\Fb#T0#\\Fa30F#D0F#D0F#G0#\\Fb#T0#\\Fa0E#D0F#D0F#H0#\\FaF#D0F#D0F#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0F#D0E#D0E#E0#\\Fb#T0#\\Fa000F#D0F#D0F#F0#\\Fb#T0#\\Fa00C#D0F#D0F#G0#\\Fb#T0#\\Fa0E#D0F#D0F#H0#\\FaF#D0F#D0F#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0D#D0F#D0F#E0#\\Fb#T0#\\Fa000F#D0F#D0F#F0#\\Fb#T0#\\Fa30F#D0F#D0F#G0#\\Fb#S05#\\Fa0D#D0F#D0F#H0#\\FaE#D0D#D0E#H06#\\F$";
        
        // This list holds the raw data split up by the $ character, which denotes the end of a scantron card.
        private List<string> cards = new List<string>();
        // This list holds the split up data translated so we can actually work with it.
        private List<Student> students = new List<Student>();
        // This object is used to read in the data stream. Documentation: https://msdn.microsoft.com/en-us/library/system.io.ports.serialport(v=vs.110).aspx
        private SerialPort serial_port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        
        // Scantron constructor. Initializes the program's GUI.
        public Scantron()
        {
            InitializeComponent();
        }

        // This method divides the raw scantron data into cards, then creates students from the divided data.
        private void CreateStudents()
        {
            students = new List<Student>();
            cards = raw_scantron_output.Split('$').ToList<string>();

            for(int i = 0; i < cards.Count - 1; i++)
            {
                students.Add(new Student(cards[i]));
            }
        }

        // Opens the serial port to read in the data stream.
        private void uxStart_Click(object sender, EventArgs e)
        {
            students = new List<Student>();
            raw_scantron_output = "";
            uxStatusBox.Text = "Press Start on Scantron";

            try
            {
                serial_port.Open();
                serial_port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
            }
            catch(InvalidOperationException)
            {
                // Do nothing. This exception just catches if the serial port is already open and prevents an
                // error window from opening.
            }
        }

        // This event occurs when data is sent from the scantron machine and does the acual reading.
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            serial_port = (SerialPort)sender;
            raw_scantron_output += serial_port.ReadExisting();
        }

        // Closes the serial port and displays the raw data in the text box.
        private void uxStop_Click(object sender, EventArgs e)
        {
            uxStatusBox.Text = "";
            serial_port.Close();
            uxDataBox.Text = raw_scantron_output;
        }

        // Clears the debug text box.
        private void uxClearText_Click(object sender, EventArgs e)
        {
            uxDataBox.Text = "";
        }

        // Prompts the user to select the destination and name of the data file.
        private void uxCreateFile_Click(object sender, EventArgs e)
        {
            uxDataBox.Text = "";
            uxStatusBox.Text = "Creating Students";
            CreateStudents();

            for(int i = 0; i < students.Count; i++)
            {
                uxDataBox.Text += "Student " + (i + 1) + ": " + Environment.NewLine 
                    + students[i].ToString() + Environment.NewLine;
            }

            #region Code for writing the students list to a file
            
            string file = WriteFile();  // Method "WriteFile" creates a string that is correctly formatted for output
            
            SaveFileDialog uxSaveFileDialog = new SaveFileDialog(); // Then we have to start a file dialog to save the string to a file
            uxSaveFileDialog.InitialDirectory = "c:\\desktop";  // could be used to select the default directory ex. "C:\Users\Public\Desktop"
            uxSaveFileDialog.Filter = "doc files (*.doc)|*.doc|All files (*.*)|*.*";  //Filter is the default file extensions seen by the user
            uxSaveFileDialog.FilterIndex = 2;  // FilterIndex sets what the user initially sees ex: 2nd index of the filter is ".doc"

            // Opens save dialog box
            if (uxSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // This stores the location of the file we want to save; use filenames for multiple.
                string path = uxSaveFileDialog.FileName;

                // Checks if the path and name are an empty string
                if (path.Equals(""))
                {
                    MessageBox.Show("You must enter a filename!");
                    throw new FileNotFoundException();
                }
                else
                {
                    // "using" opens and close the StreamWriter
                    using (StreamWriter file_generator = new StreamWriter(path))
                    {
                        file_generator.Write(file);  
                    }
                }
            }
            else
            {
                throw new Exception();
            }

            #endregion Code for writing the students list to a file
        }

        // Function for writing the student info to a string for us in the streamwriter
        private string WriteFile()
        {
            string file = "";
            // We want to write to a file and use what StudentExamInfo returns to print to a file.
            foreach (Student student in students)
            {
                file += StudentExamInfo(student);
            }
            return file;
        }

        // Method for storing the StudentExamInfo in the correct format for the text file
        private string StudentExamInfo(Student student)
        {
            string student_info = "";
            student_info += student.WID + ", ";
            student_info += student.TestVersion + student.SheetNumber + student.GrantPermission + "--,";

            string answer_container = "";

            // Row 5
            answer_container += "5, " + "'" + student.Answers[4] + "'\r\n";

            // Rows 4, 3, 2, 1
            string spaces = "         ,      ";
            for (int i = 3; i >= 0; i--)
            {
                answer_container += spaces + ',' + (i + 1) + ", '" + student.Answers[i] + "'\r\n";
            }

            student_info += answer_container;

            return student_info;
        }
    }
}
