

using Microsoft.Playwright;
using NorthumbriaTestFramework.Utilities;

namespace NorthumbriaTestFramework.Drivers
{
    public class DriverInitializer : IDriverInitializer
    {

        public async Task<IBrowser> GetChromiumDriverAsync(AppSettings appSettings)
        {
            var options = GetParameters(appSettings.Headless, appSettings.SlowMo);
            options.Channel = "chromium";
            return await GetBrowserAsync(DriverType.Chromium, options);
        }
        public async Task<IBrowser> GetChromeDriverAsync(AppSettings appSettings)
        {
            var options = GetParameters(appSettings.Headless, appSettings.SlowMo);
            options.Channel = "chrome";
            return await GetBrowserAsync(DriverType.Chromium, options);
        }
        public async Task<IBrowser> GetFirefoxDriverAsync(AppSettings appSettings)
        {
            var options = GetParameters(appSettings.Headless, appSettings.SlowMo);
            options.Channel = "firefox";
            return await GetBrowserAsync(DriverType.Firefox, options);
        }

        private static async Task<IBrowser> GetBrowserAsync(DriverType driverType, BrowserTypeLaunchOptions options)
        {
            var playwright = await Playwright.CreateAsync();
            return await playwright[driverType.ToString().ToLower()].LaunchAsync(options);
        }
        private static BrowserTypeLaunchOptions GetParameters(bool? headless = false, float? slowmo = null)
        => new()
        {
            Headless = headless,
            SlowMo = slowmo,
        };
    }
}

