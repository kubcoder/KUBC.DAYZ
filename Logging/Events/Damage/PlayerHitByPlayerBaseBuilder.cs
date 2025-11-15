using KUBC.DAYZ.Logging.ADM;

namespace KUBC.DAYZ.Logging.Events.Damage;

/// <summary>
/// Базовый построитель события когда игроку нанес урон другой игрок
/// </summary>
/// <typeparam name="T">Целевой тип события</typeparam>
public abstract class PlayerHitByPlayerBaseBuilder<T> : PlayerDamageBaseBuilder<T> where T : PlayerHitByPlayer, new()
{

    /// <summary>
    /// Тэг означающий дистанцию
    /// </summary>
    protected const string TAG_FROM = "from";

    /// <inheritdoc/>
    protected override bool IsTargetSource(string data)
    {
        return data.Contains("hit by Player");
    }



    /// <inheritdoc/>
    protected override T? GetEvent(T gameEvent, StringReader reader)
    {
        var sourceBuilder = new PlayerInfoBuilder(reader);
        var source = sourceBuilder.Build();
        if (source == null) return null;
        gameEvent.Source = source;
        var zone = ReadZoneDamage(reader);
        if (zone == null) return null;
        gameEvent.DamageZone = zone;
        return gameEvent;
    }

    /// <summary>
    /// Прочитать из потока оружие
    /// </summary>
    /// <param name="reader"></param>
    /// <returns></returns>
    protected string? ReadWeapon(StringReader reader)
    {
        reader.ReadTo(WITH_DELIMITER);
        reader.Skip(WITH_DELIMITER.Length);
        var weapon = reader.ReadTo(TAG_FROM).Trim();
        if (string.IsNullOrWhiteSpace(weapon)) return null;
        return weapon;
    }
}
