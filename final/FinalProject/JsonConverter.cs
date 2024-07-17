using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

public class CreatureConverter : JsonConverter<Creature> {
    public override Creature Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        using (var jsonDoc = JsonDocument.ParseValue(ref reader)) {
            var root = jsonDoc.RootElement;
            var type = root.GetProperty("ResponsibilityType").GetString();
            switch (type.ToLower()) {
                case "ranged":
                    return JsonSerializer.Deserialize<Ranged>(root.GetRawText(), options);
                case "melee":
                    return JsonSerializer.Deserialize<Melee>(root.GetRawText(), options);
                case "heavy":
                    return JsonSerializer.Deserialize<Heavy>(root.GetRawText(), options);
                case "support":
                    return JsonSerializer.Deserialize<Support>(root.GetRawText(), options);
                case "mystic":
                    return JsonSerializer.Deserialize<Mystic>(root.GetRawText(), options);
                default:
                    throw new JsonException($"Unknown creature type: {type}");
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Creature value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, value.GetType(), options);
    }
}

// public class ProfileConverter : JsonConverter<Profile> {}