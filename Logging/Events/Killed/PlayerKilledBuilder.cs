namespace KUBC.DAYZ.Logging.Events.Killed;

/// <summary>
/// Базовый построитель убийства игрока
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class PlayerKilledBuilder<T> : PlayerEventPositionBuilder<T> where T : PlayerKilled, new()
{
    /// <inheritdoc/>
    protected override T? GetEvent(DateTime timeStamp, string name, string plainId, bool isAlive, Events.StringReader reader)
    {
        var gameEvent = base.GetEvent(timeStamp, name, plainId, isAlive, reader);
        if (gameEvent == null) return null;
        return GetEvent(gameEvent, reader);
    }

    /// <summary>
    /// Тэг означающий что игрок был убит
    /// </summary>
    protected const string TAG_KILL_BY = "killed by";

    /// <summary>
    /// Дополнить событие
    /// </summary>
    /// <param name="gameEvent">Базовое игровое событие</param>
    /// <param name="reader">Контекст чтения</param>
    /// <returns></returns>
    protected virtual T? GetEvent(T gameEvent, StringReader reader) => gameEvent;
}
