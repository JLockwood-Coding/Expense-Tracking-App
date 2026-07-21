using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_LG_JL
{
    internal class LuxuryExpense : Expense
    {        
        public LuxuryExpense(string name, decimal amount) : base(name, amount, "luxury")
        {

        }


    } // End of LuxuryExpense class
} // End of namespace
