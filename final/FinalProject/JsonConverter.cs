using System.Text.Json; // Provides functionality for JSON serialization and deserialization.
using System.Text.Json.Serialization;
// A static class to contain methods for handling JSON serialization & deserialization,
// including creating instances of certain classes (Creature, Profile, Move).
public static class JsonConverter {
    public static void SaveToJson<T>(T obj, string filePath) { // Method to save an object to a JSON file.
        // Define JSON serialization options.
        var options = new JsonSerializerOptions  {
            WriteIndented = true, // Format the JSON with indentation for readability.
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Use camelCase naming policy for JSON properties.
        };

        // Serialize the object to a JSON string using the defined options.
        var json = JsonSerializer.Serialize(obj, options);

        File.WriteAllText(filePath, json); // Write the JSON string to the specified file.
    }

    public static T LoadFromJson<T>(string filePath) { // Method to load an object from a JSON file.
        var json = File.ReadAllText(filePath); // Read the JSON string from the specified file.
        // Deserialize JSON string into an object of type T and return.
        return JsonSerializer.Deserialize<T>(json);
    }

    // Method to create a Creature instance based on the provided responsibility type and other parameters.
    public static Creature CreateCreature( string responsibilityType, string name, string description, float health, float stamina,
        int meleeAgility = 0, int strength = 0, int defense = 0, int mana = 0, int agility = 0, int dexterity = 0, int healing = 0) {
        // Use a switch expression to create the appropriate Creature subtype based on the responsibility type.
        return responsibilityType switch {
            "heavy" => new Heavy(name, description, health, stamina, responsibilityType, defense),
            "melee" => new Melee(name, description, health, stamina, responsibilityType, meleeAgility, strength),
            "mystic" => new Mystic(name, description, health, stamina, responsibilityType, mana),
            "ranged" => new Ranged(name, description, health, stamina, responsibilityType, agility, dexterity),
            "support" => new Support(name, description, health, stamina, responsibilityType, healing),
            _ => throw new ArgumentException("Invalid type. Valid types are: heavy, melee, mystic, ranged, support.") // Throw an exception for invalid responsibility types.
        };
    }
    // Placeholder method to create a Profile instance.
    public static Profile CreateProfile(string userName, int level = 0) {
        // Return a new Profile instance with the provided user name and level.
        return new Profile(userName, level);
    }
    // Placeholder method to create a Move instance.
    public static Move CreateMove(string name, string verb, int power, float staminaCost) {
        // Return a new Move instance with the provided name, verb, power, and stamina cost.
        return new Move(name, verb, power, 0, staminaCost);
    }
}
