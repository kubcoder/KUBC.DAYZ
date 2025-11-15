using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;


/// <summary>
/// Анализатор события монтажа элемента на конструкцию
/// </summary>
public class MountedBuilder : ItemAttachEventBuilder<Mounted>
{
    /// <inheritdoc/>
    protected override string TargetText => "Mounted";

    /// <inheritdoc/>
    protected override string? EndString => "on";
}
