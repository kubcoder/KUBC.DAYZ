using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

//Player "Altai_48 (2)" (DEAD) (id=71bKIjZIjXME4VuQD6S63KpUw6N1MUCLu1mC6Ja4phU= pos=<7607.4, 3276.5, 6.1>) died. Stats> Water: 4698.26 Energy: 407.582 Bleed sources: 1

/// <summary>
/// Анализатор события игрок умер
/// </summary>
public class PlayerDiedBuilder : PlayerEventPositionBuilder<PlayerDied>
{
    private const string TargetText = "died. Stats>";

    /// <inheritdoc/>
    protected override PlayerDied? GetEvent(DateTime timeStamp, string name, string plainId, bool isAlive, Events.StringReader reader)
    {
        var gameEvent = base.GetEvent(timeStamp, name, plainId, isAlive, reader);
        if (gameEvent == null)
            return null;
        reader.ReadTo(':');
        reader.Skip(1);
        var water = reader.ReadDouble(' ');
        if (!water.HasValue)
            return null;
        gameEvent.Water = water.Value;
        reader.ReadTo(':');
        reader.Skip(1);
        var energy = reader.ReadDouble(' ');
        if (!energy.HasValue)
            return null;
        gameEvent.Energy = energy.Value;
        reader.ReadTo(':');
        reader.Skip(1);
        var bleed = reader.ReadInt();
        if (!bleed.HasValue) return null;
        gameEvent.Bleeding = bleed.Value;
        return gameEvent;
    }

    /// <inheritdoc/>
    protected override bool IsTarget(string data)
    {
        if (!base.IsTarget(data))
            return false;
        return data.Contains(TargetText);
    }
}
