namespace KUBC.DAYZ.Logging.Events;

/// <summary>
/// Построитель события <see cref="ItemEvent"/>
/// </summary>
public abstract class ItemEventBuilder<T> : PlayerEventPositionBuilder<T> where T : ItemEvent, new()
{
    /// <summary>
    /// Имя которое ищем, после чего вычитываем название игрового предмета
    /// </summary>
    protected abstract string TargetText { get; }

    /// <summary>
    /// На каком символе завершить чтение
    /// Если символ null то чтение до конца строки
    /// </summary>
    protected virtual char? EndSymbol { get; }

    /// <summary>
    /// На какой строке завершить чтение
    /// </summary>
    protected virtual string? EndString { get; }

    /// <inheritdoc/>
    protected override bool IsTarget(string data)
    {
        if (!base.IsTarget(data)) return false;
        return data.Contains(TargetText);
    }

    /// <inheritdoc/>
    protected override T? GetEvent(DateTime timeStamp, string name, string plainId, bool isAlive, StringReader reader)
    {
        var gameEvent = base.GetEvent(timeStamp, name, plainId, isAlive, reader);
        if (gameEvent == null) return null;
        reader.ReadTo(TargetText);
        reader.Skip(TargetText.Length);
        if (reader.IsEnd)
            return null;
        if (EndSymbol != null)
            gameEvent.ItemName = reader.ReadTo(EndSymbol.Value).Trim();
        else
        {
            if (EndString != null)
            {
                gameEvent.ItemName = reader.ReadTo(EndString).Trim();
            }
            else
            {
                gameEvent.ItemName = reader.ReadToEnd().Trim();
            }
        }
        if (string.IsNullOrWhiteSpace(gameEvent.ItemName))
            return null;
        return gameEvent;
    }
}
