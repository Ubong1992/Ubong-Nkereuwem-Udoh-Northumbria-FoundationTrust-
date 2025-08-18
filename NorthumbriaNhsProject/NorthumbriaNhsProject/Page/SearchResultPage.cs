

using Microsoft.Playwright;
using NorthumbriaTestFramework.Drivers;
using static System.Net.Mime.MediaTypeNames;

namespace NorthumbriaNhsProject.Page
{
    public interface ISearchResultPage
    {
        Task ClickOnQualityAndSafetyLink();
        Task VerifyTheexpectedSearchResultsAreReturened(string linkText);
    }
    public class SearchResultPage : ISearchResultPage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;
        private ILocator _qualityAndSafetyLink => _page.GetByRole(AriaRole.Link, new() { Name = "Quality and safety" });    

    public SearchResultPage(IPlaywrightDriver playwrightDriver,IBasePage basePage)
        {
            _page = playwrightDriver.Page.Result;
            _basePage = basePage;
        }

        public async Task VerifyTheexpectedSearchResultsAreReturened(string linkText)
        {          
            var linkElement = _qualityAndSafetyLink;
            await Assertions.Expect(linkElement).ToHaveTextAsync(linkText);

        }
        public async Task ClickOnQualityAndSafetyLink()
        {
            await _qualityAndSafetyLink.ClickAsync();
        }


    }
}