using System;
using System.Text.Json;
using System.Text.Json.Serialization;
public class Ranged : Creature { // Child to Creature Class
    private int _agility { get;set; }
    [JsonPropertyName("agility")] // Use "JsonPropertyName" to control serialization while keeping fields private.
    public int Agility => _agility;
    private int _dexterity { get;set; }    
    [JsonPropertyName("dexterity")] // Use "JsonPropertyName" to control serialization while keeping fields private.
    public int Dexterity => _dexterity;

    public Ranged(string name, string descript, float health, float stamina, string responsibilityType, int agility, int dexterity)
        : base(name, descript, health, stamina, responsibilityType) {
        _agility = agility;
        _dexterity = dexterity;
    }
    // Add a method that calls the class to the "program class"

    // Method to display all attributes of the creature
    public override void DisplayDetails() {
        base.LoadCreature();
        Console.WriteLine($"Agility: {Agility}");
        Console.WriteLine($"Dexterity: {Dexterity}");
    }

    public void Dodge() {
        // Dodge logic
        Console.WriteLine("Ranger Dodge logic.");
    }
    public override void SaveCreature(string filePath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(this, options);
        File.WriteAllText(filePath, json);
    }
}