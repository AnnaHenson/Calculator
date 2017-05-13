using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddStrip;

namespace Calculator
{
    class Calculation
    {
        public Calculation(ListBox lb)
        {

            // Add a CalcLine object to ArrayList then redisplay calculations     
        }

        public void Add(CalcLine cl)
        {
            // Clear the ArrayList and the ListBox
        }

        public void Clear()
        {
            // Clear ListBox 
            // For each line in the calculation, if line is ordinary calculation add text version of CalcLine to ListBox and 
            //  calculate result of the calculation so far.
            // If line is for a total or subtotal add text for total or subtotal to ListBox
            // If the line is for a total, the result of calculation so far is reset to zero
        }

        public void Redisplay()
        {
            // Return a reference to the nth CalcLine object in ArrayList
        }

        public CalcLine Find(int n)
        {
            throw new NotImplementedException();
            // Repalce the nth CalcLine object in the ArrayList wwith new calc object
            // Redisplay the calculations
        }

        /// <summary>
        /// method : Replace
        /// Insert new CalcLine object ArrayList immediately before the nth object
        /// Redisplay the claculations
        /// </summary>
        /// <param name="newCalc">The new calculate.</param>
        /// <param name="n">The n.</param>
        public void Replace(CalcLine newCalc, int n)
        {

        }

        /// <summary>
        /// method : Insert
        /// Delete the nth CalcLine object in ArrayList
        /// Redisplay the calculations
        /// </summary>
        /// <param name="newCalc">The new calculate.</param>
        /// <param name="n">The n.</param>
        public void Insert(CalcLine newCalc, int n)
        {

        }

        public void Delete(int n)
        {
            // Save all the CalcLine objects in ArrayList as lines of text in given file
        }

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
    


   







