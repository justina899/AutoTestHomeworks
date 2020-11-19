using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace autotest1.Page
{
    public class VartuTechnikaPage : BasePage
        {
            private IWebElement _widthInput => Driver.FindElement(By.Id("doors_width"));
            private IWebElement _heighInput => Driver.FindElement(By.Id("doors_height"));
            private IWebElement _autoCheckbox => Driver.FindElement(By.Id("automatika"));
            private IWebElement _montavimoCheckbox => Driver.FindElement(By.Id("darbai"));
            private IWebElement _caculateButton => Driver.FindElement(By.Id("calc_submit"));
            private IWebElement _resultBox => Driver.FindElement(By.CssSelector("#calc_result > div"));

        public VartuTechnikaPage(IWebDriver webdriver) : base(webdriver) { }

            public VartuTechnikaPage InsertWidth(string width)
            {
                _widthInput.Clear();
                _widthInput.SendKeys(width);
                return this;
            }

            public VartuTechnikaPage InsertHeight(string height)
            {
                _heighInput.Clear();
                _heighInput.SendKeys(height);
                return this;
            }

            public VartuTechnikaPage InsertWidthAndHeight(string width, string height)
            {
                InsertWidth(width);
                InsertHeight(height);
                return this;
            }

        public VartuTechnikaPage CheckAutomatikaCheckbox(bool shouldBeChecked)
            {
                if (shouldBeChecked != _autoCheckbox.Selected)
                    _autoCheckbox.Click();
                return this;
            }
            public VartuTechnikaPage CheckMontavimoDarbaiCheckbox(bool shouldBeChecked)
            {
                if (shouldBeChecked != _montavimoCheckbox.Selected)
                    _montavimoCheckbox.Click();
                return this;
            }

            public VartuTechnikaPage ClickCalculateButton()
            {
                _caculateButton.Click();
                return this;
            }

            public void CheckResult(string expectedResult)
            {
                WaitForResult();
                Assert.IsTrue(_resultBox.Text.Contains(expectedResult), $"Result is not the same, expented {expectedResult}, but was {_resultBox.Text}");
            }

            private VartuTechnikaPage WaitForResult()
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(d => _resultBox.Displayed);
                return this;
            }
        }
}
