using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_LG_JL
{
    internal class LoginManager
    {
        // Declare and initialize list to store all new/active users. The stored variables are objects of the User class
        private List<User> userList = new List<User>();



        // Method to add a new user to the list
        public void Register()
        {
            //----------------------------------------Username Creation----------------------------------------//
            // Prompt user to create a username. Declare and initialize variable for username
            Console.Clear();
            Console.Write("Choose a Username: ");
            string regUser = Console.ReadLine();

            // Make sure the username input is not empty. If it is, return to main menu
            if (string.IsNullOrEmpty(regUser))
            {
                Console.WriteLine();
                Console.WriteLine("Username cannot be empty!");
                Console.WriteLine();
                return;
            }


            //----------------------------------------Password Creation----------------------------------------//
            // Prompt user to create a password. Declare and initialize variable for password                        
            Console.Write("Choose a Password: ");
            string regPass = ReadPassword();
            Console.WriteLine();

            // Make sure the password input is not empty. If it is, return to main menu
            if (string.IsNullOrEmpty(regPass))
            {
                Console.WriteLine();
                Console.WriteLine("Password cannot be empty!");
                Console.WriteLine();
                return;
            }


            //----------------------------------------Making Sure The Username Is Available----------------------------------------//            
            // If username is not in use, inform user that the account has been created, then return to main menu. Else let them know it's already in use           
            foreach (User user in userList)
            {
                if (user.Username == regUser)
                {
                    // Username is already in use
                    Console.WriteLine();
                    Console.WriteLine("That username already exists!");
                    Console.WriteLine("Returning to Main Menu...");
                    Console.WriteLine();
                    return;
                }                   
            }


            //----------------------------------------Account Successfully Registered----------------------------------------//
            // Account is successfully created. Add the new user to the list, then return to Main Menu
            Console.Clear();
            Console.WriteLine("User registered successfully!");
            userList.Add(new User(regUser, regPass));
            Console.WriteLine("Returning to Main Menu...");
            Console.WriteLine();     


        } // End of Register() method







        // Method to check if login credentials are valid and allow login      
        public User Login()
        {
            //----------------------------------------Collect User Credentials----------------------------------------//
            // User will enter their username and password. Call to method ReadPassword() to hide user input with asterisks            
            Console.Clear();
            Console.Write("Please Enter Your Username: ");
            string loginUser = Console.ReadLine();
            Console.Write("Please Enter Your Password: ");
            string loginPass = ReadPassword();


            //----------------------------------------Login Successful, If Credentials Are Valid----------------------------------------//      
            // Uses foreach loop to check if the credentials are stored in the list. If they are, return the user
            foreach (User user in userList)
            {
                if (user.Username == loginUser && user.Password == loginPass)
                {
                    Console.Clear();                    
                    Console.WriteLine("Login successful!");
                    Console.WriteLine();
                    return user;
                }               
            }


            //----------------------------------------Login Failed, If Credentials Are Invalid----------------------------------------//
            // If credentials are not stored in the list, return null
            Console.Clear();
            Console.WriteLine("Invalid Username or Password!");
            Console.WriteLine("Returning to Main Menu...");
            Console.WriteLine();
            return null;


        } // End of Login() method






       
        // Method for reading password input and converting characters to asterisks
        public static string ReadPassword()
        {
            string input = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);


                // Stop reading when the user presses Enter
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }


                // Handle Backspace
                if (key.Key == ConsoleKey.Backspace)
                {
                    if (input.Length > 0)
                    {
                        // Move curser back, erase, move back again
                        input = input.Substring(0, input.Length - 1);
                        Console.Write("\b \b"); 
                    }
                }
                // Ignore other special control keys, accept normal characters
                else if (!char.IsControl(key.KeyChar))
                {
                    input += key.KeyChar;
                    Console.Write("*");
                }

            }
            return input;


        }//End of ReadPassword() method


    } // End of LoginManager class
} // End of namespace
