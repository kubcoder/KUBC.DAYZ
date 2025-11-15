using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события тотем поднят
/// </summary>
public class RaisedBuilder : ItemPositionEventBuilder<Raised>
{
    /// <inheritdoc/>
    protected override string StartPosition => "on TerritoryFlag at <";
    /// <inheritdoc/>
    protected override char? EndSymbol => ' ';

    /// <inheritdoc/>
    protected override string TargetText => "has raised ";
}
