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
            uxMaxCharactersBox.Text = "200";
        }

        private void uxReadFiles_Click(object sender, EventArgs e)
        {
            uxStatusBox.Text = "Press Start on Scantron";
            uxDataBox.Text += test_scanner.Scan(maxChars) + Environment.NewLine;
            uxStatusBox.Text = "";
        }

        private void uxCreateFile_Click(object sender, EventArgs e)
        {
            uxDataBox.Text = "";
        }

        private void uxMaxCharactersBox_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(uxMaxCharactersBox.Text) >= 200)
            {
                maxChars = Convert.ToInt32(uxMaxCharactersBox.Text);
            }
        }
    }
}
