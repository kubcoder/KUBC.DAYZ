using Microsoft.Extensions.Logging;
using System.Text;
using RM = KUBC.DAYZ.Logging.Resources.LogFile;
namespace KUBC.DAYZ.Logging;

/// <summary>
/// Класс работы с файлом лога
/// </summary>
public abstract class LogFile : IDisposable
{
    /// <summary>
    /// Журнал приложения
    /// </summary>
    protected abstract ILogger Logger { get; }

    /// <summary>
    /// Поток для чтения файла
    /// </summary>
    private StreamReader? fileReader;

    /// <summary>
    /// Имя файла лога
    /// </summary>
    public string FileName => fileName;

    /// <summary>
    /// Имя файла
    /// </summary>
    private string fileName = string.Empty;

    /// <summary>
    /// Выполнить чтение файла
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task ReadFileAsync(CancellationToken cancellationToken)
    {
        if (fileReader == null)
        {
            Logger.LogWarning(RM.NotOpenFile);
            return;
        }
        Logger.LogDebug(RM.StartReadFile, fileName);
        string? fileData;
        try
        {
            fileData = await fileReader.ReadToEndAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Logger.LogError(RM.ErrorRead, fileName, ex.Message);
            return;
        }
        if (fileData == null)
        {
            Logger.LogDebug(RM.NotReadData, fileName);
            return;
        }
        Logger.LogDebug(RM.ReadData, fileName, fileData.Length);
        var linesCount = 0;
        foreach (var symbol in fileData)
        {
            if (IsEndLine(symbol))
            {
                var line = currentString.ToString().Trim();
                currentString.Clear();
                Logger.LogDebug(RM.EndReadLine, fileName, line);
                linesCount++;
                await OnLineReadAsync(line);
            }
            else
            {
                try
                {
                    currentString.Append(symbol);
                }
                catch (Exception ex)
                {
                    Logger.LogError(RM.ExceptionAppend, symbol, ex.Message);
                }
            }
        }
        Logger.LogDebug(RM.EndRead, fileName, fileReader.BaseStream.Position, linesCount, currentString.Length);
    }

    /// <summary>
    /// Открыть файл для чтения
    /// </summary>
    /// <param name="file">Какой файл открываем</param>
    /// <returns>Истина если файл получилось открыть</returns>
    public bool OpenFile(FileInfo file)
    {
        Logger.LogInformation(RM.OpenFile, file.FullName);
        fileName = file.Name;
        try
        {
            fileReader = new StreamReader(file.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
        }
        catch (Exception ex)
        {
            Logger.LogError(RM.OpenFileException, file.FullName, ex.Message);
            return false;
        }
        return fileReader != null;
    }

    /// <summary>
    /// Определить является ли символ концом строки
    /// </summary>
    /// <param name="symbol">Проверяемый символ</param>
    /// <returns>Истина если это символ строки</returns>
    protected virtual bool IsEndLine(char symbol) => symbol == '\n';

    /// <summary>
    /// Буфер чтения... тут мы накапливаем строку
    /// </summary>
    private readonly StringBuilder currentString = new();

    /// <summary>
    /// Из файла прочитана строчка лога 
    /// </summary>
    /// <param name="line">Данные прочитанные из файла</param>
    /// <returns>Истина если данные были осознаны, или использованы. Используется для перегрузки метода</returns>
    protected abstract Task<bool> OnLineReadAsync(string line);

    /// <summary>
    /// Обработать строчку лога
    /// </summary>
    /// <param name="time">Дата и время строчки лога</param>
    /// <param name="data">Данные строчки лога</param>
    /// <returns></returns>
    protected abstract Task OnLineRead(DateTime time, string data);

    /// <inheritdoc/>
    public void Dispose()
    {
        fileReader?.Dispose();
        fileReader = null;
        currentString.Clear();
    }
}
