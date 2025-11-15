using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события подключения игрока
/// </summary>
public class PlayerConnectedBuilder : PlayerEventBuilder
{

    /// <inheritdoc/>
    protected override GameEvent GetEvent(DateTime timeStamp, string name, string plainId, bool isAlive)
    {
        return new PlayerConnected()
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
        return data.Contains("is connecting");

    }
}

