using System;

namespace FinalProject_LG_JL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // IT5484 Programming I, Final Project
            // Expense Tracking Application
            // Jesse Lockwood


            //----------------------------------------Login Menu----------------------------------------//
            Console.WriteLine("----------------------Welcome to Track-o-----------------------");
            Console.WriteLine("---The Best Expense Tracking App in the Southern Hemisphere!---");
            Console.WriteLine();
                                    
            
            // Instantiate a new login 
            LoginManager login = new LoginManager();


            // Declare and initialize variable to enter do/while loop
            string loginChoice = "";

                       
            // Do/while loop for handling login page switch case
            do
            {
                // Prompt user to make a selection
                Console.WriteLine("Choose one of the following options:");
                Console.WriteLine("1. Register New User");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit Application");
                Console.WriteLine();


                // Reinitialize variable for user's menu choice
                loginChoice = Console.ReadLine().ToLower();
                Console.Clear();


                switch (loginChoice)                              
                {
                    case "1" or "register" or "register new user":                        
                        // Call to method Register in class LoginManager
                        login.Register();                        
                        break;


                    case "2" or "login":                        
                        // Call to method Login in class LoginManager with the variable currentUser                        
                        User currentUser = login.Login();


                        // If the user is stored in the list, the user will be returned, and the ExpenseMenu method can be accessed
                        if (currentUser != null)
                        {
                            ExpenseMenu(currentUser);
                        }                        
                        break;


                    case "3" or "exit" or "exit application":
                        // User wishes to exit the application. Goodbye message will display once leaving the do/while statement
                        loginChoice = "3";
                        break;


                    default:
                        // User has not made a valid choice
                        Console.WriteLine("Please make a valid choice");
                        Console.WriteLine();
                        break;

                }
            }
            while (loginChoice != "3");
            // Satisfies do/while loop exit condition when loginChoice is equal to 3. Exits application            
            Console.Clear();
            Console.WriteLine("Thank you for using Track-o!");
            Console.WriteLine("Goodbye!");


        } // End of Main






        //----------------------------------------Expense Menu----------------------------------------//
        // Method to handle the Expense Tracking 'heart' of the application
        static void ExpenseMenu(User currentUser)
        {
            // Display welcome message            
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Welcome, {currentUser.Username}");
            Console.WriteLine("--------------------------------");
            Console.WriteLine();


            // Declare variable for Expense Menu choice
            string menuChoice;


            // Do/while statement to handle Main Menu
            do
            {
                // Prompt user to select one of the following options
                Console.WriteLine("What can I help you with today?");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. Add Savings");
                Console.WriteLine("3. Remove Expense");
                Console.WriteLine("4. Update Expense");
                Console.WriteLine("5. Display All Expenses");
                Console.WriteLine("6. Search Expenses");
                Console.WriteLine("7. Goals");
                Console.WriteLine("8. Logout");
                Console.WriteLine();


                // Declare and initialize user input. Convert to lowercase
                menuChoice = Console.ReadLine().ToLower();


                switch (menuChoice)
                {
                    case "1" or "add" or "add expense":
                        // Call to method AddExpense in User class
                        Console.Clear();
                        currentUser.AddExpense();
                        Console.WriteLine();
                        break;


                    case "2" or "savings" or "add savings":
                        // Call to method AddSavings in User class
                        currentUser.AddSavings();
                        break;


                    case "3" or "remove" or "remove expense":
                        // Call to method RemoveExpense in User class
                        Console.Clear();
                        currentUser.RemoveExpense();
                        Console.WriteLine();
                        break;


                    case "4" or "update" or "update expense":
                        // Call to method UpdateExpense in User class
                        Console.Clear();
                        currentUser.UpdateExpense();
                        Console.WriteLine();
                        break;


                    case "5" or "display" or "display all expenses":
                        // Call to method DisplayExpenses in User class
                        Console.Clear();
                        currentUser.DisplayExpenses();
                        Console.WriteLine();


                        // Call to methods CalculateTotalExpenses and CalculateRemainingSavings in User class to display totals. Force to two decimal places
                        Console.WriteLine($"Total Expenses: ${currentUser.CalculateTotalExpenses():F2}");
                        Console.WriteLine($"Remaining Savings: ${currentUser.CalculateRemainingSavings():F2}");
                        Console.WriteLine();
                        break;


                    case "6" or "search" or "search expenses":
                        // Call to method SearchExpenses in User class
                        currentUser.SearchExpenses();
                        Console.WriteLine();
                        break;


                    case "7" or "goals":
                        // Call to method Goals in User class
                        currentUser.Goals();
                        break;


                    case "8" or "logout":
                        // User wants to logout
                        menuChoice = "8";
                        break;


                    default:
                        // Handle invalid menu choice
                        Console.Clear();
                        Console.WriteLine("Please make a valid choice");
                        Console.WriteLine();
                        break;

                }
            }
            while (menuChoice != "8");
            // Satisfies do/while loop exit condition when menuChoice is equal to 6. Returns to login screen
            Console.Clear();
            Console.WriteLine("Logging out...");
            Console.WriteLine("Thank you for using Track-o!");
            Console.WriteLine();


        } // End of ExpenseMenu() method       


    } // End of Program class
} // End of namespace
