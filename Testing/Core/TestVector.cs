using System.Text.Json;
using Xunit.Abstractions;

namespace KUBC.DAYZ.Core;

/// <summary>
/// Тестовый класс содержащий вектор
/// </summary>
internal class DataWithVector
{
    public string? TextData { get; set; }
    public Vector? Position { get; set; }
}

public class TestVector(ITestOutputHelper output) : TestWithSample(output)
{
    [Fact]
    public async Task Load()
    {
        var testFile = Samples.GetFiles("Vectors.json").FirstOrDefault();
        Assert.NotNull(testFile);
        using var file = testFile.OpenRead();
        var data = await JsonSerializer.DeserializeAsync<DataWithVector>(file);
        Assert.NotNull(data);
        Assert.NotNull(data.Position);
        Assert.Equal(100.1, data.Position.X);
        Assert.Equal(200.2, data.Position.Y);
        Assert.Equal(300.3, data.Position.Z);
    }
}
