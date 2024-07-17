using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
public abstract class Creature  { // Abstract base class representing a Creature
    private string _name { get;set; } // Name of the Creature
    private string _descript { get;set; } // Description of the Creature    
    private float _health { get;set; } // Health of the Creature 
    private float _stamina { get;set; } // Stamina of the Creature
    private string _responsibilityType { get;set; } // Responsibilty type of the Creature

    // private Move[] _moves; // Array of moves available to the Creature
    public Creature(string name, string descript, float health, float stamina, string responsibilityType) { // Constructor to initialize a Creature with its attributes
        _name = name;
        _descript = descript;
        _health = health;
        _stamina = stamina;
        _responsibilityType = responsibilityType;
    }
    public string GetName() {return _name;}
    public string GetDescript() {return _descript;}
    public float GetHealth() {return _health;}
    public float GetStamina(){return _stamina;}
    public string GetResponsibilityType() {return _responsibilityType;}
    public abstract void DisplayDetails();
    public abstract void SaveCreature(string filePath);


    // Static method to load a Creature's data from a file in JSON format.
    public static Creature LoadCreature(string filePath)
    {
        var options = new JsonSerializerOptions
        {
            Converters = { new CreatureConverter() },
            WriteIndented = true
        };

        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<Creature>(json, options);
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
            Console.WriteLine($"-{move.staminaCost} stamina.");
        } else {
            Console.WriteLine("Not enough stamina.");
        }
    }

}