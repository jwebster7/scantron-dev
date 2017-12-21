using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;

namespace Scantron
{
    class TestScanner
    {
        private SerialPort serial_port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        private string raw_scantron_output;

        public TestScanner()
        {

        }

        public string Scan(int maxChars)
        {
            char character;
            int ascii;
            raw_scantron_output = "";

            serial_port.Open();
            
            for (int i = 0; i < maxChars; i++)
            {
                ascii = serial_port.ReadChar();
                character = (char) ascii;
                raw_scantron_output += character;
            }
            
            serial_port.Close();

            return raw_scantron_output;
        }
    }
}
