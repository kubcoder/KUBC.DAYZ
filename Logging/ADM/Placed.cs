using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM;

/// <summary>
/// Событие размещения объекта
/// </summary>
public class Placed : ItemEvent
{
    /// <summary>
    /// Имя класса объекта
    /// </summary>
    public string ClassName { get; set; } = string.Empty;
}
