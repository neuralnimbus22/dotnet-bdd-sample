using System.Text.Json;

namespace BddSample.Tests.Support;

// Run settings. The environment is picked at run time, not at build time.
public static class Settings
{
    public static string EnvironmentName =>
        System.Environment.GetEnvironmentVariable("TEST_ENVIRONMENT") is { Length: > 0 } name
            ? name.ToLowerInvariant()
            : "demo";

    public static string SeleniumUrl =>
        System.Environment.GetEnvironmentVariable("SELENIUM_URL") ?? "http://localhost:4444/wd/hub";

    public static string ArtifactsDir =>
        System.Environment.GetEnvironmentVariable("ARTIFACTS_DIR") ?? Path.Combine(AppContext.BaseDirectory, "artifacts");

    public static string BaseUrl
    {
        get
        {
            var file = Path.Combine(AppContext.BaseDirectory, "environments.json");
            var map = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(file))!;
            return map.TryGetValue(EnvironmentName, out var url)
                ? url.TrimEnd('/')
                : throw new InvalidOperationException($"Unknown environment '{EnvironmentName}'");
        }
    }
}
