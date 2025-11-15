namespace KUBC.DAYZ.Logging;

/// <summary>
/// Класс определения типа журнала
/// </summary>
public class LogTypeBuilder
{
    /// <summary>
    /// Получить тип лога по имени файла
    /// </summary>
    /// <param name="fileName">Имя файла лога</param>
    /// <returns>Тип лога, если был узнан</returns>
    public LogType Build(string fileName)
    {
        var extension = Path.GetExtension(fileName);
        switch (extension)
        {
            case ".ADM":
                return LogType.Admin;
            case ".RPT":
                return LogType.RPT;
            case ".log":
                if (fileName.StartsWith("script"))
                    return LogType.Script;
                if (fileName.StartsWith("crash"))
                    return LogType.Crash;
                break;
        }
        return LogType.Unknow;
    }
}
