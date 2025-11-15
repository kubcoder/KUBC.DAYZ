using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.RPT;

/// <summary>
/// Событие найден SteamID игрока
/// </summary>
public class PlayerSteamFound : GameEvent
{
    /// <summary>
    /// SteamID игрока
    /// </summary>
    public Int64 SteamID { get; set; } = 0;

    /// <summary>
    /// Его имя
    /// </summary>
    public string NickName { get; set; } = string.Empty;
}
