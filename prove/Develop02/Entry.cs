using System;
using System.IO;

public class Entry {
     public string _date{get; set;} // Property to store the date of the entry
     public string _promptText{get; set;} // Property to store the prompt
     public string _entryText{get; set;} // Property to store the user's entry
     public Entry(string prompt, string userEntry, string date = null) {
        _promptText = prompt;  // Set the prompt
        _entryText = userEntry;  // Set the user's entry
        _date = date ?? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");  // Set the date, using the current date if none is provided
    }
     public void Display(int index) {
         Console.WriteLine($"IndexID: {index}");  // Display the index id for the entry
         Console.WriteLine($"Date: {_date}");  // Display the date
         Console.WriteLine($"Prompt: {_promptText}");  // Display the prompt
         Console.WriteLine($"Entry: {_entryText}");  // Display the user's entry
         Console.WriteLine();  // Add a blank line for readability
     }
}