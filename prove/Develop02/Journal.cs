using System;
using System.IO;

public class Journal {
    public List<Entry> _entries; // Public attribute to store journal entries
    public string _journalFile; // Public attribute to store the journal file name
    public Journal() {
        _entries = [];  // Initialize the list of entries
        _journalFile = "journal.txt";  // Set the default journal file name
    }
    public void AddEntry ( Entry newEntry) {
     _entries.Add(newEntry);  // Add a new entry to the list
    }
    public void DisplayAll() {
        foreach (Entry entry in _entries) {  // Loop through each entry in the journal
            entry.Display();  // Display the entry details
        }
    }
    public void SaveToFile() {
        using StreamWriter writer = new StreamWriter(_journalFile);  // Create a StreamWriter to write to the journal file
        foreach (Entry entry in _entries) { // Loop through each entry in the journal
            writer.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");  // Write entry details to the file
        }
    }
    public void LoadFromFile() {
        if (File.Exists(_journalFile)) {  // Check if the journal file exists
            using StreamReader reader = new(_journalFile);  // Create a StreamReader to read from the journal file
            string line;
            while ((line = reader.ReadLine()) != null) {  // Read each line from the file
                string[] parts = line.Split('|');  // Split the line into parts
                Entry entry = new(parts[1], parts[2], parts[0]);  // Create a new Entry object from the parts
                _entries.Add(entry);  // Add the entry to the list
            }
        }
        else {
            Console.WriteLine("Journal file not found. Starting a new journal.");  // Inform the user if the file is not found
        }
    }


}