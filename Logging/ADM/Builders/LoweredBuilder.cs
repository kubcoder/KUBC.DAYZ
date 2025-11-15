using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события тотем опущен
/// </summary>
public class LoweredBuilder : ItemPositionEventBuilder<Lowered>
{
    /// <inheritdoc/>
    protected override string StartPosition => "on TerritoryFlag at <";
    /// <inheritdoc/>
    protected override char? EndSymbol => ' ';

    /// <inheritdoc/>
    protected override string TargetText => "has lowered ";
}
