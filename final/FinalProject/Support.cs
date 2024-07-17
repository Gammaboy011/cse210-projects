using System;
using System.Text.Json;
public class Support : Creature { // Child to Creature Class
    private int _healing{ get;set; }

    public Support(string name, string descript, float health, float stamina, string responsibilityType, int healing)
        : base(name, descript, health, stamina, responsibilityType)
    {
        _healing = healing;
    }
     public int GetHealing() { return _healing; }
    // Method to display all attributes of the creature
    public override void DisplayDetails() {
        Console.WriteLine($"Name: {GetName()}");
        Console.WriteLine($"Description: {GetDescript()}");
        Console.WriteLine($"Health: {GetHealth()}");
        Console.WriteLine($"Stamina: {GetStamina()}");
        Console.WriteLine($"Responsibility Type: {GetResponsibilityType()}");
        Console.WriteLine($"Healing: {GetHealing()}");
    }

    // Add a method that calls the class to the "program class"
    public override void SaveCreature(string filePath) {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(this, options);
        File.WriteAllText(filePath, json);
    }

}