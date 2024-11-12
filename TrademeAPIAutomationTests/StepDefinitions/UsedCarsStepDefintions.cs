using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using TrademeAPITests.Config;



namespace TrademeAPITests.StepDefinitions
{
    [Binding]
    public sealed class UsedCarsStepDefintions
    {
        HttpClient httpClient;
        HttpRequestMessage request;
        HttpResponseMessage response;
        string requestUrl = ApiConfig.GetUsedCarsURL();
        string content ;




        public UsedCarsStepDefintions()
        {
            
            request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            httpClient = new HttpClient();
            response = new HttpResponseMessage();
            content = new string("");
         }


        [Given(@"\[user sends Httprequest to Trademe UsedCars Url]")]
        public async Task GivenUserSendHttprequestToUrl()
        {
          
            response = await httpClient.SendAsync(request);
            Console.WriteLine("The Status Code is : " + response.StatusCode);
            content = await response.Content.ReadAsStringAsync();
            Console.WriteLine("The JSon Response is : " + content);
        }
         
        [Then(@"\[status code is (.*)]")]
        public void ThenStatusCodeIs(int status)
        {
            var statusCode = response.StatusCode;
            if (response.IsSuccessStatusCode)
            {
             
                // Verify that the status code is 200 
                Assert.AreEqual(status, (int) statusCode);
            }
            else 
            {
                Console.WriteLine($"Request failed. Status Code: {statusCode}");
            
            }
        }
 
        [Then(@"\[count of Used Car Brands is (.*)]")]
            public void ThenCountOfUsedCarBrandsIs(int CarBrands)
            {
            // Extract and parse the JSON response content
            JObject jsonResponse = JObject.Parse(content);


            JArray usedCars = (JArray)jsonResponse["Subcategories"];
            // Initialize a variable to count the subcategories
            int carsBrandCount = 0;

            // Count the subcategories array element (in this case, just count the array elements)
            if (usedCars !=null)
            {
                carsBrandCount = usedCars.Count();
            }
            else
            { Console.WriteLine($"Request failed. No Car Brands Available"); }

            Console.WriteLine($"the number of used cars brands is {carsBrandCount}");

            // Assert that the number of subcategories is greater than 0
            Assert.Greater(carsBrandCount, 0, "Subcategory count should be greater than 0.");


            //Assert number of used car brands is matching to value of CarBrands variable
            Assert.AreEqual(carsBrandCount, CarBrands);
            }

        }
    }

