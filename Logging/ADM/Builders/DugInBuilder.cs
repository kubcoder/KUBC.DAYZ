using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события закапывания клада
/// </summary>
public class DugInBuilder : ItemPositionEventBuilder<DugIn>
{
    /// <inheritdoc/>
    protected override string StartPosition => "{<";
    /// <inheritdoc/>
    protected override char? EndSymbol => '<';

    /// <inheritdoc/>
    protected override string TargetText => "Dug in ";
}
