using System;
using System.IO;

public class PromptGenerator {
    public List<string> _prompts;  // public attribute to store prompts
    public PromptGenerator() {
        _prompts = [  // Initialize the list of prompts
            "What did you learn?",
            "Who did you find interesting?",
            "Where did you visit?",
            "How did you feel the Spirit?"
        ];
    }
    public string RandomPrompt() {
        Random rand = new();  // Create a Random object
        int index = rand.Next(_prompts.Count);  // Get a random index from the list of prompts
        return _prompts[index];  // Return the random prompt
    }
}