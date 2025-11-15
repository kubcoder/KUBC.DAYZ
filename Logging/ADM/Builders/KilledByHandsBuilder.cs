using KUBC.DAYZ.Logging.Events.Killed;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Парсер события когда игрок забил другого руками
/// </summary>
public class KilledByHandsBuilder : PlayerKillPlayerBuilder<KilledByHands>
{

    /// <inheritdoc/>
    protected override bool EventCheck(string data)
    {
        return data.Contains("with (");
    }
    /// <inheritdoc/>
    protected override KilledByHands? GetKillInfo(KilledByHands gameEvent, Events.StringReader reader)
    {
        reader.ReadTo('(');
        gameEvent.DamageName = reader.ReadTo(')');
        if (string.IsNullOrWhiteSpace(gameEvent.DamageName)) return null;
        return gameEvent;
    }
}
