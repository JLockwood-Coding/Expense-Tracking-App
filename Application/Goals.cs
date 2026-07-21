using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_LG_JL
{
    internal class Goals
    {    
        // Fields
        private string goalName;
        private decimal goalAmount;        
        private decimal amountPaid;


        // Properties
        public string GoalName
        {
            get { return goalName; }
            set { goalName = value; }
        }

        public decimal GoalAmount
        {
            get { return goalAmount; }
            set { goalAmount = value; }
        }
                
        public decimal AmountPaid
        {
            get { return amountPaid; }
            set { amountPaid = value; }
        }


        // Constructor
        public Goals(string goalName, decimal goalAmount)
        {
            GoalName = goalName;
            GoalAmount = goalAmount;            
            AmountPaid = 0;
        }


    } // End of Goals class
} // End of namespace
