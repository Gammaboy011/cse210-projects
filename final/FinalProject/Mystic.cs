using System;
public class Mystic : Creature  {
    public int _mana;

    public Mystic(string name, string descript, float health, float stamina, string responsibilityType, int mana)
        : base(name, descript, health, stamina, responsibilityType)
    {
        _mana = mana;
    }
}