using KUBC.DAYZ.Logging.Events.Damage;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Абстрактный класс создания событий с именованным источником
/// </summary>
public class PlayerHitByItemInZoneBuilder : PlayerDamageBaseBuilder<PlayerHitByItemInZone>
{
    /// <summary>
    /// Инициализация списка исключаемых слов
    /// </summary>
    public PlayerHitByItemInZoneBuilder()
    {
        ExcludeNames = [
            "hit by Зараженный",
            "with",
            "hit by Player"];
    }


    /// <inheritdoc/>
    protected override PlayerHitByItemInZone? GetEvent(PlayerHitByItemInZone gameEvent, Events.StringReader reader)
    {
        reader.ReadTo(HITBY);
        reader.Skip(HITBY.Length);
        gameEvent.Source = reader.ReadTo(INTO_DELIMITER).Trim();
        if (string.IsNullOrWhiteSpace(gameEvent.Source)) return null;
        reader.Skip(INTO_DELIMITER.Length);
        var zone = ReadZoneDamage(reader, false);
        if (zone == null) return null;
        gameEvent.DamageInfo = zone;
        return gameEvent;
    }

}
