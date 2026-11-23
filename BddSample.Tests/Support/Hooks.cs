using OpenQA.Selenium;
using Reqnroll;

namespace BddSample.Tests.Support;

[Binding]
public sealed class Hooks
{
    private readonly ScenarioContext _scenario;
    private readonly BrowserContext _browser;

    public Hooks(ScenarioContext scenario, BrowserContext browser)
    {
        _scenario = scenario;
        _browser = browser;
    }

    [BeforeScenario]
    public void LogEnvironment()
    {
        Console.WriteLine($"Scenario '{_scenario.ScenarioInfo.Title}' on environment '{Settings.EnvironmentName}' ({Settings.BaseUrl})");
    }

    [AfterScenario]
    public void SaveScreenshotOnFailure()
    {
        try
        {
            if (_scenario.TestError != null && _browser.Started)
            {
                var dir = Path.Combine(Settings.ArtifactsDir, "screenshots");
                Directory.CreateDirectory(dir);
                var safe = string.Concat(_scenario.ScenarioInfo.Title.Split(Path.GetInvalidFileNameChars())).Replace(' ', '-');
                var file = Path.Combine(dir, $"{safe}.png");
                ((ITakesScreenshot)_browser.Driver).GetScreenshot().SaveAsFile(file);
                Console.WriteLine($"Screenshot saved: {file}");
            }
        }
        finally
        {
            _browser.Dispose();
        }
    }
}
