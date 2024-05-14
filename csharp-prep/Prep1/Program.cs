/* Header
    Prep1, WK1
    --Isaac Madrid--
    Number Guessing Game
    04/30/24
    */
using System;
class Program
{
    static void Main(string[] args) {   // this is the Main function.
        // Console.WriteLine("Prep1 Assignment:");
        Console.Write("What is your first name? "); // First Name.
        string f_name = Console.ReadLine(); // "f_name" stores previous input-^
        Console.Write("What is your last name? "); // Last Name.
        string l_name = Console.ReadLine(); // "l_name" stores previous input-^
        Console.WriteLine(); // spacer
        Console.WriteLine($"Your name is {l_name}, {f_name} {l_name}."); 
        // should print "Your name is [Last Name], [First Name] [Last Name]."
    }
}
/*
using System;
using System.Collections.Generic;
using System.IO;  // Importing necessary libraries for file operations

public class Journal
{
    public List<Entry> _entries;  // Private attribute to store journal entries
    public string _journalFile;   // Private attribute to store the journal file name

    public Journal()
    {
        _entries = new List<Entry>();  // Initialize the list of entries
        _journalFile = "journal.txt";  // Set the default journal file name
    }

    public void SaveFile()
    {
        using (StreamWriter writer = new StreamWriter(_journalFile))  // Create a StreamWriter to write to the journal file
        {
            foreach (Entry entry in _entries)  // Loop through each entry in the journal
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.UserEntry}");  // Write entry details to the file
            }
        }
    }

    public void LoadFile()
    {
        if (File.Exists(_journalFile))  // Check if the journal file exists
        {
            using (StreamReader reader = new StreamReader(_journalFile))  // Create a StreamReader to read from the journal file
            {
                string line;
                while ((line = reader.ReadLine()) != null)  // Read each line from the file
                {
                    string[] parts = line.Split('|');  // Split the line into parts
                    Entry entry = new Entry(parts[1], parts[2], parts[0]);  // Create a new Entry object from the parts
                    _entries.Add(entry);  // Add the entry to the list
                }
            }
        }
        else
        {
            Console.WriteLine("Journal file not found. Starting a new journal.");  // Inform the user if the file is not found
        }
    }

    public void DisplayAllEntries()
    {
        foreach (Entry entry in _entries)  // Loop through each entry in the journal
        {
            entry.Display();  // Display the entry details
        }
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);  // Add a new entry to the list
    }
}

public class Entry
{
    public string Prompt { get; set; }  // Property to store the prompt
    public string UserEntry { get; set; }  // Property to store the user's entry
    public string Date { get; set; }  // Property to store the date of the entry

    public Entry(string prompt, string userEntry, string date = null)
    {
        Prompt = prompt;  // Set the prompt
        UserEntry = userEntry;  // Set the user's entry
        Date = date ?? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");  // Set the date, using the current date if none is provided
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");  // Display the date
        Console.WriteLine($"Prompt: {Prompt}");  // Display the prompt
        Console.WriteLine($"Entry: {UserEntry}");  // Display the user's entry
        Console.WriteLine();  // Add a blank line for readability
    }
}

public class PromptGenerator
{
    public List<string> _prompts;  // Private attribute to store prompts

    public PromptGenerator()
    {
        _prompts = new List<string>  // Initialize the list of prompts
        {
            "What did you learn?",
            "Who did you find interesting?",
            "Where did you visit?",
            "How did you feel the Spirit?"
        };
    }

    public string RandomPrompt()
    {
        Random rand = new Random();  // Create a Random object
        int index = rand.Next(_prompts.Count);  // Get a random index from the list of prompts
        return _prompts[index];  // Return the random prompt
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();  // Create a new Journal object
        PromptGenerator promptGenerator = new PromptGenerator();  // Create a new PromptGenerator object

        while (true)  // Start an infinite loop for the menu
        {
            Console.WriteLine("Menu:");  // Display menu options
            Console.WriteLine("1. Load Journal");
            Console.WriteLine("2. Create Entry");
            Console.WriteLine("3. Display Journal");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();  // Get the user's choice

            if (choice == "1")  // If the user chooses to load the journal
            {
                journal.LoadFile();  // Load the journal file
            }
            else if (choice == "2")  // If the user chooses to create a new entry
            {
                string prompt = promptGenerator.RandomPrompt();  // Get a random prompt
                Console.WriteLine($"Prompt: {prompt}");  // Display the prompt
                Console.Write("Your response: ");
                string userEntry = Console.ReadLine();  // Get the user's response
                Entry entry = new Entry(prompt, userEntry);  // Create a new Entry object
                journal.AddEntry(entry);  // Add the entry to the journal
                journal.SaveFile();  // Save the journal to the file
            }
            else if (choice == "3")  // If the user chooses to display the journal
            {
                journal.DisplayAllEntries();  // Display all journal entries
            }
            else if (choice == "4")  // If the user chooses to exit
            {
                break;  // Exit the loop
            }
            else
            {
                Console.WriteLine("Invalid option. Please choose again.");  // Inform the user of an invalid choice
            }
        }
    }
}
*/