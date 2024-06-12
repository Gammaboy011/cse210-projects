using System;
class ListingActivity : Activity {
    private List<string> _prompts; // List of prompts for listing activity
    private List<string> _responses; // List to store user responses
    public ListingActivity(string welcome, string description, List<string> prompts, string congrats)
        : base(welcome, description, congrats) {
            _prompts = prompts;
            _responses = new List<string>();
    }

    public void GuideListing() {
        GetReady(); // Preparation phase
        Console.WriteLine("List as many responses to the following prompt:\n");
        var random = new Random();
        var prompt = _prompts[random.Next(_prompts.Count)]; // Select a random prompt
        Console.WriteLine(prompt);
        Console.Write("You may begin in: ");
        DisplayAnimation(); // Countdown timer
        var startTime = DateTime.Now;
        
        while ((DateTime.Now - startTime).TotalSeconds < _duration) {
            Console.Write("> ");
            var response = Console.ReadLine(); // Read user response
            _responses.Add(response); // Add response to the list
        }
        
        Console.WriteLine($"You listed {_responses.Count} thoughts."); // Display the number of responses
    }    
}

// Copy of original Code
/*
    public ListingActivity(string titleParam, string welcomeParam, string descParam, int durParam, string congratsParam) : 
    base(titleParam,welcomeParam,descParam,durParam,congratsParam)
    {

    }
*/