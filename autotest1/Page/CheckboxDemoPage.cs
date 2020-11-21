using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace autotest1.Page
{
    public class CheckboxDemoPage : BasePage
    {
        private const string PageAddress = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
        private const string TextToCheck = "Success - Check box is checked";
        IWebElement _oneCheckbox => Driver.FindElement(By.Id("isAgeSelected"));
        IWebElement _text => Driver.FindElement(By.Id("txtAge"));//
        IReadOnlyCollection<IWebElement> _multipleCheckboxList => Driver.FindElements(By.CssSelector(".cb1-element"));
        IWebElement _text1 => Driver.FindElement(By.Id("check1"));

        public CheckboxDemoPage(IWebDriver webdriver) : base(webdriver) {
            Driver.Url = PageAddress;
        }

        public CheckboxDemoPage SelectOneCheckbox()
        {
            _oneCheckbox.Click();
            return this;
        }

        public CheckboxDemoPage IfOneCheckboxIsChecked()
        {
            Assert.IsTrue(_text.Text.Equals(TextToCheck));
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
            
            GetWait().Until(ExpectedConditions.TextToBePresentInElementValue(_text1, "Uncheck All"));
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
