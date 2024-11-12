using FluentAssertions.Execution;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using TrademeWebUITests.Config;
using TrademeWebUITests.Pages;
using TrademeWebUITests.Support;



namespace TrademeWebUITests.StepDefinitions
{
    [Binding]
    internal class TrademeSearchHouseStepDefinitions 
    {
        private WebDriver driver;
        private WaitHelper waitHelper;
        private int listingCount;

        private readonly TradeMeHomePage homePage;
        private readonly PropertyListingsPage listingsPage;
        private readonly PropertyListingDetailsPage listingDetailsPage;
        
        public object ExpectedConditions { get; private set; }

        public TrademeSearchHouseStepDefinitions()
        {
            string browserName = WebConfig.GetBrowserName();
            this.driver = DriverSetup.InitializeDriver(browserName);
            this.waitHelper = new WaitHelper(driver);
            homePage = new TradeMeHomePage(driver, waitHelper);
            listingsPage = new PropertyListingsPage(driver, waitHelper);
            listingDetailsPage = new PropertyListingDetailsPage(driver, waitHelper);

        }

        [Given(@"\[User is on a Trademe Website]")]
        public void GivenUserIsOnATrademeWebsite()
        {

           //Verify that TradeMe homepage is loaded 
            bool websiteOK = homePage.VerifyPageisloaded(driver);
        }

        [When(@"\[the user inputs ""([^""]*)"" and clicks on search]")]
        public void WhenTheUserInputsAndClicksOnSearch(string searchHouse)
        {
            
            //Input text for search
            homePage.inputSearchText(searchHouse);
          
            //Click on Search button 
            homePage.clickSearchButton();
            
        }

        [When(@"\[the user selects Category as ""([^""]*)""]")]
        public void WhenTheUserSelectsCategoryAs(string category)
        {
            // click categoryDropdown 
            homePage.clickCategoryDropdownButton();
            
            // select category option as in "category" variable
            homePage.selectCategoryOption(category);

           // Thread.Sleep(100);

          }

        [When(@"\[sets location Region as ""([^""]*)""]")]
        public void WhenSetsLocationRegionAs(string region)
        {
                 
                   
            homePage.clickLocationButton();
           
            // Wait for the dropdown to appear and click 
            homePage.clickRegionDropdown();

            // Interact with the dropdown for Region (select an option)
            homePage.selectRegionOption(region);



            homePage.ClickViewlistingsResultButton();
           
        }

        [Then(@"\[number of listing displayed is (.*)]")]
        public void ThenNumberOfListingDisplayedIs(int listingCount)
        {

            int resultCount = listingsPage.viewPropertyListings();

            Assert.AreEqual(resultCount, listingCount);

        }

        [When(@"\[the user selects the first listing]")]
        public void WhenTheUserSelectsTheFirstListing()
        {
         
            listingsPage.selectFirstListing();
           
        }

        [Then(@"\[the user verifies the key details]")]
        public void ThenTheUserVerifiesTheKeyDetails()
        {
         
         // Step 6: Verify key details on the listing page
                   
         var address=listingDetailsPage.getPropertyAddress();
            
         
         var beds=listingDetailsPage.getPropertyBeds();
            
         
         var agentName=listingDetailsPage.getPropertyAgentName();
            
         Console.WriteLine($"Property Address   : {address}");
         Console.WriteLine($"Property Beds      :{beds}");
         Console.WriteLine($"Property AgentName : {agentName}");


           //  Assert key details are visible
         Assert.IsNotNull(address, "Address is not displayed!");
         Assert.IsNotNull(beds, "Beds are not displayed!");
         Assert.IsNotNull(agentName, "Agent's name is not displayed!");
        }

       [After]
       public void TearDown()
        {
        
         //Close WebPage
         DriverSetup.QuitDriver();
        }

    }

}

