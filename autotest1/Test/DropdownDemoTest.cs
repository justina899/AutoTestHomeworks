using autotest1.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autotest1.Test
{
    class DropdownDemoTest
    {
        private static DropdownDemoPage _page;

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new DropdownDemoPage(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();
        }

        [Test]
        public void TestDropdown()
        {
            _page.SelectDropdownByText("Friday")
                .VerifyRezult("Friday");
        }
        //1) Pažymime 2 valstijas, spaudžiame "First Selected" mygtuką - patikrinam, ar rezultatas teisingas, rodo pirmą pažymėtą valstiją. 
        //3) Pažymime 3 valstijas, spaudžiame "First Selected" mygtuką - patikrinam, ar rezultatas teisingas, rodo pirmą pažymėtą valstiją.
        [TestCase("New Jersey", "California", TestName = "choose 2 elements and check for first selected")]
        [TestCase("New Jersey", "California", "Texas", TestName = "choose 3 elements and check for first selected")]

        public void TestMultipleDropdownForFirstSelected(params string[] selectedElements)
        {
            _page.SelectFromMultipleDropdownByValue(selectedElements.ToList())
                .ClickFirstSelectedButton()
                .CheckResultFirstSelectedState(selectedElements.ToList());
        }

        //2) Pažymime 2 valstijas, spaudžiame "Get All Selected" mygtuką - patikrinam, ar rezultatas teisingas, rodo visas užžymėtas valstijas.
        //4) Pažymime 4 valstijas, spaudžiame "Get All Selected" mygtuką - patikrinam, ar rezultatas teisingas, rodo visas užžymėtas valstijas.
        [TestCase("New Jersey", "California", TestName = "choose 2 elements and check  for all selected")]
        [TestCase("New Jersey", "California", "Washington", "Ohio", TestName = "choose 4 elements and check  for all selected")]

        public void TestMultipleDropdownForAllSelected(params string[] selectedElements)
        {
            _page.SelectFromMultipleDropdownByValue(selectedElements.ToList())
                .ClickAllSelectedButton()
                .CheckResultAllSelected(selectedElements.ToList());
        }

    }
}
