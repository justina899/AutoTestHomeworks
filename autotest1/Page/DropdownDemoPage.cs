using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autotest1.Page
{
    class DropdownDemoPage : BasePage
    {
        private const string PageAddress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private const string ResultText = "Day selected :- ";
        private const string FirstSelectedText = "First selected option is : ";
        private SelectElement Dropdown => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private IWebElement ResultTextElement => Driver.FindElement(By.CssSelector(".selected-value"));
        private SelectElement MultiDropdown => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private IWebElement FirstSelectedButton => Driver.FindElement(By.Id("printMe"));
        private IWebElement GetAllSelectedButton => Driver.FindElement(By.Id("printAll"));
        private IWebElement SelectedResult => Driver.FindElement(By.CssSelector(".getall-selected"));



        public DropdownDemoPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }

        public DropdownDemoPage SelectDropdownByText(string text)
        {
            Dropdown.SelectByText(text);
            return this;
        }

        public DropdownDemoPage SelectDropdownByValue(string text)
        {
            Dropdown.SelectByValue(text);
            return this;
        }

        public DropdownDemoPage VerifyRezult(string selectedDay)
        {
            Assert.IsTrue(ResultTextElement.Text.Equals(ResultText + selectedDay), $"result is wrong, not {selectedDay}");
            return this;
        }

        private DropdownDemoPage DeselectMultiDropdown()
        {
            MultiDropdown.DeselectAll();
            return this;
        }

        public DropdownDemoPage SelectFromMultipleDropdownByValue(List<string> listOfStates)
        {
            DeselectMultiDropdown();

            Actions action = new Actions(Driver);
            action.KeyDown(Keys.Control);
            foreach (IWebElement option in MultiDropdown.Options)
            {
                if (listOfStates.Contains(option.GetAttribute("value")))
                {
                    action.Click(option);
                }
            }
            action.KeyUp(Keys.Control);
            action.Build().Perform();
            return this;
        }

        public DropdownDemoPage ClickFirstSelectedButton()
        {
            FirstSelectedButton.Click();
            return this;
        }

        public DropdownDemoPage CheckResultFirstSelectedState(List<string> listOfStates)
        {
            Assert.IsTrue(SelectedResult.Text.Equals(FirstSelectedText + listOfStates[0]), $"result is wrong, not {listOfStates[0]}");
            return this;
        }

        public DropdownDemoPage ClickAllSelectedButton()
        {
            GetAllSelectedButton.Click();
            return this;
        }

        public DropdownDemoPage CheckResultAllSelected(List<string> listOfStates)
        {
            foreach (string state in listOfStates)
            {
                Assert.IsTrue(SelectedResult.Text.Contains(state), $"{state} was not selected");
            }
            return this;
        }
    }
}
