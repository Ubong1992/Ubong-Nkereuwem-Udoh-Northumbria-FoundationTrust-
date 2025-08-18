using Microsoft.Playwright;

namespace NorthumbriaTestFramework.Drivers
{
    public interface IPlaywrightDriver
    {
        Task<IBrowser> Browser { get; }
        Task<IBrowserContext> BrowserContext { get; }
        Task<IPage> Page { get; }

    }
}