using System;
using System.Text.Json;
using System.Text.Json.Serialization;
public class Move  {
    private string _name; // This stores the name of the move. EX: CreatureA used "poison" on CreatureB
    [JsonPropertyName("name")] // Use "JsonPropertyName" to control serialization while keeping fields private.
    public string Name {
        get { return _name; }
        set { _name = value; }
    } 
    private string _verbDescript; // This stores the verbal decription of move.
    [JsonPropertyName("Verb")] // EX: CreatureB was "affected" by CreatureA.
    public string VerbDescript {
        get { return _verbDescript; } 
        set { _verbDescript = value; }
    }
    private int _power; // This stores the Damage that the move gives or restores. 
    [JsonPropertyName("power")] // EX: CreatureB now loses "5 HP" every turn. CreatureC gained "5 HP".
    public int Power {
        get { return _power; }
        set { _power = value; }
    }
    private int _type; // This stores the type of move being used on the target. 
    [JsonPropertyName("type")] // EX: Creature B "dodged" CreatureA's attack. // E.g., "Attack", "Defend", "Heal", etc.
    public int Type {
        get { return _type; }
        set { _type = value; }
    } 
    private float _staminaCost; // This stores the cost of stamina required to use the move.
    [JsonPropertyName("staminaCost")] // EX: CreatureA lost "5" stamina after it used poison.
    public float StaminaCost {
        get { return _staminaCost; }
        set { _staminaCost = value; }
    }
    public Move(string name, string verbDescript, int power, int type, float staminaCost) {
        _name = name;
        _verbDescript = verbDescript;
        _power = power;
        _type = type;
        _staminaCost = staminaCost;
    }
    public float staminaCost { get; internal set; }
    public void Execute() { // 
        // Move execution logic
        Console.WriteLine("execution logic.");
    }
}