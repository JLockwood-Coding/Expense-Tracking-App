using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_LG_JL
{
    internal class TravelExpense : Expense
    {
        public TravelExpense(string name, decimal amount) : base(name, amount, "travel")
        {

        }


    } // End of TravelExpense class
} // End of namespace
