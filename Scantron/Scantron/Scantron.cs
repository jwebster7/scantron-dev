using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scantron
{
    public partial class Scantron : Form
    {
        int maxChars = 200;
        TestScanner test_scanner = new TestScanner();

        public Scantron()
        {
            InitializeComponent();
        }

        private void uxStart_Click(object sender, EventArgs e)
        {
            uxStatusBox.Text = "Press Start on Scantron";
            test_scanner.Open();
            test_scanner.Scan();
        }

        private void uxStop_Click(object sender, EventArgs e)
        {
            test_scanner.Close();
            uxStatusBox.Text = "";
            uxDataBox.Text += test_scanner.Print() + Environment.NewLine;
        }

        private void uxCreateFile_Click(object sender, EventArgs e)
        {
            uxDataBox.Text = "";
        }
    }
}
