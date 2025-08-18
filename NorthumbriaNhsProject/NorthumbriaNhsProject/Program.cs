

using Microsoft.Extensions.DependencyInjection;
using NorthumbriaNhsProject.Page;
using NorthumbriaTestFramework.Drivers;
using NorthumbriaTestFramework.Utilities;
using Reqnroll.Microsoft.Extensions.DependencyInjection;

namespace NorthumbriaNhsProject
{
    public class Program
    {
        [ScenarioDependencies]
            public static IServiceCollection ConfigureServices()
            {
                var services = new ServiceCollection();
            services
                    .AddSingleton(FileReader.ReadSettings())
                    .AddScoped<IPlaywrightDriver, PlaywrightDriver>()
                    .AddScoped<IDriverInitializer, DriverInitializer>()
                    .AddScoped<IBasePage, BasePage>()
                    .AddScoped<IHomePage, HomePage>()
                    .AddScoped<ISearchResultPage, SearchResultPage>()
                    .AddScoped<IQualityAndSafetyPage, QualityAndSafetyPage>()
                    .AddScoped<IContinuallyImprovingServicesPage, ContinuallyImprovingServicesPage>();

                return services;
            }
        }

    
}


