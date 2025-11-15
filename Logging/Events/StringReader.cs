using System.Text;

namespace KUBC.DAYZ.Logging.Events;

/// <summary>
/// Процессор чтения строки
/// </summary>
public class StringReader(string data)
{

    private int position = 0;

    /// <summary>
    /// Получить фрагмент строки до первого вхождения
    /// символа 
    /// </summary>
    /// <param name="end">Символ остановки</param>
    /// <returns></returns>
    public string ReadTo(char end)
    {
        var sb = new StringBuilder();
        var symbol = ReadSymbol();
        var isEnd = (symbol == end) | (symbol == null);
        while (!isEnd)
        {
            sb.Append(symbol);
            symbol = ReadSymbol();
            isEnd = (symbol == end) | (symbol == null);
        }
        return sb.ToString();
    }

    /// <summary>
    /// Достигнут конец строки
    /// </summary>
    public bool IsEnd => !CanRead;


    /// <summary>
    /// Может выполнять чтение
    /// </summary>
    public bool CanRead => position < data.Length;



    /// <summary>
    /// Выполнить чтение до вхождения строки
    /// </summary>
    /// <param name="target">Строка ограничивающая чтение</param>
    /// <returns></returns>
    public string ReadTo(string target)
    {
        var sb = new StringBuilder();
        var isEnd = IsCurrent(target) | IsEnd;
        while (!isEnd)
        {
            sb.Append(ReadSymbol());
            isEnd = IsCurrent(target) | IsEnd;
        }
        return sb.ToString();
    }

    /// <summary>
    /// Проверить на данном ли слове стоит курсор
    /// </summary>
    /// <param name="target">Искомое слово</param>
    /// <returns></returns>
    public bool IsCurrent(string target)
    {
        if (position + target.Length > data.Length)
            return false;
        var current = data.Substring(position, target.Length);
        return current == target;
    }

    /// <summary>
    /// Прочитать все содержимое строки от текущей позиции до конца
    /// </summary>
    /// <returns></returns>
    public string ReadToEnd()
    {
        return data[position..];
    }

    /// <summary>
    /// Пропустить символы
    /// </summary>
    /// <param name="count">Количество пропускаемых символов</param>
    public void Skip(int count)
    {
        position += count;
        if (position > data.Length)
            position = data.Length;
    }

    /// <summary>
    /// Выполнить предварительное чтение
    /// без сдвига курсора
    /// </summary>
    /// <param name="count">Сколько символов прочитать</param>
    /// <returns></returns>
    public string PreRead(int count)
    {
        var left = data.Length - position;
        if (count > left)
            count = left;
        return data.Substring(position, count);
    }

    /// <summary>
    /// Читаем символ, указатель потока на 1 инкрементируем
    /// </summary>
    /// <returns></returns>
    private char? ReadSymbol()
    {
        if (data.Length > position)
        {
            var result = data[position];
            position++;
            return result;
        }
        return null;
    }


    /// <summary>
    /// Прочитать вектор из строки
    /// </summary>
    /// <returns>Вектор если чтение удалось</returns>
    public Vector? ReadVector()
    {
        var x = ReadDouble();
        if (!x.HasValue) return null;
        var y = ReadDouble();
        if (!y.HasValue) return null;
        var z = ReadDouble('>');
        if (!z.HasValue) return null;

        return new Vector() { X = x.Value, Y = y.Value, Z = z.Value };
    }

    /// <summary>
    /// Прочитать из потока число с плавающей запятой
    /// </summary>
    /// <param name="endChar">На каком символе считать, что число завершилось</param>
    /// <returns>Число с плавающей запятой, если удалось прочитать</returns>
    public double? ReadDouble(char endChar = ',')
    {
        var numberString = ReadTo(endChar).Trim();
        if (double.TryParse(numberString, System.Globalization.NumberStyles.Float, cultureInfo.NumberFormat, out var doubleValue))
            return doubleValue;
        return null;
    }

    /// <summary>
    /// Прочитать из потока целое число
    /// </summary>
    /// <param name="endChar">На каком символе считать, что число завершилось</param>
    /// <returns>Число с плавающей запятой, если удалось прочитать</returns>
    public int? ReadInt(char endChar = ',')
    {
        var numberString = ReadTo(endChar).Trim();
        if (int.TryParse(numberString, System.Globalization.NumberStyles.Number, cultureInfo.NumberFormat, out var intValue))
            return intValue;
        return null;
    }

    private System.Globalization.CultureInfo cultureInfo = System.Globalization.CultureInfo.InvariantCulture;
}
