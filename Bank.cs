/// <summary>
/// Represents a bank app which allows user to login and signup.
/// Uses a List to store User objects.
/// </summary>
class Bank
{
    // Use a List to store User objects so we can add and remove them easily.
    public List<User> users = new List<User>();

    // Runs the login logic and returns true if the login was successful.
    public bool Login(string username, string password)
    {
        // If the password on the user object matching the email matches the passed in password, set loged in and return true
        if (validateLogin(username, password))
        {
            Console.WriteLine("Login Successful!");
            return true;
        }
        else
        {
            Console.WriteLine("Login failed. Invalid email or password.");
            return false;
        }
    }

    // Validate the passed in username and password.
    bool validateLogin(string username, string password)
    {
        // Use the find LINQ expression to get the user with the matching username
        // LINQ expressions siimplify the process of searching through a list by encapsulating a loop into a single line.
        // In this case, user is the variable name we want to use to represent each item in the list and the 
        if (users.Any(user => username == user.Username))
        {

            User? user = users.Find(user => username == user.Username);

            // If the user is null, the username was not found in the list.
            if (user == null)
            {
                return false;
            }

            // If we get here, the username was found in the list and we can check the password.
            if (password == user.Password)
            {
                // 
                user.LoggedIn = true;
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Runs the signup logic to collect user input and create a new User object in the Bank's users List.
    /// </summary>
    public void Signup()
    {
        string? choice;
        do
        {
            Console.WriteLine("Would you like to add a new user (Y/N)");
            choice = Console.ReadLine();

            if (choice == "y")
            {
                // Initialise a new User object to store the user's input.
                User newUser = new User();

                // First Name user input logic.
                Console.WriteLine("Enter your first name:");
                string? firstName;
                firstName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(firstName) || firstName.Any(char.IsDigit))
                {
                    do
                    {
                        Console.WriteLine("You must enter a valid name.");
                        firstName = Console.ReadLine();

                    } while (string.IsNullOrWhiteSpace(firstName) || firstName.Any(char.IsDigit));
                }

                // Surname user input logic.
                Console.WriteLine("Enter your last name:");
                string? lastName;
                lastName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(lastName) || lastName.Any(char.IsDigit))
                {
                    do
                    {
                        Console.WriteLine("Please enter a valid name.");
                        lastName = Console.ReadLine();

                    } while (string.IsNullOrWhiteSpace(lastName) || lastName.Any(char.IsDigit));
                }

                // Age user input logic.
                int age;
                do
                {
                    Console.WriteLine("Enter your age:");
                    string? AgeInput = Console.ReadLine();

                    if (int.TryParse(AgeInput, out age))
                    {
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Please enter a valid age.");
                    }
                } while (true);

                // Phone Number user input logic.
                int phoneNumber;
                do
                {
                    Console.WriteLine("Enter your phone number:");
                    string? PhoneNumberInput = Console.ReadLine();

                    if (int.TryParse(PhoneNumberInput, out phoneNumber))
                    {
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Please enter a valid phone number.");
                    }
                } while (true);


                // Email user input logic.
                Console.WriteLine("Enter your email address:");

                string? email = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
                {
                    do
                    {
                        Console.WriteLine("You must enter a valid email address.");
                        email = Console.ReadLine();

                    } while (string.IsNullOrWhiteSpace(email) || !email.Contains('@'));
                }

                // Username user input logic.
                // TODO: Need to add unique username check!!
                Console.WriteLine("Enter a unique Username:");
                string? username;
                username = Console.ReadLine();

                bool ExistingUser = false;

                foreach (User user in users)
                {
                    if (user.Username == username)
                    {
                        ExistingUser = true;
                        break;
                    }
                }
                if (ExistingUser)
                {
                    do
                    {
                        Console.WriteLine("The Username " + username + " already exists, please try again.");
                        username = Console.ReadLine();

                        ExistingUser = false;
                        foreach (User users in users)
                        {
                            if (users.Username == username)
                            {
                                ExistingUser = true;
                                break;
                            }
                        }
                    } while (ExistingUser);
                }


                //Password user input logic
                Console.WriteLine("Enter a password:");
                string? password;
                password = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(password))
                {
                    do
                    {
                        Console.WriteLine("Enter a password:");
                        password = Console.ReadLine();
                    } while (string.IsNullOrEmpty(password));
                }

                // Add a new user with the input data.
                newUser = new User(firstName, lastName, age, phoneNumber, email, username, password);

                users.Add(newUser);
                Console.WriteLine("New user added: " + firstName + " " + lastName + " " + age + " "
                    + phoneNumber + " " + email + " " + username + " " + password);

            }
            else if (choice == "n")
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter either (Y/N)");
            }

        } while (choice != "n");
    }

    public void CheckCredit(User currentUser)
    {
        Console.WriteLine($"Your current balance is ${currentUser.Balance}");
    }

    public void DepositCredit(User currentUser)
    {
        Console.WriteLine("How much would you like to deposit?: $");
        double amountDeposit = Convert.ToDouble(Console.ReadLine());
        currentUser.Balance += amountDeposit;
    }

    public void WithdrawCredit(User currentUser)
    {
        Console.WriteLine("Enter the amount for withdrawal: $");
        double withdrawAmount = Convert.ToDouble(Console.ReadLine());

        if (withdrawAmount <= currentUser.Balance)
        {
            // If the amount is correct, reduce the current user's balance.
            currentUser.Balance -= withdrawAmount;
            Console.WriteLine("Credit withdrawal succesful!");
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }

    public void TransferCredit(User currentUser)
    {
        Console.WriteLine("Enter the recepient's email: ");
        string? recepientEmail = Console.ReadLine();

        // Check if the email is null or whitespace.
        if (String.IsNullOrWhiteSpace(recepientEmail))
        {
            Console.WriteLine("Email cannot be empty.");
            return;
        }

        // Check if the recepient email exists in the list of users.
        User? recepient = users.Find(user => recepientEmail == user.Email);

        if (recepient != null)
        {
            // If the user is found, ask for the amount to transfer.
            Console.WriteLine("Enter the amount to transfer: $");
            double amountTransfer = Convert.ToDouble(Console.ReadLine());

            if (amountTransfer <= currentUser.Balance)
            {
                // If the amount is correct, reduce the current user's balance and increase the recepient's balance.
                currentUser.Balance -= amountTransfer;
                recepient.Balance += amountTransfer;
                Console.WriteLine("Transfer successful!");
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }
        else
        {
            Console.WriteLine("Recepient not found.");
        }
    }


}