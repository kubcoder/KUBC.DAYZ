using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Анализатор события демонтажа предмета с конструкции
/// </summary>
public class UnmountedBuilder : ItemAttachEventBuilder<Unmounted>
{
    /// <inheritdoc/>
    protected override string TargetText => "Unmounted";

    /// <inheritdoc/>
    protected override string? EndString => "from";
}
