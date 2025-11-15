namespace KUBC.DAYZ.Logging.Events;

/// <summary>
/// Базовый парсер события
/// </summary>
public abstract class EventBuilder
{
    /// <summary>
    /// Попытка преобразования 
    /// </summary>
    /// <param name="timeStamp">Дата и время регистрации события</param>
    /// <param name="data">Строчка лога</param>
    /// <returns></returns>
    public abstract GameEvent? Build(DateTime timeStamp, string data);

}
