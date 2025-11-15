namespace KUBC.DAYZ.Logging.Events.Killed;

/// <summary>
/// Абстрактный клас парсера событий игрок убил игрока
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class PlayerKillPlayerBuilder<T> : PlayerKilledBuilder<T> where T : PlayerKilledByPlayer, new()
{

    /// <inheritdoc/>
    protected override bool IsTarget(string data)
    {
        if (!base.IsTarget(data))
            return false;
        if (!data.Contains("killed by Player"))
            return false;
        return EventCheck(data);
    }

    /// <summary>
    /// Выполнить дополнительные проверки на соответствие событию
    /// </summary>
    /// <param name="data">Строка лога</param>
    /// <returns>Истина если строчка подходит событию</returns>
    protected virtual bool EventCheck(string data) => true;

    /// <inheritdoc/>
    protected override T? GetEvent(T gameEvent, StringReader reader)
    {
        var killerBuilder = new PlayerInfoBuilder(reader);
        var killer = killerBuilder.Build();
        if (killer == null)
            return null;
        gameEvent.Killer = killer;
        return GetKillInfo(gameEvent, reader);
    }

    /// <summary>
    /// Получить полное описание события
    /// </summary>
    /// <param name="gameEvent">Игровое событие с указанием киллера</param>
    /// <param name="reader">Поток для чтения</param>
    /// <returns></returns>
    protected abstract T? GetKillInfo(T gameEvent, StringReader reader);

    /// <summary>
    /// Тэг означающий дистанцию
    /// </summary>
    protected const string TAG_FROM = "from";

    /// <summary>
    /// Тэг означающий чем убивали
    /// </summary>
    protected const string TAG_WITH = "with";

    /// <summary>
    /// Вычитать оружие с помощью которого убивали
    /// </summary>
    /// <param name="reader"></param>
    /// <returns></returns>
    protected string ReadWeapon(StringReader reader)
    {
        reader.ReadTo(TAG_WITH);
        reader.Skip(TAG_WITH.Length);
        return reader.ReadTo(TAG_FROM).Trim();
    }
}
