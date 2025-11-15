namespace KUBC.DAYZ.Logging.Events.Damage;

/// <summary>
/// Событие урона игроку
/// </summary>
public class PlayerDamage : PlayerEventPosition
{
    /// <summary>
    /// Здоровье игрока на момент получения урона
    /// </summary>
    public double HP { get; set; } = 0;
}
