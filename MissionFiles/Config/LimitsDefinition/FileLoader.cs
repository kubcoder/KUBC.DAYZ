using System.Xml;

namespace KUBC.DAYZ.MissionFiles.Config.LimitsDefinition;

/// <summary>
/// Инструмент загрузки данных из файла
/// </summary>
public class FileLoader
{
    /// <summary>
    /// Загрузить данные из файла
    /// </summary>
    /// <param name="fileInfo">полный путь к файлу</param>
    /// <returns>Результаты чтения файла</returns>
    /// <exception cref="FileNotFoundException"/>
    /// <exception cref="XmlException"/>
    public static ConfigFile Load(FileInfo fileInfo)
    {
        using var fileStream = fileInfo.OpenRead();
        using var xmlReader = XmlReader.Create(fileStream);
        var result = new ConfigFile();
        result.ReadXml(xmlReader);
        return result;
    }

    /// <summary>
    /// Загрузить данные из файла
    /// </summary>
    /// <param name="missionPath">путь к файлам миссии</param>
    /// <returns>Результаты чтения файла</returns>
    /// <exception cref="FileNotFoundException"/>
    /// <exception cref="XmlException"/>
    public static ConfigFile Load(DirectoryInfo missionPath)
    {
        var fileNameBuilder = new FileNameBuilder(missionPath);
        return Load(fileNameBuilder.Build());
    }
}
