using System;
using System.IO;

public class MotivationPrompt { // Class for mortivational prompts
    public List<string> _prompts;  // public attribute to store prompts
    public MotivationPrompt() {
        _prompts = [  // Initialize the list of prompts
            "Never Give Up.",
            "Integrity is the most valuable and respected quality of leadership. Always keep your word.\n\t-Brian Tracy",
            "The best and most beautiful things in the world cannot be seen or even touched; they must be felt with the heart.\n\t-Helen Keller",
            "Do or do not. There is no try.\n\t-Yoda",
            "The only real mistake is the one from which we learn nothing\n\t-Henry Ford",
            "Don't watch the clock; do what it does. Keep going.\n\t-Sam Levenson",
            "If you are doing mindfulness meditation, you are doing it with your ability to attend to the moment.\n\t-Daniel Goleman",
            "You can’t use up creativity. The more you use, the more you have.\n\t-Maya Angelou",
        ];
    }
    public string RandomPrompt() {
        Random rand = new();  // Create a Random object
        int index = rand.Next(_prompts.Count);  // Get a random index from the list of prompts
        return _prompts[index];  // Return the random prompt
    }
}