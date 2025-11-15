namespace KUBC.DAYZ.Logging.Events;

/// <summary>
/// Событие с известным предметом и его координатами
/// </summary>
public class ItemPositionEvent : ItemEvent
{
    /// <summary>
    /// Известны координаты предмета
    /// </summary>
    public Vector ItemPosition { get; set; } = new();
}
