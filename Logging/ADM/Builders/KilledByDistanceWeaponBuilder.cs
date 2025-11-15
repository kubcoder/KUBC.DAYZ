using KUBC.DAYZ.Logging.Events.Killed;

namespace KUBC.DAYZ.Logging.ADM.Builders;

/// <summary>
/// Парсер события когда игрок бахнул другого на дистанции
/// </summary>
public class KilledByDistanceWeaponBuilder : PlayerKillPlayerBuilder<KilledByDistanceWeapon>
{
    /// <inheritdoc/>
    protected override bool EventCheck(string data)
    {
        if (!data.Contains(TAG_FROM)) return false;
        return data.Contains(TAG_WITH);
    }

    /// <summary>
    /// Получить информацию о убийце, читаем координаты, ник, идентификатор
    /// </summary>
    /// <param name="gameEvent">Игровое событие</param>
    /// <param name="reader">Поток для чтения данных</param>
    /// <returns></returns>
    protected override KilledByDistanceWeapon? GetKillInfo(KilledByDistanceWeapon gameEvent, Events.StringReader reader)
    {
        gameEvent.Weapon = ReadWeapon(reader);
        if (string.IsNullOrWhiteSpace(gameEvent.Weapon)) return null;
        reader.ReadTo(TAG_FROM);
        reader.Skip(TAG_FROM.Length);
        var distance = reader.ReadDouble('m');
        if (!distance.HasValue) return null;
        gameEvent.Distance = distance.Value;
        return gameEvent;
    }
}
