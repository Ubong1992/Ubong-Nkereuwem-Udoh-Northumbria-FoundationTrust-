using Microsoft.Playwright;
using NorthumbriaTestFramework.Utilities;



namespace NorthumbriaTestFramework.Drivers
{
    public sealed class PlaywrightDriver : IDisposable, IPlaywrightDriver
    {
        private readonly AppSettings appSettings;
        private readonly AsyncLazy<IBrowser> _browser;
        private readonly AsyncLazy<IBrowserContext> _browserContext;
        private readonly AsyncLazy<IPage> _page;
        private readonly IDriverInitializer _driverInitializer;
        private bool _disposed;


        public PlaywrightDriver(AppSettings appSettings, IDriverInitializer driverInitializer)
        {
            _browser = new AsyncLazy<IBrowser>(InitializeDriverAsync);
            _browserContext = new AsyncLazy<IBrowserContext>(CreateBrowserContext);
            _page = new AsyncLazy<IPage>(CreatePageAsync);
            _appSettings = appSettings;
            _driverInitializer = driverInitializer;
        }
        public Task<IPage> Page => _page.Value;
        public Task<IBrowser> Browser => _browser.Value;
        public Task<IBrowserContext> BrowserContext => _browserContext.Value;    
        private bool _isDisposed;
        private readonly AppSettings _appSettings;

        private async Task<IBrowser> InitializeDriverAsync()
        {
            return _appSettings.DriverType switch

            {

                DriverType.Chromium => await _driverInitializer.GetChromiumDriverAsync(_appSettings),
                DriverType.Firefox => await _driverInitializer.GetFirefoxDriverAsync(_appSettings),
                _ => await _driverInitializer.GetChromiumDriverAsync(_appSettings)

            };
        }

        private async Task<IPage> CreatePageAsync()
        {
            return await (await _browser).NewPageAsync();
        }

        private async Task<IBrowserContext> CreateBrowserContext()
        {
            return await (await _browser).NewContextAsync();
        }


        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }
            if (_browser.IsValueCreated)
            {
                Task.Run(async () =>
                {
                    await (await _browser).CloseAsync();
                    await (await _browser).DisposeAsync();

                });
                _isDisposed = true;
            }
        }

    }
}