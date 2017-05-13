// Class Purpose :
// Name : Anna Henson
// Date Written: 11/05/2017 12:21 PM

using System.Collections;
using System.Windows.Forms;
using AddStrip;

namespace Calculator
{
    internal class Calculation
    {
        private readonly ListBox lstDisplay;
        private readonly ArrayList theCalcs;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Calculation" /> class.
        /// </summary>
        /// <param name="lb">The lb.</param>
        public Calculation(ListBox lb)
        {
            lstDisplay = lb;
            theCalcs = new ArrayList();
        }

        /// <summary>
        ///     method : Add
        ///     Clear the ArrayList and the ListBox
        /// </summary>
        /// <param name="cl">The cl.</param>
        public void Add(CalcLine cl)
        {
            theCalcs.Add(cl);
            Redisplay();
        }

        /// <summary>
        ///     method : Clear
        ///     Clear the array list and the listbox
        /// </summary>
        public void Clear()
        {
            theCalcs.Clear();
            lstDisplay.Items.Clear();
        }

        public void Redisplay()
        {
            lstDisplay.Items.Clear();
            double subTotal = 0;
            foreach (var theCalc in theCalcs)
            {
                var calc = (CalcLine) theCalc;
                if (calc.Op == Operator.subtotal)
                {
                    lstDisplay.Items.Add(subTotal);
                }
                else if (calc.Op == Operator.total)
                {
                    lstDisplay.Items.Add(subTotal);
                    subTotal = 0;
                }
                else
                {
                    lstDisplay.Items.Add(calc.ToString());
                    subTotal = calc.NextResult(subTotal);
                }
            }
        }

        /// <summary>
        ///     method : Find
        ///     Return a reference to the nth CalcLine object in ArrayList
        /// </summary>
        /// <param name="n">The n.</param>
        /// <returns></returns>
        public CalcLine Find(int n)
        {
            return (CalcLine) theCalcs[n];
        }

        /// <summary>
        ///     method : Replace
        ///     Repalce the nth CalcLine object in the ArrayList wwith new calc object
        ///     Redisplay the calculations
        /// </summary>
        /// <param name="newCalc">The new calculate.</param>
        /// <param name="n">The n.</param>
        public void Replace(CalcLine newCalc, int n)
        {
            theCalcs[n] = newCalc;
            Redisplay();
        }

        /// <summary>
        ///     method : Insert
        ///     Insert new CalcLine object ArrayList immediately before the nth object
        ///     Redisplay the claculations
        /// </summary>
        /// <param name="newCalc">The new calculate.</param>
        /// <param name="n">The n.</param>
        public void Insert(CalcLine newCalc, int n)
        {
            theCalcs.Insert(n - 1, newCalc);
            Redisplay();
        }

        /// <summary>
        ///     method : Delete
        ///     Delete the nth CalcLine object in ArrayList
        ///     Redisplay the calculations
        /// </summary>
        /// <param name="n">The n.</param>
        public void Delete(int n)
        {
            theCalcs.RemoveAt(n);
            Redisplay();
        }

        // Save all the CalcLine objects in ArrayList as lines of text in given file
        public void SaveToFile(string filename)
        {
            // Clear the ArrayList
            //Then open the given file and convert lines of the file to a set of CalcLine objects held in ArrayList
            // Redisplay Calculations
        }

        public void LoadFromFile(string filename)
        {
            // load string file name from the file
        }
    }
}