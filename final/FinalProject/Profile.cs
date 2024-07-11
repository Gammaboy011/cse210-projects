using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text.Json;

public class Profile { // Class representing a user profile.
    private string _userName; // User name associated with the profile.
    public string GetUserName() {return _userName;}
    private int _level; // User's level.
    private Creature[] Creatures = new Creature[6]; // Array to store up to 6 Creatures.

    public Profile() { // Set variable
        _userName = "";
        _level = 0;
    }
    // Constructor to initialize the profile with a user name and level.
    public Profile(string userName, int level) { // Set variable
        _userName = userName;
        _level = level;
    }
    
    // Method to save the profile data to a file in JSON format.
    public void SaveProfile(string filePath) {
        var json = JsonSerializer.Serialize(this);
        File.WriteAllText(filePath, json);
    }
    // Static method to load profile data from a file in JSON format.
    public static Profile LoadProfile(string filePath) {
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<Profile>(json);
    }
    // Method to add a Creature to the profile.
    public void AddCreature(Creature creature) {
        for (int i = 0; i < Creatures.Length; i++) {
            if (Creatures[i] == null) {
                Creatures[i] = creature;
                return;
            }
        }
        Console.WriteLine("Maximum number of creatures reached.");
    }
    // Method to remove a Creature from the profile.
    public void RemoveCreature(Creature creature) {
        for (int i = 0; i < Creatures.Length; i++) {
            if (Creatures[i] == creature) {
                Creatures[i] = null;
                return;
            }
        }
    }
    // Method to swap two Creatures in the profile.
    public void SwapCreatures(int index1, int index2) { // Check for valid indices
        if (index1 < 0 || index1 >= Creatures.Length || index2 < 0 || index2 >= Creatures.Length) {
            Console.WriteLine("Invalid indices.");
            return;
        }
        // Swap the Creatures.
        var temp = Creatures[index1];
        Creatures[index1] = Creatures[index2];
        Creatures[index2] = temp;
    }
}
