namespace KUBC.DAYZ.Logging.Events;

/// <summary>
/// Игровое событие где есть игрок и известны его координаты
/// </summary>
public class PlayerEventPosition : PlayerEvent
{
    /// <summary>
    /// Координаты где произошло событие
    /// </summary>
    public Vector Position { get; set; } = new();
}
