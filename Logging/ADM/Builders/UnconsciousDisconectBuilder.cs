using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события когда игрок отключился в бессознательном состоянии
/// </summary>
public class UnconsciousDisconectBuilder : PlayerEventPositionBuilder<UnconsciousDisconect>
{
    /// <inheritdoc/>
    protected override bool IsTarget(string data)
    {
        if (!base.IsTarget(data))
            return false;
        return data.Contains("is disconnecting while being unconscious");
    }
}
