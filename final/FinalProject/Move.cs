using System.Text.Json.Serialization;
public class Move  {
    private string _name; // This stores the name of the move. EX: CreatureA used "poison" on CreatureB
    [JsonPropertyName("name")] // Use "JsonPropertyName" to control serialization while keeping fields private.
    public string Name { get { return _name; } set { _name = value; } } 
    private string _verb; // This stores the verbal decription of move.
    [JsonPropertyName("Verb")] // EX: CreatureB was "affected" by CreatureA.
    public string VerbDescript { get { return _verb; } set { _verb = value; } }
    private int _power; // This stores the Damage that the move gives or restores. 
    public int GetPower() { return _power; }
    public void SetPower(int power) { _power = power; }
    [JsonPropertyName("power")] // EX: CreatureB now loses "5 HP" every turn. CreatureC gained "5 HP".
    public int Power { get { return _power; } set { _power = value; }}
    private int _type; // This stores the type of move being used on the target. 
    [JsonPropertyName("type")] // EX: Creature B "dodged" CreatureA's attack. // E.g., "Attack", "Defend", "Heal", etc.
    public int Type { get { return _type; } set { _type = value; }} 
    private float _staminaCost; // This stores the cost of stamina required to use the move.
    public float GetStaminaCost() { return _staminaCost; }
    public void SetSaminaCost(int staminaCost) { _staminaCost = staminaCost; }
    [JsonPropertyName("staminaCost")] // EX: CreatureA lost "5" stamina after it used poison.
    public float StaminaCost { get { return _staminaCost; } set { _staminaCost = value; } }
    public float staminaCost { get; internal set; }
    public Move(string name, string verb, int power, int type, float staminaCost) {
        _name = name;
        _verb = verb;
        _power = power;
        _type = type;
        _staminaCost = staminaCost;
    }
    public static void AddMoveToCreature(Creature creature) {
        Console.WriteLine("Enter move name:");
        var moveName = Console.ReadLine();

        Console.WriteLine("Enter move description:");
        var moveDescript = Console.ReadLine();

        Console.WriteLine("Enter move power:");
        var movePower = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter move type (Attack/Defend/Heal/Block/dodge/etc.):");
        var moveType = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter move stamina cost (ex: 5):");
        var staminaCost = int.Parse(Console.ReadLine());

        var move = new Move(moveName, moveDescript, movePower, moveType, staminaCost);
        creature.AddMove(move);
        Console.WriteLine("Move added to creature.");
    }
    public void Execute() { // 
        // Move execution logic
        Console.WriteLine("execution logic.");
    }
}