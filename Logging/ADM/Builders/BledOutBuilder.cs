using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события игрок истек кровью
/// </summary>
public class BledOutBuilder : PlayerEventPositionBuilder<BledOut>
{
    /// <inheritdoc/>
    protected override bool IsTarget(string data)
    {
        if (!base.IsTarget(data))
        {
            return false;
        }
        return data.Contains("bled out");
    }
}
