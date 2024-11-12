using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TrademeWebUITests.Support;

namespace TrademeWebUITests.Pages
{
    internal class PropertyListingsPage
    {
     
        private WebDriver driver;
        private WaitHelper waitHelper;
        private By listingResultHeader = By.XPath("//tm-property-search-results//tm-search-header-result-count/h3");
        private By firstListing = By.XPath("//tm-property-search-card-address-subtitle");
        public PropertyListingsPage(WebDriver driver, WaitHelper waitHelper)
        {
            this.driver = driver;
            this.waitHelper = waitHelper;
        }


        public int viewPropertyListings()
        {

            // Find the header which displays the number of results e.g.Showing 284 results for 'house'
            IWebElement listingResult = waitHelper.WaitUntilElementVisible(listingResultHeader);

            Thread.Sleep(500);
         
            //Find the displayed number[listing results count] from the header 
            string resultsText = listingResult.Text;
            int resultCount = 0;
            Console.WriteLine($" This is the Listing Result : {resultsText}");

            Regex regex = new Regex(@"\d+");
            Match match = regex.Match(resultsText);

            if (match.Success)
            {
                // Parse the matched number
                resultCount = int.Parse(match.Value);
                Console.WriteLine("Number of results: " + resultCount);


            }
            else
            {
                Console.WriteLine("Could not extract the number of results.");
            }
            return resultCount;
        }


        public void selectFirstListing()
        {
            
            waitHelper.WaitUntilElementVisible(firstListing).Click();
         
        }

    }

}
