using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace TrademeAPITests.Config
{
    internal static class ApiConfig
    {
        private static readonly IConfiguration Configuration;        
        static ApiConfig()
        {

            Configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("apisettings.json")
             .Build();

        }


        public static string GetUsedCarsURL()
        {
            var apiURL = Configuration.GetSection("ApiSettings")["usedCarsAPIUrl"];
            return apiURL;
        }

    }

}
