using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autotest1
{
    class TestWebdriver
    {
        [Test]
        public static void TestChromeDriver()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://login.yahoo.com/";
            chrome.Quit();
        }
        [Test]
        public static void TestYahooPage()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://login.yahoo.com/";
            IWebElement loginInputField = chrome.FindElement(By.Id("login-username"));
            loginInputField.SendKeys("test");
            IWebElement loginButton = chrome.FindElement(By.Id("login-signin"));
            loginButton.Click();
            chrome.Quit();
        }

        [Test]
        public static void TestSeleniumPage()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "http://www.seleniumeasy.com/test/basic-first-form-demo.html";
            IWebElement inputField = chrome.FindElement(By.Id("user-message"));
            string myText = "Katinukai";
            inputField.SendKeys(myText);
            IWebElement button = chrome.FindElement(By.CssSelector("#get-input > button"));
            button.Click();
            IWebElement result = chrome.FindElement(By.Id("display"));
            Assert.IsTrue(myText.Equals(result.Text), "no text appeared");
            chrome.Quit();
        }
    }
}
