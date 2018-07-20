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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks; //Requires .Net 4
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;
using Newtonsoft.Json;
// Remove unused using statements in final version.

namespace Scantron
{
    public class ScantronCom
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

        public static ScantronCom Deserialize()
        {
            using (StreamReader settings = File.OpenText("Config.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (ScantronCom)serializer.Deserialize(settings, typeof(ScantronCom));
            }
        }
    }
}