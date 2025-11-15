using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события игрок потерял сознание
/// </summary>
public class UnconsciousBuilder : PlayerEventPositionBuilder<Unconscious>
{
    /// <inheritdoc/>
    protected override bool IsTarget(string data)
    {
        if (!base.IsTarget(data))
            return false;
        return data.Contains("is unconscious");
    }
}
