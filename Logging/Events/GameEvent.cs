namespace KUBC.DAYZ.Logging.Events;

/// <summary>
/// Класс игрового события
/// </summary>
public class GameEvent
{
    /// <summary>
    /// Дата и время события, в UTC
    /// </summary>
    public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
}
