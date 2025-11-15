namespace KUBC.DAYZ.Logging.Events;

/// <summary>
/// Игровое событие где есть игрок
/// </summary>
public class PlayerEvent : GameEvent
{
    /// <summary>
    /// Идентификатор игрока в DAYZ
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Никнейм игрока
    /// </summary>
    public string NickName { get; set; } = string.Empty;

    /// <summary>
    /// Игрок живой
    /// </summary>
    public bool IsAlive { get; set; } = true;
}
