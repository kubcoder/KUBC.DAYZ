namespace KUBC.DAYZ.Logging.Events;

/// <summary>
/// Событие прикрепления/открепления элемента
/// </summary>
public class ItemAttachEvent : ItemEvent
{
    /// <summary>
    /// Конструкция на которую был прикреплен элемент
    /// </summary>
    public string Construction { get; set; } = string.Empty;
}
