

using Microsoft.Playwright;
using NorthumbriaTestFramework.Drivers;

namespace NorthumbriaNhsProject.Page
{
    public interface IHomePage
    {      
        Task ClickOnTheSearchButton();
        Task EnterTheSearchKeyword(string keyword);
        Task PressTheKeyboardEnterButton();
    }
    public class HomePage : IHomePage
    {
        private readonly IPage _page;
        private ILocator _keywordField => _page.GetByRole(AriaRole.Textbox, new() { Name = "Enter your search" });
        private ILocator _searchButton => _page.GetByRole(AriaRole.Button, new() { Name = "Search" });

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
    }


}
