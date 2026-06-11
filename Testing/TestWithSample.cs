
namespace KUBC.DAYZ;

/// <summary>
/// Тест с доступом к папке тестовых файлов
/// </summary>
public class TestWithSample : TestWithServices
{
    public static DirectoryInfo Samples => new("Sample");
}
