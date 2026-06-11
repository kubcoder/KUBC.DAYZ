using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace KUBC.DAYZ;

/// <summary>
/// Класс теста с журналом
/// </summary>
public class TestWithServices : TestWithConfig
{
    /// <summary>
    /// Провайдер сервисов
    /// </summary>
    public IServiceProvider ServiceProvider;

    /// <summary>
    /// Вывод тестов
    /// </summary>
    protected readonly ITestOutputHelper Output;

    /// <summary>
    /// Инициализируем сервисы теста
    /// </summary>
    public TestWithServices()
    {
        var output = TestContext.Current.TestOutputHelper;
        Assert.NotNull(output);
        Output = output;
        var services = new ServiceCollection();
        services.TryAddSingleton(Configuration);
        services.AddLogging((builder) =>
        {
            builder.AddXUnit(Output, options =>
            {
                options.TimestampFormat = "HH:mm:ss.fffffff";
            });
            builder.AddConfiguration(Configuration.GetSection("Logging"));
        });
        AddTestServices(services);
        ServiceProvider = services.BuildServiceProvider();
    }
    /// <summary>
    /// Добавляем сервисы теста
    /// </summary>
    /// <param name="services"></param>
    protected virtual void AddTestServices(ServiceCollection services)
    {

    }
}
