namespace KUBC.DAYZ.Logging.Events.Damage;

/// <summary>
/// Событие нанесения урона игроку 
/// с указанием зоны куда был нанесен урон
/// </summary>
public class PlayerDamageWithZone : PlayerDamage
{
    /// <summary>
    /// Куда был нанесен урон
    /// </summary>
    public ZoneDamageInfo DamageInfo { get; set; } = new();
}
