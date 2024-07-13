using System;
public class Melee : Creature { // Child to Creature Class
    private int _agility;
    private int _strength;

    public Melee(string name, string descript, float health, float stamina, string responsibilityType, int agility, int strength)
        : base(name, descript, health, stamina, responsibilityType) {
        _agility = agility;
        _strength = strength;
    }
    
    // Add a method that calls the class to the "program class"

    public void Block() {
        // Block logic
        Console.WriteLine("Melee Block logic.");
    }
}