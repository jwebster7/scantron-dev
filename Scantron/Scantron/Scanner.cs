/* Formatting is based off of the content found here:
 * https://code.msdn.microsoft.com/windowsdesktop/SerialPort-brief-Example-ac0d5004
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;

namespace Scantron
{
    class Scanner
    {
        /// <summary>
        /// A list of all the students; Each Student object may also be viewed as a sheet
        /// </summary>
        private List<Student> students = new List<Student>();

        /// <summary>
        /// A list of each sheets data; Used for constructing our list of Student Objects
        /// NOTE: The type of elements may or may not need to be altered 
        /// </summary>
        private List<string> raw_sheet_data = new List<string>();
        /// <summary>
        /// The port name for communication from scanner to computer
        /// </summary>
        private string port_name = "COM1";

        /// <summary>
        /// The serial port object used for interacting with the scanner
        /// </summary>
        private SerialPort serial_port = new SerialPort();

        /// <summary>
        /// The default speed at which information is moved from "portName"
        /// </summary>
        private int baud_rate = 9600;

        /// <summary>
        /// Number of bits for the data read in
        /// </summary>
        private int data_bits = 8;

        /// <summary>
        /// The number of stopBits used on "serialPort"
        /// </summary>
        private StopBits stop_bits = StopBits.One;

        /// <summary>
        /// Used for checking if data has been lost when it is moved
        /// </summary>
        private Parity parity = Parity.None;

        /// <summary>
        /// Signifies the end of transmition
        /// </summary>
        private byte terminator = 0x4;

        /// <summary>
        /// Default constructor for Scanner objects
        /// </summary>
        public Scanner()
        {

        }
    }
}
