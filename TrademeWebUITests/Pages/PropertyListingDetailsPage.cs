using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V128.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrademeWebUITests.Support;

namespace TrademeWebUITests.Pages
{
    internal class PropertyListingDetailsPage
    {
        private WebDriver driver;
        private WaitHelper waitHelper;
        private By SearchInputField = By.Id("search");
        private By searchButon = By.XPath("//button[@type='submit']");
        private By propertyAddress = By.CssSelector(".tm-property-listing-body__location");
        private By propertyBeds = By.XPath("(//div[@class='tm-property-listing-attribute-tag__tag--content'])[1]");
        private By propertyAgentName = By.XPath("//div[@class='tm-property-agent-no-branding']");



        public PropertyListingDetailsPage(WebDriver driver, WaitHelper waitHelper)
        {
            this.driver = driver;
            this.waitHelper = waitHelper;
        }

        public string getPropertyAddress() {

            string address = waitHelper.WaitUntilElementVisible(propertyAddress).Text;
             return address;
        }

        public string getPropertyBeds() {
            string numberOfBeds = waitHelper.WaitUntilElementVisible(propertyBeds).Text;
            return numberOfBeds;
        }

        public string getPropertyAgentName() {
            string agentName = waitHelper.WaitUntilElementVisible(propertyAgentName).Text;
            return agentName;
        }

    }
}
