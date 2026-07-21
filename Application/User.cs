using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_LG_JL
{
    internal class User
    {
        // This class is used to create each user account, and handle all expenses tied to that specific user


        //----------------------------------------Fields, Properties and Constructor----------------------------------------//       

        // Fields
        private string username;
        private string password;       
        private List<Expense> expenses = new List<Expense>();   
        private List<Goals> goals = new List<Goals>();
        decimal savings = 0;


        // Properties
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        
        public List<Expense> Expenses
        {
            get { return expenses; }
        }


        // Constructor
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }





        //----------------------------------------Methods----------------------------------------//

        // Methods        

        // When called, this method will add an expense to the expenses list
        public void AddExpense()
        {           
            //----------------------------------------Adding The Name Of The Expense----------------------------------------//
            // Prompt user to enter the expense name and initialize variable
            Console.Clear();
            Console.Write("Enter the name of the expense: ");
            string expenseName = Console.ReadLine();

            // Make sure the input is not empty
            if (string.IsNullOrEmpty(expenseName))
            {                
                Console.WriteLine("Expense name cannot be empty!");
                return;
            }


            //----------------------------------------Adding The Cost Of The Expense----------------------------------------//
            // Prompt user to enter the expense cost and initialize variable through error handling
            Console.WriteLine();
            Console.Write("Enter the expense cost: ");
            try
            {
                // Will check for and remove any $ symbols. Initialize variable with user's input
                string input = Console.ReadLine();
                input = input.Replace("$", "");


                // Convert the corrected input into decimal
                decimal expenseCost = Convert.ToDecimal(input);


                // Make sure input is above 0
                if (expenseCost <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Expense amount must be greater than zero!");                    
                    return;
                }


                //----------------------------------------Sorting The Expense Into A Category----------------------------------------//
                // Prompt user to select an expense category through a switch case
                Console.WriteLine();
                Console.WriteLine("Choose an expense category:");
                Console.WriteLine("1. Food");
                Console.WriteLine("2. Travel");
                Console.WriteLine("3. Luxury");
                Console.WriteLine("4. Bills");
                Console.WriteLine();

                
                // Convert user's input into lowercase for code simplification
                string categoryChoice = Console.ReadLine().ToLower();


                // Instantiate Expense object
                Expense newExpense;


                switch (categoryChoice)
                {
                    case "1" or "food":
                        // Categorize the expense as a Food Expense
                        newExpense = new FoodExpense(expenseName, expenseCost);
                        break;


                    case "2" or "travel":
                        // Categorize the expense as a Travel Expense
                        newExpense = new TravelExpense(expenseName, expenseCost);
                        break;


                    case "3" or "luxury":
                        // Categorize the expense as a Luxury expense
                        newExpense = new LuxuryExpense(expenseName, expenseCost);
                        break;


                    case "4" or "bills":
                        // Categorize the expense as a Bills expense
                        newExpense = new BillsExpense(expenseName, expenseCost);
                        break;


                    default:
                        // Error handling for incorrect category selection
                        Console.Clear();
                        Console.WriteLine("Invalid category selection");                        
                        return;

                }


                //----------------------------------------Finally Adding The Expense To The List----------------------------------------//
                // Add the expense to the expense list
                expenses.Add(newExpense);
                Console.Clear();
                Console.WriteLine("Expense has been added!");


            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Invalid amount entered");                
            }
            catch (OverflowException)
            {
                Console.Clear();
                Console.WriteLine("Amount is too large");                
            }            

        } // End of AddExpense() method







        // When called, this method will allow the removal of an expense
        public void RemoveExpense()
        {
            //----------------------------------------Making Sure Expense List Is Not Currently Empty----------------------------------------//
            // Check if list is empty. Even though this is in DisplayExpenses(), it is needed here otherwise...
            // ...the code will run even if there are no expenses
            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses to remove");                
                return;
            }


            //----------------------------------------Selecting An Expense To Remove----------------------------------------//
            // Display all expenses so user can choose which to remove
            DisplayExpenses();
            Console.WriteLine();
            Console.Write("Enter the number of the expense you wish to remove: ");
            int choice;


            // Error handling if the format is wrong and if the entered number is far too large
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid number");                
                return;
            }
            catch (OverflowException)
            {
                Console.Clear();
                Console.WriteLine("Number is too large");                
                return;
            }
            Console.WriteLine();


            //----------------------------------------Converting User Input Into Index Selection----------------------------------------//
            // Convert the user's choice into the proper index for accurate selection
            int index = choice - 1;


            // Make sure the user has entered a valid index
            if (index < 0 || index >= expenses.Count)
            {
                Console.Clear();
                Console.WriteLine("Invalid expense number");                
                return;
            }


            //----------------------------------------Temporarily Store Expense So It Can Be Displayed One Last Time----------------------------------------//
            // Store the expense before removing it, so we can display to the user which expense was removed
            Expense removedExpense = expenses[index];


            //----------------------------------------Finally Remove The Expense----------------------------------------//
            // Remove the expense at the index selected
            expenses.RemoveAt(index);
            Console.Clear();
            Console.WriteLine($"'{removedExpense.ExpenseName}' has been removed");            

        } // End of RemoveExpense() method







        // When called, this method will allow the user to update an existing expense
        public void UpdateExpense()
        {
            //----------------------------------------Making Sure Expense List Is Not Currently Empty----------------------------------------//
            // Check if list is empty. Even though this is in DisplayExpences(), it is needed here otherwise...
            // ...the code will run even if there are no expenses
            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses to update");               
                return;
            }


            //----------------------------------------Selecting An Expense To Update----------------------------------------//
            // Display all expenses so user can choose which to update
            DisplayExpenses();
            Console.WriteLine();
            Console.Write("Enter the number of the expense you wish to update: ");
            int update;


            // Error handling if the format is wrong and if the entered number is far too large
            try
            {
                update = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid number");                
                return;
            }
            catch (OverflowException)
            {
                Console.Clear();
                Console.WriteLine("Number is too large");                
                return;
            }
            Console.WriteLine();


            //----------------------------------------Converting User Input Into Index Selection----------------------------------------//
            // Convert the user's choice into the proper index
            int updatedIndex = update - 1;


            // Make sure the user has entered a valid index
            if ((updatedIndex < 0) || updatedIndex >= expenses.Count)
            {
                Console.Clear();
                Console.WriteLine("Invalid expense number");
                
                return;
            }


            //----------------------------------------Temporarily Store Old Expense Details So The Change Can Be Viewed----------------------------------------//
            // Store old values for confirmation message at end
            string oldName = expenses[updatedIndex].ExpenseName;
            decimal oldAmount = expenses[updatedIndex].Amount;


            //----------------------------------------User Will Enter The New Expense Details----------------------------------------//
            // Prompt user to update the name of the expense
            Console.Clear();
            Console.WriteLine("Enter the updated name for the expense:");
            string newName = Console.ReadLine();
            if (string.IsNullOrEmpty(newName))
            {
                Console.Clear();
                Console.WriteLine("Expense name cannot be empty");                
                return;
            }
            Console.WriteLine();


            // Prompt user to update the cost of the expense
            Console.WriteLine("Enter the updated expense cost:");


            // Error handling to make sure the amount is above 0, is in the right format, and the number is not too large
            try
            {
                // Will check for and remove any $ symbols
                string userInput = Console.ReadLine();
                userInput = userInput.Replace("$", "");

                decimal newAmount = Convert.ToDecimal(userInput);

                // Make sure input is above 0
                if (newAmount <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Expense amount must be greater than zero");
                    Console.WriteLine();
                    return;
                }
                Console.WriteLine();


                //----------------------------------------Finally Update The Expense----------------------------------------//
                // Update the existing expense
                expenses[updatedIndex].ExpenseName = newName;
                expenses[updatedIndex].Amount = newAmount;
                Console.WriteLine($"'{oldName}' '${oldAmount}' has been updated to '{newName}' '${newAmount}'");                


            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Invalid amount entered");                
                return;
            }
            catch (OverflowException)
            {
                Console.Clear();
                Console.WriteLine("Amount is too large");
                return;
            }

        } // End of UpdateExpense() method







        // When called, this method will display all current expenses, as well as total expenses and remaining savings
        public void DisplayExpenses()
        {
            //----------------------------------------Making Sure Expense List Is Not Currently Empty----------------------------------------//
            // Check if list is empty
            if (expenses.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No expenses found!");                
                return;
            }


            //----------------------------------------Display All Expenses Under Each Expense Category----------------------------------------//
            // Display all food expenses and assign number
            Console.WriteLine("----- Food Expenses -----");
            foreach (Expense expense in expenses)
            {
                if (expense is FoodExpense)
                {
                    Console.WriteLine($"{expenses.IndexOf(expense) + 1}. {expense.ExpenseName} - ${expense.Amount:F2}");
                }
            }
            Console.WriteLine();


            // Display all travel expenses and assign number
            Console.WriteLine("----- Travel Expenses -----");
            foreach (Expense expense in expenses)
            {
                if (expense is TravelExpense)
                {
                    Console.WriteLine($"{expenses.IndexOf(expense) + 1}. {expense.ExpenseName} - ${expense.Amount:F2}");
                }
            }
            Console.WriteLine();


            // Display all luxury expenses and assign number
            Console.WriteLine("----- Luxury Expenses -----");
            foreach (Expense expense in expenses)
            {
                if (expense is LuxuryExpense)
                {
                    Console.WriteLine($"{expenses.IndexOf(expense) + 1}. {expense.ExpenseName} - ${expense.Amount:F2}");
                }
            }
            Console.WriteLine();


            // Display all bills expenses and assign number
            Console.WriteLine("----- Bills Expenses -----");
            foreach (Expense expense in expenses)
            {
                if (expense is BillsExpense)
                {
                    Console.WriteLine($"{expenses.IndexOf(expense) + 1}. {expense.ExpenseName} - ${expense.Amount:F2}");
                }
            }

        } // End of DisplayExpenses() method







        // When called, this method will calculate the total expenses and allow them to be displayed
        public decimal CalculateTotalExpenses()
        {
            // This gets called in Main as part of the Display Expenses case
            // Variable to calculate total expenses is reset to 0 each time
            decimal totalExpenses = 0;


            foreach (Expense expense in expenses)
            {
                totalExpenses += expense.Amount;
            }


            return totalExpenses;

        } // End of CalculateTotalExpenses() method







        // When called, this method will calculate the remaining savings by subtracting total expenses and total goal payments
        public decimal CalculateRemainingSavings()
        {
            // This gets called in Main as part of the Display Expenses case, and in the methods AddSavings() and Goals()
            // Remaining Savings = The savings the user has added in total - expenses and goal payments
            decimal remainingSavings = savings - CalculateTotalExpenses() - CalculateTotalGoalPayments();


            return remainingSavings;

        } // End of CalculateRemainingSavings() method







        // When called, this method will calculate the total goal payments made
        public decimal CalculateTotalGoalPayments()
        {
            // This gets called in the above method CalculateRemainingSavings() and in Goals()
            // Variable to calculate total goal payments is reset to 0 each time
            decimal totalGoalPayments = 0;


            foreach (Goals goal in goals)
            {
                totalGoalPayments += goal.AmountPaid;
            }


            return totalGoalPayments;

        } // End of CalculateTotalGoalPaymenrs() method







        // When called, this method will allow the user to search for expenses by name, amoung, or category
        public void SearchExpenses()
        {
            //----------------------------------------Making Sure Expense List Is Not Currently Empty----------------------------------------//
            // Check if list is empty
            if (expenses.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No expenses available to search");                
                return;
            }


            //----------------------------------------User Will Select Which Method They Want To Search By----------------------------------------//
            // Prompt user to pick a method to search by
            Console.Clear();
            Console.WriteLine("Choose a method to search by:");
            Console.WriteLine("1. Expense Name");
            Console.WriteLine("2. Expense Amount");
            Console.WriteLine("3. Expense Category");
            Console.WriteLine();


            // Convert user input to lowercase for code simplification
            string searchChoice = Console.ReadLine().ToLower();


            // Variable that controls the logic for whether or not a matching expense is found
            bool found = false;


            switch (searchChoice)
            {
                case "1" or "expense name" or "name":
                    //----------------------------------------User Has Chosen To Search By Expense Name----------------------------------------//
                    Console.Clear();
                    Console.WriteLine("Enter the expense name:");
                    string searchName = Console.ReadLine().ToLower();
                    Console.Clear();


                    // Search through all expenses in the list by name
                    for (int i = 0; i < expenses.Count; i++)
                    {
                        // If the expense name matches one found in the list, display it and set bool variable to true
                        if (expenses[i].ExpenseName.ToLower().Contains(searchName))
                        {
                            Console.WriteLine($"{i + 1}. {expenses[i].ExpenseName} - ${expenses[i].Amount}");
                            
                            found = true;
                        }
                    }
                    break;


                case "2" or "expense amount" or "amount":
                    //----------------------------------------User Has Chosen To Search By Expense Amount----------------------------------------//
                    Console.Clear();
                    Console.WriteLine("Enter the expense amount:");

                    // Error handling to make sure the amount is above 0, is in the right format, and the number is not too large
                    try
                    {
                        // Will check for and remove any $ symbols. Initialize variable with user's input
                        string inputAmount = Console.ReadLine();
                        inputAmount = inputAmount.Replace("$", "");


                        // Convert the corrected input into decimal
                        decimal searchAmount = Convert.ToDecimal(inputAmount);
                        Console.Clear();


                        // Make sure input is above 0
                        if (searchAmount <= 0)
                        {                            
                            Console.WriteLine("Expense amount must be greater than zero");
                            Console.WriteLine();
                            break;
                        }                        


                        // Search through all expenses in the list by amount
                        for (int i = 0; i < expenses.Count; i++)
                        {
                            // If the expense amount matches one found in the list, display it and set bool variable to true
                            if (expenses[i].Amount == searchAmount)
                            {
                                Console.WriteLine($"{i + 1}. {expenses[i].ExpenseName} - ${expenses[i].Amount}");
                                
                                found = true;
                            }
                        }


                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid amount entered");
                        Console.WriteLine();
                        return;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Amount is too large");
                        Console.WriteLine();
                    }
                    break;


                case "3" or "Expense Category" or "expense category" or "Category" or "category":
                    //----------------------------------------User Has Chosen To Search By Expense Category----------------------------------------//
                    // Prompt user to pick a category of expense
                    Console.Clear();
                    Console.WriteLine("Choose a category:");
                    Console.WriteLine("1. Food");
                    Console.WriteLine("2. Travel");
                    Console.WriteLine("3. Luxury");
                    Console.WriteLine("4. Bills");
                    Console.WriteLine();


                    // Initialize variable with user's input to enable switch case
                    string categorySearch = Console.ReadLine();
                    Console.Clear();


                    // Search through all expenses in each expense category
                    for (int i = 0; i < expenses.Count; i++)
                    {
                        // Variable that controls the logic for whether or not a matching expense category is found
                        bool match = false;

                        switch (categorySearch)
                        {
                            case "1" or "Food" or "food":                                
                                if (expenses[i] is FoodExpense)
                                {
                                    match = true;
                                }
                                break;


                            case "2" or "Travel" or "travel":
                                if (expenses[i] is TravelExpense)
                                {
                                    match = true;
                                }
                                break;


                            case "3" or "Luxury" or "luxury":
                                if (expenses[i] is LuxuryExpense)
                                {
                                    match = true;
                                }
                                break;


                            case "4" or "Bills" or "bills":
                                if (expenses[i] is BillsExpense)
                                {
                                    match = true;
                                }
                                break;


                            default:
                                Console.WriteLine("Invalid category selection");
                                Console.WriteLine();
                                return;

                        }


                        // If the expense is found, display it and set bool variable to true
                        if (match)
                        {
                            Console.WriteLine($"{i + 1}. {expenses[i].ExpenseName} - ${expenses[i].Amount:F2}");
                            found = true;                            
                        }
                    }
                    break;


                default:
                    Console.Clear();
                    Console.WriteLine("Invalid search option");
                    return;

            }


            // If no matches are found, inform user that none were found
            if (!found)
            {
                Console.WriteLine("No matching expenses found!");                
            }


        } // End of SearchExpenses() method







        // When called, this method will allow the user to add savings to a pool
        public void AddSavings()
        {
            //----------------------------------------Adding Savings----------------------------------------//
            Console.Clear();
            Console.WriteLine("-----Adding To Savings-----");
            Console.Write("Enter the amount you wish to add: ");


            // Error handling to make sure the amount is in the right format, and the number is not too large
            try
            {
                // Will check for and remove any $ symbols. Initialize variable with user's input
                string savingsInput = Console.ReadLine();
                savingsInput = savingsInput.Replace("$", "");


                // Convert the corrected input into decimal
                decimal addSavings = Convert.ToDecimal(savingsInput);    
                

                // Add the new amount of savings to the total pool
                savings = savings + addSavings;


                // Display the total pool of savings
                Console.WriteLine($"Your current total savings is: ${CalculateRemainingSavings()}");
                Console.WriteLine();


            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Invalid amount entered");
                Console.WriteLine();
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine();
                Console.WriteLine("Amount is too large");
                Console.WriteLine();
            }

        } // End of AddSavings() method     







        // When called, this method will allow the user to interact with the Goals Menu
        public void Goals()
        {
            // Declare and initialzie variable to enable do/while loop and switch case
            Console.Clear();
            string goalMenu = "";


            do
            {               
                // Prompt user to make a selection
                Console.WriteLine("Choose one of the following options: ");
                Console.WriteLine("1. Add Goals");
                Console.WriteLine("2. View Goals");
                Console.WriteLine("3. Dedicate Funds");
                Console.WriteLine("4. Remove Goals");
                Console.WriteLine("5. Exit");
                Console.WriteLine();


                // Reinitialize variable and convert user input to lowercase for code simplification
                string goalChoice = Console.ReadLine().ToLower();


                switch (goalChoice)
                {
                    case "1" or "add goals" or "add":
                        //----------------------------------------Creating Goal----------------------------------------//
                        // Prompt user to enter the name of the goal and initialize variable
                        Console.Clear();
                        Console.WriteLine("Please type the name of your goal: ");
                        string goalName = Console.ReadLine();


                        // Make sure the input is not empty
                        if (string.IsNullOrEmpty(goalName))
                        {
                            Console.Clear();
                            Console.WriteLine("Goal name cannot be empty!");
                            Console.WriteLine();
                            break;
                        }


                        // Prompt user to enter the target cost of the goal and initialize variable
                        Console.WriteLine();
                        Console.Write($"Enter the estimated cost for '{goalName}': ");
                        try
                        {
                            // Will check for and remove any $ symbols. Initialize variable with user's input
                            string goalInput = Console.ReadLine();
                            goalInput = goalInput.Replace("$", "");


                            // Convert the corrected input into decimal
                            decimal goalCost = Convert.ToDecimal(goalInput);


                            // Make sure input is above 0
                            if (goalCost <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Goal amount must be greater than zero!");
                                Console.WriteLine();
                                return;
                            }


                            //----------------------------------------Adding The New Goal To The Goal List----------------------------------------//
                            Goals newGoal = new Goals(goalName, goalCost);
                            goals.Add(newGoal);
                            Console.Clear();
                            Console.WriteLine("New Goal has been added!");


                        }
                        catch (FormatException)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid amount entered");                            
                        }
                        catch (OverflowException)
                        {
                            Console.Clear();
                            Console.WriteLine("Amount is too large");                            
                        }                        
                        Console.WriteLine();
                        break;


                    case "2" or "view goals" or "goals" or "view":
                        //----------------------------------------Display Goals----------------------------------------//
                        // Check if list is empty
                        Console.Clear();                        
                        if (goals.Count == 0)
                        {                            
                            Console.WriteLine("No goals found!");
                            Console.WriteLine();
                            break;
                        }


                        // Display all goals and assign number. Also show how much has been paid towards each goal
                        Console.WriteLine("-----Displaying Goals-----");
                        foreach (Goals goal in goals)
                        {
                            Console.WriteLine($"{goals.IndexOf(goal) + 1}. {goal.GoalName} - ${goal.AmountPaid:F2}/${goal.GoalAmount:F2}");

                            // If the goal has been reached, tag it with 'COMPLETED'
                            if (goal.AmountPaid >= goal.GoalAmount)
                            {
                                Console.WriteLine("-----COMPLETED-----");
                            }
                        }
                        Console.WriteLine();                      
                        break;


                    case "3" or "dedicate funds" or "add funds" or "funds":
                        //----------------------------------------Dedicate Funds Towards Goal----------------------------------------//
                        // Check if list is empty
                        Console.Clear();                        
                        if (goals.Count == 0)
                        {
                            Console.WriteLine("No goals available");
                            Console.WriteLine();
                            break;
                        }


                        // Display goals and the current amount remaining on the goal
                        Console.WriteLine("-----Current Goals-----");
                        for (int i = 0; i < goals.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {goals[i].GoalName} - ${goals[i].AmountPaid:F2}/${goals[i].GoalAmount:F2}");
                        }


                        // Prompt user to select a goal
                        Console.WriteLine();
                        Console.WriteLine("Select a goal to dedicate funds to:");

                        try
                        {
                            // Convert user's input into a valid index selection
                            int goalChoiceNum = Convert.ToInt32(Console.ReadLine());
                            int goalIndex = goalChoiceNum - 1;
                            Console.Clear();


                            // Error handling if the user has made an invalid selection
                            if (goalIndex < 0 || goalIndex >= goals.Count)
                            {                                
                                Console.WriteLine("Invalid goal selection");
                                Console.WriteLine();
                                break;
                            }


                            // Prompt user to to dedicate funds                            
                            Console.Write("Enter amount to dedicate: ");


                            // Will check for and remove any $ symbols. Initialize variable with user's input
                            string goalChoiceInput = Console.ReadLine();
                            goalChoiceInput = goalChoiceInput.Replace("$", "");


                            // Convert the corrected input into decimal
                            decimal goalChoiceAmount = Convert.ToDecimal(goalChoiceInput);


                            // Calculate the amount remaining on the goal
                            decimal remainingGoalAmount = goals[goalIndex].GoalAmount - goals[goalIndex].AmountPaid;
                            Console.Clear();


                            // Prevent the user from over-dedicating funds
                            if (goalChoiceAmount > remainingGoalAmount)
                            {
                                Console.Clear();
                                Console.WriteLine($"Too much! Only ${remainingGoalAmount:F2} is needed to complete this goal!");
                                Console.WriteLine();
                                break;
                            }


                            // Inform the user if they do not have enough savings to dedicate that amount of funds
                            if (goalChoiceAmount > CalculateRemainingSavings())
                            {
                                Console.Clear();
                                Console.WriteLine("You do not have enough savings to pay this amount");
                                Console.WriteLine();
                                break;
                            }
                                  
                            
                            // Dedicate the chosen funds to the desired goal
                            goals[goalIndex].AmountPaid += goalChoiceAmount;


                            // Display message showing that funds were dedicated, and display the current goal progress                            
                            Console.WriteLine($"${goalChoiceAmount:F2} dedicated to '{goals[goalIndex].GoalName}'");
                            Console.WriteLine();
                            Console.WriteLine($"Goal progress: ${goals[goalIndex].AmountPaid:F2}/{goals[goalIndex].GoalAmount:F2}");


                            // If the goal amount is reached, display a congratulations message
                            if (goals[goalIndex].AmountPaid >= goals[goalIndex].GoalAmount)
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Congratulations! You have completed your goal: {goals[goalIndex].GoalName}");
                                Console.WriteLine();
                            }


                            // Display the remaining savings 
                            Console.WriteLine($"Remaining savings: ${CalculateRemainingSavings():F2}");

                        }
                        catch (FormatException)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid amount entered");
                            Console.WriteLine();
                            break;
                        }
                        catch (OverflowException)
                        {
                            Console.Clear();
                            Console.WriteLine("Amount is too large");
                            Console.WriteLine();
                            break;
                        }
                        Console.WriteLine();
                        break;


                    case "4" or "remove" or "delete" or "remove goals":
                        //----------------------------------------Remove Goal----------------------------------------//
                        // Check if list is empty
                        Console.Clear();                        
                        if (goals.Count == 0)
                        {
                            Console.WriteLine("No goals to remove");
                            Console.WriteLine();
                            break;
                        }


                        // Display all goals and assign number
                        foreach (Goals goal in goals)
                        {
                            Console.WriteLine($"{goals.IndexOf(goal) + 1}. {goal.GoalName} - ${goal.GoalAmount:F2}");
                        }


                        // Prompt user to make a selection
                        Console.WriteLine();
                        Console.Write("Enter the number of the goal you wish to remove: ");
                        int removalChoice;


                        // Error handling if the format is wrong and if the entered number is far too large
                        try
                        {
                            removalChoice = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                        }
                        catch (FormatException)
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter a valid number");   
                            Console.WriteLine();
                            break;
                        }
                        catch (OverflowException)
                        {
                            Console.Clear();
                            Console.WriteLine("Number is too large");   
                            Console.WriteLine();
                            break;
                        }
                        Console.WriteLine();


                        // Convert the user's choice into the proper index 
                        int removalIndex = removalChoice - 1;


                        // Make sure the user has entered a valid index
                        if (removalIndex < 0 || removalIndex >= goals.Count)
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid goal number");
                            Console.WriteLine();
                            break;
                        }


                        // Store the goal before removing it, so we can display to the user which goal was removed
                        Goals removedGoal = goals[removalIndex];


                        // Remove the goal at the index selected. Display the removed goal one last time
                        goals.RemoveAt(removalIndex);
                        Console.Clear();
                        Console.WriteLine($"'{removedGoal.GoalName}' has been removed");
                        Console.WriteLine();                        
                        break;


                    case "5" or "exit" or "back":
                        // User has chosen to exit the menu
                        Console.Clear();
                        goalMenu = "5";
                        break;


                    default:
                        // User has made an invalid choice
                        Console.Clear();
                        Console.WriteLine("Please make a valid choice");
                        Console.WriteLine();
                        break;

                }

            } while (goalMenu != "5");
            // Satisfies do/while exit criteria when goalMenu variable is equal to "5"

        } // End of Goals() method    


    } // End of User class
} // End of namespace
