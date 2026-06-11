namespace KUBC.DAYZ.MissionFiles.Config.LimitsDefinition;

/// <summary>
/// Коллекция доступных тэгов
/// </summary>
public class Tags : NameItem
{
    /// <summary>
    /// Имя корневого элемента списка
    /// </summary>
    public const string ROOT_ELEMENT_NAME = "tags";

    private const string ELEMENT_NAME = "tag";

    /// <inheritdoc/>
    protected override string ElementName => ELEMENT_NAME;
}
