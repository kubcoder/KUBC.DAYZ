using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Построитель события размещения объекта
/// </summary>
public class PlacedBuilder : ItemEventBuilder<Placed>
{
    /// <inheritdoc/>
    protected override string TargetText => "placed";

    /// <inheritdoc/>
    protected override char? EndSymbol => '<';

    /// <inheritdoc/>
    protected override Placed? GetEvent(DateTime timeStamp, string name, string plainId, bool isAlive, Events.StringReader reader)
    {
        var placed = base.GetEvent(timeStamp, name, plainId, isAlive, reader);
        if (placed == null)
            return null;
        placed.ClassName = reader.ReadTo('>');
        if (string.IsNullOrWhiteSpace(placed.ClassName))
            return null;
        return placed;
    }
}
