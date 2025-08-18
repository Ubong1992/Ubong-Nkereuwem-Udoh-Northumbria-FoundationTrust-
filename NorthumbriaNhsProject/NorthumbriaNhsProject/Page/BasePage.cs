
using Microsoft.Playwright;
using NorthumbriaTestFramework.Drivers;
using NorthumbriaTestFramework.Utilities;


namespace NorthumbriaNhsProject.Page
{
    public interface IBasePage
    {
        Task GotoHomePage();
        Task AssertCurrentUrl(string expectedUrl);
    }
    public class BasePage : IBasePage
    {
        private readonly IPage _page;
        private readonly AppSettings _appSettings;

        public BasePage(IPlaywrightDriver playwrightDriver, AppSettings appSettings)
        {
            _page = playwrightDriver.Page.Result;
            _appSettings = appSettings;
        }
        public async Task GotoHomePage()
        {
            await _page.GotoAsync(_appSettings.BaseUrl);
        }

        public async Task AssertCurrentUrl(string expectedUrl)
        {
            var actualURl = _page.Url;
            Assert.Equal(expectedUrl, actualURl);
        }
    }


}
