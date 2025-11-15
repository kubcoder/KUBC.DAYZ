using KUBC.DAYZ.Logging.Events.Damage;

namespace KUBC.DAYZ.Logging.ADM;

/// <summary>
/// Урон игроку от бризантного боеприпаса
/// </summary>
public class PlayerHitByExplosion : PlayerDamage
{
    /// <summary>
    /// Название боеприпаса
    /// </summary>
    public string ExplosionName { get; set; } = string.Empty;
}
