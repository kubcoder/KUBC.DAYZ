using Microsoft.Extensions.DependencyInjection;

namespace KUBC.DAYZ.MissionFiles;

public class MissionsTest : TestWithSample
{
    private const string MF = "Mission";

    protected override void AddTestServices(ServiceCollection services)
    {
        services.AddSingleton(new DirectoryInfo(Path.Combine(Samples.FullName, MF)));
    }
}
