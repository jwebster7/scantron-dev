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
        List<string> sheets = new List<string>();       //Seperates each sheet by the the end_of_record char '$'
        List<Student> students = new List<Student>();   //A list for the Student objects; generated from the sheets list

        private SerialPort serial_port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        private char character;
        private int ascii;
        private string raw_scantron_output;
        private char positive = '+';            //This is sent back when a Scantron card is read correctly.
        private char negative = '-';            //This is sent back when a Scantron card is not read correctly.
        private char start_of_record = '!';     //This is sent back at the beginning of a scantron card.
        private char end_of_record = '$';       //This is sent back at the end of a scantron card.
        private char initiate = '@';            //Use this to send start signal to Scantron.
        private char start = '<';               //Use this to raise the tray the scantron cards lay on.
        private char stop = '>';                //Use this to lower the tray the scantron cards lay on.
        private char release = '%';             //Use this to clear the communication buffer for the next scantron card.
        private char status = 's';              //Use this to get the scantron machine's statu
        private string end_of_line = "#\\F";    //This is sent back at the end of a line. It is the compression code
                                                //for 28 F's in a row. This is because the scanner is reading the 
                                                //empty space to the right of the card and it is completely black.

        /// <summary>
        /// This method intends to sort the raw_scantron_output string into seperate sheets for 
        /// constructing Student objects in the future
        /// </summary>
        public void SortIntoSheets()
        {

            String[] tempSheets = raw_scantron_output.Split('$');   //A string array to hold each sheet from the raw input

            for (int i = 0; i < tempSheets.Length; i++) //Foreach sheet in tempSheets...
            {
                string wid = tempSheets[i].Substring(2, 9); //Reads in the WID
                /*
                string rowElevenAnswers = tempSheets[i].Substring(11, 5);
                string rowTwelveAnswers = tempSheets[i].Substring(18, 5);
                string rowThirteenAnswers = tempSheets[i].Substring(24, 5);
                string rowFourteenAnswers = tempSheets[i].Substring(32, 5);
                string rowFifteenAnswers = tempSheets[i].Substring(38, 5);
                */
                char[] firstFiveAnswers = FirstFiveAnswers(tempSheets[i].Substring(11, 5), tempSheets[i].Substring(18, 5),
                                                           tempSheets[i].Substring(24, 5), tempSheets[i].Substring(32, 5),
                                                           tempSheets[i].Substring(38, 5));

            }
        }

        /// <summary>
        /// Helper function for "SortIntoSheets"; returns a char[] of the first five scantron answers
        /// </summary>
        /// <param name="eleven">the 11th row of the scantron</param>
        /// <param name="twelve">the 12th row of the scantron</param>
        /// <param name="thirteen">the 13th row of the scantron</param>
        /// <param name="fourteen">the 14th row of the scantron</param>
        /// <param name="fifteen">the 15th row of the scantron</param>
        /// <returns>The first five answers in a char[]</returns>
        public char[] FirstFiveAnswers(string eleven, string twelve, string thirteen, string fourteen, string fifteen)
        {
            char[] firstFive = new char[5]; //[Q5 Ans], [Q4 Ans], [Q3 Ans], ...
            
            for (int i = 4; i >= 0; i--)
            {
                if (eleven[i].Equals(""))
                {
                    if (twelve[i].Equals(""))
                    {
                        if (thirteen[i].Equals(""))
                        {
                            if (fourteen[i].Equals(""))
                            {
                                if (fifteen[i].Equals(""))
                                {
                                    //this is the scenario where the student has neglected to answer
                                    firstFive[i] = ' ';
                                }
                                else
                                {
                                    firstFive[i] = fourteen[i];
                                }
                            }
                            else
                            {
                                firstFive[i] = thirteen[i];
                            }
                        }
                        else
                        {
                            firstFive[i] = thirteen[i];
                        }
                    }
                    else
                    {
                        firstFive[i] = twelve[i];
                    }
                }
                else
                {
                    firstFive[i] = eleven[i];
                }
            }
            return firstFive;
        }

        public TestScanner()
        {
            serial_port.ReadBufferSize = 20000000;
        }

        public string Open()
        {
            serial_port.Open();
            return "Port open";
        }

        public string Scan()
        {
            raw_scantron_output = "";
            
            while (serial_port.IsOpen)
            {
                serial_port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
            }

            /*
            while (serial_port.IsOpen)
            {
                ascii = serial_port.ReadChar();
                character = (char)ascii;
                raw_scantron_output += character;
            }
            */

            return "Port scanned";
        }

        public string Close()
        {
            serial_port.Close();
            return "Port closed";
        }

        public string Print()
        {
            return raw_scantron_output;
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ascii = serial_port.ReadChar();
            character = (char)ascii;
            raw_scantron_output += character;
        }
    }
}
