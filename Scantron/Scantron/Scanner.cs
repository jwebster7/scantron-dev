// Scanner.cs
//
// Property of the Kansas State University IT Help Desk
// Written by: William McCreight, Caleb Schweer, and Joseph Webster
// 
// An extensive explanation of the reasoning behind the architecture of this program can be found on the github 
// repository: https://github.com/prometheus1994/scantron-dev/wiki
//
// This class read the data stream from the Scantron machine.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace Scantron
{
    class Scanner
    {
        // Serial port that reads in the data. A very basic implementation is used.
        private SerialPort serial_port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        // Holds the data from the scanner as is.
        private string raw_scantron_output;
        // Raw data split up at EndOfRecord symbol specified in the Scantron machine's configuration sheet.
        private List<string> raw_cards;

        private GUI gui;

        public List<string> RawCards
        {
            get
            {
                return raw_cards;
            }
        }

        public string Raw
        {
            get
            {
                return raw_scantron_output;
            }
        }

        public Scanner(GUI gui)
        {
            this.gui = gui;
        }

        /// <summary>
        /// Open the serial port to read data. User will need to press start on the machine for data to be sent.
        /// </summary>
        public void Scan()
        {
            raw_scantron_output = "";
            raw_cards = new List<string>();
            if (!serial_port.IsOpen)
            {
                serial_port.Open();
            }
            else
            {
                gui.DisplayMessage("Machine is ready to scan!");
            }
            serial_port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
        }

        /// <summary>
        /// Event for when data is received by the serial port.
        /// </summary>
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            serial_port = (SerialPort)sender;
            raw_scantron_output += serial_port.ReadExisting();
        }

        /// <summary>
        /// Closes the serial port and puts the data into a list, split at EndOfRecord symbol.
        /// </summary>
        public void Stop()
        {
            serial_port.Close();
            char[] splitter = new char[] { '$' };
            raw_cards = raw_scantron_output.Split(splitter, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
        }
    }
}
