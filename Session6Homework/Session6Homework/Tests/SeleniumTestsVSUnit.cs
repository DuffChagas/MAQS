using CognizantSoftvision.Maqs.BaseSeleniumTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModel;
using System;

namespace Tests
{
    /// <summary>
    /// SeleniumTest test class with VS unit
    /// </summary>
    [TestClass]
    public class SeleniumTestsVSUnit : BaseSeleniumTest
    {
        // Create a class setup function
        [ClassInitialize]
        public static void TestSetup(TestContext context)
        {
            Console.WriteLine("Class Setup");
        }

        /// <summary>
        /// Open page test
        /// </summary>
        [TestMethod]
        public void OpenLoginPageTest()
        {
            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();
        }

        /// <summary>
        /// Enter credentials test
        /// </summary>
        [TestMethod]
        public void EnterValidCredentialsTest()
        {
            string username = "Ted";
            string password = "123";
            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();
            HomePageModel homepage = page.LoginWithValidCredentials(username, password);
            Assert.IsTrue(homepage.IsPageLoaded());
        }

        // Data Drive 5 Invalid Login Tests
        [TestMethod]
        [TestCategory("DataDriven")]
        [DataRow("Tedd", "1233")]
        [DataRow("Teddy", "1234")]
        [DataRow("ted", "1123")]
        [DataRow("td", "12")]
        [DataRow("TED", "321")]
        public void EnterInvalidCredentials(string username, string password)
        {
            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();
            Assert.IsTrue(page.LoginWithInvalidCredentials(username, password));
        }

        [TestCleanup()]
        public void TestTeardown()
        {
            Console.WriteLine("Function Teardown");
        }


        [ClassCleanup]
        public static void ClassCleanup()
        {
            Console.WriteLine("Class cleanup");
        }
    }
}
