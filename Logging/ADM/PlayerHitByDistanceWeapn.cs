namespace KUBC.DAYZ.Logging.ADM;

/// <summary>
/// Урон нанесен с помощью дистанционного оружия
/// </summary>
public class PlayerHitByDistanceWeapon : PlayerHitByWeapon
{
    /// <summary>
    /// С какой дистанции был нанесен урон
    /// </summary>
    public double Distance { get; set; } = 0;


}
