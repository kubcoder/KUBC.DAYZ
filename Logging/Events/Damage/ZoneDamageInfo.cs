namespace KUBC.DAYZ.Logging.Events.Damage;

/// <summary>
/// Описание зоны куда был нанесен урон
/// </summary>
public class ZoneDamageInfo
{
    /// <summary>
    /// Название зоны куда нанесен урон
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Индекс зоны куда нанесен урон
    /// </summary>
    public int Index { get; set; } = 0;

    /// <summary>
    /// Размер урона
    /// </summary>
    public double Damage { get; set; } = 0;

    /// <summary>
    /// Название урона
    /// </summary>
    public string DamageName { get; set; } = string.Empty;
}
