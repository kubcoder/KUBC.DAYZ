using KUBC.DAYZ.Logging.Events.Killed;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события игрок убит зомби
/// </summary>
public class KilledByZombieBuilder : PlayerKilledBuilder<KilledByZombie>
{

    /// <inheritdoc/>
    protected override bool IsTarget(string data)
    {
        if (!base.IsTarget(data))
            return false;
        return data.Contains("killed by Zmb");
    }

    /// <inheritdoc/>
    protected override KilledByZombie? GetEvent(KilledByZombie gameEvent, Events.StringReader reader)
    {
        reader.ReadTo(TAG_KILL_BY);
        reader.Skip(TAG_KILL_BY.Length);
        var zmb = reader.ReadToEnd().Trim();
        if (string.IsNullOrWhiteSpace(zmb)) return null;
        gameEvent.Zombie = zmb;
        return gameEvent;
    }

}
