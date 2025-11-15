using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события свернул что-то
/// </summary>
public class FoldedBuilder : ItemEventBuilder<Folded>
{
    /// <inheritdoc/>
    protected override string TargetText => "folded";
}
