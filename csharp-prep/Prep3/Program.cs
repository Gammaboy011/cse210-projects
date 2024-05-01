using System;
/*
Prep3, WK3
--Isaac Madrid--
Number Guessing Game
05/01/24
*/
class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();   //creates a Random class instance, and uses it to get the next integer in a given range.
        int number = random.Next(1, 101); // // sets the range between 1 & 100.
        int numberOfGuesses = 0; // sets count to 0.
        bool game = true; // sets the while loop to true.
        string playAgain = ""; // vareible stores input for "Yes || No" response.

        while (game)
        {
            Console.Write("\nPlease guess a number between 1 and 100: ");
            int guess = int.Parse(Console.ReadLine());
            numberOfGuesses++; // increase count by +1

            if (guess == number) // guess matches the number.
            {
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"It took you {numberOfGuesses} guesses!\n");
                Console.Write("Would you like to play again? 'YES'|'NO' ");
                playAgain = Console.ReadLine().ToLower();   // {.ToLower();} sets all characters letters in string to lowercase.
                
                if (playAgain == "no")
                {
                    game = false; // ends the while loop.
                }
                else // resets variables to default.
                {
                    number = random.Next(1, 101);
                    numberOfGuesses = 0;
                }
            }
            else
            {
                if (guess > number)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("Higher");
                }
            }
        } Console.WriteLine("\nThanks for playing!"); // {\n} create a new line in text.
    }
}