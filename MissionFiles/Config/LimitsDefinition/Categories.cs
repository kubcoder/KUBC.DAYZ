namespace KUBC.DAYZ.MissionFiles.Config.LimitsDefinition;

/// <summary>
/// Категории игровых предметов
/// </summary>
public class Categories : NameItem
{
    /// <summary>
    /// Имя корневого элемента списка
    /// </summary>
    public const string ROOT_ELEMENT_NAME = "categories";

    private const string ELEMENT_NAME = "category";

    /// <inheritdoc/>
    protected override string ElementName => ELEMENT_NAME;

}
