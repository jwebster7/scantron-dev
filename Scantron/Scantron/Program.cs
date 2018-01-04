// Program.cs
//
// Property of the Kansas State University IT Help Desk
// Written by: William McCreight, Caleb Schweer, and Joseph Webster
// 
// More in-depth explanations of each method and the overall architecture of this program can be found on the github 
// repository: https://github.com/prometheus1994/scantron-dev
//
// This file is just the main program file that starts the Scantron.cs functionality.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Scantron
{
    public class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Scantron());
        }
    }
}
