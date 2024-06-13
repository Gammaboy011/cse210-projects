using System;
/*
Additionally, creativity was included in the program by integrating a random prompt generator to display motivating messages and 
quotes for the user to reflect on as they quit the program. The Motivation Prompt class is a public class that returns a random 
value from a list of strings in the RandomPrompt() function. As soon as the user clicks quit, they are left with a mindful quote or 
message that is randomly displayed. */
class Program {
    static void Main(string[] args) {
        var program = new Program();
        Console.WriteLine("Mindfulness Exercise\n"); // Display the title
        program.DisplayMenu(); // Call the method to display the menu
        program.PromptReminder(); // Call the method to display a reminder
    }

    private Activity _currentActivity; // Field to hold the current activity
    public void DisplayMenu() {
        Console.Clear(); // Clear the console screen
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Quit");
        Console.Write("Choose an activity: ");
        int choice = int.Parse(Console.ReadLine()); // Read user choice
        Console.Clear(); // Clear the console screen
        ActivityOptions(choice); // Call the method to handle the chosen activity
    }

    private void ActivityOptions(int choice) {
        switch (choice) {
            case 1: // Breathing Activity
                _currentActivity = new BreathingActivity(
                    "Welcome to Breathing Activity\n",
                    "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.",
                    "Breathing Activity"
                );
                _currentActivity.Start();
                ((BreathingActivity)_currentActivity).GuideBreathing();
                _currentActivity.OnEnd();
                DisplayMenu(); // Display the menu again after the activity
                break; // required at the end of every case value.

            case 2: // Reflection Activity
                var prompts = new List<string> {
                    "---Think of a time when you stood up for someone else.---",
                    "---Think of a time when you did something really difficult.---",
                    "---Think of a time when you helped someone in need.---",
                    "---Think of a time when you did something truly selfless.---"
                };
                var questions = new List<string> {
                    "Why was this experience meaningful to you? ",
                    "Have you ever done anything like this before? ",
                    "How did you get started? ",
                    "How did you feel when it was complete? ",
                    "What made this time different than other times when you were not as successful? ",
                    "What is your favorite thing about this experience? ",
                    "What could you learn from this experience that applies to other situations? ",
                    "What did you learn about yourself through this experience? ",
                    "How can you keep this experience in mind in the future? ",
                };
                _currentActivity = new ReflectionActivity(
                    "Welcome to Reflection Activity ",
                    "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
                    prompts,
                    questions,
                    "Reflection Activity"
                );
                _currentActivity.Start();
                ((ReflectionActivity)_currentActivity).GuideReflection();
                _currentActivity.OnEnd();
                DisplayMenu(); // Display the menu again after the activity
                break;

            case 3: // Listing Activity
                var listPrompts = new List<string> {
                    "===Who are people that you appreciate?===",
                    "===What are personal strengths of yours?===",
                    "===Who are people that you have helped this week?===",
                    "===When have you felt the Holy Ghost this month?===",
                    "===Who are some of your personal heroes?===",
                };
                _currentActivity = new ListingActivity(
                    "Welcome to Listing Activity",
                    "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
                    listPrompts,
                    "Listing Activity"
                );
                _currentActivity.Start();
                ((ListingActivity)_currentActivity).GuideListing();
                _currentActivity.OnEnd();
                DisplayMenu(); // Display the menu again after the activity
                break;

            case 4: // Quit the program
                MotivationPrompt MotivationPrompt = new MotivationPrompt();  // *Create a new MotivationPrompt object
                string _prompt = MotivationPrompt.RandomPrompt();  // *Get a random message
                Console.WriteLine($"{_prompt}"); // *Print a motivational message
                break;

            default: // Handle invalid choices
                Console.WriteLine("Invalid choice. Please try again.\n");
                DisplayMenu(); // Display the menu again for a valid choice
                break;
        }
    }

    public void PromptReminder() {
        Console.WriteLine("\nRemember to take breaks and relax!"); // Reminder after each activity
    }
}
/*
        Console.WriteLine("Hello Develop04 World!");
                Activity BreathingActivity = new ("titleParam","welcomeParam","descParam",1000,"congratsParam");
                Activity ReflectionActivity = new ("titleParam","welcomeParam","descParam",1000,"congratsParam");
                Activity ListingActivity = new ("titleParam","welcomeParam","descParam",1000,"congratsParam"); */