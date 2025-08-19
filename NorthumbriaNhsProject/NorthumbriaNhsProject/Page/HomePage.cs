

using Microsoft.Playwright;
using NorthumbriaTestFramework.Drivers;

namespace NorthumbriaNhsProject.Page
{
    public interface IHomePage
    {      
        Task ClickOnTheSearchButton();
        Task EnterTheSearchKeyword(string keyword);
        Task PressTheKeyboardEnterButton();
        Task VerifyInfoMessageIsDisplayed(string infoMessage);
        Task VerifyThatTheInvalidSearchResultsAreReturned(string? pageLink, string? fileLink, string? pageResults, string? FileResults);
    }
    public class HomePage : IHomePage
    {
        private readonly IPage _page;
        private ILocator _keywordField => _page.GetByRole(AriaRole.Textbox, new() { Name = "Enter your search" });
        private ILocator _searchButton => _page.GetByRole(AriaRole.Button, new() { Name = "Search" });
        private ILocator _infoMessage =>  _page.GetByRole(AriaRole.Heading, new() { Name = "You might also be interested"});        
        private ILocator _pageLink => _page.GetByText("0 Pages found that matched");
        private ILocator _fileLink => _page.GetByText("0 Files found that matched");
        private ILocator _pageResult => _page.GetByText("No page results found.");
        private ILocator _fileResult => _page.GetByText("No file results found.");
    

    public HomePage(IPlaywrightDriver playwrightDriver)
        {
            _page = playwrightDriver.Page.Result;
        }

       
        public async Task EnterTheSearchKeyword(string keyword)
        {
         await _keywordField.FillAsync(keyword);
        }
        public async Task ClickOnTheSearchButton()
        {
            await _searchButton.ClickAsync();
        }
        public async Task PressTheKeyboardEnterButton()
        {
            await _searchButton.PressAsync("Enter");
        }
        public async Task VerifyInfoMessageIsDisplayed(string infoMessage)
        {
            var infoMessageElement = _infoMessage;
            await Assertions.Expect(infoMessageElement).ToHaveTextAsync(infoMessage);
        }
        public async Task VerifyThatTheInvalidSearchResultsAreReturned(string? pageLink, string? fileLink, string? pageResults, string? fileResults)
        {
            var pageLinkElement = _pageLink;
            await Assertions.Expect(pageLinkElement).ToHaveTextAsync(pageLink);
            var fileLinkElement = _fileLink;
            await Assertions.Expect(fileLinkElement).ToHaveTextAsync(fileLink);
            var pageResultElement = _pageResult;
            await Assertions.Expect(pageResultElement).ToHaveTextAsync(pageResults);
            var fileResultElement = _fileResult;
            await Assertions.Expect(fileResultElement).ToHaveTextAsync(fileResults);

        }
    }


}
