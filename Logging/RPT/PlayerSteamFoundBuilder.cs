using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.RPT;

/*Player "Survivor"(steamID=76561198323721568) is connected*/

/// <summary>
/// Анализатор события о найденном STEAM ID игрока
/// </summary>
public class PlayerSteamFoundBuilder : Events.EventBuilder
{
    /// <inheritdoc/>
    public override GameEvent? Build(DateTime timeStamp, string data)
    {
        if (!IsTargetLine(data))
            return null;
        var reader = new Events.StringReader(data);
        reader.ReadTo('"');
        var name = reader.ReadTo('"');
        if (string.IsNullOrWhiteSpace(name))
            return null;
        reader.ReadTo('=');
        var stringSteamID = reader.ReadTo(' ');
        if (stringSteamID.EndsWith(')'))
        {
            stringSteamID = stringSteamID[..^1];
        }
        if (string.IsNullOrWhiteSpace(stringSteamID))
            return null;
        if (!Int64.TryParse(stringSteamID, out var steamId))
            return null;
        return new PlayerSteamFound()
        {
            SteamID = steamId,
            NickName = name,
            TimeStamp = timeStamp,
        };
    }

    private bool IsTargetLine(string data)
    {
        if (!data.StartsWith("Player"))
            return false;
        if (!data.Contains("steamID="))
            return false;
        if (!data.Contains("is connected"))
            return false;
        return true;
    }
}
