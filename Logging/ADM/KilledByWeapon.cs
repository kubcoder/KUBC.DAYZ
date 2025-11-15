using KUBC.DAYZ.Logging.Events.Killed;

namespace KUBC.DAYZ.Logging.ADM;

/// <summary>
/// Игрока убил другой игрок 
/// с помощью оружия
/// </summary>
public class KilledByWeapon : PlayerKilledByPlayer
{
    /// <summary>
    /// Какое оружие использовал другой игрок
    /// </summary>
    public string Weapon { get; set; } = string.Empty;
}
