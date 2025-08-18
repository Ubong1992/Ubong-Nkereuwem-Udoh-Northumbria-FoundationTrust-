using Microsoft.Playwright;
using NorthumbriaTestFramework.Drivers;
using Reqnroll.Assist;

namespace NorthumbriaNhsProject.Page
{
    public interface IContinuallyImprovingServicesPage
    {
        Task VerifyThatAllRelevantInformationAreReturned();
    }
    public class ContinuallyImprovingServicesPage : IContinuallyImprovingServicesPage
    {
        private readonly IPage _page;

        public ContinuallyImprovingServicesPage(IPlaywrightDriver playwrightDriver)
        {
            _page = playwrightDriver.Page.Result;
        }
        public async Task VerifyThatAllRelevantInformationAreReturned()
        {
            var headerElement = _page.GetByRole(AriaRole.Heading, new() { Name = "Continually improving services" });
            await Assertions.Expect(headerElement).ToHaveTextAsync("Continually improving services");
            var safetyElement = _page.GetByRole(AriaRole.Heading, new() { Name = "Safety and quality priorities" });
            await Assertions.Expect(safetyElement).ToHaveTextAsync("Safety and quality priorities");
            var serviceElement = _page.GetByRole(AriaRole.Heading, new() { Name = "Service reviews" });
            await Assertions.Expect(serviceElement).ToHaveTextAsync("Service reviews");
            var measuringElement = _page.GetByRole(AriaRole.Heading, new() { Name = "Measuring the quality of" });
            await Assertions.Expect(measuringElement).ToHaveTextAsync("Measuring the quality of clinical care");
            var wardElement = _page.GetByRole(AriaRole.Heading, new() { Name = "Ward and service assessments" });
            await Assertions.Expect(wardElement).ToHaveTextAsync("Ward and service assessments");
            var ourQualityElement = _page.GetByRole(AriaRole.Heading, new() { Name = "Our quality strategy" });
            await Assertions.Expect(ourQualityElement).ToHaveTextAsync("Our quality strategy");
            var ensuringElement = _page.GetByRole(AriaRole.Heading, new() { Name = "Ensuring patients understand" });
            await Assertions.Expect(ensuringElement).ToHaveTextAsync("Ensuring patients understand their medication");
            var successElement = _page.GetByRole(AriaRole.Heading, new() { Name = "Measuring the success of a" });
            await Assertions.Expect(successElement).ToHaveTextAsync("Measuring the success of a service");
        }

    }
}

    

