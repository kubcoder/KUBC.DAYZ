using KUBC.DAYZ.Logging.Events.Killed;

namespace KUBC.DAYZ.Logging.ADM;

/// <summary>
/// Игрок забил другого игрока руками до смерти
/// </summary>
public class KilledByHands : PlayerKilledByPlayer
{
    /// <summary>
    /// Какой урон использовался во время убийства
    /// </summary>
    public string DamageName { get; set; } = string.Empty;
}
