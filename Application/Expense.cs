using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_LG_JL
{
    internal class Expense
    {
        // Fields
        private string expenseName;
        private decimal expenseAmount;
        private string expenseType;


        // Properties
        public string ExpenseName
        {
            get { return expenseName; }
            set { expenseName = value; }
        }

        public decimal Amount
        {
            get { return expenseAmount; }
            set { expenseAmount = value; }
        }

        public string ExpenseType
        {
            get { return expenseType; }
            set { expenseType = value; }
        }


        // Constructor
        public Expense(string expenseName, decimal expenseAmount, string expenseType)
        {
            ExpenseName = expenseName;
            Amount = expenseAmount;
            ExpenseType = expenseType;
        }


    } // End of Expense class
} // End of namespace
