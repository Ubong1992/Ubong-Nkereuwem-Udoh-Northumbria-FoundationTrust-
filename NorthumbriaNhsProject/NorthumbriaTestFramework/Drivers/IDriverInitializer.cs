using Microsoft.Playwright;
using NorthumbriaTestFramework.Utilities;

namespace NorthumbriaTestFramework.Drivers
{
    public interface IDriverInitializer
    {
     Task<IBrowser> GetChromiumDriverAsync(AppSettings appSettings);
     Task<IBrowser> GetFirefoxDriverAsync(AppSettings appSettings);
    }
}