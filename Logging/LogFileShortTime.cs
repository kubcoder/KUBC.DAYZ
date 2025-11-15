namespace KUBC.DAYZ.Logging;

/// <summary>
/// Файл журнала с указанием короткой даты в начале строки
/// </summary>
public abstract class LogFileShortTime : LogFile
{
    /// <summary>
    /// Дата начала лога (локальное)
    /// </summary>
    public DateOnly? LocalDateLogStarted;

    /// <summary>
    /// Время начала лога (локальное)
    /// </summary>
    public TimeOnly? LocalTimeStarted;

    /// <summary>
    /// Корректируем дату и время и возвращаем дату и время в UTC
    /// В частности если в лог пишется только время то добавляем дату
    /// начала записи лога.
    /// </summary>
    /// <param name="sTime">Дата и время из события</param>
    /// <returns>Правильное дата и время</returns>
    protected DateTime CorrectTime(TimeOnly sTime)
    {
        if (LocalTimeStarted == null)
            return DateTime.Now;
        if (LocalDateLogStarted == null)
            return DateTime.Now;
        var result = new DateTime(LocalDateLogStarted.Value, sTime);
        if (sTime < LocalTimeStarted.Value)
        {
            result.AddDays(1);
        }
        return result.ToUniversalTime();

    }
}
