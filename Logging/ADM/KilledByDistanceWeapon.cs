namespace KUBC.DAYZ.Logging.ADM;

/// <summary>
/// Игрок убит другим игроком с дальнобойного оружия
/// </summary>
public class KilledByDistanceWeapon : KilledByWeapon
{
    /// <summary>
    /// Дистанция с которой совершено убийство
    /// </summary>
    public double Distance { get; set; } = 0;
}
