using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM;

/// <summary>
/// Событие строительства игроком
/// </summary>
public class Built : PlayerEventPosition
{
    /// <summary>
    /// Объект
    /// </summary>
    public string? Construction { get; set; }
    /// <summary>
    /// Какой элемент был построен/разрушен
    /// </summary>
    public string? Element { get; set; }
    /// <summary>
    /// Какой инструмент использован
    /// </summary>
    public string? Tool { get; set; }
}
