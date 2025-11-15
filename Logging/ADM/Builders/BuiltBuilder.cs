using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события строительства
/// </summary>
public class BuiltBuilder : PlayerEventPositionBuilder<Built>
{
    private const string tagName = "Built";

    /// <inheritdoc/>
    protected override bool IsTarget(string data)
    {
        if (!base.IsTarget(data)) return false;
        return data.Contains(tagName);
    }

    private const string constructionTag = "on";

    private const string toolTag = "with";

    /// <inheritdoc/>
    protected override Built? GetEvent(DateTime timeStamp, string name, string plainId, bool isAlive, Events.StringReader reader)
    {
        var builtEvent = base.GetEvent(timeStamp, name, plainId, isAlive, reader);
        if (builtEvent == null) return null;
        reader.ReadTo(tagName);
        reader.Skip(tagName.Length);
        builtEvent.Element = reader.ReadTo(constructionTag).Trim();
        if (string.IsNullOrEmpty(builtEvent.Element)) return null;
        if (reader.IsEnd)
            return null;
        reader.Skip(constructionTag.Length);
        builtEvent.Construction = reader.ReadTo(toolTag).Trim();
        if (string.IsNullOrEmpty(builtEvent.Construction)) return null;
        if (reader.IsEnd)
            return null;
        reader.Skip(toolTag.Length);
        builtEvent.Tool = reader.ReadToEnd().Trim();
        if (string.IsNullOrEmpty(builtEvent.Tool)) return null;
        return builtEvent;
    }
}
