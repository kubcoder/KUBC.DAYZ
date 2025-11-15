using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события об отключении игрока
/// </summary>
public class PlayerDisconnectedBuilder : PlayerEventBuilder
{

    /// <inheritdoc/>
    protected override GameEvent GetEvent(DateTime timeStamp, string name, string plainId, bool isAlive)
    {
        return new PlayerDisconnected()
        {
            Id = plainId,
            NickName = name,
            TimeStamp = timeStamp
        };

    }
    /// <inheritdoc/>
    protected override bool IsTarget(string data)
    {
        if (!base.IsTarget(data))
            return false;
        return data.Contains("has been disconnected");

    }
}
