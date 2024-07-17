using System;
using System.Text.Json;
public class Ranged : Creature { // Child to Creature Class
    private int _agility { get;set; }
    private int _dexterity { get;set; }

    public Ranged(string name, string descript, float health, float stamina, string responsibilityType, int agility, int dexterity)
        : base(name, descript, health, stamina, responsibilityType) {
        _agility = agility;
        _dexterity = dexterity;
    }
    // Add a method that calls the class to the "program class"
    public int GetAgility() { return _agility; }
    public int GetDexterity() { return _dexterity; }
    // Method to display all attributes of the creature
    public override void DisplayDetails() {
        Console.WriteLine($"Name: {GetName()}");
        Console.WriteLine($"Description: {GetDescript()}");
        Console.WriteLine($"Health: {GetHealth()}");
        Console.WriteLine($"Stamina: {GetStamina()}");
        Console.WriteLine($"Responsibility Type: {GetResponsibilityType()}");
        Console.WriteLine($"Agility: {GetAgility()}");
        Console.WriteLine($"Dexterity: {GetDexterity()}");
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