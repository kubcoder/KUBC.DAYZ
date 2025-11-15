using System.Text.Json.Serialization;

namespace KUBC.DAYZ;

/// <summary>
/// Представление вектора в игре
/// </summary>
[JsonConverter(typeof(VectorJsonConverter))]
public class Vector
{
    /// <summary>
    /// Координата с запада на восток
    /// </summary>
    public double X { get; set; } = 0;

    /// <summary>
    /// Координата c севера на ЮГ (или наоборот, зависит от карты)
    /// </summary>
    public double Y { get; set; } = 0;

    /// <summary>
    /// Высота над уровнем моря
    /// </summary>
    public double Z { get; set; } = 0;

    /// <summary>
    /// Дистанция до точки
    /// </summary>
    /// <param name="target">Точка до которой необходимо посчитать дистанцию</param>
    /// <returns>Дистанция</returns>
    public double DistanceTo(Vector target)
    {
        var ppX = Math.Pow(X - target.X, 2);
        var ppY = Math.Pow(Y - target.Y, 2);
        var ppZ = Math.Pow(Z - target.Z, 2);
        return Math.Sqrt(ppX + ppY + ppZ);
    }
    /// <summary>
    /// Дистанция до точки в плоскости X-Y
    /// Координата Z игнорируется
    /// </summary>
    /// <param name="target">Точка до которой необходимо посчитать дистанцию</param>
    /// <returns>Дистанция</returns>
    public double Distance2DTo(Vector target)
    {
        var ppX = Math.Pow(X - target.X, 2);
        var ppY = Math.Pow(Y - target.Y, 2);
        return Math.Sqrt(ppX + ppY);
    }
}
