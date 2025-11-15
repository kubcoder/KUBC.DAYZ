using KUBC.DAYZ.Logging.Events;

namespace KUBC.DAYZ.Logging.ADM.Builders;

// PLAYER REPORT: <2023-11-26_18-14-16> <B1idL_7H1auUS5DPBOEDcTFQ3EBBrzFLa8r1GGmv7GA=>: тестовое сообщение

/// <summary>
/// Анализатор события жалобы игрока
/// </summary>
public class ReportBuilder : EventBuilder
{
    /// <inheritdoc/>
    public override GameEvent? Build(DateTime timeStamp, string data)
    {
        if (!IsTarget(data))
            return null;
        var reader = new Events.StringReader(data.Substring(StartText.Length));
        reader.ReadTo('<');
        var report = new Report()
        {
            TimeStamp = timeStamp,
            PlayerId = reader.ReadTo('>')
        };
        if (report.PlayerId.Length != 44)
            return null;
        reader.ReadTo(':');
        report.Message = reader.ReadToEnd().Trim();
        return report;
    }

    private const string StartText = "PLAYER REPORT: <";

    /// <summary>
    /// Убедится что строка имеет требуемый формат
    /// </summary>
    /// <param name="data">Проверяемая строка</param>
    /// <returns>Истина если строка соответствует поиску</returns>
    protected virtual bool IsTarget(string data)
    {
        return data.StartsWith(StartText);
    }
}
