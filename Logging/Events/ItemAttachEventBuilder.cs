namespace KUBC.DAYZ.Logging.Events;

/*
Player "BANDIT_EKB" (id=IlWOr_LRrhS0y5s0IgiFForEiOaiY0AXXjHjKoMtBZE= pos=<4376.8, 4598.8, 232.0>)Player SurvivorBase<435816a0> Mounted BarbedWire on Fence
Player "Axperrr223" (id=0TIrcPPAC6Ca1UHXh1d1CgV3komVDGOICmT6wXL7tCU= pos=<1266.3, 8888.9, 282.1>)Player SurvivorBase<a5fef010> Unmounted BarbedWire from Watchtower
*/

/// <summary>
/// Абстрактный класс поиска события монтажа/демонтажа 
/// элемента на какую то конструкцию
/// </summary>
/// <typeparam name="T">Тип события</typeparam>
public abstract class ItemAttachEventBuilder<T> : ItemEventBuilder<T> where T : ItemAttachEvent, new()
{

    /// <inheritdoc/>
    protected override T? GetEvent(DateTime timeStamp, string name, string plainId, bool isAlive, StringReader reader)
    {
        var gameEvent = base.GetEvent(timeStamp, name, plainId, isAlive, reader);
        if (gameEvent == null)
            return null;
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
        reader.Skip(EndString.Length);
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
        if (reader.IsEnd)
            return null;
        gameEvent.Construction = reader.ReadToEnd().Trim();
        if (string.IsNullOrWhiteSpace(gameEvent.Construction))
            return null;
        return gameEvent;
    }
}
