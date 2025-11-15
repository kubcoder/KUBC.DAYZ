using System.Text.Json;
using System.Text.Json.Serialization;

namespace KUBC.DAYZ;

/// <summary>
/// Интерфейс записи и сохранения в JSON
/// </summary>
public class VectorJsonConverter : JsonConverter<Vector>
{
    /// <inheritdoc/>
    public override Vector? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        do
        {
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var result = ReadFromArray(ref reader);
                if (VectorLoaded(result))
                    return result;
                return null;
            }
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return null;
            }
        } while (reader.Read());

        return null;
    }

    private Vector CreateVector()
    {
        return new Vector()
        {
            X = double.MinValue,
            Y = double.MinValue,
            Z = double.MinValue,
        };
    }

    private bool VectorLoaded(Vector? result)
    {
        if (result == null) return false;
        if (result.X == double.MinValue) return false;
        if (result.Y == double.MinValue) return false;
        if (result.Z == double.MinValue) return false;
        return true;
    }
    private Vector? ReadFromArray(ref Utf8JsonReader reader)
    {
        var result = CreateVector();
        int index = 0;
        do
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                if (reader.TryGetDouble(out double property))
                {
                    switch (index)
                    {
                        case 0:
                            result.X = property;
                            index++;
                            break;
                        case 1:
                            result.Y = property;
                            index++;
                            break;
                        case 2:
                            result.Z = property;
                            index++;
                            break;
                    }
                }
            }
            if (reader.TokenType == JsonTokenType.EndArray)
                return result;
        }
        while (reader.Read());
        return result;
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, Vector value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        writer.WriteNumberValue(value.X);
        writer.WriteNumberValue(value.Y);
        writer.WriteNumberValue(value.Z);
        writer.WriteEndArray();
    }
}
