using System;
public class Melee : Creature   {
    private int _agility;
    private int _strength;

    public Melee(string name, string descript, float health, float stamina, string responsibilityType, int agility, int strength)
        : base(name, descript, health, stamina, responsibilityType) {
        _agility = agility;
        _strength = strength;
    }

    public void Block() {
        // Block logic
        Console.WriteLine("Melee Block logic.");
    }
}