using NorthumbriaNhsProject.Model;
using NorthumbriaNhsProject.Page;
using Reqnroll;

namespace NorthumbriaNhsProject.StepDefinitions
{
    [Binding]
    public class SearchFunctionalityStepDef
    {
        private readonly IBasePage _basePage;
        private readonly IHomePage _homePage;
        private readonly ISearchResultPage _searchResultPage;
        private readonly IQualityAndSafetyPage _qualityAndSafetyPage;
        private readonly IContinuallyImprovingServicesPage _continuallyImprovingServicesPage;

        public SearchFunctionalityStepDef(IBasePage basePage, IHomePage homePage,ISearchResultPage searchResultPage,IQualityAndSafetyPage qualityAndSafetyPage,
            IContinuallyImprovingServicesPage continuallyImprovingServicesPage)
        {
            _basePage = basePage;
            _homePage = homePage;
            _searchResultPage = searchResultPage;
            _qualityAndSafetyPage = qualityAndSafetyPage;
            _continuallyImprovingServicesPage = continuallyImprovingServicesPage;
        }

        [Given("the user is on the northumbria nhs homepage")]
        public async Task GivenTheUserIsOnTheNorthumbriaNhsHomepage()
        {
            await _basePage.GotoHomePage();
        }

        [Given("verify the homepage url is returned as {string}")]
        public async Task GivenVerifyTheHomepageUrlIsReturnedAs(string expectedUrl)
        {
        await _basePage.AssertCurrentUrl(expectedUrl);
        }

        [When("the user enter {string} on the search field")]
        public async Task WhenTheUserEnterOnTheSearchField(string searchKeyword)
        {
            await _homePage.EnterTheSearchKeyword(searchKeyword);
        }

        [When("click on the search button")]
        public async Task WhenClickOnTheSearchButton()
        {
           await _homePage.ClickOnTheSearchButton();
        }
        [Then("the result based on the search criteria will be returned as a linkText {string}")]
        public async Task ThenTheResultBasedOnTheSearchCriteriaWillBeReturnedAsALinkText(string linkText)
        {
            await _searchResultPage.VerifyTheexpectedSearchResultsAreReturened(linkText);
        }

        [Then("the user verify that the search result page url is returned as {string}")]
        public async Task ThenTheUserVerifyThatTheSearchResultPageUrlIsReturnedAs(string expectedUrl)
        {
            await _basePage.AssertCurrentUrl(expectedUrl);
        }
      
        [Then("the user will be able access quality and safty link on the search result page")]
        public async Task ThenTheUserWillBeAbleAccessQualityAndSaftyLinkOnTheSearchResultPage()
        {
            await _searchResultPage.ClickOnQualityAndSafetyLink();
        }

        [Then("verify the quality and safety page url is returned as {string}")]
        public async Task ThenVerifyTheQualityAndSafetyPageUrlIsReturnedAs(string expectedUrl)
        {     
            await _basePage.AssertCurrentUrl(expectedUrl);
            await _qualityAndSafetyPage.VerifyThePageTitle();
        }

        [Then("the user selects the {string} card on the quality and safety page")]
        public async Task ThenTheUserSelectsTheCardOnTheQualityAndSafetyPage(string resultCard)
        {
            await _qualityAndSafetyPage.SelectAResultCard(resultCard);
        }

        [Then("verify the Continually improving servces page is returned as {string}")]
        public async Task ThenVerifyTheContinuallyImprovingServcesPageIsReturnedAs(string expectedUrl)
        {             
        await _basePage.AssertCurrentUrl(expectedUrl);
        }

        [Then("the relevant information about the section will be returned on the page")]
        public async Task ThenTheRelevantInformationAboutTheSectionWillBeReturnedOnThePage()
        {
            await _continuallyImprovingServicesPage.VerifyThatAllRelevantInformationAreReturned();
        }
        [When("press the keyboard enter button")]
        public async Task WhenPressTheKeyboardEnterButton()
        {
            await _homePage.PressTheKeyboardEnterButton();
        }
        [Then("the user should see a suggestion message {string}")]
        public async Task ThenTheUserShouldSeeASuggestionMessage(string infoMessage)
        {
            await _homePage.VerifyInfoMessageIsDisplayed(infoMessage);
        }
        [Then("the following results with links and messages will be returned")]
        public async Task ThenTheFollowingResultsWithLinksAndMessagesWillBeReturned(DataTable dataTable)
        {
            var dataStore = dataTable.CreateInstance<DataStore>();
            await _homePage.VerifyThatTheInvalidSearchResultsAreReturned(dataStore.PageLink,dataStore.FileLink,dataStore.PageResults,dataStore.FileResults);
        }


    }
}


