// Scantron.cs
//
// Property of the Kansas State University IT Help Desk
// Written by: William McCreight, Caleb Schweer, and Joseph Webster
// 
// An extensive explanation of the reasoning behind the architecture of this program can be found on the github 
// repository: https://github.com/prometheus1994/scantron-dev/wiki
//
// This class handles button click events on the GUI.

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
// Remove unused using statements in final version.

using Newtonsoft.Json;

namespace Scantron
{
    public partial class Scantron : Form
    {
        private GUI gui;
        public ScantronConfig config;

        // The location/student in the grader.students
        private static int location = 0;

        // The default constructor for the scantron GUI.
        public Scantron()
        {
            InitializeComponent();
            using (StreamReader settings = File.OpenText("Config.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                config = (ScantronConfig)serializer.Deserialize(settings, typeof(ScantronConfig));
            }
            gui = new GUI(this, config);
        }

        // The event handler opens the serial port and begins reading data from the scantron machine.
        private void uxStart_Click(object sender, EventArgs e)
        {
            gui.Start();
        }

        // Event handler for the stop button; closes the serial port; enables the create file button.
        private void uxStop_Click(object sender, EventArgs e)
        {
            gui.Stop();
        }

        // Click event for the 'Restart' button.
        private void uxRestart_Click(object sender, EventArgs e)
        {
            gui.Restart();
        }

        // Event handler for the 'Enter' button.
        private void uxEnter_Click(object sender, EventArgs e)
        {
            gui.Enter();
        }

        // Event handler for the 'Create Answer Key' button.
        private void uxCreateAnswerKey_Click(object sender, EventArgs e)
        {
            gui.CreateAnswerKey();
        }

        // Event handler for the 'Grade' button.
        private void Grade_Click(object sender, EventArgs e)
        {
            gui.Grade();
        }

        // Event handler for selecting student answers to view.
        private void uxStudentSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            gui.SelectStudent();
        }

        private void uxNextStudent_Click(object sender, EventArgs e)
        {
            gui.NextStudent();
        }

        private void uxPreviousStudent_Click(object sender, EventArgs e)
        {
            gui.PreviousStudent();
        }
    }
}