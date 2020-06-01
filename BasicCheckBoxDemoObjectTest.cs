using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using VcsWebdriver.Pages;




namespace VcsWebdriver.Tests
{
    public class BasicCheckBoxDemoTest
    {
        private static BasicCheckBoxDemoPage _seleniumBasicCheckBoxPage;

        [OneTimeSetUp]
        public static void SetUpChrome()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            _seleniumBasicCheckBoxPage = new BasicCheckBoxDemoPage(driver);

        }

        [Test]
        public static void PazymimeClickOnThisCheckBox()
        {
            string tekstas = "Success - Check box is checked";
            _seleniumBasicCheckBoxPage.ClickCheckBox();
            _seleniumBasicCheckBoxPage.SuccesTekstoRodymas(tekstas);
        }

        [Test]
        public static void PazymimeMultipleCheckBox()
        {
            _seleniumBasicCheckBoxPage.ClickAllOptions();
            _seleniumBasicCheckBoxPage.MygtukoTekstoRezultatas("Uncheck All");

        }


        [Test]
        public static void PaspaudziameUncheckAll()
        {
            _seleniumBasicCheckBoxPage.UncheckMygtukoPaspaudimas();
            _seleniumBasicCheckBoxPage.UncheckMygtukoPatikra();
        }




        [OneTimeTearDown]
        public static void CloseBrowser()
        {
            _seleniumBasicCheckBoxPage.CloseBrowser();
        }

    }
}