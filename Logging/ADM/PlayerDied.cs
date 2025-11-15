using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM;

/// <summary>
/// Событие игрок умер
/// </summary>
public class PlayerDied : PlayerEventPosition
{
    /// <summary>
    /// Вода в игроке на момент смерти
    /// </summary>
    public double Water { get; set; } = 0;
    /// <summary>
    /// Энергия на момент смерти
    /// </summary>
    public double Energy { get; set; } = 0;
    /// <summary>
    /// Количество открытых ран на момент смерти
    /// </summary>
    public int Bleeding { get; set; } = 0;
}
