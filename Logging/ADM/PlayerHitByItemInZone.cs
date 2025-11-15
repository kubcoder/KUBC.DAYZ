using KUBC.DAYZ.Logging.Events.Damage;

namespace KUBC.DAYZ.Logging.ADM;

/// <summary>
/// Урон игроку от некого игрового итема
/// с указанием зоны поражения
/// </summary>
public class PlayerHitByItemInZone : PlayerDamageWithZone
{
    /// <summary>
    /// Имя источника повреждений
    /// </summary>
    public string Source { get; set; } = string.Empty;
}
