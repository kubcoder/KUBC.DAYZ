using KUBC.DAYZ.Logging.Events.Killed;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события игрок убит предметом
/// </summary>
public class KilledByItemBuilder : PlayerKilledBuilder<KilledByItem>
{
    /// <inheritdoc/>
    protected override bool IsTarget(string data)
    {
        if (!base.IsTarget(data))
            return false;
        if (data.Contains("killed by Zmb"))
            return false;
        if (data.Contains("killed by Player"))
            return false;
        if (data.Contains("with"))
            return false;
        return data.Contains("killed by");
    }

    /// <inheritdoc/>
    protected override KilledByItem? GetEvent(KilledByItem gameEvent, Events.StringReader reader)
    {
        reader.ReadTo(TAG_KILL_BY);
        reader.Skip(TAG_KILL_BY.Length);
        var item = reader.ReadToEnd().Trim();
        if (string.IsNullOrWhiteSpace(item)) return null;
        gameEvent.ItemName = item;
        return gameEvent;
    }
}
