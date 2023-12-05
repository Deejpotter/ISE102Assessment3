/*
 * Assessment 3 - Bank App
 * 
 * Written by: Daniel Potter A00124220, Michael Rourke A00127958, and Rainier Martin Enriquez A00122886
 * Date: 02/12/23
 */

using System;
// Required to use Lists
using System.Collections.Generic;
// Required for LINQ expressions
using System.Linq;

class Program
{
    // Initialise a Bank object to use throughout the program.
    static Bank bank = new Bank();

    // This is the entry point of the program which is called when the program is run.
    static void Main()
    {
        // Run the StartMenu method to start the main program loop.
        StartMenu();
    }

    /// <summary>
    /// Run the start menu which allows the user to login, signup or quit.
    /// Uses a switch statement inside a Do While loop to allow the user to keep trying until they quit by entering 3.
    /// </summary>
    static void StartMenu()
    {
        // Initialise a string to store the user's choice.
        string? choice;

        // Use a Do While loop because we want the menu to show before we test any logic.
        do
        {
            Console.WriteLine("Welcome to the Bank App!");
            Console.WriteLine("1. Login\n2. Signup\n3. Quit");
            Console.Write("Please select an option: ");
            // Read the next line from the console and assign it to the choice variable for checking.
            choice = Console.ReadLine();

            // Use a switch statement to run different code depending on the user's choice.
            switch (choice)
            {
                // Case 1 is the login option.
                case "1":
                    bool loggedIn = false;
                    while (!loggedIn)
                    {
                        // Get the username and password from the user.
                        Console.Write("Enter your username: ");
                        string? username = Console.ReadLine();
                        // If the username is null, continue to the next iteration of the loop.
                        if (username == null)
                        {
                            Console.WriteLine("Username cannot be null.");
                            continue;
                        }
                        Console.Write("Enter your password: ");
                        string? password = Console.ReadLine();
                        // If the password is null, continue to the next iteration of the loop.
                        if (password == null)
                        {
                            Console.WriteLine("Password cannot be null.");
                            continue;
                        }
                        // If the login method returns true, run the UserMenu method.
                        if (bank.Login(username, password))
                        {
                            loggedIn = true;
                            // Login successful, run the UserMenu method to start the user menu loop.
                            UserMenu();
                        }
                        else
                        {
                            // If the login fails, ask to login again.
                            Console.Write("Do you want to try again? y/n: ");
                            string? tryAgain = Console.ReadLine();
                            // If the answer is "y"
                            if (tryAgain == "y")
                            {
                                Console.WriteLine("Please enter a different username and password.");
                                // Continue to the next iteration of the loop.
                                continue;
                            }
                            else
                            {
                                // If the answer is anything else, break out of the loop back to the main menu.
                                break;
                            }
                        }
                    }
                    break;
                case "2":
                    bank.Signup();
                    break;
                case "3":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
            // Keep looping until the user enters the quit choice.
        } while (choice != "3");
    }

    /// <summary>
    /// Run the user menu which allows the user to view their balance, deposit, withdraw and transfer.
    /// Has placeholder functionality for now.
    /// </summary>
    static void UserMenu()
    {
        // Initialise a string to store the user's choice. 
        // We can use the same variable name as above because they are scoped to the methods.
        string? choice;

        do
        {
            Console.WriteLine("1. View Balance\n2. Deposit\n3. Withdraw\n4. Transfer\n5. Quit");
            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // TODO: Implement View Balance
                    Console.WriteLine("View Balance functionality coming soon.");
                    break;
                case "2":
                    // TODO: Implement Deposit
                    Console.WriteLine("Deposit functionality coming soon.");
                    break;
                case "3":
                    // TODO: Implement Withdraw
                    Console.WriteLine("Withdraw functionality coming soon.");
                    break;
                case "4":
                    // TODO: Implement Transfer
                    Console.WriteLine("Transfer functionality coming soon.");
                    break;
                case "5":
                    // Return instead of break so we go back to the start menu where this method was called.
                    Console.WriteLine("Returning to main menu...");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        } while (choice != "5");
    }

}
