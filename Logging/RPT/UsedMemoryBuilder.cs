using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.RPT;
/// <summary>
/// Парсер строчки лога с информацией об используемой памяти
/// </summary>
public class UsedMemoryBuilder : Events.EventBuilder
{
    private const string TARGETTEXT = "Used memory:";

    /// <inheritdoc/>
    public override GameEvent? Build(DateTime timeStamp, string data)
    {
        if (!data.StartsWith(TARGETTEXT))
        {
            return null;
        }
        var reader = new Events.StringReader(data.Substring(TARGETTEXT.Length).Trim());
        var mem = reader.ReadDouble(' ');
        if (mem == null)
        {
            return null;
        }
        return new UsedMemory()
        {
            TimeStamp = timeStamp,
            Value = mem.Value
        };
    }
}
