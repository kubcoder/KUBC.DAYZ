using Microsoft.Testing.Platform.Services;

namespace KUBC.DAYZ.MissionFiles.Config.LimitsDefinition;

public class TestFile : MissionsTest
{
    [Fact]
    public void ReadFile()
    {
        var missionPath = ServiceProvider.GetRequiredService<DirectoryInfo>();
        var readFile = FileLoader.Load(missionPath);
        Assert.NotEmpty(readFile.Categories);
        CheckCategorise(readFile);
    }

    private void CheckCategorise(ConfigFile readFile)
    {
        Assert.Equal(8, readFile.Categories.Count);
        Assert.Contains("tools", readFile.Categories);
        Assert.Contains("containers", readFile.Categories);
        Assert.Contains("clothes", readFile.Categories);
        Assert.Contains("lootdispatch", readFile.Categories);
        Assert.Contains("food", readFile.Categories);
        Assert.Contains("weapons", readFile.Categories);
        Assert.Contains("books", readFile.Categories);
        Assert.Contains("explosives", readFile.Categories);
    }
}
