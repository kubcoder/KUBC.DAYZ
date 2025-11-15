using KUBC.DAYZ.Logging.Events.Damage;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Построитель события когда игрок выхватил от игрового предмета
/// </summary>
public class PlayerHitByItemBuilder : PlayerDamageBaseBuilder<PlayerHitByItem>
{
    /// <summary>
    /// Инициализация списка исключаемых слов
    /// </summary>
    public PlayerHitByItemBuilder()
    {
        ExcludeNames = [
            "hit by Зараженный",
            "into",
            "hit by Player",
            "with TransportHit",
            "hit by explosion"
        ];
    }

    /// <inheritdoc/>
    protected override bool IsTargetSource(string data)
    {
        return data.Contains(WITH_DELIMITER);
    }

    /// <inheritdoc/>
    protected override PlayerHitByItem? GetEvent(PlayerHitByItem gameEvent, Events.StringReader reader)
    {
        reader.ReadTo(HITBY);
        reader.Skip(HITBY.Length);
        gameEvent.Source = reader.ReadTo(WITH_DELIMITER).Trim();
        if (string.IsNullOrWhiteSpace(gameEvent.Source)) return null;
        reader.Skip(WITH_DELIMITER.Length);
        gameEvent.DamageName = reader.ReadToEnd().Trim();
        return gameEvent;
    }
}
