using KUBC.DAYZ.Logging.Events.Damage;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события когда игрок грохнул другого 
/// с какой то дистанции
/// </summary>
public class PlayerHitByDistanceWeaponBuilder : PlayerHitByPlayerBaseBuilder<PlayerHitByDistanceWeapon>
{
    /// <inheritdoc/>
    protected override bool IsTargetSource(string data)
    {
        if (!base.IsTargetSource(data))
            return false;
        if (!data.Contains(WITH_DELIMITER))
            return false;
        return data.Contains(TAG_FROM);
    }
    /// <inheritdoc/>
    protected override PlayerHitByDistanceWeapon? GetEvent(PlayerHitByDistanceWeapon gameEvent, Events.StringReader reader)
    {
        var hitEvent = base.GetEvent(gameEvent, reader);
        if (hitEvent == null) return null;

        var weapon = ReadWeapon(reader);
        if (weapon == null) return null;
        gameEvent.Weapon = weapon;
        reader.ReadTo(TAG_FROM);
        reader.Skip(TAG_FROM.Length);
        var distance = reader.ReadDouble('m');
        if (distance == null) return null;
        gameEvent.Distance = distance.Value;
        return gameEvent;

    }
}
