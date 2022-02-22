using CognizantSoftvision.Maqs.BaseWebServiceTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebServiceModel;

namespace Tests
{
    /// <summary>
    /// Simple web service test class using VS unit
    /// </summary>
    [TestClass]
    public class ArrayOfProductsTest : BaseWebServiceTest
    {              
        [TestMethod]
        public void GetAllProducts_ShouldReturnSuccess()
        {
            //Override the WebServiceDriver and add the key "Auth" and value "AuthKey" to the DEFAULT request header
            this.WebServiceDriver.HttpClient.DefaultRequestHeaders.Add("Auth", "AuthKey");

            //Create a JSON test that gets from api/XML_JSON/GetAllProducts and save the result as an ArrayOfProducts

            ArrayOfProductsModel result = this.WebServiceDriver.Get<ArrayOfProductsModel>("/api/XML_JSON/GetAllProducts", "application/json", false);
            Assert.AreEqual(3, result.Count);
        }
    }
}
