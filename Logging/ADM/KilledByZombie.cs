using KUBC.DAYZ.Logging.Events.Killed;

namespace KUBC.DAYZ.Logging.ADM;

/// <summary>
/// Игрок убит зомби
/// </summary>
public class KilledByZombie : PlayerKilled
{
    /// <summary>
    /// Имя класса зомби который убил игрока
    /// </summary>
    public string Zombie { get; set; } = string.Empty;
}
