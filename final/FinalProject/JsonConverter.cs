using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

// A custom converter for the Creature class to handle JSON serialization and deserialization
public static class JsonConverter {
    public static void SaveToJson<T>(T obj, string filePath) {
        var options = new JsonSerializerOptions {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        var json = JsonSerializer.Serialize(obj, options);
        File.WriteAllText(filePath, json);
    }

    public static T LoadFromJson<T>(string filePath) {
        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(json);
    }

    public static Creature CreateCreature(string responsibilityType, string name, string description, float health, float stamina, int meleeAgility = 0, int strength = 0, int defense = 0, int mana = 0, int agility = 0, int dexterity = 0, int healing = 0) {
        return responsibilityType switch {
            "heavy" => new Heavy(name, description, health, stamina, responsibilityType, defense),
            "melee" => new Melee(name, description, health, stamina, responsibilityType, meleeAgility, strength),
            "mystic" => new Mystic(name, description, health, stamina, responsibilityType, mana),
            "ranged" => new Ranged(name, description, health, stamina, responsibilityType, agility, dexterity),
            "support" => new Support(name, description, health, stamina, responsibilityType, healing),
            _ => throw new ArgumentException("Invalid type. Valid types are: heavy, melee, mystic, ranged, support.")
        };
    }
}

// Placeholder for a custom converter for the Profile class (currently not implemented)
// public class ProfileConverter : JsonConverter<Profile> {}

// Placeholder for a custom converter for the Moves class (currently not implemented)
// public class MoveConverter : JsonConverter<Move> {}
