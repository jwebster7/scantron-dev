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
        private string raw_scantron_output = "b0F30F0FF#F0#DF00#\\Fa3F00F0FF#F0#DF00#\\Fb#T0#\\Fb#T0#\\Fa3#S0#\\Fb#T0#\\Fa4F#G036#I0#\\Fb#T0#\\Fa4#G0F09#I0#\\Fb#T0#\\Fa33000F00035#I0#\\Fb#T0#\\Fa3300F#E06#I0#\\Fb#T0#\\Fa03#D0F003#J0#\\Fb#T0#\\Fa00F#F038#I0#\\Fb#T0#\\Fa000F#F08#I0#[FEb#T0#\\Fa#I0F4#I0#[FEaF#H037#I0#\\Fb#T0#\\Fa3033F#O0#\\Fb#T0#\\Fa303F0003#L0#\\Fb#T0#\\Fa30F#J0E#F0#\\Fb#T0#\\Fb#T0#\\Fa0E#R0#\\FaF#F0F00E#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0F#D0F#D0E#E0#\\Fb#T0#\\Fa000F#D0F#D0F#F0#\\Fb#T0#\\Fa00F#D0F#D0F#G0#\\Fb#T0#\\Fa0F#D0F#D0F#H0#\\FaF#D0F#D0F#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0F#D0E#D0E#E0#\\Fb#T0#\\Fa000F#D0F#D0F#F0#\\Fb#T0#\\Fa00F#D0F#D0F#G0#\\Fb#T0#\\Fa0F#D0F#D0F#H0#\\FaF#D0F#D0F#I0#\\Fb#T0#\\Fb#T0#\\Fa#D0E#D0F#D0F#E0#\\Fb#T0#\\Fa000F#D0F#D0F#F0#\\Fb#T0#\\Fa00F#D0F#D0F#G0#\\Fb#S04#\\Fa0F#D0F#D0F#H0#\\FaF#D0E#D0F#H06#\\F$";

        public Scantron()
        {
            InitializeComponent();
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
            uxStatusBox.Text = "Press Start on Scantron";
            serial_port.Open();
            serial_port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            serial_port = (SerialPort)sender;
            raw_scantron_output += serial_port.ReadExisting();
        }

        private void uxStop_Click(object sender, EventArgs e)
        {
            uxStatusBox.Text = "";
            serial_port.Close();
            uxDataBox.Text += raw_scantron_output + Environment.NewLine;
        }

        private void uxClearText_Click(object sender, EventArgs e)
        {
            uxDataBox.Text = "";
        }

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
        }

        //Function for writing the student info to a string for us in the streamwriter
        private string WriteFile()
        {
            string file = "";
            //we want to write to a file and use what StudentExamInfo returns to print to a file
            foreach (Student student in students)
            {
                file += StudentExamInfo(student);
            }
            return file;
        }

        //Method for storing the StudentExamInfo in the correct format for the text file
        private string StudentExamInfo(Student student)
        {
            string student_info = "";
            student_info += student.WID + ", ";
            student_info += student.GrantPermission + student.TestVersion + student.TestVersion + ", ";

            string answer_container = "";

            //Row 5
            answer_container += ",5, " + "'" + student.Answers[4] + "'\n";

            //Rows 4, 3, 2, 1
            string spaces = "                ";
            for (int i = 3; i >= 0; i--)
            {
                answer_container += spaces + ',' + (i + 1) + ", '" + student.Answers[i] + "'\n";
            }

            student_info += answer_container;

            return student_info;
        }
    }
}
