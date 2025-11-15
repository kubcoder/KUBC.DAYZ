namespace KUBC.DAYZ.Logging;

/// <summary>
/// Тип журнала игры
/// </summary>
public enum LogType
{
    /// <summary>
    /// Журнал администраторов игры
    /// </summary>
    Admin,
    /// <summary>
    /// Журнал реального времени
    /// </summary>
    RPT,
    /// <summary>
    /// Журнал выполнения скриптов
    /// </summary>
    Script,
    /// <summary>
    /// Журнал ошибок
    /// </summary>
    Crash,
    /// <summary>
    /// Вывод консоли сервера
    /// </summary>
    Console,
    /// <summary>
    /// Неизвестно, т.е. быстрей всего не журнал
    /// </summary>
    Unknow
}
