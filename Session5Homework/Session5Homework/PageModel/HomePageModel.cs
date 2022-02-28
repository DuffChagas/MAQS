using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for the Automation page
    /// </summary>
    public class HomePageModel : BaseSeleniumPageModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageModel" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public HomePageModel(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        /// <summary>
        /// Gets welcome message
        /// </summary>
        private LazyElement WelcomeMessage
        {
            get { return this.GetLazyElement(By.CssSelector("#WelcomeMessage"), "Welcome message"); }
        }

        private LazyElement AboutButton
        {
            get { return this.GetLazyElement(By.CssSelector("#About"), "About button"); }
        }

        public void NavigateToAboutPage()
        {
            this.AboutButton.Click();
        }

        /// <summary>
        /// Check if the home page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public override bool IsPageLoaded()
        {
            return this.WelcomeMessage.Displayed;
        }
    }
}

