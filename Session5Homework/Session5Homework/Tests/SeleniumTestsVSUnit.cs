using CognizantSoftvision.Maqs.BaseSeleniumTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;  
using PageModel;

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
            string username = "Ted";
            string password = "123";
            LoginPageModel page = new LoginPageModel(this.TestObject);
            page.OpenLoginPage();
            HomePageModel homepage = page.LoginWithValidCredentials(username, password);
            Assert.IsTrue(homepage.IsPageLoaded());
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
        public void OpenAboutPageTest()
        {
            // override webdriver to open EDGE browser instead of CHROME
            this.ManagerStore.AddOrOverride(new SeleniumDriverManager(() => WebDriverFactory.GetBrowserWithDefaultConfiguration(SeleniumConfig.GetBrowserType("Edge")), this.TestObject));
            LoginPageModel loginPage = new LoginPageModel(this.TestObject);
            loginPage.OpenLoginPage();
            HomePageModel homepage = loginPage.LoginWithValidCredentials("Ted", "123");
            Assert.IsTrue(homepage.IsPageLoaded());
            homepage.NavigateToAboutPage(); 
            AboutPageModel aboutpage = new AboutPageModel(this.TestObject);
            Assert.IsTrue(aboutpage.IsPageLoaded());

        }
    }
}
