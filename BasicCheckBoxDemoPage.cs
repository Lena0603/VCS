using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;



//Nadodamiesi "page object pattern" struktūra, automatizuokite 3 testus:

//https://www.seleniumeasy.com/test/basic-checkbox-demo.html
//1. Pažymime “Click on this check box”, checpatikriname kad atsirado “Success - Check box is ked” pranešimas
//2. Pažymime visas “Multiple Checkbox Demo” sekcijos varneles, patikriname kad mygtukas persivadino į “Uncheck All”
//3. Paspaudžiame mygtuką “Uncheck All” , patikriname kad visos “Multiple Checkbox Demo” sekcijos varneles atžymėtos

//Namų darbų pridavimo formą: atsiūskite nuorodą į jūsų GIT repositoriją(pasirūpinkite tuo kad ji būtų PUBLIC)


namespace VcsWebdriver.Pages
{
    class BasicCheckBoxDemoPage : PageBase
    {

        private IWebElement PazymimeVarnele => Driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement AtsidaroPranesimas => Driver.FindElement(By.Id("txtAge"));

        private IReadOnlyCollection<IWebElement> ElementuOptionSarasas => Driver.FindElements(By.ClassName("cb1-element"));
        private IWebElement ShowMygtukas => Driver.FindElement(By.Id("check1"));




        public BasicCheckBoxDemoPage(IWebDriver inputDriver) : base(inputDriver) //konstruktorius
        {
            Driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
        }



        public void ClickCheckBox()
        {
            PazymimeVarnele.Click();
        }

        public void SuccesTekstoRodymas(string expectedPranesimas)
        {
            Assert.AreEqual(expectedPranesimas, AtsidaroPranesimas.Text, $"Mes tikejomes teksto:{expectedPranesimas}, o gavome {AtsidaroPranesimas}");
        }


        //public void AssertTekstoRodymas(string expectedTekstas)
        //{
        //    string tekstas = AtsidaroPranesimas.Text;
        //    Assert.AreEqual(expectedTekstas, tekstas, "Success - Check box is checked");
        //}



        public void ClickAllOptions()
        {
            foreach (IWebElement elementasOption in ElementuOptionSarasas)
            {
                elementasOption.Click();
            }

        }

        public void MygtukoTekstoRezultatas(string expectedPranesimas2)
        {
            string MygtukoTekstas = ShowMygtukas.GetAttribute("value");
            Assert.AreEqual(expectedPranesimas2, MygtukoTekstas, "Tekstas ne toks, kokio tikejomes.");
        }




        public void UncheckMygtukoPaspaudimas()
        {
            if (ShowMygtukas.GetAttribute("value") == "Check All")

                ShowMygtukas.Click();

            ShowMygtukas.Click();
        }

        public void UncheckMygtukoPatikra()
        {
            foreach (var option in ElementuOptionSarasas)
                Assert.AreEqual(false, option.Selected, "Viena is varneliu pazymeta"); //option.Selected = duoda true, jei pazymeta varnele.

        }
    }
}
