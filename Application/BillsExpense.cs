using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_LG_JL
{
    internal class BillsExpense : Expense
    {        
        public BillsExpense(string name, decimal amount) : base(name, amount, "bills")
        {

        }


    } // End of BillsExpense class
} // End of namespace
