using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события разборки конструкции
/// </summary>
public class DismantledBuilder : PlayerEventPositionBuilder<Dismantled>
{
    private const string tagName = "Dismantled";

    /// <inheritdoc/>
    protected override bool IsTarget(string data)
    {
        if (!base.IsTarget(data)) return false;
        return data.Contains(tagName);
    }

    private const string constructionTag = "from";

    private const string toolTag = "with";

    /// <inheritdoc/>
    protected override Dismantled? GetEvent(DateTime timeStamp, string name, string plainId, bool isAlive, Events.StringReader reader)
    {
        var dismantledEvent = base.GetEvent(timeStamp, name, plainId, isAlive, reader);
        if (dismantledEvent == null) return null;
        reader.ReadTo(tagName);
        reader.Skip(tagName.Length);
        dismantledEvent.Element = reader.ReadTo(constructionTag).Trim();
        if (string.IsNullOrEmpty(dismantledEvent.Element)) return null;
        if (reader.IsEnd)
            return null;
        reader.Skip(constructionTag.Length);
        dismantledEvent.Construction = reader.ReadTo(toolTag).Trim();
        if (string.IsNullOrEmpty(dismantledEvent.Construction)) return null;
        if (reader.IsEnd)
            return null;
        reader.Skip(toolTag.Length);
        dismantledEvent.Tool = reader.ReadToEnd().Trim();
        if (string.IsNullOrEmpty(dismantledEvent.Tool)) return null;
        return dismantledEvent;
    }


}
