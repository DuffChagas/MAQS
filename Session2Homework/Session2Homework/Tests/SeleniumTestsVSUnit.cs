using CognizantSoftvision.Maqs.BaseSeleniumTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModel;
using CognizantSoftvision.Maqs.Utilities.Helper;
using OpenQA.Selenium;

namespace Tests
{
    /// <summary>
    /// SeleniumTest test class with VS unit
    /// </summary>
    [TestClass]
    public class SeleniumTestsVSUnit : BaseSeleniumTest
    {
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
            //Pulling the added username and password in the appsettings.json
            string username = Config.GetGeneralValue("Username");
            string password = Config.GetGeneralValue("Password");

            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();

            //Add Custom logging to show when you open the login page
            this.Log.LogMessage("Opening the login page");

            //Capture response time for how long it takes to login - start
            this.PerfTimerCollection.StartTimer("login timer");

            HomePageModel homepage = page.LoginWithValidCredentials(username, password);
            Assert.IsTrue(homepage.IsPageLoaded());

            //Capture response time for how long it takes to login - end
            this.PerfTimerCollection.StopTimer("login timer");

            //Add Custom logging to show when you have successfully logged in
            this.Log.LogMessage("Successfully logged in");
            //Assert.Fail();
        }

        /// <summary>
        /// Enter credentials test
        /// </summary>
        [TestMethod]
        public void EnterInvalidCredentials()
        {
            string username = "NOT";
            string password = "Valid";
            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();
            Assert.IsTrue(page.LoginWithInvalidCredentials(username, password));
        }


        [TestMethod]
        public void ExtraExtraCreditTest()
        {
            //adding firefox driver
            this.ManagerStore.Add("Firefox",
                 new SeleniumDriverManager(() => WebDriverFactory.GetBrowserWithDefaultConfiguration(BrowserType.Firefox), this.TestObject));
            string loginPageUrl = SeleniumConfig.GetWebSiteBase() + "Static/Training3/loginpage.html";

            // Open login page with default driver
            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();

            //Open login page with firefox driver
            var firefoxDriver = this.ManagerStore.GetDriver<IWebDriver>("Firefox");
            firefoxDriver.Navigate().GoToUrl(loginPageUrl);              
           
            // Test default driver
            Assert.IsTrue(page.LoginWithInvalidCredentials("NOT", "Valid"));
            // Test Firefox driver title is the same as the default driver
            Assert.AreEqual(this.WebDriver.Title, firefoxDriver.Title);       

        }
    }
}
