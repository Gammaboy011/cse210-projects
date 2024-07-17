using System;
using System.Text.Json;
public class Melee : Creature { // Child to Creature Class
    private int _agility{ get;set; }
    private int _strength{ get;set; }

    public Melee(string name, string descript, float health, float stamina, string responsibilityType, int agility, int strength)
        : base(name, descript, health, stamina, responsibilityType) {
        _agility = agility;
        _strength = strength;
        // also saved to same creatures file
        Console.Write("Enter agility: ");
        var meleeAgility = int.Parse(Console.ReadLine());
    }
    
    // Add a method that calls the class to the "program class"
    public int GetAgility() { return _agility; }
    public int GetStrength() { return _strength; }

    // Method to display all attributes of the creature
    public override void DisplayDetails() {
        Console.WriteLine($"Name: {GetName()}");
        Console.WriteLine($"Description: {GetDescript()}");
        Console.WriteLine($"Health: {GetHealth()}");
        Console.WriteLine($"Stamina: {GetStamina()}");
        Console.WriteLine($"Responsibility Type: {GetResponsibilityType()}");
        Console.WriteLine($"Agility: {GetAgility()}");
        Console.WriteLine($"Strength: {GetStrength()}");
    }
    public void Block() {
        // Block logic
        Console.WriteLine("Melee Block logic.");
    }
    public override void SaveCreature(string filePath) {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(this, options);
        File.WriteAllText(filePath, json);
    }
}