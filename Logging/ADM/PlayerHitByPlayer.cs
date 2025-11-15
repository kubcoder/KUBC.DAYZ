using KUBC.DAYZ.Logging.Events;
using KUBC.DAYZ.Logging.Events.Damage;

namespace KUBC.DAYZ.Logging.ADM;

/// <summary>
/// Событие игрок получил урон от другого игрока без использования 
/// оружия. Буквально выражаясь кулаками побил
/// </summary>
public class PlayerHitByPlayer : PlayerDamage
{
    /// <summary>
    /// Источник урона
    /// </summary>
    public PlayerInfo Source { get; set; } = new();

    /// <summary>
    /// Зона куда был нанесен урон
    /// </summary>
    public ZoneDamageInfo DamageZone { get; set; } = new();
}
