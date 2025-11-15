using Microsoft.Extensions.Logging;
using RM = KUBC.DAYZ.Logging.Resources.ADM.AdminLogFile;
namespace KUBC.DAYZ.Logging.ADM;

/// <summary>
/// Класс обработки журнала администратора
/// </summary>
public abstract class AdminLogFile : LogFileShortTime
{
    /// <summary>
    /// Шаблон поиска строчки с указанием начала лога
    /// </summary>
    private const string KEYFINDSTARTTIME = "AdminLog started on";

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
        if (line.Contains(KEYFINDSTARTTIME))
        {
            var tokens = line.Split(' ');
            if (tokens.Length > 5)
            {
                var sTime = $"{tokens[3]} {tokens[5]}";
                if (DateTime.TryParse(sTime, out DateTime startTime))
                {
                    LocalDateLogStarted = new DateOnly(startTime.Year, startTime.Month, startTime.Day);
                    LocalTimeStarted = new(startTime.Hour, startTime.Minute, startTime.Second, startTime.Millisecond);
                    Logger.LogInformation(RM.SetStartTime, startTime);
                }
                else
                {
                    Logger.LogError(RM.ErrorReadTimeStart, sTime);
                }
            }
            else
            {
                Logger.LogError(RM.ErrorFormatTime, line);
            }
            return true;
        }
        return false;
    }

    private async Task<bool> ReadLine(string line)
    {
        var dateEnd = line.IndexOf('|');
        if (dateEnd == -1)
            return false;
        var timeString = line[..dateEnd];
        if (TimeOnly.TryParse(timeString.Trim(), out var time))
        {
            var utc = CorrectTime(time);
            var data = line.Substring(dateEnd + 1).Trim();
            Logger.LogInformation(RM.ReadLine, utc, data);
            await OnLineRead(utc, data);
            return true;
        }
        else
        {
            Logger.LogError(RM.ErrorReadLineTime, timeString);
        }
        return false;
    }

}
