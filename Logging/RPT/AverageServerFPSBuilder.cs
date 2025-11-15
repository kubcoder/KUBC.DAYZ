using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.RPT;

/// <summary>
/// Парсер строчки лога с FPS
/// </summary>
public class AverageServerFPSBuilder : Events.EventBuilder
{
    private const string TARGETTEXT = "Average server FPS:";

    /// <inheritdoc/>
    public override GameEvent? Build(DateTime timeStamp, string data)
    {
        if (!data.StartsWith(TARGETTEXT))
        {
            return null;
        }
        var reader = new Events.StringReader(data.Substring(TARGETTEXT.Length).Trim());
        var fps = reader.ReadDouble(' ');
        if (fps == null)
        {
            return null;
        }
        return new AverageServerFPS()
        {
            TimeStamp = timeStamp,
            Value = fps.Value
        };
    }
}
