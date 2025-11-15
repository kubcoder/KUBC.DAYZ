using KUBC.DAYZ.Logging.Events.Damage;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события урон с помощью ручного оружия
/// </summary>
public class PlayerHitByWeaponBuilder : PlayerHitByPlayerBaseBuilder<PlayerHitByWeapon>
{

    /// <summary>
    /// Инициализируем отсчечку похожих событий
    /// </summary>
    public PlayerHitByWeaponBuilder()
    {
        ExcludeNames = [
            TAG_FROM
            ];
    }
    /// <inheritdoc/>
    protected override bool IsTargetSource(string data)
    {
        if (!base.IsTargetSource(data))
            return false;
        return data.Contains(WITH_DELIMITER);
    }

    /// <inheritdoc/>
    protected override PlayerHitByWeapon? GetEvent(PlayerHitByWeapon gameEvent, Events.StringReader reader)
    {
        var hitEvent = base.GetEvent(gameEvent, reader);
        if (hitEvent == null) return null;

        var weapon = ReadWeapon(reader);
        if (weapon == null) return null;
        gameEvent.Weapon = weapon;
        return gameEvent;
    }
}
