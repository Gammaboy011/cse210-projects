/* Header
    Dev02, WK4
    --Isaac Madrid--
    Journal Entry program
    05/14/24
    */
using System;
using System.IO;

Journal journal = new Journal();  // Create a new Journal object
PromptGenerator promptGenerator = new PromptGenerator();  // Create a new PromptGenerator object
while (true) {  // Start an infinite loop for the menu
    Console.WriteLine("Menu:");  // Display menu options
    Console.WriteLine("1. Load Journal");
    Console.WriteLine("2. Create Entry");
    Console.WriteLine("3. Display Journal");
    Console.WriteLine("4. Exit");
    Console.Write("Choose an option: ");
    string choice = Console.ReadLine();  // Get the user's choice

    if (choice == "1") {  // If the user chooses to load the journal
        journal.LoadFromFile();  // Load the journal file
    }
    else if (choice == "2") { // If the user chooses to create a new entry
        string prompt = promptGenerator.RandomPrompt();  // Get a random prompt
        Console.WriteLine($"Prompt: {prompt}");  // Display the prompt
        Console.Write("Your response: ");
        string userEntry = Console.ReadLine();  // Get the user's response
        Entry entry = new(prompt, userEntry);  // Create a new Entry object
        journal.AddEntry(entry);  // Add the entry to the journal
        journal.SaveToFile();  // Save the journal to the file
    }
    else if (choice == "3") {  // If the user chooses to display the journal
        journal.DisplayAll();  // Display all journal entries
    }
    else if (choice == "4") {  // If the user chooses to exit
        break;  // Exit the loop
    }
    else {
        Console.WriteLine("Invalid option. Please choose again.");  // Inform the user of an invalid choice
    }
}
Console.WriteLine("Hello Develop02 World!"); // test if program works
