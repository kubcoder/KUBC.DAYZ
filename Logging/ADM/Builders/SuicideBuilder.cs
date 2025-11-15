using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Построитель события игрок суициднулся
/// </summary>
public class SuicideBuilder : PlayerEventPositionBuilder<Suicide>
{
    /// <inheritdoc/>
    protected override bool IsTarget(string data)
    {
        if (!base.IsTarget(data))
            return false;
        return data.Contains("committed suicide");
    }
}
