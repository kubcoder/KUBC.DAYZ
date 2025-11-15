namespace KUBC.DAYZ.Logging.Events.Damage;



/// <summary>
/// Базовый анализатор получения урона игроком
/// </summary>
/// <typeparam name="T">Тип события</typeparam>
public abstract class PlayerDamageBaseBuilder<T> : PlayerEventPositionBuilder<T> where T : PlayerDamage, new()
{


    /// <inheritdoc/>
    protected override bool IsTarget(string data)
    {
        if (!base.IsTarget(data))
            return false;
        return IsTargetSource(data);
    }

    private const string HP = "HP: ";

    /// <inheritdoc/>
    protected override T? GetEvent(DateTime timeStamp, string name, string plainId, bool isAlive, StringReader reader)
    {
        var gameEvent = base.GetEvent(timeStamp, name, plainId, isAlive, reader);
        if (gameEvent == null)
            return null;
        reader.ReadTo(HP);
        reader.Skip(HP.Length);
        var hp = reader.ReadDouble(']');
        if (!hp.HasValue)
            return null;
        gameEvent.HP = hp.Value;
        return GetEvent(gameEvent, reader);

    }
    /// <summary>
    /// Получить типизированное событие
    /// </summary>
    /// <param name="gameEvent">Созданное событие</param>
    /// <param name="reader">Поток для чтения</param>
    /// <returns>Событие если удалось прочитать</returns>
    protected abstract T? GetEvent(T gameEvent, StringReader reader);

    /// <summary>
    /// Проверить что источник урона для целевого события
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    protected virtual bool IsTargetSource(string data) => true;


    /// <summary>
    /// Тэг указания что урон нанесен в конкретную зону
    /// </summary>
    protected const string INTO_DELIMITER = "into";
    /// <summary>
    /// Тэг указания кем нанесен урон
    /// </summary>
    protected const string HITBY = "hit by ";

    private const string FOR_DELIMITER = "for";

    /// <summary>
    /// Тэг указания чем именно нанесли урон
    /// </summary>
    protected const string WITH_DELIMITER = "with";

    /// <summary>
    /// Выполнить чтение информации о зоне поражения
    /// </summary>
    /// <param name="reader">Поток для чтения</param>
    /// <param name="skipToData">
    /// Выполнить поиск слова into, и после этого выполнить чтение.
    /// Если установить false то пропуск текста не будет осуществляться
    /// </param>
    /// <returns></returns>
    protected ZoneDamageInfo? ReadZoneDamage(StringReader reader, bool skipToData = true)
    {
        if (skipToData)
        {
            reader.ReadTo(INTO_DELIMITER);
            reader.Skip(INTO_DELIMITER.Length);
        }
        string zoneName = reader.ReadTo('(');
        var zoneIndex = reader.ReadInt(')');
        if (zoneIndex == null) return null;
        reader.ReadTo(FOR_DELIMITER);
        reader.Skip(FOR_DELIMITER.Length + 1);
        var damageValue = reader.ReadDouble(' ');
        if (damageValue == null) return null;
        reader.ReadTo('(');
        var damageName = reader.ReadTo(')');
        if (damageName == null) return null;
        return new()
        {
            Damage = damageValue.Value,
            DamageName = damageName,
            Index = zoneIndex.Value,
            Name = zoneName.Trim()
        };

    }
}
