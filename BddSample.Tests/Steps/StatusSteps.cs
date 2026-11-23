using BddSample.Tests.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reqnroll;

namespace BddSample.Tests.Steps;

[Binding]
public sealed class StatusSteps
{
    private static readonly HttpClient Http = new() { Timeout = TimeSpan.FromSeconds(30) };
    private HttpResponseMessage? _response;

    [When("the client calls {string}")]
    public async Task WhenTheClientCalls(string path)
    {
        _response = await Http.GetAsync($"{Settings.BaseUrl}{path}");
    }

    [Then("the response status is {int}")]
    public void ThenTheResponseStatusIs(int status)
    {
        Assert.IsNotNull(_response);
        Assert.AreEqual(status, (int)_response.StatusCode);
    }
}
