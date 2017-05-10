// Class Purpose :
// Name : Anna Henson
// Date Written: 06/05/2017 3:48 PM

using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class frmAddStrip : Form
    {
        public frmAddStrip()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}