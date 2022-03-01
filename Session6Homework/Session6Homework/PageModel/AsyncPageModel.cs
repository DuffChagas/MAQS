using CognizantSoftvision.Maqs.BaseSeleniumTest;
using CognizantSoftvision.Maqs.BaseSeleniumTest.Extensions;
using OpenQA.Selenium;

namespace PageModel
{
    public class AsyncPageModel : BaseSeleniumPageModel
    {
        public AsyncPageModel(ISeleniumTestObject testObject) : base(testObject)
        {

        }

        private LazyElement AsyncContent
        {
            get { return this.GetLazyElement(By.CssSelector("#AsyncContent"), "Async page content"); }
        }
              
        private LazyElement OptionsLabel
        {
            get { return this.GetLazyElement(By.CssSelector("#Label"), "Options label"); }
        }

        private LazyElement DropdownBox
        {
            get { return this.GetLazyElement(By.CssSelector("#Selector"), "Dropdown box"); }
        }

        public override bool IsPageLoaded()
        {
            return this.AsyncContent.Displayed && this.OptionsLabel.Displayed && this.DropdownBox.Displayed;
        }
    }
}
