namespace KUBC.DAYZ.Logging.Events;

/// <summary>
/// Сущность данных метрики события
/// </summary>
public class GameMetrics : GameEvent
{
    /// <summary>
    /// Значение данных метрики сервера
    /// </summary>
    public double Value { get; set; } = 0;
}
