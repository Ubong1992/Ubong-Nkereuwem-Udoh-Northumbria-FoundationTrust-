@Regression
Feature: Search Functionality

As a Northumbria foundation user
I want to be able to access the northumbria nhs website
So that I can perform a search for information regarding quality and safety


Scenario: Search for quality and safety using the search button
	Given the user is on the northumbria nhs homepage
	And verify the homepage url is returned as "https://www.northumbria.nhs.uk/"
	When the user enter "quality and safety" on the search field
	And click on the search button
	Then the result based on the search criteria will be returned as a linkText "Quality and safety"
	And the user verify that the search result page url is returned as "https://www.northumbria.nhs.uk/search?query=quality+and+safety#search-anchor"
	And the user will be able access quality and safty link on the search result page 
	And verify the quality and safety page url is returned as "https://www.northumbria.nhs.uk/about-us/quality-and-safety"
	And the user selects the "Continually improving services" card on the quality and safety page
	And verify the Continually improving servces page is returned as "https://www.northumbria.nhs.uk/about-us/quality-and-safety/continually-improving-services"
	And the relevant information about the section will be returned on the page 


	Scenario: Search for quality and safety using the enter keyboard button
	Given the user is on the northumbria nhs homepage
	And verify the homepage url is returned as "https://www.northumbria.nhs.uk/"
	When the user enter "quality and safety" on the search field
	And press the keyboard enter button
	Then the result based on the search criteria will be returned as a linkText "Quality and safety"
	And the user verify that the search result page url is returned as "https://www.northumbria.nhs.uk/search?query=quality+and+safety#search-anchor"
	And the user will be able access quality and safty link on the search result page 
	And verify the quality and safety page url is returned as "https://www.northumbria.nhs.uk/about-us/quality-and-safety"
	And the user selects the "Continually improving services" card on the quality and safety page
	And verify the Continually improving servces page is returned as "https://www.northumbria.nhs.uk/about-us/quality-and-safety/continually-improving-services"
	And the relevant information about the section will be returned on the page 