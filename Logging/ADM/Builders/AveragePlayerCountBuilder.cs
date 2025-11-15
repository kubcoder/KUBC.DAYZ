using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события числа игроков на сервере
/// </summary>
public class AveragePlayerCountBuilder : EventBuilder
{
    private const string TARGETTEXT = "##### PlayerList log:";

    /// <inheritdoc/>
    public override GameEvent? Build(DateTime timeStamp, string data)
    {
        if (!data.StartsWith(TARGETTEXT))
        {
            return null;
        }
        var reader = new Events.StringReader(data[TARGETTEXT.Length..].Trim());
        var playerCount = reader.ReadDouble(' ');
        if (playerCount == null)
        {
            return null;
        }
        return new AveragePlayerCount()
        {
            TimeStamp = timeStamp,
            Value = playerCount.Value
        };
    }
}
