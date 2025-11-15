using KUBC.DAYZ.Logging.Events.Damage;

namespace KUBC.DAYZ.Logging.ADM;

/// <summary>
/// Урон игроку в ДТП
/// </summary>
public class PlayerHitByTransport : PlayerDamage
{
    /// <summary>
    /// Имя класса транспортного средства
    /// </summary>
    public string Transport { get; set; } = string.Empty;
}
