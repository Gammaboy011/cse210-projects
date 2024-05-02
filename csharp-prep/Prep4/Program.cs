/* Header
    Prep4, WK2
    --Isaac Madrid--
    Listing Numbers
    05/02/24
    */
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new();
        int number;
        Console.WriteLine("Enter a list of numbers, type '0' when finished");
        while (true){
            Console.Write("Type number: "); // User inputs a number.
            number = int.Parse(Console.ReadLine());
            if (number != 0) { // Skips to end the loop after '0' is typed
                numbers.Add(number);
            }
            else {
                break;
            }
        }
        int sum_Num = numbers.Sum(); // Store sum of numbers
        double avg_Num = numbers.Average(); // Store average of list.
        int big_Num = numbers.Max(); // Store highest number.
        int small_Positve = big_Num; // smallest positve number starts w/ highest number befor measurment.
        foreach (int num in numbers) { // finds the smallest positve.
            if (num > 0 && num < small_Positve) {
                small_Positve = num;
            }
        }
        List<int> sortedNumbers = numbers.OrderBy(num => num).ToList(); // Sort the list from smallest to largest.
        Console.WriteLine($"\nThe sum is: {sum_Num}\nThe average is: {avg_Num}\nThe largest number is: {big_Num}\nThe smallest positive number is: {small_Positve}");
        Console.WriteLine("\nThe sorted list is: ");
        foreach (int num in sortedNumbers)
        {
            Console.WriteLine(num); // Print the list.
        }
    }
}