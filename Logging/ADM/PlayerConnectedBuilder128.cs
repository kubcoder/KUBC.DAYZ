using KUBC.DAYZ.Logging.ADM;
using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Host.Events.Parsers;

/// <summary>
/// Событие подключения игрока для сервера версии 1.28 и раньше
/// </summary>
public class PlayerConnectedBuilder128 : PlayerEventBuilder
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
        return data.Contains("is connected");

    }
}