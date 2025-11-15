using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события выкапывания
/// </summary>
public class DugOutBuilder : ItemPositionEventBuilder<DugOut>
{
    /// <inheritdoc/>
    protected override string TargetText => "Dug out ";

    /// <inheritdoc/>
    protected override string StartPosition => "{<";

    /// <inheritdoc/>
    protected override char? EndSymbol => '<';
}
