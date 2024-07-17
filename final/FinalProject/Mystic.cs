using System;
using System.Text.Json;
using System.Text.Json.Serialization;
public class Mystic : Creature  { // Child to Creature Class
    private int _mana { get;set; }
    [JsonPropertyName("mana")] // Use "JsonPropertyName" to control serialization while keeping fields private.
    public int Mana => _mana;

    public Mystic(string name, string descript, float health, float stamina, string responsibilityType, int mana)
        : base(name, descript, health, stamina, responsibilityType) {
        _mana = mana;
        // also saved to same creatures file 
        Console.Write("Enter mana: ");
                // var mana = int.Parse(Console.ReadLine());
                // creature = (Creature)Activator.CreateInstance(typeof(Mystic), name, descript, health, stamina, responsibilityType, mana);
    }

    // Method to display all attributes of the creature
    public override void DisplayDetails() {
        base.LoadCreature();
        Console.WriteLine($"Mana: {Mana}");
    }
    public override void SaveCreature(string filePath) {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(this, options);
        File.WriteAllText(filePath, json);
    }
    // Add a method that calls the class to the "program class"

}