using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            WriteToFile();  //Method writes to a file
        }

        //Function for writing and saving text to a file
        private void WriteToFile()
        {
            string file = "";
            //we want to write to a file and use what StudentExamInfo returns to print to a file
            foreach (Student student in students)
            {
                file += StudentExamInfo(student);
            }

            SaveFileDialog file_dialog = new SaveFileDialog();
            //Opens save dialog box
            if (file_dialog.ShowDialog() == DialogResult.OK)
            {

            }
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
