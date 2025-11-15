using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Построитель события игрок очнулся
/// </summary>
public class RegainedBuilder : PlayerEventPositionBuilder<Regained>
{
    /// <inheritdoc/>
    protected override bool IsTarget(string data)
    {
        if (!base.IsTarget(data))
            return false;
        return data.Contains("regained consciousness");
    }
}
