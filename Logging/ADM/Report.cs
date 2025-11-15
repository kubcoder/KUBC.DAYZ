using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM;

/// <summary>
/// Базовое событие жалобы/отчета игрока
/// </summary>
public class Report : GameEvent
{
    /// <summary>
    /// Идентификатор игрока
    /// </summary>
    public string PlayerId { get; set; } = string.Empty;

    /// <summary>
    /// Сообщение от игрока
    /// </summary>
    public string Message { get; set; } = string.Empty;
}
