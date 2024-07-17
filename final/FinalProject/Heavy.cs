using System;
using System.Text.Json;
public class Heavy : Creature { // Child to Creature Class
    private int _defense { get;set; }

    public Heavy(string name, string descript, float health, float stamina, string responsibilityType, int defense)
        : base(name, descript, health, stamina, responsibilityType) {
        _defense = defense;
        // also saved to same creatures file.
        // Console.Write("Enter defense: ");
        // var defense = int.Parse(Console.ReadLine());
        // creature = (Creature)Activator.CreateInstance(typeof(Heavy), name, descript, health, stamina, responsibilityType, defense);
    }
 // Additional logic for Heavy : Creature class
    public int GetDefense() { return _defense; }

    // Method to display all attributes of the creature
    public override void DisplayDetails() {
        Console.WriteLine($"Name: {GetName()}");
        Console.WriteLine($"Description: {GetDescript()}");
        Console.WriteLine($"Health: {GetHealth()}");
        Console.WriteLine($"Stamina: {GetStamina()}");
        Console.WriteLine($"Responsibility Type: {GetResponsibilityType()}");
        Console.WriteLine($"Defense: {GetDefense()}");
    }

 // Add a method that calls the class to the "program class"
    public override void SaveCreature(string filePath) {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(this, options);
        File.WriteAllText(filePath, json);
    }
}