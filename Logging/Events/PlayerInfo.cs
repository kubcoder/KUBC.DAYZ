namespace KUBC.DAYZ.Logging.Events;

/// <summary>
/// Сущность данных игрока
/// </summary>
public class PlayerInfo
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

    /// <summary>
    /// Координаты игрока
    /// </summary>
    public Vector Position { get; set; } = new();
}
