using KUBC.DAYZ.Logging.Events.Killed;

namespace KUBC.DAYZ.Logging.ADM;

/// <summary>
/// Игрок убит каким то игровым предметом
/// </summary>
public class KilledByItem : PlayerKilled
{
    /// <summary>
    /// Какой предмет привел к смерти
    /// </summary>
    public string ItemName { get; set; } = string.Empty;
}
