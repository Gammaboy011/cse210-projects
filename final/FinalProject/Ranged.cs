using System;
public class Ranged : Creature  {
    private int _agility;
    private int _dexterity;

    public Ranged(string name, string descript, float health, float stamina, string responsibilityType, int agility, int dexterity)
        : base(name, descript, health, stamina, responsibilityType) {
        _agility = agility;
        _dexterity = dexterity;
    }

    public void Dodge() {
        // Dodge logic
        Console.WriteLine("Ranger Dodge logic.");
    }
}