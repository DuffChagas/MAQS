using CognizantSoftvision.Maqs.BaseWebServiceTest;
using CognizantSoftvision.Maqs.Utilities.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using HttpClientFactory = CognizantSoftvision.Maqs.BaseWebServiceTest.HttpClientFactory;

namespace Tests
{
    /// <summary>
    /// Base setup for trip api tests
    /// </summary>
    [TestClass]
    public class BaseTripTests : BaseWebServiceTest
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            var acceptedMediaType = "text/html";
            WebServiceDriver driver = new WebServiceDriver(Config.GetValueForSection(ConfigSection.WebServiceMaqs, "WebServiceIdentUri"));

            // 1. Create the Token Endpoint Request body
            var tokenRequestContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", "test1"),
                new KeyValuePair<string, string>("password", "password1"),
                new KeyValuePair<string, string>("scope", "authTripsAPI"),
                new KeyValuePair<string, string>("client_id", "ro.client"),
                new KeyValuePair<string, string>("client_secret", "secret")               
            });

            // 2. Request the Tokens from identityserver token endpoint  
            var tokenRequestEndPoint = driver.Post("/connect/token", acceptedMediaType, tokenRequestContent);
            JObject o = JObject.Parse(tokenRequestEndPoint);

            // 3. Save off token for later use
            Config.AddTestSettingValue("TOKEN", (string)o["access_token"], ConfigSection.WebServiceMaqs);
        }

        /// <summary>
        /// Setup our webservice driver
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.ManagerStore.AddOrOverride(new WebServiceDriverManager(() =>
            {
                HttpClient client = HttpClientFactory.GetClient(
                    new Uri(Config.GetValueForSection(ConfigSection.WebServiceMaqs, "WebServiceTripUri")), WebServiceConfig.GetWebServiceTimeout());
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Config.GetValueForSection(ConfigSection.WebServiceMaqs, "TOKEN"));
                return client;
            }, this.TestObject));
        }
    }
}