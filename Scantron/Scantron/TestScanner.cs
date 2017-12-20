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
        private SerialPort serial_port = new SerialPort("COM1");
        private Thread read_thread;
        private string raw_scantron_output;

        public TestScanner()
        {

        }

        public void Scan()
        {
            serial_port.Open();
            read_thread.Start();
            raw_scantron_output = serial_port.ReadLine();
            serial_port.Close();
        }
    }
}
