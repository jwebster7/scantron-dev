// ScannerConfig.cs
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
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Scantron
{
    public class ScantronCom
    {
        ScannerConfig config;
        private SerialPort serial_port;
        private GUI gui;


        public ScantronCom(GUI gui)
        {
            this.gui = gui;

            config = ScannerConfig.Deserialize();

            serial_port = new SerialPort(config.port_name, config.baud_rate, (Parity)Enum.Parse(typeof(Parity), config.parity_bit), config.bit_length, (StopBits)Enum.Parse(typeof(StopBits), config.stop_bits));
            serial_port.NewLine = config.end_of_record;
        }


        public void Start()
        {
            if (!serial_port.IsOpen)
            {
                serial_port.Open();
                serial_port.Write(config.start);
            }

        }

        public  List<string> Run(List<string> raw_cards)
        {
            serial_port.Write(config.initate);

            while (Status()[11] != '1') //will loop while the hopper is up
            {
                serial_port.Write(config.positive);

                if (Status()[8] == '1' || Status()[8] == '2') //checks status if there was an error reading in the sheet
                {
                    Stop();
                    serial_port.DiscardInBuffer();
                    gui.DisplayMessage("A card has jammed. Please remove the card.\n \n " +
                        "Place it back in your scantron pile and close this pop up.");
                    //Display Message Box to remove jammed card and add it back to the top of the card stack
                    //Event that user resumes scanning
                    Start();
                    serial_port.Write(config.initate);
                }
                else
                {
                    raw_cards.Add(serial_port.ReadLine());
                }
            }

            serial_port.Close();
            return raw_cards;
        }

        public void Stop()
        {
           // serial_port.Write(config.stop);
        }

        private string Status()
        {
            serial_port.Write(config.status);
            serial_port.Write("0"); // 0 - for long status
                                    // 1 - for short status
            return serial_port.ReadLine();

        }

    }

    public  class ScannerConfig
    {
        public string port_name { get; set; }
        public int baud_rate { get; set; }
        public string parity_bit { get; set; }
        public int bit_length { get; set; }
        public string stop_bits { get; set; }
        public string start_of_record { get; set; }
        public string end_of_record { get; set; }
        public string end_of_document { get; set; }
        public string compress { get; set; }
        public string record_length { get; set; }
        public string initate { get; set; }
        public string positive { get; set; }
        public string negitive { get; set; }
        public string x_on { get; set; }
        public string x_off { get; set; }
        public string start { get; set; }
        public string stop { get; set; }
        public string release { get; set; }
        public string select_stacker { get; set; }
        public string download { get; set; }
        public string runtime { get; set; }
        public string status { get; set; }
        public string scanner_control { get; set; }
        public string print_position { get; set; }
        public string print_data { get; set; }
        public string display_data { get; set; }
        public string end_of_info { get; set; }
        public string end_of_batch { get; set; }
        public string ocr { get; set; }


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