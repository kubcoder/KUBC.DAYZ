namespace KUBC.DAYZ.Logging.Events.Killed;

/// <summary>
/// Событие когда игрок убил другого игрока
/// </summary>
public class PlayerKilledByPlayer : PlayerKilled
{
    /// <summary>
    /// Информация о убийце
    /// </summary>
    public PlayerInfo Killer { get; set; } = new();
}
