using KUBC.DAYZ.Logging.Events.Damage;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события, игрок нанес урон другому игроку
/// </summary>
public class PlayerHitByPlayerBuilder : PlayerHitByPlayerBaseBuilder<PlayerHitByPlayer>
{
    /// <summary>
    /// Инициализируем отсечение связанных событий
    /// </summary>
    public PlayerHitByPlayerBuilder()
    {
        ExcludeNames = [
            "with"
            ];
    }
}
