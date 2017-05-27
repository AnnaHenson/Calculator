// Class Purpose :
// Name : Anna Henson
// Date Written: 06/05/2017 3:48 PM

using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AddStrip;

namespace Calculator
{
    public partial class frmAddStrip : Form
    {
        private readonly Calculation calculation;

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
            var calcLine = txtReplacementValue.Text;
            var firstChar = calcLine[0];
            if (firstChar == '+' || firstChar == '-')
            {
                var secondChar = calcLine[1];
                if (char.IsDigit(secondChar))
                {
                    var lastChar = calcLine[calcLine.Length - 1];
                    if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/' || lastChar == '#' || lastChar == '=' || lastChar == '\r')
                    {
                        var calc = new CalcLine(calcLine);
                        calculation.Replace(calc, lstCalculationLines.SelectedIndex);
                    }
                    else
                    {
                        MessageBox.Show("The terminating character must be a +, -, *,/,# or =");
                    }
                }
                else
                {
                    MessageBox.Show("The characters immediately following the first character must be numeric", "Error");
                }
            }
            else
            {
                MessageBox.Show("The first character must be a + or - ", "Error");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete the selected line", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                calculation.Delete(lstCalculationLines.SelectedIndex);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var calcLine = txtReplacementValue.Text;
            var firstChar = calcLine[0];
            if (firstChar == '+' || firstChar == '-')
            {
                var secondChar = calcLine[1];
                if (char.IsDigit(secondChar))
                {
                    var lastChar = calcLine[calcLine.Length - 1];
                    if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/' || lastChar == '#' || lastChar == '=' || lastChar == '\r')
                    {
                        var calc = new CalcLine(calcLine);
                        calculation.Insert(calc, lstCalculationLines.SelectedIndex);
                    }
                    else
                    {
                        MessageBox.Show("The terminating character must be a +, -, *,/,# or =");
                    }
                }
                else
                {
                    MessageBox.Show("The characters immediately following the first character must be numeric", "Error");
                }
            }
            else
            {
                MessageBox.Show("The first character must be a + or - ", "Error");
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If they press the backspace let them.
            if (e.KeyChar == '\b')
                return;
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
                    // Is is a char that needs to go to the start of the line
                    if (e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '*' || e.KeyChar == '/')
                    {
                        txtValue.Text = e.KeyChar.ToString();
                        txtValue.Select(1, 1);
                        e.Handled = true;
                        return;
                    } // Is it a subtotal
                    if (e.KeyChar == '#')
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
                else if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("You must enter a digit or #, +, -, *. /, or =", "Error");
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calculation.Clear();
        }

        private void lstCalculationLines_SelectedValueChanged(object sender, EventArgs e)
        {
            var calcLine = calculation.Find(lstCalculationLines.SelectedIndex);
            if (calcLine.Op != Operator.subtotal && calcLine.Op != Operator.total)
                txtReplacementValue.Text = lstCalculationLines.SelectedItem.ToString().Replace(" ", "");
            else if (calcLine.Op == Operator.subtotal)
                txtReplacementValue.Text = "#";
            else if (calcLine.Op == Operator.total)
                txtReplacementValue.Text = "=";
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            if (dlgSave.FileName == String.Empty)
            {
                dlgSave.FileName = "Calculation1.cal";
                if (dlgSave.ShowDialog() == DialogResult.OK)
                {
                    calculation.SaveToFile(dlgSave.FileName);
                }
            }
            else
            {
                calculation.SaveToFile(dlgSave.FileName);
            }
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                calculation.LoadFromFile(dlgOpen.FileName);
            }
            dlgSave.FileName = dlgOpen.FileName;
        }

        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            if (dlgSave.FileName == String.Empty)
            {
                dlgSave.FileName = "Calaculation1.cal";
            }

            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                calculation.SaveToFile(dlgSave.FileName);
            }
        }

        private void mnuPrint_Click(object sender, EventArgs e)
        {
            dlgPrintPreview.Show();
        }

        private void prtCalculation_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int linesSoFarHeading = 0;
            Font textFont = new Font("Arial", 10,FontStyle.Regular);
            Font headingFont = new Font("Arial", 10, FontStyle.Regular);
            Brush brush = new SolidBrush(Color.Black);
            int leftMargin = e.MarginBounds.Left;
            int topMargin = e.MarginBounds.Top;



            // Heading
            g.DrawString("Calculation", headingFont, brush, leftMargin, topMargin + linesSoFarHeading * textFont.Height);
            linesSoFarHeading++;
            linesSoFarHeading++;

            for (int i = 0; i < lstCalculationLines.Items.Count; i++)
            {
                var calcLine = calculation.Find(i);
                g.DrawString(calcLine.ToString(), textFont, brush, leftMargin, topMargin +(linesSoFarHeading * textFont.Height));
                linesSoFarHeading++;
            }
        }
    }
}