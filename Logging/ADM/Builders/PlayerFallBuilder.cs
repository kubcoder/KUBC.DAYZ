using KUBC.DAYZ.Logging.Events.Damage;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события игрок упал и повредился
/// </summary>
public class PlayerFallBuilder : PlayerDamageBaseBuilder<PlayerFall>
{
    /// <inheritdoc/>
    protected override PlayerFall? GetEvent(PlayerFall gameEvent, Events.StringReader reader)
    {
        return gameEvent;
    }


    /// <inheritdoc/>
    protected override bool IsTargetSource(string data)
    {
        return data.Contains("hit by FallDamageHealth");
    }
}
