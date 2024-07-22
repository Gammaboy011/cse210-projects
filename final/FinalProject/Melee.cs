using System.Text.Json;
using System.Text.Json.Serialization;
public class Melee : Creature { // Child to Creature Class
    private int _agility{ get;set; }
    [JsonPropertyName("agility")] // Use "JsonPropertyName" to control serialization while keeping fields private.
    public int Agility => _agility;
    private int _strength{ get;set; }
    [JsonPropertyName("strength")] // Use "JsonPropertyName" to control serialization while keeping fields private.
    public int Strength => _strength;

    public Melee(string name, string descript, float health, float stamina, string responsibilityType, int agility, int strength)
        : base(name, descript, health, stamina, responsibilityType) {
        _agility = agility;
        _strength = strength;
    }
    
    // Add a method that calls the class to the "program class"
    public int GetAgility() { return _agility; }
    public int GetStrength() { return _strength; }

    // Method to display all attributes of the creature
    public override void DisplayDetails() {
        base.LoadCreature();
        Console.WriteLine($"Agility: {Agility}");
        Console.WriteLine($"Strength: {Strength}");
    }
    public void Block() {
        // Block logic
        Console.WriteLine("Melee Block logic.");
    }
    public override void SaveCreature(string filePath) {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(this, options); // An unhandled exception of type 'System.InvalidOperationException' occurred in System.Text.Json.dll: 'The JSON property name for 'Move.staminaCost' collides with another property.
        File.WriteAllText(filePath, json);
    }
}