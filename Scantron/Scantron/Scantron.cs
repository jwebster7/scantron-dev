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
        private string raw_scantron_output;

        public Scantron()
        {
            InitializeComponent();
        }

        private void CreateStudents()
        {
            cards = raw_scantron_output.Split('$').ToList<string>();

            foreach (string card in cards)
            {
                students.Add(new Student(card));
            }
        }

        private void uxStart_Click(object sender, EventArgs e)
        {
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
            serial_port.Close();
            uxDataBox.Text += raw_scantron_output + Environment.NewLine;
        }

        private void uxClearText_Click(object sender, EventArgs e)
        {
            uxDataBox.Text = "";
        }

        private void uxCreateFile_Click(object sender, EventArgs e)
        {
            CreateStudents();
        }
    }
}
