using NUnit.Framework;
using Omada.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Omada.BDDSteps
{
    [Binding]
    class SearchSteps
    {
        IWebDriver driver = BaseClass.driver;

        [When(@"I want to search for '(.*)'")]
        public void WhenIWantToSearchFor(string searchPhrase)
        {
            HomePage homePage = new HomePage(driver);
            Assert.That(homePage.searchInput.Displayed, "Search input is not displayed, check window size");
            homePage.searchInput.SendKeys(searchPhrase);
            homePage.searchInput.SendKeys(Keys.Enter);
        }

        [Then(@"I want to check if there is more then (.*) results")]
        public void ThenIWantToCheckIfThereIsMoreThenResults(int numberOfResults)
        {
            var results = driver.FindElements(By.CssSelector(".search-results__item a"));
            Assert.IsTrue(results.Count > numberOfResults, "Number of searched results is incorrect");
        }

        [When(@"I want to click '(.*)' link")]
        public void WhenIWantToClickLink(string textlink)
        {
            //driver.FindElement(By.XPath("//a[text()='" + textlink + "']")).Click();
            var elem = driver.FindElement(By.XPath("//a[contains(text(),'" + textlink + "')]"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", elem);

        }
        [Then(@"I want to check if I am redirected to page with '(.*)' title")]
        public void ThenIWantToCheckIfIAmRedirectedToPageWithTitle(string pageTitle)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var heading = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("h1.text__heading")));
            string actualPageTitle = heading.Text;
            Assert.AreEqual(pageTitle, actualPageTitle, "Page title is incorrect");
        }
        [Then(@"I want to check if I am redirected to page'(.*)' page")]
        public void ThenIWantToCheckIfIAmRedirectedToPagePage(string pageTitle)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var heading = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("h1.headline__heading")));
            string actualPageTitle = heading.Text;
            Assert.AreEqual(pageTitle, actualPageTitle, "Page title is incorrect");
        }



        [Then(@"I want to check if there is '(.*)' news")]
        public void ThenIWantToCheckIfThereIsNews(string newsTitle)
        {
            var elems = driver.FindElements(By.XPath("//*[text()='"+newsTitle+"']"));
            Assert.IsTrue(elems.Count > 0, "I have not found any newses");
        }











    }
}
