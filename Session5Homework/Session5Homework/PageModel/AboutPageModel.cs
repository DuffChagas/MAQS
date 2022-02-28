using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    public class AboutPageModel : BaseSeleniumPageModel
    {
        public AboutPageModel(ISeleniumTestObject testObject) : base(testObject)
        {
        }

        private LazyElement AboutTable
        {
            get { return this.GetLazyElement(By.CssSelector("#AboutTable"), "Contact Info"); }
        }
        public override bool IsPageLoaded()
        {
            return this.AboutTable.Displayed;
        }
    }
}
