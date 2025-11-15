using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM;

/// <summary>
/// Событие игрового чата
/// </summary>
public class Chat : PlayerEvent
{
    /// <summary>
    /// Сообщение отправленное в чат
    /// </summary>
    public string Message { get; set; } = string.Empty;
}
