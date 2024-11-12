using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace TrademeWebUITests.Config
{
    internal static class WebConfig
    {
        private static readonly IConfiguration Configuration;        
        static WebConfig()
        {

            Configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("websettings.json")
             .Build();

        }


        public static string GetTestingSiteURL()
        {
            var webURL = Configuration.GetSection("WebUiSettings")["testingSiteUrl"];
            return webURL;
        }

        public static string GetBrowserName()
        {
            var browserName = Configuration.GetSection("BrowserSettings")["Browser"];
            return browserName;
        }

    }

}
