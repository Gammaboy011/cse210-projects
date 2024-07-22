using System.Text.Json;
using System.Text.Json.Serialization;
public class Heavy : Creature { // Child to Creature Class
    private int _defense { get;set; }
    [JsonPropertyName("defense")] // Use "JsonPropertyName" to control serialization while keeping fields private.
    public int Defense => _defense;
    public Heavy(string name, string descript, float health, float stamina, string responsibilityType, int defense)
        : base(name, descript, health, stamina, responsibilityType) {
        _defense = defense;
    }
 
    // Method to display all attributes of the creature
    public override void DisplayDetails() {
        base.LoadCreature();
        Console.WriteLine($"Defense: {Defense}");
    }

// bridge a connection with the creature and store the moves that the creature has.
    //public override void UseMove(Move move);

 // Add a method that calls the class to the "program class"
    public override void SaveCreature(string filePath) {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(this, options); 
        File.WriteAllText(filePath, json);
    }
}