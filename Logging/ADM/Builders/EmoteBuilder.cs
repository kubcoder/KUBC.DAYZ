using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Парсер событий эмоций
/// </summary>
public class EmoteBuilder : PlayerEventPositionBuilder<Emote>
{
    /// <inheritdoc/>
    protected override bool IsTarget(string data)
    {
        if (!base.IsTarget(data))
        {
            return false;
        }
        return data.Contains(KEY_TAG);
    }

    private const string KEY_TAG = "performed";

    private const string WITH_TAG = "with";


    /// <inheritdoc/>
    protected override Emote? GetEvent(DateTime timeStamp, string name, string plainId, bool isAlive, Events.StringReader reader)
    {
        var gameEvent = base.GetEvent(timeStamp, name, plainId, isAlive, reader);
        if (gameEvent == null) return null;
        reader.ReadTo(KEY_TAG);
        reader.Skip(KEY_TAG.Length);
        gameEvent.Action = reader.ReadTo(WITH_TAG).Trim();
        if (string.IsNullOrWhiteSpace(gameEvent.Action)) return null;
        if (reader.PreRead(WITH_TAG.Length) != WITH_TAG)
            return gameEvent;
        reader.Skip(WITH_TAG.Length);
        var item = reader.ReadToEnd().Trim();
        if (string.IsNullOrWhiteSpace(item)) return gameEvent;
        return new EmoteWithItem()
        {
            Action = gameEvent.Action,
            Id = plainId,
            IsAlive = isAlive,
            Item = item,
            NickName = name,
            Position = gameEvent.Position,
            TimeStamp = timeStamp,
        };
    }
}
