using System;

class ReflectionActivity : Activity {
    private List<string> _prompts; // List of prompts for reflection
    private List<string> _questions; // List of questions for reflection
    public ReflectionActivity(string welcome, string description, List<string> prompts, List<string> questions, string congrats)
        : base(welcome, description, congrats) { 
            _prompts = prompts;
            _questions = questions;
    }

    public void GuideReflection() {
        Console.WriteLine("Consider the following prompt:\n");
        var random = new Random();
        var prompt = _prompts[random.Next(_prompts.Count)]; // Select a random prompt
        Console.WriteLine(prompt);
        Console.WriteLine("\nWhen you have something in mind, press 'ENTER' to proceed:\n");
        string input = Console.ReadLine(); // User hits 'Enter'
        Console.WriteLine("Ponder each of the following questions relevant to your experience");
        Console.Write("You may begin in: ");
        DisplayAnimation(); // Countdown timer
        Console.Clear(); // Clear the console screen
        StartSpinner(); // Start the spinner animation
        var startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration) {
            Console.Write("\b");
            var question = _questions[random.Next(_questions.Count)]; // Select a random question
            Console.WriteLine(question);
            Thread.Sleep(7000); // Wait for 7 seconds
        }
        StopSpinner(); // Stop the spinner animation
    }
}

/*  // Copy of original Code
    public ReflectionActivity(string titleParam, string welcomeParam, string descParam, int durParam, string congratsParam) : 
    base(titleParam,welcomeParam,descParam,durParam,congratsParam)
    {

    } */