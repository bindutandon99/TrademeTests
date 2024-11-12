using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrademeWebUITests.Support
{
    public static class DriverSetup
    {
        private static WebDriver _driver;

        public static WebDriver InitializeDriver(string browser)
        {
            if (browser.Equals("chrome", StringComparison.OrdinalIgnoreCase))
            {
                _driver = new ChromeDriver();
            }
            else if (browser.Equals("firefox", StringComparison.OrdinalIgnoreCase))
            {
                _driver = new FirefoxDriver();
            }
            else if (browser.Equals("edge", StringComparison.OrdinalIgnoreCase))
            {
                _driver = new EdgeDriver();
            }
            else
            {
                throw new NotImplementedException($"Browser {browser} is not supported.");
            }

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _driver.Manage().Window.Maximize();
            return _driver;

        }
            public static void QuitDriver()
            {
                _driver.Quit();
            }
        }
    }


