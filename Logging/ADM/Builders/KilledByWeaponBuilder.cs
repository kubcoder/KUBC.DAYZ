using KUBC.DAYZ.Logging.Events.Killed;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Парсер события, убил с помощью оружия
/// </summary>
public class KilledByWeaponBuilder : PlayerKillPlayerBuilder<KilledByWeapon>
{

    /// <inheritdoc/>
    protected override bool EventCheck(string data)
    {
        if (data.Contains(TAG_FROM)) return false;
        if (data.Contains("with (")) return false;
        return data.Contains(TAG_WITH);
    }

    /// <inheritdoc/>
    protected override KilledByWeapon? GetKillInfo(KilledByWeapon gameEvent, Events.StringReader reader)
    {
        gameEvent.Weapon = ReadWeapon(reader);
        if (string.IsNullOrWhiteSpace(gameEvent.Weapon)) return null;
        return gameEvent;
    }
}
