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
        private char positive = '+';        //This is sent back when a Scantron card is read correctly.
        private char negative = '-';        //This is sent back when a Scantron card is not read correctly.
        private char start_of_record = '!'; //This is sent back at the beginning of a scantron card.
        private char end_of_record = '$';   //This is sent back at the end of a scantron card.
        private char initiate = '@';        //Use this to send start signal to Scantron.
        private char start = '<';           //Use this to raise the tray the scantron cards lay on.
        private char stop = '>';            //Use this to lower the tray the scantron cards lay on.
        private char release = '%';         //Use this to clear the communication buffer for the next scantron card.
        private char status = 's';          //Use this to get the scantron machine's statu
        private string end_of_line = "#\\F";   //This is sent back at the end of a line. It is the compression code
                                               //for 28 F's in a row. This is because the scanner is reading the 
                                               //empty space to the right of the card and it is completely black.

        public TestScanner()
        {
            serial_port.ReadBufferSize = 20000000;
        }

        public void Open()
        {
            serial_port.Open();
        }

        public void Scan()
        {
            char character;
            int ascii;
            raw_scantron_output = "";

            while (serial_port.IsOpen)
            {
                ascii = serial_port.ReadChar();
                character = (char)ascii;
                raw_scantron_output += character;
            }
        }

        public void Close()
        {
            serial_port.Close();
        }

        public string Print()
        {
            return raw_scantron_output;
        }
    }
}
