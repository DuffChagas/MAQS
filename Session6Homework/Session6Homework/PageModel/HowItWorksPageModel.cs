using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    public class HowItWorksPageModel : BaseSeleniumPageModel
    {
        public HowItWorksPageModel(ISeleniumTestObject testObject) : base(testObject)
        {

        }

        private LazyElement HowItWorksContent
        {
            get { return this.GetLazyElement(By.CssSelector("#HowWorks"), "How it works content"); }
        }
        public override bool IsPageLoaded()
        {
            return this.HowItWorksContent.Displayed;
        }
    }
}
