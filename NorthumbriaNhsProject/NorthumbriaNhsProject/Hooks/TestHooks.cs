

using Microsoft.Playwright;
using NorthumbriaNhsProject.Page;
using NorthumbriaTestFramework.Drivers;
using Reqnroll;


namespace NorthumbriaNhsProject.Hooks
{
    [Binding]
    public sealed class TestHooks
    {
        private readonly IPlaywrightDriver _playwrightDriver;
        private readonly Task<IPage> _page;
        private readonly IBasePage _basePage;

        public TestHooks(IPlaywrightDriver playwrightDriver, IBasePage basePage)
        {
            _playwrightDriver = playwrightDriver;
            _page = playwrightDriver.Page;
            _basePage = basePage;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Test execution started.");
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Test execution completed.");
        }


        [BeforeScenario("SmokeTest")]
        public async Task BeforeScenario()
        {
            await _basePage.GotoHomePage();
        }

        [AfterScenario]
        public async Task AfterScenario(ScenarioContext scenarioContext)
        {
            try
            {
                var page = await _page;

                if (scenarioContext.TestError != null)
                {
                    // Scenario failed – take a screenshot
                    var screenshotsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
                    Directory.CreateDirectory(screenshotsDir);

                    var fileName = $"{scenarioContext.ScenarioInfo.Title}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                    var screenshotPath = Path.Combine(screenshotsDir, fileName);

                    await page.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotPath, FullPage = true });

                    Console.WriteLine($"Screenshot saved: {screenshotPath}");
                }

                if (!page.IsClosed)
                {
                    await page.CloseAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during AfterScenario hook: {ex.Message}");
                // Consider rethrowing or swallowing depending on your policy
            }
        }

    }
}

    


