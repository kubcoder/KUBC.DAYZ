using Microsoft.Extensions.Logging;
using RM = KUBC.DAYZ.Logging.Resources.RPT.RealTimeLogFile;
namespace KUBC.DAYZ.Logging.RPT;

/// <summary>
/// Лог реального времени
/// </summary>
public abstract class RealTimeLogFile : LogFileShortTime
{
    /// <summary>
    /// Шаблон поиска строчки с указанием начала лога
    /// </summary>
    private const string KEYFINDSTARTTIME = "Current time:";

    private const string TIMEFORMAT = "00:00:00.000";

    /// <inheritdoc/>
    protected override async Task<bool> OnLineReadAsync(string line)
    {
        if (FindStartTime(line))
            return true;
        return await ReadLine(line);
    }
    private bool FindStartTime(string line)
    {
        if (LocalDateLogStarted != null)
            return false;
        if (!line.StartsWith(KEYFINDSTARTTIME))
            return false;
        var timeString = line[KEYFINDSTARTTIME.Length..];
        if (DateTime.TryParse(timeString, out DateTime startTime))
        {
            LocalDateLogStarted = new DateOnly(startTime.Year, startTime.Month, startTime.Day);
            LocalTimeStarted = new(startTime.Hour, startTime.Minute, startTime.Second, startTime.Millisecond);
            Logger.LogInformation(RM.SetStartTime, startTime);
        }
        return true;
    }

    private readonly int lineTimeLength = TIMEFORMAT.Length;

    private async Task<bool> ReadLine(string line)
    {
        if (line.Length < lineTimeLength)
            return false;
        var timeString = line[..lineTimeLength];
        if (TimeOnly.TryParse(timeString.Trim(), out var time))
        {
            var utc = CorrectTime(time);
            var data = line.Substring(lineTimeLength).Trim();
            await OnLineRead(utc, data);
            return true;
        }
        return false;
    }
}
