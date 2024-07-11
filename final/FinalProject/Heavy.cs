using System;
public class Heavy : Creature   {
    private int _defense;

    public Heavy(string name, string descript, float health, float stamina, string responsibilityType, int defense)
        : base(name, descript, health, stamina, responsibilityType) {
        _defense = defense;
    }
 // Additional logic for Heavy : Creature class
 
}