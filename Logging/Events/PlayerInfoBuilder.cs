namespace KUBC.DAYZ.Logging.Events;

/// <summary>
/// Построитель информации о игроке
/// </summary>
/// <param name="reader"></param>
public class PlayerInfoBuilder(StringReader reader)
{
    private const string StartText = "Player";

    /// <summary>
    /// Получить информацию о игроке
    /// </summary>
    /// <param name="SkipToStart">Выполнить поиск позиции старта данных</param>
    /// <returns></returns>
    public PlayerInfo? Build(bool SkipToStart = true)
    {
        if (SkipToStart)
        {
            reader.ReadTo(StartText);
            reader.Skip(StartText.Length);
            if (reader.IsEnd)
                return null;
        }

        reader.ReadTo('"');
        var name = reader.ReadTo('"');
        if (string.IsNullOrWhiteSpace(name))
            return null;
        var deadText = reader.PreRead(8);
        var isAlive = true;
        if (deadText.Contains("(DEAD)"))
            isAlive = false;
        reader.ReadTo('=');
        var plainId = reader.ReadTo(' ');
        if (string.IsNullOrWhiteSpace(plainId))
            return null;
        if (plainId.Length != 44)
            return null;
        var posText = reader.ReadTo('=');
        if (posText != "pos")
        {
            return null;
        }
        reader.Skip(1);
        var vector = reader.ReadVector();
        if (vector == null) return null;
        return new()
        {
            Id = plainId,
            NickName = name,
            IsAlive = isAlive,
            Position = vector
        };
    }
}
