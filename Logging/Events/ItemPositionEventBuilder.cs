
namespace KUBC.DAYZ.Logging.Events;

/// <summary>
/// Абстрактный построитель события связанного с игровым предметом и известны координаты объекта
/// </summary>
/// <typeparam name="T"></typeparam>

public abstract class ItemPositionEventBuilder<T> : ItemEventBuilder<T> where T : ItemPositionEvent, new()
{
    /// <summary>
    /// Строка для поиска начала координат
    /// </summary>
    protected abstract string StartPosition { get; }

    /// <inheritdoc/>
    protected override T? GetEvent(DateTime timeStamp, string name, string plainId, bool isAlive, StringReader reader)
    {
        var gameEvent = base.GetEvent(timeStamp, name, plainId, isAlive, reader);
        if (gameEvent == null)
            return null;
        reader.ReadTo(StartPosition);
        reader.Skip(StartPosition.Length);
        if (reader.IsEnd) return null;
        var position = reader.ReadVector();
        if (position == null) return null;
        gameEvent.ItemPosition = position;
        return gameEvent;
    }
}
