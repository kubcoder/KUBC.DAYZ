using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Парсер события игрок нажал респавн 
/// </summary>
public class PlayerChoosingRespawnBuilder : PlayerEventPositionBuilder<PlayerChoosingRespawn>
{
    /// <inheritdoc/>
    protected override bool IsTarget(string data)
    {
        if (!base.IsTarget(data))
        {
            return false;
        }
        return data.Contains("is choosing to respawn");
    }
}
