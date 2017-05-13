// Class Purpose :
// Name : Anna Henson
// Date Written: 06/05/2017 3:48 PM

using System;
using System.Diagnostics;
using System.Windows.Forms;
using AddStrip;

namespace Calculator
{
    public partial class frmAddStrip : Form
    {
        private Calculation calculation;
        public frmAddStrip()
        {
            InitializeComponent();
            calculation = new Calculation(lstCalculationLines);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            CalcLine calcLine = null;
            // 1st char in the line
            if (txtValue.Text.Length == 0)
            {
                if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '\n')
                {
                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("You must enter a +, - or the Enter key as the first value", "Error");
                }
            }
            else
            {
                // Not the first char
                // Is it a terminating char
                if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/' || e.KeyChar == '#' || e.KeyChar == '=' || e.KeyChar == '\r')
                {
                    calcLine = new CalcLine(txtValue.Text);
                    calculation.Add(calcLine);
                    lstCalculationLines.Items.Add(txtValue.Text);
                    // Is is a char that needs to go to the start of the line
                    if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/')
                    {
                        txtValue.Text = e.KeyChar.ToString();
                        txtValue.Select(1,1);
                        e.Handled = true;
                        return;
                    } // Is it a subtotal
                    else if (e.KeyChar == '#')
                    {
                        calcLine = new CalcLine(Operator.subtotal);
                        calculation.Add(calcLine);
                    } // Is it a total
                    else if (e.KeyChar == '=')
                    {
                        calcLine = new CalcLine(Operator.total);
                        calculation.Add(calcLine);
                    }
                    txtValue.Text = "";
                }
                else if (!Char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("You must enter a digit or #, +, -, *. /, or =", "Error");
                }
            }
        }
    }
}