

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnFelDeFinal;
using UnFelDeFinal.Controllers;
using UnFelDeFinal.Extern.Dtos;

namespace WebApi_UnitTestProject1
{
    [TestClass]
    public class EServiceIntegrationTest
    {
        private readonly HttpClient client;

        public EServiceIntegrationTest()
        {
            //var server = new TestServer(new WebHostBuilder().UseEnvironment("Development").UseStartup<Startup>());
            var server = new WebApplicationFactory<Startup>();

            client = server.CreateClient();

        }

        [TestMethod]
        public async Task ShouldAccess_Get()
        {
            var request = "/api/eservice";
            var response = await client.GetAsync(request);
            response.EnsureSuccessStatusCode();
            var jsonFromPostResponse = await response.Content.ReadAsStringAsync();
           
            
            var obj = JsonConvert.DeserializeObject<List<EserviceController>>(jsonFromPostResponse);
           

            Assert.IsTrue(obj.Count == 5);
        }


        [TestMethod]
        public async Task ShouldAccess_Post()
        {
            var request = new
            {
                Url = "/api/eservice",
                Body = new
                {
                    Name = "dtodto",
                    Amount = 10,
                    TreasureAccount = "dtodto"
                }
            };

            var postResponse = await client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            postResponse.EnsureSuccessStatusCode();
        }

        [TestMethod]
        public async Task ShouldGetEService_ById()
        {
            var request = "/api/eservice/2";
            var response = await client.GetAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var jsonFromPostResponse = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<ElectronicServiceDto>(jsonFromPostResponse);
                Assert.IsTrue(obj.Id == 2);
            }
            response.EnsureSuccessStatusCode();
        }


    }
}
