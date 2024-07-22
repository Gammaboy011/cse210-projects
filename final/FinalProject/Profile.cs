
using System.Text.Json;
using System.Text.Json.Serialization;

public class Profile { // Class representing a user profile.
    private string _userName; // User name associated with the profile.
    private int _level; // User's level.
    public string GetUserName() {return _userName;}
    public void SetUserName(string userName) { _userName = userName; }
    
    public int GetLevel() {return _level;}
    public void SetLevel(int level) { _level = level; }
    private Creature[] _creatures = new Creature[6]; // Array to store up to 6 Creatures.

    // Constructor to initialize the profile with a user name and level.
    public Profile(string userName, int level = 0) { // Set variable
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
    // method to increase the players current level by +1. It should store it back into the Json File assosiated with this profile.
    public void IncreaseLevel() {
        _level += 1;
    }
    // Method to add a Creature to the profile.
    public void AddCreature(Creature creature) {
        for (int i = 0; i < _creatures.Length; i++) {
            if (_creatures[i] == null) {
                _creatures[i] = creature;
                return;
            }
        }
        Console.WriteLine("Maximum number of creatures reached.");
    }
    // Method to remove a Creature from the profile.
    public void RemoveCreature(Creature creature) {
        for (int i = 0; i < _creatures.Length; i++) {
            if (_creatures[i] == creature) {
                _creatures[i] = null;
                return;
            }
        }
    }
    
    public bool HasUsableCreatures() {
        foreach (var creature in _creatures)
        {
            if (creature != null && creature.Health > 0 && creature.Stamina >= creature.Moves.Min(m => m.StaminaCost))
            {
                return true;
            }
        }
        return false;
    }
    
    public Creature GetUsableCreature()
    {
        foreach (var creature in _creatures)
        {
            if (creature != null && creature.Health > 0 && creature.Stamina >= creature.Moves.Min(m => m.StaminaCost))
            {
                return creature;
            }
        }
        return null;
    }
    
    
    
    
    // Method to swap two Creatures in the profile.
    public void SwapCreatures(int index1, int index2) { // Check for valid indices
        if (index1 < 0 || index1 >= _creatures.Length || index2 < 0 || index2 >= _creatures.Length) {
            Console.WriteLine("Invalid indices.");
            return;
        }
        // Swap the Creatures.
        var temp = _creatures[index1];
        _creatures[index1] = _creatures[index2];
        _creatures[index2] = temp;
    }
}
