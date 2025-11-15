using Xunit.Abstractions;

namespace KUBC.DAYZ;

/// <summary>
/// Тест с доступом к папке тестовых файлов
/// </summary>
/// <param name="output">Интерфейс вывода в результаты теста</param>
public class TestWithSample(ITestOutputHelper output) : TestWithLogger(output)
{
    public DirectoryInfo Samples => new DirectoryInfo("Sample");
}
