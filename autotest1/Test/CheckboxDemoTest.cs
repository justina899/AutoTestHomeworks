using autotest1.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace autotest1.Test
{
    public class CheckboxDemoTest
    {
        private static CheckboxDemoPage _page;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new CheckboxDemoPage(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();
        }

        [Order(1)]
        [Test]
        public void TestOneCheckbox()
        {
            _page.SelectOneCheckbox()
                 .IfOneCheckboxIsChecked();

        }

        [Order(2)]
        [Test]
        //2) Pažymime visas “Multiple Checkbox Demo” sekcijos varneles, patikriname kad mygtukas persivadino į “Uncheck All”.
        public void TestMultipleCheckboxIfChecked()
        {
            _page.CheckMultipleCheckbox()
                 .CheckIfMultiCheckboxSelected("Uncheck All");
        }

        [Order(3)]
        [Test]
        //3) Paspaudžiame mygtuką “Uncheck All” , patikriname kad visos “Multiple Checkbox Demo” sekcijos varneles atžymėtos.
        public void TestMultipleCheckboxesIfUnchecked()
        {
            _page.UncheckAllCheckboxes()
                 .CheckIfAllCheckboxesIfUnselectedOneByOne();


        }
    }
}
