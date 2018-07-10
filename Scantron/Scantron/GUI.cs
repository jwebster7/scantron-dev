// GUI.cs
//
// Property of the Kansas State University IT Help Desk
// Written by: William McCreight, Caleb Schweer, and Joseph Webster
// 
// An extensive explanation of the reasoning behind the architecture of this program can be found on the github 
// repository: https://github.com/prometheus1994/scantron-dev/wiki
//
// This class handles GUI changing methods.

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

namespace Scantron
{
    class GUI
    {
        public GUI()
        {

        }

        public void Start(TextBox uxInstructionBox, string raw_scantron_output, SerialPort serial_port)
        {
            try
            {
                uxInstructionBox.Text = "Now press Start on the Machine to begin scanning." + Environment.NewLine +
                                        "Once all the cards have successfully scanned, " + Environment.NewLine +
                                        "press the 'Stop' within this window.";
                raw_scantron_output = "";
                serial_port.Open();
            }
            // SystemException is the superclass containing IOException and InvalidOperationException
            catch (SystemException)
            {
                // Do nothing. This is to prevent an error message about the port already being open if a user has to rescan cards.
            }
        }

        public void Stop(Grader grader, TextBox uxInstructionBox, string raw_scantron_output)
        {
            // If no students were created, (this should already be taken care of in the Stop event handler), 
            // we want to set the state back to the start button and start over.
            if (grader.Students.Count == 0)
            {
                uxInstructionBox.Text = "Please load the hopper of the Scantron," + Environment.NewLine +
                                        "then click on 'Start' within this window.";

                MessageBox.Show("Something went wrong when scanning the cards." + Environment.NewLine +
                                Environment.NewLine +
                                "Please ensure the cards are not stuck together," + Environment.NewLine +
                                "backwards, or reversed and reload the hopper.");
            }

            // We cannot create students if raw_scantron_output is empty.
            // Sets the program to initial state of the program.
            if (raw_scantron_output.Equals(""))
            {
                uxInstructionBox.Text = "Please load the hopper of the Scantron," + Environment.NewLine +
                                        "then click on 'Start' within this window.";

                MessageBox.Show("Something went wrong when scanning the cards." + Environment.NewLine +
                                Environment.NewLine +
                                "Please ensure the cards are not stuck together," + Environment.NewLine +
                                "backwards, or reversed and reload the hopper.");
            }
            else
            {
                uxInstructionBox.Text = "Please insert a USB drive into the computer" + Environment.NewLine +
                                        "Then press 'Create File' to create and save" + Environment.NewLine +
                                        "a file onto the USB drive";
            }
        }
    }
}
