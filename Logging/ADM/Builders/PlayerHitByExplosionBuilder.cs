using KUBC.DAYZ.Logging.Events.Damage;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события урона от бризантного боеприпаса
/// </summary>
public class PlayerHitByExplosionBuilder : PlayerDamageBaseBuilder<PlayerHitByExplosion>
{
    /// <inheritdoc/>
    protected override PlayerHitByExplosion? GetEvent(PlayerHitByExplosion gameEvent, Events.StringReader reader)
    {
        reader.ReadTo('(');
        gameEvent.ExplosionName = reader.ReadTo(')').Trim();
        if (string.IsNullOrWhiteSpace(gameEvent.ExplosionName)) return null;
        return gameEvent;
    }

    /// <inheritdoc/>
    protected override bool IsTargetSource(string data)
    {
        return data.Contains("hit by explosion");
    }
}
