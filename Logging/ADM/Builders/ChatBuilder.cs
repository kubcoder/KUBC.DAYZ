using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события игрового чата
/// </summary>
public class ChatBuilder : EventBuilder
{
    private const string TargetSTring = "Chat(\"";

    /// <inheritdoc/>
    public override GameEvent? Build(DateTime timeStamp, string data)
    {
        if (!data.StartsWith(TargetSTring))
            return null;
        var stream = new Events.StringReader(data.Substring(TargetSTring.Length));
        var name = stream.ReadTo('"');
        if (string.IsNullOrWhiteSpace(name))
            return null;
        stream.ReadTo('=');
        var id = stream.ReadTo(')');
        if (string.IsNullOrWhiteSpace(id))
            return null;
        stream.ReadTo(':');
        var message = stream.ReadToEnd();
        if (string.IsNullOrWhiteSpace(message))
            return null;
        return new Chat()
        {
            IsAlive = true,
            Message = message,
            NickName = name,
            Id = id,
            TimeStamp = timeStamp
        };
    }
}
