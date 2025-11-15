using KUBC.DAYZ.Logging.Events.Damage;

namespace KUBC.DAYZ.Logging.ADM;

/// <summary>
/// Игрок получил урон от предмета или игровой механики
/// </summary>
public class PlayerHitByItem : PlayerDamage
{
    /// <summary>
    /// Источник урона
    /// </summary>
    public string Source { get; set; } = string.Empty;

    /// <summary>
    /// Название типа урона
    /// </summary>
    public string DamageName { get; set; } = string.Empty;
}
