using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM;

/// <summary>
/// Событие когда игрок сотворил какую то эмоцию, или там сел или еще какую анимацию замутил
/// </summary>
public class Emote : PlayerEventPosition
{
    /// <summary>
    /// Название эмоции игрока
    /// </summary>
    public string Action { get; set; } = string.Empty;
}
