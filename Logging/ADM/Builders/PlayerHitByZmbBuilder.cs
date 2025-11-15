using KUBC.DAYZ.Logging.Events.Damage;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события когда игрок выхватил от зомбя
/// </summary>
public class PlayerHitByZmbBuilder : PlayerDamageBaseBuilder<PlayerHitByZmb>
{
    /// <inheritdoc/>
    protected override PlayerHitByZmb? GetEvent(PlayerHitByZmb gameEvent, Events.StringReader reader)
    {
        var zoneDamage = ReadZoneDamage(reader);
        if (zoneDamage == null)
            return null;
        gameEvent.DamageInfo = zoneDamage;
        return gameEvent;
    }

    /// <inheritdoc/>
    protected override bool IsTargetSource(string data)
    {
        return data.Contains("hit by Зараженный into");
    }
}
