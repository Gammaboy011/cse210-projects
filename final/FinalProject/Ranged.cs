using System;
public class Ranged : Creature { // Child to Creature Class
    private int _agility;
    private int _dexterity;

    public Ranged(string name, string descript, float health, float stamina, string responsibilityType, int agility, int dexterity)
        : base(name, descript, health, stamina, responsibilityType) {
        _agility = agility;
        _dexterity = dexterity;
    }
    // Add a method that calls the class to the "program class"

    public void Dodge() {
        // Dodge logic
        Console.WriteLine("Ranger Dodge logic.");
    }
}