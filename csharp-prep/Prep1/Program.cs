using System;

class Program
{
    static void Main(string[] args)
    {   // this is the Main function.
        // Console.WriteLine("Prep1 Assignment:");
        Console.Write("What is your first name? "); // First Name.
        string f_name = Console.ReadLine(); // "f_name" stores previous input-^
        Console.Write("What is your first name? "); // Last Name.
        string l_name = Console.ReadLine(); // "l_name" stores previous input-^
        Console.WriteLine(); // spacer
        Console.WriteLine($"Your name is {l_name}, {f_name} {l_name}."); 
        // should print "Your name is [Last Name], [First Name] [Last Name]."
    }
}