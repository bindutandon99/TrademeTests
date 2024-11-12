using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using TrademeWebUITests.Config;
using TrademeWebUITests.Support;



namespace TrademeWebUITests.Pages
{
    public class TradeMeHomePage
    {

        private WebDriver driver;
        private WaitHelper waitHelper;
        private string baseUrl = WebConfig.GetTestingSiteURL();
        private By SearchInputField = By.Id("search");
        private By searchButton = By.XPath("//button[@type='submit']");
        private By categoryDropdownButton = By.XPath("//button[contains(.,'Category')]");
        private By categoryDropdownHeader = By.XPath("//h2[contains(.,'Category')]/..");
        private string categorySelectOptionPath = "//span[contains(.,'{0}')]";

        private By allLocationsButton = By.XPath("//button[contains(.,'All Locations')]");
        private By locationHeader = By.XPath("//h2[contains(.,'Location')]/..");
        private By regionDropDown = By.XPath("//tg-scrollable-container//tm-location-refine-dropdown-select//select");
        private By tradeMeMainPage = By.XPath("//div[@class='tm-shell-main-nav__global-options-logo']");
        private By viewListingsResultButton = By.XPath("//.//button[contains(.,'View')]");

        public IWebElement regionElement;
        public IWebElement locationElement;


        public TradeMeHomePage(WebDriver driver, WaitHelper waitHelper)
        {

            this.driver = driver;
            this.waitHelper = waitHelper;
        }

        public bool VerifyPageisloaded(WebDriver driver)
        {
            driver.Navigate().GoToUrl(baseUrl);

            bool isValid = driver.FindElement(tradeMeMainPage).Displayed;

            Console.WriteLine("Trademe Logo exists and page is loaded : " + isValid);

            return isValid;

        }

        public void inputSearchText(string searchText)
        {


            waitHelper.WaitUntilElementVisible(SearchInputField).SendKeys(searchText);

        }


        public void clickSearchButton()
        {

            waitHelper.WaitUntilElementClickable(searchButton).Click();

        }


        public void clickCategoryDropdownButton()
        {

            waitHelper.WaitUntilElementClickable(categoryDropdownButton).Click();

        }

        public void selectCategoryOption(string categoryOption)
        {

            bool categoryHeader = waitHelper.WaitUntilElementVisible(categoryDropdownHeader).Displayed;
            // Verify the Category Header is displayed
            Assert.IsTrue(categoryHeader);

            //create xpath expression dynamically based on categoryoption -- here Trade Me Property 
            string xpathExpression = string.Format(categorySelectOptionPath, categoryOption);

            //Click on Trade Me Property 
            waitHelper.WaitUntilElementClickable(By.XPath(xpathExpression)).Click();

            Thread.Sleep(200);
        }


        public void clickLocationButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
           
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            try
            {
                //locationElement = waitHelper.WaitUntilElementClickable(allLocationsButton);
                locationElement = wait.Until(webDriver =>
                {
                    var element = webDriver.FindElement(allLocationsButton);
                    return (element.Displayed && element.Enabled) ? element : null;
                });

            }
            catch (Exception e)
            {
                //Button not found 
                Console.WriteLine("Element location cannot be found within 30 seconds ");
                throw new Exception("Failed in loading 'All Locations' Button " + e.Message);

            }
                
             locationElement.Click();

           // locate the Header "Location" after "All locations" button is clicked
           
            bool isLocationHeaderVisible = waitHelper.WaitUntilElementVisible(locationHeader).Displayed;
            Assert.IsTrue(isLocationHeaderVisible);
        }

        public void clickRegionDropdown()
        {

            regionElement = waitHelper.WaitUntilElementClickable(regionDropDown);
            regionElement.Click();

        }

        public void selectRegionOption(string region)
        {
            // Step 3: Interact with the dropdown (select an option)
            SelectElement selectElement = new SelectElement(regionElement);
            // Select an option by visible text
            selectElement.SelectByText(region);
        }


        public void ClickViewlistingsResultButton()
        {

            //Click on "View <N> Results" 
            waitHelper.WaitUntilElementClickable(viewListingsResultButton).Click();


        }
    }
}


