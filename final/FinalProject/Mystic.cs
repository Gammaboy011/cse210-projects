using System;
using System.Text.Json;
public class Mystic : Creature  { // Child to Creature Class
    private int _mana { get;set; }

    public Mystic(string name, string descript, float health, float stamina, string responsibilityType, int mana)
        : base(name, descript, health, stamina, responsibilityType) {
        _mana = mana;
        // also saved to same creatures file 
        Console.Write("Enter mana: ");
                // var mana = int.Parse(Console.ReadLine());
                // creature = (Creature)Activator.CreateInstance(typeof(Mystic), name, descript, health, stamina, responsibilityType, mana);
    }
    public int GetMana() { return _mana; }

    // Method to display all attributes of the creature
    public override void DisplayDetails() {
        Console.WriteLine($"Name: {GetName()}");
        Console.WriteLine($"Description: {GetDescript()}");
        Console.WriteLine($"Health: {GetHealth()}");
        Console.WriteLine($"Stamina: {GetStamina()}");
        Console.WriteLine($"Responsibility Type: {GetResponsibilityType()}");
        Console.WriteLine($"Mana: {GetMana()}");
    }
    public override void SaveCreature(string filePath) {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(this, options);
        File.WriteAllText(filePath, json);
    }
    // Add a method that calls the class to the "program class"

}