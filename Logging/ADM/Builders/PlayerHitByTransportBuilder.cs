using KUBC.DAYZ.Logging.Events.Damage;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события, урона от ДТП
/// </summary>
public class PlayerHitByTransportBuilder : PlayerDamageBaseBuilder<PlayerHitByTransport>
{
    /// <inheritdoc/>
    protected override bool IsTargetSource(string data)
    {
        return data.Contains("with TransportHit");
    }

    /// <inheritdoc/>
    protected override PlayerHitByTransport? GetEvent(PlayerHitByTransport gameEvent, Events.StringReader reader)
    {
        reader.ReadTo(HITBY);
        reader.Skip(HITBY.Length);
        gameEvent.Transport = reader.ReadTo(WITH_DELIMITER).Trim();
        if (string.IsNullOrWhiteSpace(gameEvent.Transport)) return null;
        return gameEvent;
    }
}
