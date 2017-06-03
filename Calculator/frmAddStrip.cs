// Class Purpose : This is the UI for the calculator program
// Name : Anna Henson
// Date Written: 06/05/2017 3:48 PM

using System;
using System.Drawing;
using System.Windows.Forms;
using AddStrip;

namespace Calculator
{
    public partial class frmAddStrip : Form
    {
        private readonly Calculation calculation;
        private bool changed;

        /// <summary>
        /// Initializes a new instance of the <see cref="frmAddStrip"/> class.
        /// </summary>
        public frmAddStrip()
        {
            InitializeComponent();
            calculation = new Calculation(lstCalculationLines);
        }

        /// <summary>
        /// method : exitToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForChanges();
            Close();
        }

        /// <summary>
        /// method : btnUpdate_Click
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var calcLine = txtReplacementValue.Text;
            var firstChar = calcLine[0];
            if (firstChar == '+' || firstChar == '-')
            {
                var secondChar = calcLine[1];
                if (char.IsDigit(secondChar))
                {
                    var calc = new CalcLine(calcLine);
                    calculation.Replace(calc, lstCalculationLines.SelectedIndex);
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

        /// <summary>
        /// method : btnDelete_Click
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete the selected line", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                calculation.Delete(lstCalculationLines.SelectedIndex);
            }
        }

        /// <summary>
        /// method : btnInsert_Click
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            var calcLine = txtReplacementValue.Text;
            var firstChar = calcLine[0];
            if (firstChar == '+' || firstChar == '-')
            {
                var secondChar = calcLine[1];
                if (char.IsDigit(secondChar))
                {
                    var calc = new CalcLine(calcLine);
                    calculation.Insert(calc, lstCalculationLines.SelectedIndex + 1);
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

        /// <summary>
        /// method : txt_KeyPress
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
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
                    changed = true;
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

        /// <summary>
        /// method : newToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calculation.Clear();
        }

        /// <summary>
        /// method : lstCalculationLines_SelectedValueChanged
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// method : mnuSave_Click
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mnuSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        /// <summary>
        /// method : Save
        /// </summary>
        private void Save()
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
            changed = false;
        }

        /// <summary>
        /// method : mnuOpen_Click
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mnuOpen_Click(object sender, EventArgs e)
        {
            CheckForChanges();
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                calculation.LoadFromFile(dlgOpen.FileName);
            }
            dlgSave.FileName = dlgOpen.FileName;
            changed = false;
        }

        /// <summary>
        /// method : mnuSaveAs_Click
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            CheckForChanges();
            if (dlgSave.FileName == String.Empty)
            {
                dlgSave.FileName = "Calaculation1.cal";
            }

            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                calculation.SaveToFile(dlgSave.FileName);
            }

            changed = false;
        }

        /// <summary>
        /// method : mnuPrint_Click
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mnuPrint_Click(object sender, EventArgs e)
        {
            dlgPrintPreview.Show();
        }

        /// <summary>
        /// method : prtCalculation_PrintPage
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Drawing.Printing.PrintPageEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// method : CheckForChanges
        /// </summary>
        private void CheckForChanges()
        {
            if (changed)
            {
                if (MessageBox.Show("You have unsaved changes, would you like to save them?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Save();
                    changed = false;
                }
            
            }
        }

        /// <summary>
        /// method : frmAddStrip_FormClosing
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void frmAddStrip_FormClosing(object sender, FormClosingEventArgs e)
        {
            CheckForChanges();
        }
    }
}