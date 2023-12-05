/*
 * Assessment 2 - Bank App
 * 
 * Written by: Daniel Potter A00124220, Michael Rourke A00127958, and Rainier Martin Enriquez A00122886
 * Date: 02/11/23
 */

// Required to use Lists
// Required for LINQ expressions
/// <summary>
/// Represents a user of the bank.
/// Initialised with a username and password.
/// </summary>
class User
{
    // Used for signup.
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int PhoneNumber { get; set; }
    public string Email { get; set; }

    // Used for login and signup.
    public string Username { get; set; }
    public string Password { get; set; }
    public bool LoggedIn { get; set; }

    public double Balance { get; set; }

    // Basic constructor for the User class that initialises all properties to default values.
    public User()
    {
        FirstName = "";
        LastName = "";
        Age = 0;
        PhoneNumber = 0;
        Email = "";
        Username = "";
        Password = "";
    }

    // Constructor for the User class that takes the first name, last name, age, phone number, email, username and password.
    public User(string firstName, string lastName, int age,
        int phoneNumber, string email, string username, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        PhoneNumber = phoneNumber;
        Email = email;
        Username = username;
        Password = password;
    }
}
