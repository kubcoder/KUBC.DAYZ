namespace KUBC.DAYZ.Logging.Events;

/// <summary>
/// Обобщенный класс для строительства события в котором известен игрок и его идентификатор
/// Т.е. сообщения которые начинаются с 'Player "kot23rus"(id=B1idL_7H1auUS5DPBOEDcTFQ3EBBrzFLa8r1GGmv7GA=)'
/// </summary>
public abstract class PlayerEventBuilder : EventBuilder
{
    private const string StartText = "Player";

    /// <inheritdoc/>
    public override GameEvent? Build(DateTime timeStamp, string data)
    {
        if (!IsTarget(data))
            return null;
        var reader = new StringReader(data.Substring(StartText.Length));
        reader.ReadTo('"');
        var name = reader.ReadTo('"');
        if (string.IsNullOrWhiteSpace(name))
            return null;
        var deadText = reader.PreRead(8);
        var isAlive = true;
        if (deadText.Contains("(DEAD)"))
            isAlive = false;
        reader.ReadTo('=');
        var plainId = reader.ReadTo(SymbolEndId);
        if (plainId.EndsWith(')'))
        {
            plainId = plainId.Remove(plainId.Length - 1);
        }
        if (string.IsNullOrWhiteSpace(plainId))
            return null;
        /*if (plainId.Length != 44)
            return null;*/
        return GetEvent(timeStamp, name, plainId, isAlive, reader);
    }
    /// <summary>
    /// Символ завершения идентификатора игрока
    /// </summary>
    protected virtual char SymbolEndId => ' ';

    /// <summary>
    /// Сгенерировать событие на основании данных
    /// </summary>
    /// <param name="timeStamp">Время события</param>
    /// <param name="name">Никнейм игрока</param>
    /// <param name="plainId">Идентификатор игрока</param>
    /// <param name="isAlive">Игрок жив на момент записи строчки</param>
    /// <returns></returns>
    protected virtual GameEvent? GetEvent(DateTime timeStamp, string name, string plainId, bool isAlive)
    {
        return null;
    }

    /// <summary>
    /// Сгенерировать событие на основании данных
    /// Если метод не перегружен, будет просто вызван метод <see cref="GetEvent(DateTime, string, string, bool)"/>
    /// </summary>
    /// <param name="timeStamp">Время события</param>
    /// <param name="name">Никнейм игрока</param>
    /// <param name="plainId">Идентификатор игрока</param>
    /// <param name="reader">Поток чтения строки, в позиции где завершили чтение координаты</param>
    /// <param name="isAlive">Игрок жив на момент записи строчки</param>
    /// <returns></returns>
    protected virtual GameEvent? GetEvent(DateTime timeStamp, string name, string plainId, bool isAlive, StringReader reader)
    {
        return GetEvent(timeStamp, name, plainId, isAlive);
    }

    /// <summary>
    /// Какие термины должны быть исключены из поиска события
    /// </summary>
    protected List<string>? ExcludeNames;

    /// <summary>
    /// Убедится что строка имеет требуемый формат
    /// </summary>
    /// <param name="data">Проверяемая строка</param>
    /// <returns>Истина если строка соответствует поиску</returns>
    protected virtual bool IsTarget(string data)
    {
        if (!data.StartsWith(StartText))
            return false;
        if (ExcludeNames != null)
        {
            foreach (var source in ExcludeNames)
            {
                if (data.Contains(source))
                    return false;
            }
        }
        return true;
    }
}
