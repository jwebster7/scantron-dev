using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;

namespace Scantron
{
    public class TestScanner
    {
        private SerialPort serial_port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        private string raw_scantron_output;
        private string end_of_line_sequence = "#\\F"; //This sequence marks when the scanner starts reading beyond the
                                                      //rightmost border of the scantron card. This way we don't have 
                                                      //to change the End Of Record settings on the Scantron settings
                                                      //sheet.

        public TestScanner()
        {
            serial_port.ReadBufferSize = 20000000;
        }

        public string Scan(int maxChars)
        {
            char character;
            int ascii;
            raw_scantron_output = "";

            serial_port.Open();

            /*
            for (int i = 0; i < maxChars; i++)
            {
                ascii = serial_port.ReadChar();
                character = (char) ascii;

                if (character == 'a' || character == 'b')
                {
                    raw_scantron_output += Environment.NewLine + character;
                }
                else
                {
                    raw_scantron_output += character;
                }
            }
            */

            Thread.Sleep(10000);
            raw_scantron_output = serial_port.ReadExisting();
            
            //serial_port.DataReceived += new SerialDataReceivedEventHandler(serial_port_dataReceived);

            serial_port.Close();

            return raw_scantron_output;
        }

        void serial_port_dataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] buffer = new byte[4096];
            int bytesRead = serial_port.Read(buffer, 0, buffer.Length);
            raw_scantron_output = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
        }
    }
}
