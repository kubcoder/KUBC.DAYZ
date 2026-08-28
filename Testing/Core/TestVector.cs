using System.Text.Json;


namespace KUBC.DAYZ.Core;

/// <summary>
/// Тестовый класс содержащий вектор
/// </summary>
internal class DataWithVector
{
    public string? TextData { get; set; }
    public Vector? Position { get; set; }
}

public class TestVector : TestWithSample
{
    [Fact]
    public async Task Load()
    {
        var testFile = Samples.GetFiles("Vectors.json").FirstOrDefault();
        Assert.NotNull(testFile);
        using var file = testFile.OpenRead();
        var data = await JsonSerializer.DeserializeAsync<DataWithVector>(file, cancellationToken: TestContext.Current.CancellationToken);
        Assert.NotNull(data);
        Assert.NotNull(data.Position);
        Assert.Equal(100.1, data.Position.X);
        Assert.Equal(200.2, data.Position.Y);
        Assert.Equal(300.3, data.Position.Z);
    }
}
