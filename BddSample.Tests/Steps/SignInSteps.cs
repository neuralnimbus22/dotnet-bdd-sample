using BddSample.Tests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Reqnroll;

namespace BddSample.Tests.Steps;

[Binding]
public sealed class SignInSteps
{
    private readonly BrowserContext _browser;

    public SignInSteps(BrowserContext browser) => _browser = browser;

    [Given("the user is on the sign-in page")]
    public void GivenTheUserIsOnTheSignInPage()
    {
        _browser.Driver.Navigate().GoToUrl($"{Settings.BaseUrl}/login");
    }

    [When("the user signs in as {string} with password {string}")]
    public void WhenTheUserSignsIn(string user, string password)
    {
        _browser.Driver.FindElement(By.Id("username")).SendKeys(user);
        _browser.Driver.FindElement(By.Id("password")).SendKeys(password);
        _browser.Driver.FindElement(By.CssSelector("button[type='submit']")).Click();
    }

    [Then("the page shows the message {string}")]
    public void ThenThePageShowsTheMessage(string expected)
    {
        var message = _browser.Driver.FindElement(By.Id("flash")).Text;
        StringAssert.Contains(message, expected);
    }
}
