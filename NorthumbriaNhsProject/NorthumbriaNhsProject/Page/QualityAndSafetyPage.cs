

using Microsoft.Playwright;
using NorthumbriaTestFramework.Drivers;

namespace NorthumbriaNhsProject.Page
{
    public interface IQualityAndSafetyPage
    {
        Task SelectAResultCard(string resultCard);
        Task<string> VerifyThePageTitle();
    }
    public class QualityAndSafetyPage : IQualityAndSafetyPage
    {
        private readonly IPage _page;
        private ILocator _keepingPatientSafeElement => _page.GetByRole(AriaRole.Link, new () { Name = "Keeping patients safe" });
        private ILocator _continuallyImprovingServicesElement => _page.GetByRole(AriaRole.Link, new () { Name = "Continually improving services" });
        private ILocator _listeningToPatientsElement => _page.GetByRole(AriaRole.Link, new () { Name = "Listening to patients" });
        private ILocator _researchAndClinicalTrialsElement => _page.GetByRole(AriaRole.Link, new() { Name = "Research and clinical trials" });
        private ILocator _ourModelForUrgentAndEmergencyCareElement => _page.GetByRole(AriaRole.Link, new() { Name = "Our model for urgent and" });

public QualityAndSafetyPage(IPlaywrightDriver playwrightDriver)
        {
            _page = playwrightDriver.Page.Result;
        }

        public async Task<string> VerifyThePageTitle()
        {
            return await _page.TitleAsync();
            
        }
        public async Task SelectAResultCard(string resultCard)
        {
            if (resultCard == "Keeping patients safe")
            {
                await _keepingPatientSafeElement.ClickAsync();
            }
            else if (resultCard == "Continually improving services")
            {
                await _continuallyImprovingServicesElement.ClickAsync();
            }
            else if (resultCard == "Listening to patients")
            {
                await _listeningToPatientsElement.ClickAsync();
            }
            else if (resultCard == "Research and clinical trials")
            {
                await _researchAndClinicalTrialsElement.ClickAsync();
            }
            else if (resultCard == "Our model for urgent and emergency care")
            {
                await _ourModelForUrgentAndEmergencyCareElement.ClickAsync();
            }
            else
            {
                throw new NotImplementedException("There is not such result card named " + resultCard);
            }
        }
    }

    
}
