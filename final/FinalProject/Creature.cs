using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
public abstract class Creature  { // Abstract base class representing a Creature
    // Private fields with public properties
    private string _name { get; set; } // Name of the Creature
    private string _descript { get; set; } // Description of the Creature
    private float _health { get; set; } // Health of the Creature
    private float _stamina { get; set; } // Stamina of the Creature
    private string _responsibilityType { get; set; } // Responsibility type of the Creature
    private List<Move> _moves; // Array of moves available to the Creature
    // JSON property mappings for serialization
    [JsonPropertyName("name")]
    public string Name => _name;

    [JsonPropertyName("description")]
    public string Descript => _descript;

    [JsonPropertyName("health")]
    public float Health => _health;

    [JsonPropertyName("stamina")]
    public float Stamina => _stamina;

    [JsonPropertyName("responsibilityType")]
    public string ResponsibilityType => _responsibilityType;

    [JsonPropertyName("moves")]
    public List<Move> Moves => _moves;
    public Creature(string name, string descript, float health, float stamina, string responsibilityType) { // Constructor to initialize a Creature with its attributes
        _name = name;
        _descript = descript;
        _health = health;
        _stamina = stamina;
        _responsibilityType = responsibilityType;
        _moves = [];
    }
    
    public abstract void DisplayDetails(); 
    // Abstract method to display details, to be implemented by derived classes
    public virtual void SaveCreature(string filePath) { // Virtual method to save the Creature's data to a file in JSON format
        var options = new JsonSerializerOptions { WriteIndented = true }; // JSON options to format output
        var json = JsonSerializer.Serialize(this, options); // Serialize the Creature object to JSON
        File.WriteAllText(filePath, json); // Write JSON data to the specified file
    }

    public virtual void LoadCreature() { // Virtual method to load and display a Creature's data from a file in JSON format.
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Description: {Descript}");
        Console.WriteLine($"Health: {Health}");
        Console.WriteLine($"Stamina: {Stamina}");
        Console.WriteLine($"Responsibility Type: {ResponsibilityType}");
        Console.WriteLine("Moves:");
        foreach (var move in Moves)
        {
            Console.WriteLine($"- {move.Name}: {move.VerbDescript} (Power: {move.Power}, Type: {move.Type})");
        }
    
    }
    
    public void AddMove(Move move) { // Method to create a move for a creature up to 6 moves.
            if (_moves.Count >= 6) {
                _moves.RemoveAt(0); // Remove the oldest move
                Console.WriteLine("Max moves reached. The oldest move has been removed.");
            }
            _moves.Add(move);
        }

    public virtual void UseMove(Move move) { // Method to use a move if the Creature has enough stamina.
        if (_stamina >= move.staminaCost) {
            _stamina -= move.staminaCost; // Deduct stamina cost
            move.Execute(); // Execute the move
            Console.WriteLine($"-{move.staminaCost} stamina."); // Print stamina cost deduction
        } else {
            Console.WriteLine("Not enough stamina."); // Print error message if not enough stamina
        }
    }

    public void TakeDamage(float damage) { // Method to reduce the Creature's health by a specified amount of damage.
        _health -= damage;
    }
}