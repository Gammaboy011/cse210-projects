using System;
public class Heavy : Creature { // Child to Creature Class
    private int _defense;

    public Heavy(string name, string descript, float health, float stamina, string responsibilityType, int defense)
        : base(name, descript, health, stamina, responsibilityType) {
        _defense = defense;
    }
 // Additional logic for Heavy : Creature class
 // Add a method that calls the class to the "program class"
}