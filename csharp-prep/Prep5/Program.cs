using System;
/* Header
    Prep5, WK2
    --Isaac Madrid--
    Functions
    05/02/24
    */
class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }
    static void DisplayWelcome () { // Displays the message, "Welcome to the Program!"
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName () { // Asks for and returns the user's name
        Console.WriteLine($"Please enter your name: ");
        String name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber () { // Asks for and returns the user's favorite number 
        Console.WriteLine("Please enter your number: ");
        int number = int.Parse(Console.ReadLine());
        return number; 
    }
    static int SquareNumber (int number) { // Accepts an integer as a parameter and returns that number squared.
        int square = number * number; // is their module for advanced math in C#?
        return square;
    }
    static void DisplayResult (string userName, int square ) { // Accepts the user's name and the squared number and displays them.
    Console.WriteLine($"Hello {userName}, the square of your number is {square}! ");
    }
}