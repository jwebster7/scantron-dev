// ScannerCom.cs
//
// Property of the Kansas State University IT Help Desk
// Written by: William McCreight, Caleb Schweer, and Joseph Webster
// 
// An extensive explanation of the reasoning behind the architecture of this program can be found on the github 
// repository: https://github.com/prometheus1994/scantron-dev/wiki
//
// === This class is depricated. Being left in for if someone wants to undertake controlling the Scantron machine 
// === entirely from the computer.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace Scantron
{
    public class FancyScanner
    {
        private SerialPort serial_port;
        private ScannerConfig config;

        public static ManualResetEvent ToAbort = new ManualResetEvent(false);
               
        public FancyScanner()
        {
            config = ScannerConfig.Deserialize();
            
            serial_port = new SerialPort(config.port_name, config.baud_rate, (Parity)Enum.Parse(typeof(Parity), config.parity_bit), config.bit_length, (StopBits)Enum.Parse(typeof(StopBits), config.stop_bits));
            serial_port.NewLine = config.end_of_record;
        }

        public void Start()
        {
            serial_port.Dispose();

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
        //public static List<string> Run()
        public List<string> Run(List<string> raw_cards)
        {
            Thread.Sleep(1000);
            Thread.BeginCriticalRegion();

            // Reads in data from the scantron cards into raw_cards
            string cardFromSerialPort;
            while (Status()[11] != '1') //will loop while the hopper is up
            {

                //if(ToAbort.WaitOne())
                //    Console.WriteLine("runs");
                //if(!ToAbort.WaitOne())
                //    Console.WriteLine("NO run");

                ToAbort.WaitOne();


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

        /// <summary>
        /// Writes a stop command to the serial port to close the buffer.
        /// </summary>
        public void Stop()
        {
            serial_port.Write(config.stop);
        }

        /// <summary>
        /// Gets the status of the serial port. 
        /// </summary>
        /// <returns>The status of the serial port.</returns>
        private string Status()
        {
            string status;
            serial_port.Write(config.status);
            serial_port.Write("0"); // 0 - for long status
                                    // 1 - for short status
            status = serial_port.ReadLine();
            return status;
        }

        /// <summary>
        /// Displays the current config.
        /// </summary>
        /// <param name="message">the message to write to the config.</param>
        private void Display(string message)
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

    public delegate void ScannerHandler(object source, EventArgs e);

    public class ScannerNew
    {
        public event ScannerHandler Completed;

        private SerialPort serial_port;
        private ScannerConfig config;

        Thread scanner;
        private List<string> rawCards;

        //private readonly object runLock = new object();
        //private volatile static bool run = false;
        private static long _run = 0;

        public ScannerNew()
        {
            config = ScannerConfig.Deserialize();

            serial_port = new SerialPort(config.port_name, config.baud_rate, (Parity)Enum.Parse(typeof(Parity), config.parity_bit), config.bit_length, (StopBits)Enum.Parse(typeof(StopBits), config.stop_bits));
            serial_port.NewLine = config.end_of_record;
        }

        public List<string> RawCards
        {
            get
            {
                return rawCards;
            }
        }

        public bool IsRunning
        {
            get
            {
                if(scanner.ThreadState == ThreadState.Running)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void Start()
        {
            if (!serial_port.IsOpen)
            {
                serial_port.Open();
            }
            if (scanner == null || scanner.ThreadState == ThreadState.Running)
            {
                //lock(runLock)
                //{
                //    run = true;
                //}
                Interlocked.Exchange(ref _run, 1);
                

                scanner = new Thread(new ThreadStart(Run));
                

                serial_port.Write(config.start);
                scanner.Start();
            }
        }

        public void Stop()
        {
            if(scanner.ThreadState == ThreadState.Running)
            {
                //lock(runLock)
                //{
                //    run = false;
                //}

                Interlocked.Exchange(ref _run, 0);

            }

            serial_port.Write(config.stop);
        }

        public void Display(string s)
        {
            serial_port.Write(config.display_data);
            serial_port.Write("{");
            serial_port.Write("0");
            serial_port.Write("0");
            serial_port.Write(s);
            serial_port.Write("}");
            serial_port.Write(config.end_of_info);
        }

        private string StatusShort()
        {
            string status;
            serial_port.Write(config.status);
            serial_port.Write("0");
            status = serial_port.ReadLine();
            return status;
        }

        private string StatusLong()
        {
            string status;
            serial_port.Write(config.status);
            serial_port.Write("1");
            status = serial_port.ReadLine();
            return status;
        }

        private void completed()
        {
            if(Completed != null)
            {
                Completed(this, new EventArgs());
            }
        }

        private void Run()
        {
            List<string> l = new List<string>();

            while (StatusShort()[11] != '1' && Interlocked.Read(ref _run) == 1)
            {
                //lock (runLock)
                //{
                //    doRun = run;
                //}
                serial_port.Write(config.positive);
                string s = serial_port.ReadLine();

                if (StatusShort()[8] == '1' || StatusShort()[8] == '2') //checks status if there was an error reading in the sheet
                {
                    //Do not need to stop when the scanner gets an error it drops the bed
                    serial_port.DiscardInBuffer();
                    DialogResult dialogResult = MessageBox.Show("Please removed the skewed card and add it back to the stop of the stack.\n\n" +
                                                                "After doing so click Retry to continue scanning or Cancel to Abort the Scanning proccess",
                                                                "Continue?", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
                    if (dialogResult != DialogResult.Retry)
                    {

                        goto BREAK;
                    }
                    else
                    {
                        serial_port.Write(config.start);
                    }

                }
                else
                {
                    l.Add(s);
                }

                Interlocked.Read(ref _run);
            }
            BREAK:
            rawCards = l;
            completed();
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
