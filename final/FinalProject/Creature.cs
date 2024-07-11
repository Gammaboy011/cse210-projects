using System;
using System.Text.Json;
public class Creature  { // Abstract base class representing a Creature
    private string _name; // Name of the Creature
    public string GetName() {return _name;}
    private string _descript; // Description of the Creature
    public string GetDescript() {return _descript;}
    private float _health; // Health of the Creature 
    public float GetHealth() {return _health;}
    private float _stamina; // Stamina of the Creature
    public float GetStamina(){return _stamina;}
    private string _responsibilityType; // Responsibilty type of the Creature
    public string GetResponsibilityType() {return _responsibilityType;}
    private Move[] _moves; // Array of moves available to the Creature

    // public string name { get { return _name; } } // Property to get the Creature's name
    // public string descript { get { return _descript; } } // Property to get the Creature's name
    // public string responsibilityType { get { return _responsibilityType; } } // Property to get the Creature's name
    // public float health { get { return _health; } } // Property to get the Creature's health
    // public float stamina { get { return _stamina; } } // Property to get the Creature's stamina
    public Creature(string name, string descript, float health, float stamina, string responsibilityType) { // Constructor to initialize a Creature with its attributes
        _name = name;
        _descript = descript;
        _health = health;
        _stamina = stamina;
        _responsibilityType = responsibilityType;
    }
    // Method to reduce the Creature's health by a specified amount of damage.
    public void TakeDamage(float damage) {
        _health -= damage;
    }
    // Method to use a move if the Creature has enough stamina.
    public void UseMove(Move move) {
        if (_stamina >= move.staminaCost) {
            _stamina -= move.staminaCost;
            move.Execute();
            Console.WriteLine("minus stamina.");
        } else {
            Console.WriteLine("Not enough stamina.");
        }
    }
    // Method to save the Creature's data to a file in JSON format.
    public void SaveCreature(string filePath) {
        var json = JsonSerializer.Serialize(this);
        File.WriteAllText(filePath, json);
        Console.WriteLine("Creature Saved.");
    }
    // Static method to load a Creature's data from a file in JSON format.
    public static Creature LoadCreature(string filePath) {
        var json = File.ReadAllText(filePath);
        Console.WriteLine("Creature loaded.");
        return JsonSerializer.Deserialize<Creature>(json);
        
    }
}
