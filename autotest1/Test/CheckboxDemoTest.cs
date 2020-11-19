using autotest1.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace autotest1.Test
{
    public class CheckboxDemoTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void TestOneCheckbox()
        {
            CheckboxDemoPage page = new CheckboxDemoPage(_driver);
            page.SelectOneCheckbox();
            page.IfOneCheckboxIsChecked("Success - Check box is checked");

        }

        [Test]
        //2) Pažymime visas “Multiple Checkbox Demo” sekcijos varneles, patikriname kad mygtukas persivadino į “Uncheck All”.
        public void TestMultipleCheckboxIfChecked()
        {
            CheckboxDemoPage page = new CheckboxDemoPage(_driver);
            page.CheckMultipleCheckbox();
            page.CheckIfMultiCheckboxSelected("Uncheck All");
        }

        [Test]
        //3) Paspaudžiame mygtuką “Uncheck All” , patikriname kad visos “Multiple Checkbox Demo” sekcijos varneles atžymėtos.
        public void TestMultipleCheckboxesIfUnchecked()
        {
            CheckboxDemoPage page = new CheckboxDemoPage(_driver);
            page.UncheckAllCheckboxes();
            page.CheckIfAllCheckboxesIfUnselectedOneByOne();


        }
    }
}
