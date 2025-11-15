namespace KUBC.DAYZ.Logging.Events;

/// <summary>
/// Генерировать событие
/// </summary>
public class PlayerEventPositionBuilder<T> : PlayerEventBuilder where T : PlayerEventPosition, new()
{
    /// <inheritdoc/>
    protected override char SymbolEndId => ' ';

    /// <inheritdoc/>
    protected override T? GetEvent(DateTime timeStamp, string name, string plainId, bool isAlive, StringReader reader)
    {
        var posText = reader.ReadTo('=');
        if (posText != "pos")
        {
            return null;
        }
        reader.Skip(1);
        var vector = reader.ReadVector();
        if (vector == null) return null;
        return new T()
        {
            Id = plainId,
            NickName = name,
            Position = vector,
            TimeStamp = timeStamp,
            IsAlive = isAlive,
        };
    }

}
