using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace autotest1.Page
{
    public class CheckboxDemoPage : BasePage
    {
        IWebElement _oneCheckbox => Driver.FindElement(By.Id("isAgeSelected"));
        IWebElement _text => Driver.FindElement(By.Id("txtAge"));//
        IReadOnlyCollection<IWebElement> _multipleCheckboxList => Driver.FindElements(By.CssSelector(".cb1-element"));
        IWebElement _text1 => Driver.FindElement(By.Id("check1"));

        public CheckboxDemoPage(IWebDriver webdriver) : base(webdriver) { }

        public CheckboxDemoPage SelectOneCheckbox()
        {
            _oneCheckbox.Click();
            return this;
        }

        public CheckboxDemoPage IfOneCheckboxIsChecked(string text)
        {
            Assert.IsTrue(_text.Text.Equals(text));
            return this;
        }

        public CheckboxDemoPage CheckMultipleCheckbox()
        {
            if (_oneCheckbox.Selected)
            {
                _oneCheckbox.Click();
            }
            foreach (IWebElement element in _multipleCheckboxList)
            {
                element.Click();

            }
            return this;
        }

        public CheckboxDemoPage CheckIfMultiCheckboxSelected(string text)
        {
            Assert.AreEqual(text, _text1.GetAttribute("value"));
            return this;
        }

        public CheckboxDemoPage UncheckAllCheckboxes()
        {
            _text1.Click();
            return this;
        }

        public CheckboxDemoPage CheckIfAllCheckboxesIfUnselectedOneByOne()
        {
            foreach (IWebElement element in _multipleCheckboxList)
            {
                Assert.IsTrue(!element.Selected, "element is selected");
            }
            return this;
        }

    }
}
