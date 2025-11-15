namespace KUBC.DAYZ.Logging.ADM;

/// <summary>
/// Урон игроку от другого игрока с 
/// использованием оружия. Прямым использованием
/// т.е. топоры, молоты и прочее, но уже не голыми 
/// руками
/// </summary>
public class PlayerHitByWeapon : PlayerHitByPlayer
{
    /// <summary>
    /// Используемое оружие
    /// </summary>
    public string Weapon { get; set; } = string.Empty;
}
