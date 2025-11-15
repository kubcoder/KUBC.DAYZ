using Microsoft.Extensions.Logging;
using System.Text;
using Xunit.Abstractions;

namespace KUBC.DAYZ;

/// <summary>
/// Класс теста с журналом
/// </summary>
public class TestWithLogger : TestWithConfig
{
    /// <summary>
    /// Фабрика логов
    /// </summary>
    public ILoggerFactory LoggerFactory => Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
        builder.AddSimpleConsole(options =>
        {
            options.IncludeScopes = true;
            options.SingleLine = true;
            options.TimestampFormat = "HH:mm:ss ";
        })
    );

    /// <summary>
    /// Инициализация класса тестов
    /// </summary>
    /// <param name="output">Интерфейс вывода в результаты теста</param>
    public TestWithLogger(ITestOutputHelper output)
    {
        Output = output;
        Console.OutputEncoding = Encoding.UTF8;
    }

    /// <summary>
    /// Интерфейс вывода в результаты теста
    /// </summary>
    protected readonly ITestOutputHelper Output;

}
