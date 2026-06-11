namespace KUBC.DAYZ.MissionFiles.Config.LimitsDefinition;

/// <summary>
/// Инструмент получения полного имени файла
/// </summary>
/// <param name="missionPath">Полный путь к папке миссии</param>
public class FileNameBuilder(DirectoryInfo missionPath)
{

    /// <summary>
    /// Имя файла лимитов
    /// </summary>
    public const string FILE_NAME = "cfglimitsdefinition.xml";

    /// <summary>
    /// Получить полное имя файла
    /// </summary>
    /// <returns>Описание файла, не факт что он существует</returns>
    public FileInfo Build()
    {
        return new FileInfo(Path.Combine(missionPath.FullName, FILE_NAME));
    }
}
