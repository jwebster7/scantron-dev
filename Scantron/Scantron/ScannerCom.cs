// ScannerCom.cs
//
// Property of the Kansas State University IT Help Desk
// Written by: William McCreight, Caleb Schweer, and Joseph Webster
// 
// An extensive explanation of the reasoning behind the architecture of this program can be found on the github 
// repository: https://github.com/prometheus1994/scantron-dev/wiki
//
// This class is used for configuring the serial port and scantron machine settings.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Threading;

namespace Scantron
{
    public static class ScannerCom
    {
        private static SerialPort serial_port;
        private static ScannerConfig config;

        static ScannerCom()
        {
            config = ScannerConfig.Deserialize();

            serial_port = new SerialPort(config.port_name, config.baud_rate, (Parity)Enum.Parse(typeof(Parity), config.parity_bit), config.bit_length, (StopBits)Enum.Parse(typeof(StopBits), config.stop_bits));
            serial_port.NewLine = config.end_of_record;
        }

        public static void Start()
        {
            if (!serial_port.IsOpen)
            {
                serial_port.Open();
                serial_port.Write(config.start);
            }
        }

        /// <summary>
        /// Starts reading cards from the scantron to a serial port and addes the string produced to a list
        /// </summary>
        /// <param name="raw_cards">A list of raw card data filled by the method</param>
        /// <param name="partial_wids">A list of potential partial_wids; Null if no partial_wids found</param>
        /// <returns></returns>
        public static List<string> Run(List<string> raw_cards)
        {
            
            Thread.Sleep(1000);
            Thread.BeginCriticalRegion();

            // Reads in data from the scantron cards into raw_cards
            string cardFromSerialPort;
            while (Status()[11] != '1') //will loop while the hopper is up
            {
                serial_port.Write(config.positive);
                cardFromSerialPort = serial_port.ReadLine();

                if (Status()[8] == '1' || Status()[8] == '2') //checks status if there was an error reading in the sheet
                {
                    //Do not need to stop when the scanner gets an error it drops the bed
                    serial_port.DiscardInBuffer();
                    MessageBox.Show("A card has jammed. Please remove the card.\n \n " +
                        "Place it back in your scantron pile and close this pop up.");

                    serial_port.Write(config.start);
                }
                else
                {
                    raw_cards.Add(cardFromSerialPort);
                }
            }

            Thread.EndCriticalRegion();

            serial_port.Close();
            return raw_cards;
        }

        public static void Stop()
        {
            serial_port.Write(config.stop);
        }

        private static string Status()
        {
            string status;
            serial_port.Write(config.status);
            serial_port.Write("0"); // 0 - for long status
                                    // 1 - for short status
            status = serial_port.ReadLine();
            return status;
        }

        private static void Display(string message)
        {
            serial_port.Write(config.display_data);
            serial_port.Write("{");
            serial_port.Write("0");
            serial_port.Write("0");
            serial_port.Write(message);
            serial_port.Write("}");
            serial_port.Write(config.end_of_info);
        }




    }

    public class ScannerConfig
    {
        public string port_name { get; set; }
        public int baud_rate { get; set; }
        public string parity_bit { get; set; }
        public int bit_length { get; set; }
        public string stop_bits { get; set; }

        public string end_of_record { get; set; }
        public string compress { get; set; }
        public string initiate { get; set; }
        public string positive { get; set; }
        public string negative { get; set; }
        public string start { get; set; }
        public string stop { get; set; }
        public string release { get; set; }
        public string status { get; set; }
        public string print_data { get; set; }
        public string display_data { get; set; }
        public string end_of_info { get; set; }

        public static ScannerConfig Deserialize()
        {
            using (StreamReader settings = File.OpenText("Config.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (ScannerConfig)serializer.Deserialize(settings, typeof(ScannerConfig));
            }

        }
    }
}
