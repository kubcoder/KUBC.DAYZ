using Microsoft.Extensions.Configuration;

namespace KUBC.DAYZ;

/// <summary>
/// Базовый класс теста с загрузкой конфигурации из
/// файла JSON
/// </summary>
public class TestWithConfig
{
    /// <summary>
    /// Конфигурация тестов
    /// </summary>
    public readonly IConfiguration Configuration;

    /// <summary>
    /// Имя файла конфигурации для загрузки на старте
    /// </summary>
    public const string ConfigFileName = "config.json";

    public TestWithConfig()
    {
        var configBuilder = new ConfigurationBuilder();
        configBuilder.AddJsonFile(ConfigFileName);
        Configuration = configBuilder.Build();
    }
}
