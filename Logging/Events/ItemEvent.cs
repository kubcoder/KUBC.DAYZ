namespace KUBC.DAYZ.Logging.Events;

/// <summary>
/// Событие в координатах, при этом известен предмет
/// который использовался
/// </summary>
public class ItemEvent : PlayerEventPosition
{
    /// <summary>
    /// Использованный предмет
    /// </summary>
    public string ItemName { get; set; } = string.Empty;

}
