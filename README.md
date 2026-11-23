# dotnet-bdd-sample

A small .NET 9 BDD suite: Gherkin scenarios with Reqnroll, run by MSTest, with Selenium for the browser and HttpClient for the API.

It runs as a Testkube Test Workflow. The workflow is in `testkube/dotnet-bdd-sample.yaml`.

- `dotnet test` runs the scenarios. A JUnit logger writes the results.
- Chrome runs as a Selenium service next to the tests.
- Two inputs are set at run time: `environment` (`demo` or `uat`) and `filter` (for example `TestCategory=SignIn`).
- Gherkin tags become MSTest categories. Each scenario has an area tag and a test case ID.
- A screenshot is saved for every failed scenario.
- The `@Stale` scenario was written for an older page. It is left out of the default run. Run it with `filter` set to `TestCategory=Stale` to see a failure.

Run locally with a Selenium server on port 4444:

```
dotnet test BddSample.Tests/BddSample.Tests.csproj --filter "TestCategory!=Stale"
```
