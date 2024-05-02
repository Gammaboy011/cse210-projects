/* Header
    Prep2, WK1
    --Isaac Madrid--
    Number Guessing Game
    04/30/24
    */
using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int grade = int.Parse(answer);

        string letter = "";
        
        if (grade >= 90)  // Logic for A grades
        {
            letter = "A";
        }
        else if (grade >= 80) // Logic for B grades
        {
            letter = "B";
        }
        else if (grade >= 70) // Logic for C grades
        {
            letter = "C";
        }
        else if (grade >= 60) // Logic for D grades
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        /* Rewrite all of the + - code here
        If the second charicter is >= 7 and grade < 90 and grade > 60: sign = '+'
         else if the second character is < 3 and grade > 60: sign = '-'
         else: sign = ''
        */
        char secondDigit = answer.Length > 1 ? answer[1] : '0'; // If the string has no second character, it assigns the character '0' to secondDigit.
        char sign = ' ';

        if (secondDigit >= '7' && grade < 93 && grade > 60)
        {
            sign = '+';
        }
        else if (secondDigit < '3' && grade > 60)
        {
            sign = '-';
        }
        else {
            sign = ' ';
        }

        Console.WriteLine($"Your grade is: {letter}{sign}");
        
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course! |_(*°o°*)_/");
        }
        else
        {
            Console.WriteLine("Stay focused!! You'll get it next time! (9__o) ");
        }

    }
}