using System;
public class Support : Creature { // Child to Creature Class
    public int _healing;

    public Support(string name, string descript, float health, float stamina, string responsibilityType, int healing)
        : base(name, descript, health, stamina, responsibilityType)
    {
        _healing = healing;
    }
    // Add a method that calls the class to the "program class"

}