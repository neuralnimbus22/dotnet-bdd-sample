using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace BddSample.Tests.Support;

// One browser per scenario, created in one place and shared through dependency injection.
public sealed class BrowserContext : IDisposable
{
    private IWebDriver? _driver;

    public IWebDriver Driver => _driver ??= Create();

    public bool Started => _driver != null;

    private static IWebDriver Create()
    {
        var options = new ChromeOptions();
        options.AddArgument("--window-size=1366,900");
        var driver = new RemoteWebDriver(new Uri(Settings.SeleniumUrl), options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        return driver;
    }

    public void Dispose()
    {
        _driver?.Quit();
        _driver = null;
    }
}
