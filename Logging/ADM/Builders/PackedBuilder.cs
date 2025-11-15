using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события свернули предмет
/// </summary>
public class PackedBuilder : ItemEventBuilder<Packed>
{
    /// <inheritdoc/>
    protected override string TargetText => "packed";

    /// <inheritdoc/>
    protected override string? EndString => "with";
}
