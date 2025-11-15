namespace KUBC.DAYZ.Logging.ADM;

/// <summary>
/// Эмоция игрока, с предметом в руках
/// </summary>
public class EmoteWithItem : Emote
{
    /// <summary>
    /// Название предмета
    /// </summary>
    public string Item { get; set; } = string.Empty;
}
