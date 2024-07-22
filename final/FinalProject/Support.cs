using System.Text.Json;
using System.Text.Json.Serialization;
public class Support : Creature { // Child to Creature Class
    private int _healing{ get;set; }
    [JsonPropertyName("healing")] // Use "JsonPropertyName" to control serialization while keeping fields private.
    public int Healing => _healing;

    public Support(string name, string descript, float health, float stamina, string responsibilityType, int healing)
        : base(name, descript, health, stamina, responsibilityType) {
        _healing = healing;
    }
    
    // Method to display all attributes of the creature
    public override void DisplayDetails() {
        base.LoadCreature();
        Console.WriteLine($"Healing: {Healing}");
    }

    // Add a method that calls the class to the "program class"
    public override void SaveCreature(string filePath) {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(this, options);
        File.WriteAllText(filePath, json);
    }

}