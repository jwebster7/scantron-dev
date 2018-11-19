using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace Scantron
{
    class SimpleScanner
    {
        private SerialPort serial_port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        private string raw_scantron_output;
        private List<string> raw_cards;

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

        public SimpleScanner()
        {

        }

        public void Scan()
        {
            raw_scantron_output = "";
            raw_cards = new List<string>();
            if (!serial_port.IsOpen)
            {
                serial_port.Open();
            }
            serial_port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            serial_port = (SerialPort)sender;
            raw_scantron_output += serial_port.ReadExisting();
        }

        public void Stop()
        {
            serial_port.Close();
            char[] splitter = new char[] { '$' };
            raw_cards = raw_scantron_output.Split(splitter, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
        }
    }
}
