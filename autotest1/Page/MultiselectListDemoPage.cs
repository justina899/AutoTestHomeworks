using OpenQA.Selenium;

namespace autotest1.Page
{
    public class MultiselectListDemoPage : BasePage
    {
        private const string PageAddress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        IWebElement _multiselectBox => Driver.FindElement(By.Id("multi-select"));

        public MultiselectListDemoPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }

        public MultiselectListDemoPage ChooseTwoCountries()
        {
           
            return this;
        }
    }
}
