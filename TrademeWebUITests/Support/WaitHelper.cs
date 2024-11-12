using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace TrademeWebUITests.Support
{
    public class WaitHelper
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        int timeoutInSeconds = 20;

        public WaitHelper(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
        }

       
        public IWebElement WaitUntilElementClickable(By locator)
        { 
            try
            {
                // Attempt to wait until the element is clickable
                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (Exception ex)
            {
                // Handle the case where the element cannot be clicked within the timeout period
                Console.WriteLine($"Element located by {locator} was not clickable after waiting for {timeoutInSeconds} seconds.");
                Console.WriteLine($"Error: {ex.Message}");
                return null; 
            }
           
           
        }
        
        public IWebElement WaitUntilElementVisible(By locator)
        {

            try
            {
                // Attempt to wait until the element is visible

                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            }
            catch (Exception ex)
            {
                // Handle the case where the element cannot be clicked within the timeout period
                Console.WriteLine($"Element located by {locator} was not visible after waiting for {timeoutInSeconds} seconds.");
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }


        }
    }
}

