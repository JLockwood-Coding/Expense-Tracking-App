using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_LG_JL
{
    internal class FoodExpense : Expense
    {       
        public FoodExpense(string name, decimal amount) : base(name, amount, "food")
        {

        }


    } // End of FoodExpense class
} // End of namespace
